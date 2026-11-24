using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuizSystem
{
    // "Performance analytics": two GDI+ charts built from the results that are
    // currently shown in the Results screen. Built entirely in code.
    public class AnalyticsForm : Form
    {
        private List<Student> results;

        private ScoreChart chart;
        private DonutChart donut;
        private ModernButton btnSave;
        private ModernButton btnReplay;
        private ModernButton btnClose;
        private Label lblSub;

        public AnalyticsForm(List<Student> shown)
        {
            results = new List<Student>(shown);

            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Segoe UI", 10F);
            this.Text = "EduQuiz - Performance analytics"; this.Icon = Theme.AppIcon;
            this.BackColor = Theme.Background;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(1060, 700);
            this.KeyPreview = true;

            BuildScreen();

            this.Load += AnalyticsForm_Load;
            this.KeyDown += AnalyticsForm_KeyDown;
        }

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

        private RoundedPanel MakeCard(int x, int y, int w, int h, string title, string sub)
        {
            RoundedPanel card = new RoundedPanel();
            card.SetBounds(x, y, w, h);
            card.BackColor = Theme.Background;
            card.FillColor = Color.White;
            card.Controls.Add(MakeLabel(title, Theme.HeadingFont, Theme.TextDark, Color.White, 20, 14));

            if (sub != "")
                card.Controls.Add(MakeLabel(sub, Theme.SmallFont, Theme.TextMuted, Color.White, 22, 46));

            this.Controls.Add(card);
            return card;
        }

        private void BuildScreen()
        {
            // header
            Panel header = new Panel();
            header.SetBounds(0, 0, 1060, 64);
            header.BackColor = Theme.Navy;
            header.Controls.Add(MakeLabel("Performance analytics", Theme.TitleFont,
                Color.White, Theme.Navy, 28, 8));
            lblSub = MakeLabel("", Theme.SmallFont, Color.FromArgb(148, 163, 184), Theme.Navy, 30, 42);
            header.Controls.Add(lblSub);

            btnClose = new ModernButton();
            btnClose.Text = "Close";
            btnClose.Kind = ButtonKind.Secondary;
            btnClose.SetBounds(936, 11, 100, 42);
            btnClose.DialogResult = DialogResult.Cancel;
            header.Controls.Add(btnClose);
            this.Controls.Add(header);

            Panel line = new Panel();
            line.SetBounds(0, 61, 1060, 3);
            line.BackColor = Theme.Primary;
            this.Controls.Add(line);
            line.BringToFront();

            // card with the column chart
            RoundedPanel cardBars = MakeCard(24, 88, 690, 560, "Score distribution",
                "How many attempts fall into each score range. Move the mouse over a column.");
            chart = new ScoreChart();
            chart.SetBounds(12, 76, 666, 468);
            cardBars.Controls.Add(chart);

            // card with the ring chart
            RoundedPanel cardDonut = MakeCard(738, 88, 298, 340, "Pass rate",
                "Passed and failed attempts");
            donut = new DonutChart();
            donut.SetBounds(10, 76, 278, 252);
            cardDonut.Controls.Add(donut);

            // card with the actions
            RoundedPanel cardActions = MakeCard(738, 448, 298, 200, "Chart actions", "");

            btnSave = new ModernButton();
            btnSave.Text = "Save chart as image";
            btnSave.SetBounds(20, 56, 258, 46);
            btnSave.Click += btnSave_Click;
            cardActions.Controls.Add(btnSave);

            btnReplay = new ModernButton();
            btnReplay.Text = "Replay animation";
            btnReplay.Kind = ButtonKind.Secondary;
            btnReplay.SetBounds(20, 110, 258, 46);
            btnReplay.Click += btnReplay_Click;
            cardActions.Controls.Add(btnReplay);

            cardActions.Controls.Add(MakeLabel("The image is saved as a PNG file",
                Theme.SmallFont, Theme.TextMuted, Color.White, 22, 164));

            // footer
            Panel footer = new Panel();
            footer.SetBounds(0, 670, 1060, 30);
            footer.BackColor = Color.White;
            footer.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.Border))
                {
                    e.Graphics.DrawLine(p, 0, 0, footer.Width, 0);
                }
            };
            footer.Controls.Add(MakeLabel("Esc Close     Ctrl+S Save image", Theme.SmallFont,
                Theme.TextMuted, Color.White, 28, 6));
            this.Controls.Add(footer);

            this.CancelButton = btnClose;
        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {
            int passed = 0;
            int failed = 0;
            bool samePass = true;

            foreach (Student s in results)
            {
                if (s.IsPassed())
                    passed++;
                else
                    failed++;

                if (s.PassPercent != results[0].PassPercent)
                    samePass = false;
            }

            // one pass-mark line only makes sense when every attempt used the same mark
            double passMark = -1;

            if (results.Count > 0 && samePass)
                passMark = results[0].PassPercent;

            chart.SetData(results, passMark);
            donut.SetData(passed, failed);

            btnSave.Enabled = results.Count > 0;
            btnReplay.Enabled = results.Count > 0;

            if (results.Count == 0)
                lblSub.Text = "There are no attempts to analyse yet";
            else
                lblSub.Text = "Based on the " + results.Count + " attempt" +
                    (results.Count == 1 ? "" : "s") + " currently shown in Results";
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            chart.Replay();
            donut.Replay();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void SaveImage()
        {
            if (results.Count == 0)
                return;

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PNG image|*.png";
                dlg.FileName = "EduQuiz_score_distribution.png";

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    using (Bitmap bitmap = chart.ToBitmap("Score distribution"))
                    {
                        bitmap.Save(dlg.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }

                    MessageBox.Show("The chart was saved:\n" + dlg.FileName, "Save chart",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The image could not be saved: " + ex.Message, "Save chart",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AnalyticsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveImage();
                e.SuppressKeyPress = true;
            }
        }
    }
}