using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public enum ButtonKind
    {
        Primary,
        Secondary,
        Danger
    }

    public class ModernButton : Button
    {
        private bool hover = false;
        private bool pressed = false;
        private ButtonKind kind = ButtonKind.Primary;

        public ModernButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = Theme.BodyBoldFont;
            Size = new Size(140, 42);
        }

        [Category("Appearance")]
        [DefaultValue(ButtonKind.Primary)]
        public ButtonKind Kind
        {
            get { return kind; }
            set
            {
                kind = value;
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
            pressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            pressed = true;
            Invalidate();
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            pressed = false;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            Invalidate();
            base.OnEnabledChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(Theme.BackdropOf(this));

            Color fill;
            Color textColor;
            Color border;
            GetColors(out fill, out textColor, out border);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = Theme.RoundedRect(rect, Theme.Radius))
            using (SolidBrush brush = new SolidBrush(fill))
            using (Pen pen = new Pen(border))
            {
                g.FillPath(brush, path);
                g.DrawPath(pen, path);
            }

            TextRenderer.DrawText(g, Text, Font, ClientRectangle, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis);
        }

        private void GetColors(out Color fill, out Color textColor, out Color border)
        {
            if (!Enabled)
            {
                fill = Color.FromArgb(226, 232, 240);
                textColor = Color.FromArgb(148, 163, 184);
                border = fill;
                return;
            }

            if (kind == ButtonKind.Secondary)
            {
                textColor = Theme.TextDark;
                border = Theme.Border;

                if (pressed)
                    fill = Color.FromArgb(226, 232, 240);
                else if (hover)
                    fill = Color.FromArgb(241, 245, 249);
                else
                    fill = Color.White;

                return;
            }

            textColor = Color.White;

            if (kind == ButtonKind.Danger)
            {
                if (pressed)
                    fill = Color.FromArgb(153, 27, 27);
                else if (hover)
                    fill = Color.FromArgb(185, 28, 28);
                else
                    fill = Theme.Danger;
            }
            else
            {
                if (pressed)
                    fill = Theme.PrimaryPressed;
                else if (hover)
                    fill = Theme.PrimaryHover;
                else
                    fill = Theme.Primary;
            }

            border = fill;
        }
    }
}