using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public class RoundedPanel : Panel
    {
        private Color fillColor = Color.White;
        private Color borderColor = Theme.Border;
        private int radius = 12;

        public RoundedPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        [Category("Appearance")]
        public Color FillColor
        {
            get { return fillColor; }
            set
            {
                fillColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Theme.BackdropOf(this));

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = Theme.RoundedRect(rect, radius))
            using (SolidBrush brush = new SolidBrush(fillColor))
            using (Pen pen = new Pen(borderColor))
            {
                g.FillPath(brush, path);
                g.DrawPath(pen, path);
            }
            base.OnPaint(e);
        }
    }
}