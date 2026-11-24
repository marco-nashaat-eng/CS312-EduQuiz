using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public class ModernTextBox : UserControl
    {
        private TextBox inner = new TextBox();
        private bool focused = false;

        public ModernTextBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            inner.BorderStyle = BorderStyle.None;
            inner.Font = Theme.BodyFont;
            inner.BackColor = Color.White;
            inner.ForeColor = Theme.TextDark;
            inner.GotFocus += Inner_GotFocus;
            inner.LostFocus += Inner_LostFocus;
            inner.TextChanged += Inner_TextChanged;
            Controls.Add(inner);

            Size = new Size(300, 44);
            PlaceInner();
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return inner.Text; }
            set { inner.Text = value; }
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        public bool UseSystemPasswordChar
        {
            get { return inner.UseSystemPasswordChar; }
            set { inner.UseSystemPasswordChar = value; }
        }

        [Category("Behavior")]
        [DefaultValue(32767)]
        public int MaxLength
        {
            get { return inner.MaxLength; }
            set { inner.MaxLength = value; }
        }

        public void Clear()
        {
            inner.Clear();
        }

        public new bool Focus()
        {
            return inner.Focus();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            inner.Focus();
            base.OnMouseDown(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            inner.Focus();
            base.OnGotFocus(e);
        }

        private void PlaceInner()
        {
            inner.Width = Width - 24;
            inner.Left = 12;
            inner.Top = (Height - inner.Height) / 2;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            PlaceInner();
        }

        private void Inner_GotFocus(object sender, EventArgs e)
        {
            focused = true;
            Invalidate();
        }

        private void Inner_LostFocus(object sender, EventArgs e)
        {
            focused = false;
            Invalidate();
        }

        private void Inner_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(Theme.BackdropOf(this));

            Rectangle rect = new Rectangle(1, 1, Width - 3, Height - 3);
            Color borderColor = Theme.Border;
            float borderWidth = 1F;

            if (focused)
            {
                borderColor = Theme.Primary;
                borderWidth = 2F;
            }

            using (GraphicsPath path = Theme.RoundedRect(rect, 8))
            using (SolidBrush brush = new SolidBrush(Color.White))
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                g.FillPath(brush, path);
                g.DrawPath(pen, path);
            }
        }
    }
}