using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public class SidebarButton : Button
    {
        private bool hover = false;
        private bool active = false;

        public SidebarButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = Theme.BodyFont;
            Size = new Size(194, 44);
        }

        [Category("Appearance")]
        [DefaultValue(false)]
        public bool Active
        {
            get { return active; }
            set
            {
                active = value;
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

            Color fill = Theme.BackdropOf(this);
            Color textColor = Color.FromArgb(203, 213, 225);
            Color dotColor = Color.FromArgb(100, 116, 139);

            if (active)
            {
                fill = Theme.Primary;
                textColor = Color.White;
                dotColor = Color.White;
            }
            else if (hover)
            {
                fill = Color.FromArgb(30, 41, 59);
                textColor = Color.White;
                dotColor = Color.FromArgb(165, 180, 252);
            }

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = Theme.RoundedRect(rect, 10))
            using (SolidBrush brush = new SolidBrush(fill))
            using (SolidBrush dotBrush = new SolidBrush(dotColor))
            {
                g.FillPath(brush, path);
                g.FillEllipse(dotBrush, 18, (Height - 8) / 2, 8, 8);
            }

            Rectangle textRect = new Rectangle(40, 0, Width - 44, Height);

            TextRenderer.DrawText(g, Text, Font, textRect, textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis);
        }
    }
}