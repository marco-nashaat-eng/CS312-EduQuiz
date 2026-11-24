using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public class ChipSelector : Control
    {
        private List<string> items = new List<string>();
        private int selectedIndex = -1;
        private int hoverIndex = -1;
        private bool showAddChip = false;

        public event EventHandler SelectedIndexChanged;
        public event EventHandler AddChipClicked;

        public ChipSelector()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            Cursor = Cursors.Hand;
            Font = Theme.BodyBoldFont;
            Size = new Size(520, 34);
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        public bool ShowAddChip
        {
            get { return showAddChip; }
            set
            {
                showAddChip = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (value < -1 || value >= items.Count)
                    value = -1;

                if (selectedIndex == value)
                    return;

                selectedIndex = value;
                Invalidate();

                if (SelectedIndexChanged != null)
                    SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedItem
        {
            get
            {
                if (selectedIndex == -1)
                    return "";

                return items[selectedIndex];
            }
        }

        public bool AddItem(string text)
        {
            items.Add(text);

            if (ComputePadding() < 16)
            {
                items.RemoveAt(items.Count - 1);
                return false;
            }

            Invalidate();
            return true;
        }

        public void SelectItem(string text)
        {
            SelectedIndex = items.IndexOf(text);
        }

        private List<string> ChipTexts()
        {
            List<string> texts = new List<string>(items);

            if (showAddChip)
                texts.Add("+");

            return texts;
        }

        private int ComputePadding()
        {
            List<string> texts = ChipTexts();

            if (texts.Count == 0)
                return 32;

            int textTotal = 0;

            foreach (string t in texts)
                textTotal += TextRenderer.MeasureText(t, Font).Width;

            int gaps = (texts.Count - 1) * 8;
            int pad = (Width - gaps - textTotal) / texts.Count;

            if (pad > 32)
                pad = 32;

            return pad;
        }

        private List<Rectangle> GetChipRects()
        {
            List<Rectangle> rects = new List<Rectangle>();
            List<string> texts = ChipTexts();

            int pad = ComputePadding();
            if (pad < 8)
                pad = 8;

            int x = 0;

            foreach (string t in texts)
            {
                int w = TextRenderer.MeasureText(t, Font).Width + pad;
                rects.Add(new Rectangle(x, 1, w, Height - 2));
                x += w + 8;
            }

            return rects;
        }

        private int HitTest(Point p)
        {
            List<Rectangle> rects = GetChipRects();

            for (int i = 0; i < rects.Count; i++)
            {
                if (rects[i].Contains(p))
                    return i;
            }

            return -1;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            int index = HitTest(e.Location);

            if (index != hoverIndex)
            {
                hoverIndex = index;
                Invalidate();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hoverIndex = -1;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int index = HitTest(e.Location);

            if (index != -1)
            {
                if (showAddChip && index == items.Count)
                {
                    if (AddChipClicked != null)
                        AddChipClicked(this, EventArgs.Empty);
                }
                else
                {
                    SelectedIndex = index;
                }
            }

            base.OnMouseDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Theme.BackdropOf(this));

            List<Rectangle> rects = GetChipRects();
            List<string> texts = ChipTexts();

            for (int i = 0; i < rects.Count; i++)
            {
                Rectangle r = rects[i];
                bool isAdd = (showAddChip && i == items.Count);

                Color fill = Color.White;
                Color border = Theme.Border;
                Color textColor = Theme.TextDark;

                if (isAdd)
                {
                    border = Theme.Primary;
                    textColor = Theme.Primary;

                    if (i == hoverIndex)
                        fill = Color.FromArgb(238, 242, 255);
                }
                else if (i == selectedIndex)
                {
                    fill = Theme.Primary;
                    border = Theme.Primary;
                    textColor = Color.White;
                }
                else if (i == hoverIndex)
                {
                    fill = Color.FromArgb(238, 242, 255);
                    border = Theme.Primary;
                    textColor = Theme.Primary;
                }

                Rectangle drawRect = new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1);

                using (GraphicsPath path = Theme.RoundedRect(drawRect, drawRect.Height / 2))
                using (SolidBrush brush = new SolidBrush(fill))
                using (Pen pen = new Pen(border))
                {
                    if (isAdd)
                        pen.DashStyle = DashStyle.Dash;

                    g.FillPath(brush, path);
                    g.DrawPath(pen, path);
                }

                TextRenderer.DrawText(g, texts[i], Font, r, textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                    TextFormatFlags.NoPrefix);
            }
        }
    }
}