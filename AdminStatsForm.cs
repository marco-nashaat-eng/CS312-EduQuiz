using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuizSystem
{
    // Admin view: who teaches what, and who studies with whom. Built entirely in code.
    public class AdminStatsForm : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private const string TabTeachers = "Teachers";
        private const string TabStudents = "Students";

        private int startTab;
        private List<UserAccount> shown = new List<UserAccount>();
        private UserAccount selected = null;

        private KpiCard cardTeachers;
        private KpiCard cardStudents;
        private KpiCard cardLinks;
        private KpiCard cardQuizzes;

        private RoundedPanel pnlList;
        private RoundedPanel pnlSearchBox;
        private RoundedPanel pnlDetail;
        private Label lblListTitle;
        private Label lblCount;
        private Label lblDetailTitle;
        private Label lblEmpty;
        private ChipSelector chipTab;
        private TextBox txtSearch;
        private ListBox lstPeople;
        private ModernButton btnClose;

        // startTab: 0 = Teachers, 1 = Students
        public AdminStatsForm(int tab)
        {
            startTab = tab;

            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Segoe UI", 10F);
            this.Text = "EduQuiz - Teachers and students";
            this.Icon = Theme.AppIcon;
            this.BackColor = Theme.Background;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(1060, 680);
            this.KeyPreview = true;

            BuildScreen();

            this.Load += AdminStatsForm_Load;
            this.KeyDown += AdminStatsForm_KeyDown;
        }

        // ---------- building the screen ----------

        private Label MakeLabel(string text, Font font, Color color, Color back, int x, int y)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Text = text;
            lbl.Font = font;
            lbl.ForeColor = color;
            lbl.BackColor = back;
            lbl.Location = new Point(x, y);
            return lbl;
        }

        private KpiCard MakeCard(string title, string hint, Color accent, int index)
        {
            KpiCard card = new KpiCard();
            card.Title = title;
            card.Hint = hint;
            card.AccentColor = accent;
            card.Size = new Size(238, 112);
            card.Location = new Point(24 + index * 258, 20);
            card.Cursor = Cursors.Default;
            return card;
        }

        private void BuildScreen()
        {
            // Header
            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Height = 64;
            header.BackColor = Theme.Navy;

            header.Controls.Add(MakeLabel("Teachers and students",
                new Font("Segoe UI", 16F, FontStyle.Bold), Color.White, Theme.Navy, 28, 8));
            header.Controls.Add(MakeLabel("See who teaches what and who studies with whom",
                Theme.SmallFont, Color.FromArgb(148, 163, 184), Theme.Navy, 30, 38));

            btnClose = new ModernButton();
            btnClose.Text = "Close";
            btnClose.Kind = ButtonKind.Secondary;
            btnClose.Size = new Size(100, 42);
            btnClose.Location = new Point(936, 11);
            btnClose.Click += (s, e) => this.Close();
            header.Controls.Add(btnClose);

            Panel headerLine = new Panel();
            headerLine.Dock = DockStyle.Bottom;
            headerLine.Height = 3;
            headerLine.BackColor = Theme.Primary;
            header.Controls.Add(headerLine);

            // Footer
            Panel footer = new Panel();
            footer.Dock = DockStyle.Bottom;
            footer.Height = 30;
            footer.BackColor = Color.White;
            footer.Controls.Add(MakeLabel("Esc Close     Ctrl+F Search",
                Theme.SmallFont, Theme.TextMuted, Color.White, 28, 7));
            footer.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.Border))
                {
                    e.Graphics.DrawLine(p, 0, 0, footer.Width, 0);
                }
            };

            // Content
            Panel content = new Panel();
            content.Dock = DockStyle.Fill;
            content.BackColor = Theme.Background;

            cardTeachers = MakeCard("Teachers", "Registered accounts", Theme.Primary, 0);
            cardStudents = MakeCard("Students", "Registered accounts", Theme.Success, 1);
            cardLinks = MakeCard("Enrollments", "Student-subject links", Theme.Warning, 2);
            cardQuizzes = MakeCard("Quizzes ready", "Open and fully stocked", Color.FromArgb(14, 165, 233), 3);
            content.Controls.Add(cardTeachers);
            content.Controls.Add(cardStudents);
            content.Controls.Add(cardLinks);
            content.Controls.Add(cardQuizzes);

            // People list card
            pnlList = new RoundedPanel();
            pnlList.SetBounds(24, 152, 690, 414);
            pnlList.BackColor = Theme.Background;
            pnlList.FillColor = Color.White;

            lblListTitle = MakeLabel("Teachers", Theme.HeadingFont, Theme.TextDark, Color.White, 20, 14);
            pnlList.Controls.Add(lblListTitle);

            lblCount = new Label();
            lblCount.AutoSize = false;
            lblCount.SetBounds(20, 44, 650, 20);
            lblCount.Font = Theme.SmallFont;
            lblCount.ForeColor = Theme.TextMuted;
            lblCount.BackColor = Color.White;
            pnlList.Controls.Add(lblCount);

            chipTab = new ChipSelector();
            chipTab.Location = new Point(20, 76);
            chipTab.Size = new Size(260, 34);
            chipTab.AddItem(TabTeachers);
            chipTab.AddItem(TabStudents);
            pnlList.Controls.Add(chipTab);

            pnlSearchBox = new RoundedPanel();
            pnlSearchBox.SetBounds(304, 73, 366, 40);
            pnlSearchBox.FillColor = Color.White;
            pnlSearchBox.Radius = 8;
            pnlSearchBox.Click += (s, e) => txtSearch.Focus();

            txtSearch = new TextBox();
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = Theme.BodyFont;
            txtSearch.ForeColor = Theme.TextDark;
            txtSearch.BackColor = Color.White;
            txtSearch.Location = new Point(14, 10);
            txtSearch.Width = 338;
            txtSearch.TextChanged += txtSearch_TextChanged;
            pnlSearchBox.Controls.Add(txtSearch);
            pnlList.Controls.Add(pnlSearchBox);

            lstPeople = new ListBox();
            lstPeople.DrawMode = DrawMode.OwnerDrawFixed;
            lstPeople.ItemHeight = 64;
            lstPeople.BorderStyle = BorderStyle.None;
            lstPeople.IntegralHeight = false;
            lstPeople.BackColor = Color.White;
            lstPeople.SetBounds(20, 124, 650, 274);
            lstPeople.DrawItem += lstPeople_DrawItem;
            lstPeople.SelectedIndexChanged += lstPeople_SelectedIndexChanged;
            pnlList.Controls.Add(lstPeople);

            lblEmpty = new Label();
            lblEmpty.AutoSize = false;
            lblEmpty.SetBounds(20, 220, 650, 60);
            lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
            lblEmpty.Font = new Font("Segoe UI", 11F);
            lblEmpty.ForeColor = Theme.TextMuted;
            lblEmpty.BackColor = Color.White;
            lblEmpty.Visible = false;
            pnlList.Controls.Add(lblEmpty);
            lblEmpty.BringToFront();

            content.Controls.Add(pnlList);

            // Detail card
            pnlDetail = new RoundedPanel();
            pnlDetail.SetBounds(738, 152, 298, 414);
            pnlDetail.BackColor = Theme.Background;
            pnlDetail.FillColor = Color.White;
            pnlDetail.Paint += pnlDetail_Paint;

            lblDetailTitle = MakeLabel("Details", Theme.HeadingFont, Theme.TextDark, Color.White, 20, 14);
            pnlDetail.Controls.Add(lblDetailTitle);

            content.Controls.Add(pnlDetail);

            // Order matters for docking: Fill first, then the edges
            this.Controls.Add(content);
            this.Controls.Add(header);
            this.Controls.Add(footer);
        }

        private void AdminStatsForm_Load(object sender, EventArgs e)
        {
            SendMessage(txtSearch.Handle, EM_SETCUEBANNER, (IntPtr)1,
                "Search by name, username or subject...");

            UpdateCards();

            chipTab.SelectedIndex = startTab;
            chipTab.SelectedIndexChanged += chipTab_SelectedIndexChanged;

            RefreshList();
        }

        private void AdminStatsForm_KeyDown(object sender, KeyEventArgs e)
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
        }

        // ---------- data helpers ----------

        private List<Enrollment> EnrollmentsOf(string student)
        {
            List<Enrollment> list = new List<Enrollment>();

            foreach (Enrollment en in AppData.Enrollments)
            {
                if (en.StudentUsername == student)
                    list.Add(en);
            }

            return list;
        }

        // different students with this teacher, over all subjects
        private int StudentCountOfTeacher(string teacher)
        {
            List<string> seen = new List<string>();

            foreach (Enrollment en in AppData.Enrollments)
            {
                if (en.TeacherUsername == teacher && !seen.Contains(en.StudentUsername))
                    seen.Add(en.StudentUsername);
            }

            return seen.Count;
        }

        private int StudentCountOf(string teacher, string subject)
        {
            int count = 0;

            foreach (Enrollment en in AppData.Enrollments)
            {
                if (en.TeacherUsername == teacher && en.Subject == subject)
                    count++;
            }

            return count;
        }

        private int QuestionsOfTeacher(string teacher)
        {
            int count = 0;

            foreach (Question q in AppData.Questions)
            {
                if (q.Owner == teacher)
                    count++;
            }

            return count;
        }

        private string LastScoreText(string student, string subject, string teacher)
        {
            Student last = AppData.LastResult(student, subject, teacher);

            if (last == null)
                return "not taken yet";

            return "last " + last.GetPercentage().ToString("F0") + "%";
        }

        private bool Matches(UserAccount u, string search)
        {
            if (u.FullName.ToLower().Contains(search) ||
                u.Username.ToLower().Contains(search) ||
                u.Email.ToLower().Contains(search))
                return true;

            if (u.Role == "Teacher")
            {
                foreach (string subject in AppData.SubjectsOf(u.Username))
                {
                    if (subject.ToLower().Contains(search))
                        return true;
                }
            }
            else
            {
                foreach (Enrollment en in EnrollmentsOf(u.Username))
                {
                    if (en.Subject.ToLower().Contains(search))
                        return true;
                }
            }

            return false;
        }

        // ---------- refreshing ----------

        private void UpdateCards()
        {
            int teachers = 0;
            int students = 0;

            foreach (UserAccount u in AppData.Users)
            {
                if (u.Role == "Teacher")
                    teachers++;
                else if (u.Role == "Student")
                    students++;
            }

            int ready = 0;

            foreach (QuizConfig q in AppData.Quizzes)
            {
                if (AppData.IsQuizAvailable(q.TeacherUsername, q.Subject))
                    ready++;
            }

            cardTeachers.Value = teachers.ToString();
            cardStudents.Value = students.ToString();
            cardLinks.Value = AppData.Enrollments.Count.ToString();
            cardQuizzes.Value = ready.ToString();
            cardQuizzes.Hint = "of " + AppData.Quizzes.Count + " created";
        }

        private bool IsStudentTab()
        {
            return chipTab.SelectedItem == TabStudents;
        }

        private void RefreshList()
        {
            string role = "Teacher";
            string plural = "teachers";

            if (IsStudentTab())
            {
                role = "Student";
                plural = "students";
            }

            string search = txtSearch.Text.Trim().ToLower();
            string keep = "";
            if (selected != null)
                keep = selected.Username;

            shown.Clear();
            lstPeople.Items.Clear();
            int total = 0;

            foreach (UserAccount u in AppData.Users)
            {
                if (u.Role != role)
                    continue;

                total++;

                if (search == "" || Matches(u, search))
                    shown.Add(u);
            }

            shown.Sort((a, b) => string.Compare(a.FullName, b.FullName,
                StringComparison.CurrentCultureIgnoreCase));

            int keepIndex = -1;

            for (int i = 0; i < shown.Count; i++)
            {
                lstPeople.Items.Add(shown[i].FullName);

                if (shown[i].Username == keep)
                    keepIndex = i;
            }

            lblListTitle.Text = IsStudentTab() ? "Students" : "Teachers";
            lblCount.Text = "Showing " + shown.Count + " of " + total + " " + plural;

            if (shown.Count == 0)
            {
                selected = null;

                if (total == 0)
                    lblEmpty.Text = "No " + plural + " registered yet.";
                else
                    lblEmpty.Text = "No " + plural + " match your search.";

                lblEmpty.Visible = true;
                pnlDetail.Invalidate();
                return;
            }

            lblEmpty.Visible = false;

            if (keepIndex >= 0)
                lstPeople.SelectedIndex = keepIndex;
            else
                lstPeople.SelectedIndex = 0;
        }

        private void chipTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = null;
            RefreshList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void lstPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = lstPeople.SelectedIndex;

            if (i >= 0 && i < shown.Count)
                selected = shown[i];
            else
                selected = null;

            pnlDetail.Invalidate();
        }

        // ---------- drawing ----------

        private void lstPeople_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= shown.Count)
                return;

            UserAccount u = shown[e.Index];
            Graphics g = e.Graphics;
            Rectangle b = e.Bounds;
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color back = Color.White;
            if (isSelected)
                back = Color.FromArgb(238, 242, 255);

            using (SolidBrush brush = new SolidBrush(back))
            {
                g.FillRectangle(brush, b);
            }

            if (isSelected)
            {
                using (SolidBrush bar = new SolidBrush(Theme.Primary))
                {
                    g.FillRectangle(bar, b.X, b.Y, 4, b.Height);
                }
            }

            using (Pen line = new Pen(Theme.Border))
            {
                g.DrawLine(line, b.X, b.Bottom - 1, b.Right, b.Bottom - 1);
            }

            string line2;
            string pill;
            bool good;

            if (u.Role == "Teacher")
            {
                List<string> subjects = AppData.SubjectsOf(u.Username);

                if (subjects.Count == 0)
                    line2 = "No subjects yet";
                else
                    line2 = string.Join(", ", subjects);

                int n = StudentCountOfTeacher(u.Username);
                pill = n + (n == 1 ? " student" : " students");
                good = (n > 0);
            }
            else
            {
                List<Enrollment> list = EnrollmentsOf(u.Username);

                if (list.Count == 0)
                {
                    line2 = "Not enrolled in any subject";
                }
                else
                {
                    List<string> parts = new List<string>();

                    foreach (Enrollment en in list)
                        parts.Add(en.Subject + " (" + AppData.DisplayName(en.TeacherUsername) + ")");

                    line2 = string.Join(", ", parts);
                }

                pill = list.Count + (list.Count == 1 ? " subject" : " subjects");
                good = (list.Count > 0);
            }

            // avatar with the first letter
            Rectangle avatar = new Rectangle(b.X + 16, b.Y + (b.Height - 36) / 2, 36, 36);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush avatarBrush = new SolidBrush(Color.FromArgb(238, 242, 255)))
            {
                g.FillEllipse(avatarBrush, avatar);
            }

            TextRenderer.DrawText(g, Initial(u.FullName), Theme.BodyBoldFont, avatar, Theme.Primary,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            int textWidth = b.Width - 62 - 16 - 104 - 8;

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix;

            TextRenderer.DrawText(g, u.FullName, Theme.BodyBoldFont,
                new Rectangle(b.X + 62, b.Y + 9, textWidth, 22), Theme.TextDark, flags);

            TextRenderer.DrawText(g, line2, Theme.SmallFont,
                new Rectangle(b.X + 62, b.Y + 33, textWidth, 20), Theme.TextMuted, flags);

            Color pillBack = Color.FromArgb(241, 245, 249);
            Color pillText = Color.FromArgb(71, 85, 105);

            if (good)
            {
                pillBack = Color.FromArgb(220, 252, 231);
                pillText = Color.FromArgb(22, 101, 52);
            }

            Rectangle pillRect = new Rectangle(b.Right - 16 - 104, b.Y + (b.Height - 26) / 2, 104, 26);

            using (GraphicsPath path = Theme.RoundedRect(pillRect, 13))
            using (SolidBrush pillBrush = new SolidBrush(pillBack))
            {
                g.FillPath(pillBrush, path);
            }

            TextRenderer.DrawText(g, pill, Theme.SmallFont, pillRect, pillText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private string Initial(string name)
        {
            string text = name.Trim();

            if (text == "")
                return "?";

            return text.Substring(0, 1).ToUpper();
        }

        private void pnlDetail_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = pnlDetail.Width;
            int h = pnlDetail.Height;

            TextFormatFlags left = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix;
            TextFormatFlags right = TextFormatFlags.Right | TextFormatFlags.VerticalCenter |
                TextFormatFlags.NoPrefix;

            if (selected == null)
            {
                TextRenderer.DrawText(g, "Select a person in the list\nto see the details.",
                    Theme.BodyFont, new Rectangle(20, 70, w - 40, 60), Theme.TextMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.Top |
                    TextFormatFlags.WordBreak | TextFormatFlags.NoPrefix);
                return;
            }

            Rectangle avatar = new Rectangle(20, 48, 52, 52);

            using (SolidBrush brush = new SolidBrush(Theme.Primary))
            {
                g.FillEllipse(brush, avatar);
            }

            TextRenderer.DrawText(g, Initial(selected.FullName), Theme.HeadingFont, avatar,
                Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            TextRenderer.DrawText(g, selected.FullName, Theme.HeadingFont,
                new Rectangle(84, 50, w - 100, 26), Theme.TextDark, left);
            TextRenderer.DrawText(g, "@" + selected.Username, Theme.SmallFont,
                new Rectangle(84, 78, w - 100, 20), Theme.TextMuted, left);
            TextRenderer.DrawText(g, selected.Email, Theme.SmallFont,
                new Rectangle(20, 108, w - 40, 20), Theme.TextMuted, left);

            string summary;

            if (selected.Role == "Teacher")
            {
                summary = StudentCountOfTeacher(selected.Username) + " students   |   " +
                    QuestionsOfTeacher(selected.Username) + " questions written";
            }
            else
            {
                summary = "Member since " + selected.CreatedAt.ToString("dd MMM yyyy");
            }

            TextRenderer.DrawText(g, summary, Theme.SmallFont,
                new Rectangle(20, 128, w - 40, 20), Theme.TextDark, left);

            using (Pen line = new Pen(Theme.Border))
            {
                g.DrawLine(line, 20, 156, w - 20, 156);
            }

            string caption;
            if (selected.Role == "Teacher")
                caption = "SUBJECTS TAUGHT";
            else
                caption = "ENROLLED SUBJECTS";

            TextRenderer.DrawText(g, caption, Theme.SmallFont,
                new Rectangle(20, 164, w - 40, 18), Theme.TextMuted, left);

            int y = 188;
            int itemHeight = 42;

            if (selected.Role == "Teacher")
            {
                List<string> subjects = AppData.SubjectsOf(selected.Username);

                if (subjects.Count == 0)
                {
                    TextRenderer.DrawText(g, "This teacher has no subjects yet.", Theme.BodyFont,
                        new Rectangle(20, y, w - 40, 24), Theme.TextMuted, left);
                    return;
                }

                for (int i = 0; i < subjects.Count; i++)
                {
                    if (y + itemHeight > h - 8)
                    {
                        TextRenderer.DrawText(g, "+ " + (subjects.Count - i) + " more",
                            Theme.SmallFont, new Rectangle(20, y, w - 40, 20), Theme.TextMuted, left);
                        break;
                    }

                    int n = StudentCountOf(selected.Username, subjects[i]);

                    TextRenderer.DrawText(g, subjects[i], Theme.BodyBoldFont,
                        new Rectangle(20, y, w - 140, 22), Theme.TextDark, left);
                    TextRenderer.DrawText(g, n + (n == 1 ? " student" : " students"), Theme.SmallFont,
                        new Rectangle(w - 120, y, 100, 22), Theme.TextMuted, right);
                    TextRenderer.DrawText(g, "Quiz: " + AppData.QuizStatusText(selected.Username, subjects[i]),
                        Theme.SmallFont, new Rectangle(20, y + 22, w - 40, 18), Theme.TextMuted, left);

                    y += itemHeight;
                }
            }
            else
            {
                List<Enrollment> list = EnrollmentsOf(selected.Username);

                if (list.Count == 0)
                {
                    TextRenderer.DrawText(g, "Not enrolled in any subject yet.", Theme.BodyFont,
                        new Rectangle(20, y, w - 40, 24), Theme.TextMuted, left);
                    return;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (y + itemHeight > h - 8)
                    {
                        TextRenderer.DrawText(g, "+ " + (list.Count - i) + " more",
                            Theme.SmallFont, new Rectangle(20, y, w - 40, 20), Theme.TextMuted, left);
                        break;
                    }

                    Enrollment en = list[i];

                    TextRenderer.DrawText(g, en.Subject, Theme.BodyBoldFont,
                        new Rectangle(20, y, w - 140, 22), Theme.TextDark, left);
                    TextRenderer.DrawText(g, LastScoreText(selected.Username, en.Subject, en.TeacherUsername),
                        Theme.SmallFont, new Rectangle(w - 130, y, 110, 22), Theme.TextMuted, right);
                    TextRenderer.DrawText(g, "Teacher: " + AppData.DisplayName(en.TeacherUsername),
                        Theme.SmallFont, new Rectangle(20, y + 22, w - 40, 18), Theme.TextMuted, left);

                    y += itemHeight;
                }
            }
        }
    }
}