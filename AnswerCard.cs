using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public class AnswerCard : Control
    {
        private static readonly Font textFont = new Font("Segoe UI", 12F);

        private string letter = "A";
        private string answerText = "";
        private bool selected = false;
        private bool hover = false;

        public AnswerCard()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            Cursor = Cursors.Hand;
            Size = new Size(496, 100);
        }

        public string Letter
        {
            get { return letter; }
            set
            {
                letter = value;
                Invalidate();
            }
        }

        public string AnswerText
        {
            get { return answerText; }
            set
            {
                answerText = value;
                Invalidate();
            }
        }

        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                Invalidate();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            hover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hover = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Theme.BackdropOf(this));

            Rectangle rect = new Rectangle(1, 1, Width - 3, Height - 3);

            Color fill = Color.White;
            Color border = Theme.Border;
            float borderWidth = 1F;

            if (selected)
            {
                fill = Color.FromArgb(238, 242, 255);
                border = Theme.Primary;
                borderWidth = 2F;
            }
            else if (hover)
            {
                fill = Color.FromArgb(250, 250, 255);
                border = Color.FromArgb(165, 180, 252);
                borderWidth = 1.5F;
            }

            using (GraphicsPath path = Theme.RoundedRect(rect, 14))
            using (SolidBrush fillBrush = new SolidBrush(fill))
            using (Pen pen = new Pen(border, borderWidth))
            {
                g.FillPath(fillBrush, path);
                g.DrawPath(pen, path);
            }

            Rectangle badge = new Rectangle(20, (Height - 40) / 2, 40, 40);

            Color badgeFill = Color.FromArgb(241, 245, 249);
            Color badgeText = Theme.TextMuted;

            if (selected)
            {
                badgeFill = Theme.Primary;
                badgeText = Color.White;
            }

            using (SolidBrush badgeBrush = new SolidBrush(badgeFill))
            {
                g.FillEllipse(badgeBrush, badge);
            }

            TextRenderer.DrawText(g, letter, Theme.BodyBoldFont, badge, badgeText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            Rectangle textRect = new Rectangle(76, 8, Width - 76 - 20, Height - 16);

            TextRenderer.DrawText(g, answerText, textFont, textRect, Theme.TextDark,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis |
                TextFormatFlags.NoPrefix);
        }
    }
}