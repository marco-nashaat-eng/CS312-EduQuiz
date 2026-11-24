using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public class KpiCard : Control
    {
        private bool hover = false;
        private string title = "Title";
        private string valueText = "0";
        private string hint = "";
        private Color accent = Theme.Primary;

        public KpiCard()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            Cursor = Cursors.Hand;
            Size = new Size(262, 112);
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                Invalidate();
            }
        }

        public string Value
        {
            get { return valueText; }
            set
            {
                valueText = value;
                Invalidate();
            }
        }

        public string Hint
        {
            get { return hint; }
            set
            {
                hint = value;
                Invalidate();
            }
        }

        public Color AccentColor
        {
            get { return accent; }
            set
            {
                accent = value;
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

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            Color fill = Color.White;
            Color border = Theme.Border;
            float borderWidth = 1F;

            if (hover)
            {
                fill = Color.FromArgb(250, 250, 255);
                border = accent;
                borderWidth = 1.5F;
            }

            using (GraphicsPath path = Theme.RoundedRect(rect, 12))
            using (SolidBrush fillBrush = new SolidBrush(fill))
            using (Pen pen = new Pen(border, borderWidth))
            {
                g.FillPath(fillBrush, path);
                g.DrawPath(pen, path);
            }

            Rectangle chip = new Rectangle(Width - 18 - 40, 18, 40, 40);

            using (GraphicsPath chipPath = Theme.RoundedRect(chip, 10))
            using (SolidBrush chipBrush = new SolidBrush(Color.FromArgb(30, accent)))
            using (SolidBrush dotBrush = new SolidBrush(accent))
            {
                g.FillPath(chipBrush, chipPath);
                g.FillEllipse(dotBrush, chip.X + 14, chip.Y + 14, 12, 12);
            }

            TextRenderer.DrawText(g, title, Theme.SmallFont, new Point(20, 18), Theme.TextMuted);
            TextRenderer.DrawText(g, valueText, Theme.BigNumberFont, new Point(18, 40), Theme.TextDark);
            TextRenderer.DrawText(g, hint, Theme.SmallFont, new Point(20, 86), accent);
        }
    }
}