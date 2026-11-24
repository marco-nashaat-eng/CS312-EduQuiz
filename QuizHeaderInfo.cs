using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    // Quiz title, status pill and progress bar for the Question Manager header
    public class QuizHeaderInfo : Control
    {
        private string title = "";
        private string info = "";
        private string status = "";
        private int done = 0;
        private int target = 0;

        public QuizHeaderInfo()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            Size = new Size(420, 44);
        }

        // target = 0 means "no quiz yet"
        public void SetState(string quizTitle, int questionsDone, int questionsTarget,
                             string statusText, string extraInfo)
        {
            title = quizTitle;
            done = questionsDone;
            target = questionsTarget;
            status = statusText;
            info = extraInfo;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Theme.BackdropOf(this));

            Color pillBack;
            Color pillText;
            Color barFill;

            if (status.StartsWith("Quiz ready"))
            {
                pillBack = Color.FromArgb(220, 252, 231);
                pillText = Color.FromArgb(22, 101, 52);
                barFill = Theme.Success;
            }
            else if (status.StartsWith("Needs") || status == "Closed")
            {
                pillBack = Color.FromArgb(254, 243, 199);
                pillText = Color.FromArgb(146, 64, 14);
                barFill = Color.FromArgb(129, 140, 248);
            }
            else
            {
                pillBack = Color.FromArgb(241, 245, 249);
                pillText = Color.FromArgb(71, 85, 105);
                barFill = Color.FromArgb(129, 140, 248);
            }

            TextFormatFlags left = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix;

            // Row 1: quiz title and status pill
            TextRenderer.DrawText(g, title, Theme.BodyBoldFont,
                new Rectangle(0, 0, Width - 124, 22), Color.White, left);

            Rectangle pill = new Rectangle(Width - 112, 0, 112, 22);

            using (GraphicsPath pillPath = Theme.RoundedRect(pill, 11))
            using (SolidBrush pillBrush = new SolidBrush(pillBack))
            {
                g.FillPath(pillBrush, pillPath);
            }

            TextRenderer.DrawText(g, status, Theme.SmallFont, pill, pillText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Row 2: counts and settings
            string counts;

            if (target <= 0)
                counts = done + (done == 1 ? " question" : " questions");
            else if (done > target)
                counts = done + " questions  (quiz uses " + target + ")";
            else
                counts = done + " of " + target + " questions";

            if (info != "")
                counts += "   |   " + info;

            TextRenderer.DrawText(g, counts, Theme.SmallFont,
                new Rectangle(0, 22, Width, 16), Color.FromArgb(148, 163, 184), left);

            // Row 3: progress bar
            Rectangle track = new Rectangle(0, Height - 6, Width, 6);

            using (GraphicsPath trackPath = Theme.RoundedRect(track, 3))
            using (SolidBrush trackBrush = new SolidBrush(Color.FromArgb(51, 65, 85)))
            {
                g.FillPath(trackBrush, trackPath);
            }

            if (target > 0 && done > 0)
            {
                double ratio = Math.Min(1.0, done / (double)target);
                int w = Math.Max(6, (int)(track.Width * ratio));
                Rectangle fill = new Rectangle(0, track.Y, w, track.Height);

                using (GraphicsPath fillPath = Theme.RoundedRect(fill, 3))
                using (SolidBrush fillBrush = new SolidBrush(barFill))
                {
                    g.FillPath(fillBrush, fillPath);
                }
            }
        }
    }
}