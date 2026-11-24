using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    // Shown when a student clicks "Start quiz": quiz info with Start / Quit,
    // or "No Quiz Available". Built entirely in code.
    public class QuizInfoForm : Form
    {
        private Enrollment enrollment;
        private QuizConfig quiz;
        private bool available;
        private Student last;
        private string reason = "";

        private RoundedPanel card;
        private ModernButton btnStart;
        private ModernButton btnQuit;

        public QuizInfoForm(string studentUser, Enrollment en)
        {
            enrollment = en;
            quiz = AppData.FindQuiz(en.TeacherUsername, en.Subject);
            available = AppData.IsQuizAvailable(en.TeacherUsername, en.Subject);
            last = AppData.LastResult(studentUser, en.Subject, en.TeacherUsername);

            if (quiz == null)
                reason = "Your teacher has not created a quiz for this subject yet.";
            else if (!quiz.IsOpen)
                reason = "Your teacher has closed this quiz for now.";
            else
                reason = "Your teacher is still adding questions to this quiz.";

            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Segoe UI", 10F);
            this.Text = "EduQuiz - Quiz information"; this.Icon = Theme.AppIcon;
            this.BackColor = Theme.Background;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(560, 460);

            BuildScreen();
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

        private void BuildScreen()
        {
            Panel header = new Panel();
            header.SetBounds(0, 0, 560, 72);
            header.BackColor = Theme.Navy;
            header.Controls.Add(MakeLabel("Quiz information",
                new Font("Segoe UI", 15F, FontStyle.Bold), Color.White, Theme.Navy, 28, 12));
            header.Controls.Add(MakeLabel("Subject: " + enrollment.Subject,
                Theme.SmallFont, Color.FromArgb(148, 163, 184), Theme.Navy, 30, 44));
            this.Controls.Add(header);

            Panel line = new Panel();
            line.SetBounds(0, 72, 560, 3);
            line.BackColor = Theme.Primary;
            this.Controls.Add(line);

            card = new RoundedPanel();
            card.SetBounds(28, 96, 504, 284);
            card.BackColor = Theme.Background;
            card.FillColor = Color.White;
            card.Paint += card_Paint;
            this.Controls.Add(card);

            Panel footer = new Panel();
            footer.SetBounds(0, 400, 560, 60);
            footer.BackColor = Color.White;
            footer.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.Border))
                {
                    e.Graphics.DrawLine(p, 0, 0, footer.Width, 0);
                }
            };

            btnQuit = new ModernButton();
            btnQuit.Kind = ButtonKind.Secondary;
            btnQuit.Size = new Size(130, 42);
            btnQuit.DialogResult = DialogResult.Cancel;
            footer.Controls.Add(btnQuit);

            btnStart = new ModernButton();
            btnStart.Text = "Start quiz";
            btnStart.Size = new Size(170, 42);
            btnStart.DialogResult = DialogResult.OK;
            footer.Controls.Add(btnStart);

            if (available)
            {
                btnQuit.Text = "Quit";
                btnQuit.Location = new Point(220, 9);
                btnStart.Location = new Point(362, 9);
                this.AcceptButton = btnStart;
            }
            else
            {
                btnQuit.Text = "Close";
                btnQuit.Location = new Point(402, 9);
                btnStart.Visible = false;
            }

            this.CancelButton = btnQuit;
            this.Controls.Add(footer);
        }

        private void card_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = card.Width;

            TextFormatFlags left = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix;
            TextFormatFlags center = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextFormatFlags wrap = TextFormatFlags.Left | TextFormatFlags.Top |
                TextFormatFlags.WordBreak | TextFormatFlags.NoPrefix;

            if (!available)
            {
                // "No Quiz Available" state
                Rectangle icon = new Rectangle(w / 2 - 32, 34, 64, 64);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(254, 243, 199)))
                {
                    g.FillEllipse(brush, icon);
                }

                TextRenderer.DrawText(g, "!", Theme.TitleFont, icon,
                    Color.FromArgb(146, 64, 14), center);

                TextRenderer.DrawText(g, "No Quiz Available", Theme.TitleFont,
                    new Rectangle(24, 114, w - 48, 36), Theme.TextDark, center);

                TextRenderer.DrawText(g, reason + "\nPlease check again later.", Theme.BodyFont,
                    new Rectangle(40, 160, w - 80, 70), Theme.TextMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.Top |
                    TextFormatFlags.WordBreak | TextFormatFlags.NoPrefix);

                return;
            }

            // Quiz info state
            TextRenderer.DrawText(g, quiz.Title, Theme.HeadingFont,
                new Rectangle(24, 16, w - 48, 30), Theme.TextDark, left);

            TextRenderer.DrawText(g, "Teacher: " + AppData.DisplayName(enrollment.TeacherUsername) +
                "   |   " + enrollment.Subject, Theme.SmallFont,
                new Rectangle(24, 48, w - 48, 22), Theme.TextMuted, left);

            string[] values =
            {
                quiz.QuestionCount.ToString(),
                quiz.DurationMinutes.ToString(),
                quiz.PassPercent + "%"
            };
            string[] captions = { "Questions", "Minutes", "Pass mark" };

            int tileW = (w - 48 - 24) / 3;

            for (int i = 0; i < 3; i++)
            {
                Rectangle tile = new Rectangle(24 + i * (tileW + 12), 88, tileW, 84);

                using (GraphicsPath path = Theme.RoundedRect(tile, 10))
                using (SolidBrush fill = new SolidBrush(Color.FromArgb(248, 250, 252)))
                using (Pen border = new Pen(Theme.Border))
                {
                    g.FillPath(fill, path);
                    g.DrawPath(border, path);
                }

                TextRenderer.DrawText(g, values[i], Theme.BigNumberFont,
                    new Rectangle(tile.X, tile.Y + 6, tile.Width, 44), Theme.Primary, center);

                TextRenderer.DrawText(g, captions[i], Theme.SmallFont,
                    new Rectangle(tile.X, tile.Y + 52, tile.Width, 22), Theme.TextMuted, center);
            }

            TextRenderer.DrawText(g,
                "The timer starts when you press Start quiz.\n" +
                "When time runs out, the quiz is submitted automatically.\n" +
                "Closing the quiz early quits it and your answers are lost.",
                Theme.SmallFont, new Rectangle(24, 188, w - 48, 60), Theme.TextMuted, wrap);

            if (last != null)
            {
                string verdict = "Failed";
                Color verdictColor = Theme.Danger;

                if (last.IsPassed())
                {
                    verdict = "Passed";
                    verdictColor = Theme.Success;
                }

                TextRenderer.DrawText(g, "Your last score: " + last.GetPercentage().ToString("F0") +
                    "%  (" + verdict + ")", Theme.BodyBoldFont,
                    new Rectangle(24, 250, w - 48, 24), verdictColor, left);
            }
        }
    }
}