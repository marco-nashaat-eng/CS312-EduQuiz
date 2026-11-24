using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class ResultForm : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private const string SortAZ = "A\u2013Z";
        private const string SortLow = "Lowest \u2192 Highest";
        private const string SortHigh = "Highest \u2192 Lowest";
        private const string AllSubjects = "All subjects";

        // empty = admin view (every result); a username = that teacher's results only
        private string teacherUser = "";

        private List<Student> shownResults = new List<Student>();

        private KpiCard cardAttempts;
        private KpiCard cardAverage;
        private KpiCard cardHighest;
        private KpiCard cardLowest;

        private ChipSelector chipSort;
        private ComboBox cmbSubject;
        private ModernButton btnAnalytics;

        private int passedCount = 0;
        private int failedCount = 0;
        private string textAverage = "-";
        private string textHighest = "-";
        private string textLowest = "-";
        private string passNote = "Pass mark: -";

        public ResultForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(1060, 700);
            WireEvents();
        }

        // Teacher view: only the results of this teacher's own quizzes
        public ResultForm(string teacherUsername) : this()
        {
            teacherUser = teacherUsername;
            btnClearResults.Visible = false;
        }

        private bool IsTeacherView()
        {
            return teacherUser != "";
        }

        private List<Student> SourceResults()
        {
            if (IsTeacherView())
                return new List<Student>(AppData.ResultsOfTeacher(teacherUser));

            return AppData.Results;
        }

        private void WireEvents()
        {
            btnExport.Click += btnExport_Click;
            btnClearResults.Click += btnClearResults_Click;
            btnClose.Click += btnClose_Click;
            chipFilter.SelectedIndexChanged += chipFilter_SelectedIndexChanged;
            txtSearch.TextChanged += txtSearch_TextChanged;
            pnlSearchBox.Click += pnlSearchBox_Click;
            lstResults.DrawItem += lstResults_DrawItem;
            pnlPass.Paint += pnlPass_Paint;
        }

        private void SetPlaceholder(TextBox box, string text)
        {
            SendMessage(box.Handle, EM_SETCUEBANNER, (IntPtr)1, text);
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            cardAttempts = CreateCard("Attempts", "Matching the filter", Theme.Primary);
            cardAverage = CreateCard("Average score", "Mean percentage", Theme.Warning);
            cardHighest = CreateCard("Highest score", "Best result", Theme.Success);
            cardLowest = CreateCard("Lowest score", "Needs attention", Theme.Danger);

            // make room for the new sort / subject row
            pnlResults.Height = 434;
            pnlActions.Height = 234;
            lstResults.SetBounds(20, 176, 650, 240);
            lblEmpty.Location = new Point(20, 270);

            if (IsTeacherView())
            {
                lblPageTitle.Text = "Results of your students";
                lblPageSub.Text = "Scores from the quizzes you created";
            }

            BuildSortControls();
            BuildAnalyticsButton();

            SetPlaceholder(txtSearch, "Search by student name...");

            chipFilter.AddItem("All");
            chipFilter.AddItem("Passed");
            chipFilter.AddItem("Failed");
            chipFilter.SelectedIndex = 0;

            RefreshResults();
        }

        // The sort chips and the subject dropdown are created in code
        private void BuildSortControls()
        {
            chipSort = new ChipSelector();
            chipSort.Location = new Point(20, 124);
            chipSort.Size = new Size(420, 34);
            chipSort.AddItem(SortAZ);
            chipSort.AddItem(SortLow);
            chipSort.AddItem(SortHigh);
            pnlResults.Controls.Add(chipSort);

            cmbSubject = new ComboBox();
            cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubject.FlatStyle = FlatStyle.Flat;
            cmbSubject.BackColor = Color.White;
            cmbSubject.Font = Theme.BodyFont;
            cmbSubject.SetBounds(460, 127, 210, 28);
            cmbSubject.Items.Add(AllSubjects);

            List<string> names = new List<string>();

            foreach (Student s in SourceResults())
            {
                if (s.Subject != "" && !names.Contains(s.Subject))
                    names.Add(s.Subject);
            }

            names.Sort();

            foreach (string name in names)
                cmbSubject.Items.Add(name);

            cmbSubject.SelectedIndex = 0;
            pnlResults.Controls.Add(cmbSubject);

            // default order, then start listening for changes
            chipSort.SelectedIndex = 0;
            chipSort.SelectedIndexChanged += chipSort_SelectedIndexChanged;
            cmbSubject.SelectedIndexChanged += cmbSubject_SelectedIndexChanged;

            toolTipHint(cmbSubject, "Show the results of one subject only");
        }

        // tiny helper so the dropdown has a tooltip without a Designer component
        private void toolTipHint(Control control, string text)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(control, text);
        }

        private void ResultForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                txtSearch.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                ExportReport();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.G)
            {
                OpenAnalytics();
                e.SuppressKeyPress = true;
            }
        }

        // The "Analytics" button sits in the header, left of the Close button
        private void BuildAnalyticsButton()
        {
            btnAnalytics = new ModernButton();
            btnAnalytics.Text = "Analytics";
            btnAnalytics.Kind = ButtonKind.Secondary;
            btnAnalytics.Size = new Size(110, 42);
            btnAnalytics.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnalytics.Location = new Point(btnClose.Left - 120, btnClose.Top);
            btnAnalytics.Click += btnAnalytics_Click;
            pnlHeader.Controls.Add(btnAnalytics);

            lblFooterHint.Text = "Esc Close     Ctrl+F Search     Ctrl+E Export     Ctrl+G Analytics";
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            OpenAnalytics();
        }

        // Shows the charts for the results that are currently in the list
        private void OpenAnalytics()
        {
            using (AnalyticsForm form = new AnalyticsForm(shownResults))
            {
                form.ShowDialog(this);
            }
        }

        private KpiCard CreateCard(string title, string hint, Color accent)
        {
            KpiCard card = new KpiCard();
            card.Title = title;
            card.Hint = hint;
            card.AccentColor = accent;
            card.Size = new Size(238, 112);
            card.Margin = new Padding(0, 0, 20, 0);
            card.Cursor = Cursors.Default;
            flpStats.Controls.Add(card);
            return card;
        }

        private string SelectedSubject()
        {
            if (cmbSubject == null || cmbSubject.SelectedItem == null)
                return AllSubjects;

            return cmbSubject.SelectedItem.ToString();
        }

        private string SelectedSort()
        {
            if (chipSort == null || chipSort.SelectedItem == "")
                return SortAZ;

            return chipSort.SelectedItem;
        }

        // Stable sorts: equal scores keep a sensible order (by name)
        private List<Student> SortResults(List<Student> list)
        {
            string sort = SelectedSort();

            if (sort == SortLow)
            {
                return list.OrderBy(r => r.GetPercentage())
                           .ThenBy(r => r.Name, StringComparer.CurrentCultureIgnoreCase)
                           .ToList();
            }

            if (sort == SortHigh)
            {
                return list.OrderByDescending(r => r.GetPercentage())
                           .ThenBy(r => r.Name, StringComparer.CurrentCultureIgnoreCase)
                           .ToList();
            }

            return list.OrderBy(r => r.Name, StringComparer.CurrentCultureIgnoreCase)
                       .ThenByDescending(r => r.TakenAt)
                       .ToList();
        }

        private void RefreshResults()
        {
            if (chipSort == null || cmbSubject == null)
                return;

            lstResults.Items.Clear();
            shownResults.Clear();

            List<Student> source = SourceResults();

            string search = txtSearch.Text.Trim().ToLower();
            string filter = chipFilter.SelectedItem;
            string subject = SelectedSubject();

            foreach (Student s in source)
            {
                bool matchesName = (search == "" || s.Name.ToLower().Contains(search));
                bool matchesSubject = (subject == AllSubjects || s.Subject == subject);

                bool matchesFilter = true;

                if (filter == "Passed")
                    matchesFilter = s.IsPassed();
                else if (filter == "Failed")
                    matchesFilter = !s.IsPassed();

                if (matchesName && matchesSubject && matchesFilter)
                    shownResults.Add(s);
            }

            shownResults = SortResults(shownResults);

            foreach (Student s in shownResults)
                lstResults.Items.Add(s.Print());

            lblCount.Text = "Showing " + shownResults.Count + " of " +
                source.Count + " attempts   |   Sorted " + SelectedSort();

            if (shownResults.Count == 0)
            {
                if (source.Count == 0)
                {
                    if (IsTeacherView())
                        lblEmpty.Text = "No attempts by your students yet." + Environment.NewLine +
                            "Results will appear here after they finish your quizzes.";
                    else
                        lblEmpty.Text = "No quiz attempts yet." + Environment.NewLine +
                            "Results will appear here after students finish a quiz.";
                }
                else
                {
                    lblEmpty.Text = "No attempts match your filter or search.";
                }

                lblEmpty.Visible = true;
            }
            else
            {
                lblEmpty.Visible = false;
            }

            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            if (cardAttempts == null)
                return;

            int count = shownResults.Count;

            passedCount = 0;
            failedCount = 0;
            textAverage = "-";
            textHighest = "-";
            textLowest = "-";
            passNote = "Pass mark: -";

            if (count > 0)
            {
                double sum = 0;
                double highest = shownResults[0].GetPercentage();
                double lowest = shownResults[0].GetPercentage();
                double firstPass = shownResults[0].PassPercent;
                bool samePass = true;

                foreach (Student s in shownResults)
                {
                    double p = s.GetPercentage();
                    sum += p;

                    if (p > highest)
                        highest = p;

                    if (p < lowest)
                        lowest = p;

                    if (s.IsPassed())
                        passedCount++;

                    if (s.PassPercent != firstPass)
                        samePass = false;
                }

                failedCount = count - passedCount;
                textAverage = (sum / count).ToString("F1") + "%";
                textHighest = highest.ToString("F1") + "%";
                textLowest = lowest.ToString("F1") + "%";

                if (samePass)
                    passNote = "Pass mark: " + firstPass.ToString("F0") + "%";
                else
                    passNote = "Pass mark: varies by quiz";
            }

            cardAttempts.Value = count.ToString();
            cardAverage.Value = textAverage;
            cardHighest.Value = textHighest;
            cardLowest.Value = textLowest;

            pnlPass.Invalidate();
        }

        private void pnlPass_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int total = passedCount + failedCount;

            string percent = "-";
            if (total > 0)
                percent = (passedCount * 100.0 / total).ToString("F0") + "%";

            TextRenderer.DrawText(g, percent, Theme.BigNumberFont, new Point(18, 34), Theme.TextDark);
            TextRenderer.DrawText(g, "of shown attempts passed", Theme.SmallFont,
                new Point(20, 80), Theme.TextMuted);

            Color trackColor = Color.FromArgb(226, 232, 240);
            if (total > 0)
                trackColor = Theme.Danger;

            Rectangle track = new Rectangle(20, 106, 258, 12);

            using (GraphicsPath trackPath = Theme.RoundedRect(track, 6))
            using (SolidBrush trackBrush = new SolidBrush(trackColor))
            {
                g.FillPath(trackBrush, trackPath);
            }

            if (total > 0 && passedCount > 0)
            {
                int w = (int)(track.Width * passedCount / (double)total);
                Rectangle fill = new Rectangle(track.X, track.Y, Math.Max(w, 12), track.Height);

                using (GraphicsPath fillPath = Theme.RoundedRect(fill, 6))
                using (SolidBrush fillBrush = new SolidBrush(Theme.Success))
                {
                    g.FillPath(fillBrush, fillPath);
                }
            }

            using (SolidBrush green = new SolidBrush(Theme.Success))
            using (SolidBrush red = new SolidBrush(Theme.Danger))
            {
                g.FillEllipse(green, 20, 134, 10, 10);
                g.FillEllipse(red, 150, 134, 10, 10);
            }

            TextRenderer.DrawText(g, "Passed: " + passedCount, Theme.BodyFont,
                new Point(36, 128), Theme.TextDark);
            TextRenderer.DrawText(g, "Failed: " + failedCount, Theme.BodyFont,
                new Point(166, 128), Theme.TextDark);
            TextRenderer.DrawText(g, passNote, Theme.SmallFont,
                new Point(20, 154), Theme.TextMuted);
        }

        private void lstResults_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= shownResults.Count)
                return;

            Student s = shownResults[e.Index];
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color back = Color.White;
            if (selected)
                back = Color.FromArgb(238, 242, 255);

            using (SolidBrush brush = new SolidBrush(back))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            if (selected)
            {
                using (SolidBrush bar = new SolidBrush(Theme.Primary))
                {
                    e.Graphics.FillRectangle(bar, e.Bounds.X, e.Bounds.Y, 4, e.Bounds.Height);
                }
            }

            using (Pen line = new Pen(Theme.Border))
            {
                e.Graphics.DrawLine(line, e.Bounds.X, e.Bounds.Bottom - 1,
                    e.Bounds.Right, e.Bounds.Bottom - 1);
            }

            Rectangle nameRect = new Rectangle(e.Bounds.X + 16, e.Bounds.Y + 7,
                e.Bounds.Width - 210, 20);
            Rectangle metaRect = new Rectangle(e.Bounds.X + 16, e.Bounds.Y + 28,
                e.Bounds.Width - 210, 18);
            Rectangle percentRect = new Rectangle(e.Bounds.Right - 16 - 72 - 8 - 76,
                e.Bounds.Y + 14, 76, 24);
            Rectangle pillRect = new Rectangle(e.Bounds.Right - 16 - 72, e.Bounds.Y + 14, 72, 24);

            TextRenderer.DrawText(e.Graphics, s.Name, Theme.BodyBoldFont, nameRect,
                Theme.TextDark,
                TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);

            string meta = "";

            if (s.Subject != "")
                meta += s.Subject + "   |   ";

            meta += "Score " + s.Score + " of " + s.Total + "   |   " +
                s.TakenAt.ToString("dd/MM HH:mm");

            if (!IsTeacherView() && s.TeacherUsername != "")
                meta += "   |   " + AppData.DisplayName(s.TeacherUsername);

            TextRenderer.DrawText(e.Graphics, meta,
                Theme.SmallFont, metaRect, Theme.TextMuted,
                TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);

            TextRenderer.DrawText(e.Graphics, s.GetPercentage().ToString("F1") + "%",
                Theme.BodyBoldFont, percentRect, Theme.TextDark,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter);

            Color pillBack;
            Color pillText;
            string statusText;

            if (s.IsPassed())
            {
                pillBack = Color.FromArgb(220, 252, 231);
                pillText = Color.FromArgb(22, 101, 52);
                statusText = "Passed";
            }
            else
            {
                pillBack = Color.FromArgb(254, 226, 226);
                pillText = Color.FromArgb(153, 27, 27);
                statusText = "Failed";
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath pill = Theme.RoundedRect(pillRect, 12))
            using (SolidBrush pillBrush = new SolidBrush(pillBack))
            {
                e.Graphics.FillPath(pillBrush, pill);
            }

            TextRenderer.DrawText(e.Graphics, statusText, Theme.SmallFont, pillRect, pillText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private string BuildReport()
        {
            string filterText = chipFilter.SelectedItem;
            if (filterText == "")
                filterText = "All";

            string report = "EduQuiz - Quiz Results Report" + Environment.NewLine;
            report += "Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + Environment.NewLine;

            if (IsTeacherView())
                report += "Teacher: " + AppData.DisplayName(teacherUser) + Environment.NewLine;

            report += "Subject: " + SelectedSubject() + Environment.NewLine;
            report += "Filter: " + filterText + Environment.NewLine;
            report += "Sorted: " + SelectedSort() + Environment.NewLine;
            report += "----------------------------------------" + Environment.NewLine;

            foreach (Student s in shownResults)
            {
                string subjectText = "";
                if (s.Subject != "")
                    subjectText = " [" + s.Subject + "]";

                report += s.Print() + subjectText + Environment.NewLine;
            }

            report += "----------------------------------------" + Environment.NewLine;
            report += "Attempts: " + shownResults.Count + Environment.NewLine;
            report += "Average: " + textAverage + Environment.NewLine;
            report += "Highest: " + textHighest + Environment.NewLine;
            report += "Lowest: " + textLowest + Environment.NewLine;
            report += "Passed: " + passedCount + Environment.NewLine;
            report += "Failed: " + failedCount + Environment.NewLine;
            report += passNote + Environment.NewLine;

            return report;
        }

        private void ExportReport()
        {
            if (shownResults.Count == 0)
            {
                MessageBox.Show("There are no results to export.", "Export",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text File|*.txt";
            dlg.FileName = "quiz-results.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(dlg.FileName, BuildReport());
                    MessageBox.Show("Export completed.", "Export",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not save the file:\n" + ex.Message, "Export Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chipFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshResults();
        }

        private void chipSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshResults();
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshResults();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshResults();
        }

        private void pnlSearchBox_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportReport();
        }

        private void btnClearResults_Click(object sender, EventArgs e)
        {
            if (AppData.Results.Count == 0)
            {
                MessageBox.Show("There are no results to clear.", "Clear Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Delete ALL saved results? This cannot be undone.",
                "Clear Results", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                AppData.Results.Clear();
                RefreshResults();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}