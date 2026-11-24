using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    // Chips you can switch on and off (several can be selected).
    // Chips wrap onto new rows. An optional "+" chip lets the user add an item.
    public class MultiChipSelector : Control
    {
        private const int ChipHeight = 32;
        private const int Gap = 8;

        private List<string> items = new List<string>();
        private List<string> checkedList = new List<string>();
        private int hoverIndex = -1;
        private bool showAddChip = false;
        private int maxRows = 2;
        private bool singleSelect = false;

        public event EventHandler SelectionChanged;
        public event EventHandler AddChipClicked;

        public MultiChipSelector()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            Cursor = Cursors.Hand;
            Font = Theme.BodyBoldFont;
            Size = new Size(516, 74);
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

        [Category("Behavior")]
        [DefaultValue(2)]
        public int MaxRows
        {
            get { return maxRows; }
            set
            {
                if (value < 1)
                    value = 1;

                maxRows = value;
            }
        }
        // When true, exactly one chip is selected at a time
        [Category("Behavior")]
        [DefaultValue(false)]
        public bool SingleSelect
        {
            get { return singleSelect; }
            set { singleSelect = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedItem
        {
            get
            {
                if (checkedList.Count == 0)
                    return "";

                return checkedList[0];
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<string> CheckedItems
        {
            get
            {
                List<string> result = new List<string>();

                foreach (string s in items)
                {
                    if (checkedList.Contains(s))
                        result.Add(s);
                }

                return result;
            }
        }

        // Returns false when there is no room for one more chip
        public bool AddItem(string text)
        {
            items.Add(text);

            if (RowCount() > maxRows)
            {
                items.RemoveAt(items.Count - 1);
                return false;
            }

            Invalidate();
            return true;
        }

        public void RemoveItem(string text)
        {
            items.Remove(text);
            checkedList.Remove(text);
            Invalidate();
        }

        // Case-insensitive search. Returns the stored text, or null.
        public string FindItem(string text)
        {
            foreach (string s in items)
            {
                if (s.ToLower() == text.ToLower())
                    return s;
            }

            return null;
        }

        public bool IsChecked(string text)
        {
            return checkedList.Contains(text);
        }

        public void SetChecked(string text, bool value)
        {
            if (!items.Contains(text))
                return;

            if (singleSelect)
            {
                // one chip is always selected; clicking another one moves the selection
                if (!value || (checkedList.Count == 1 && checkedList[0] == text))
                    return;

                checkedList.Clear();
                checkedList.Add(text);
                Invalidate();

                if (SelectionChanged != null)
                    SelectionChanged(this, EventArgs.Empty);

                return;
            }

            if (checkedList.Contains(text) == value)
                return;

            if (value)
                checkedList.Add(text);
            else
                checkedList.Remove(text);

            Invalidate();

            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);
        }

        // ---------- Layout ----------

        private List<string> ChipTexts()
        {
            List<string> texts = new List<string>(items);

            if (showAddChip)
                texts.Add("+");

            return texts;
        }

        private List<Rectangle> GetChipRects()
        {
            List<Rectangle> rects = new List<Rectangle>();
            int x = 0;
            int y = 1;

            foreach (string t in ChipTexts())
            {
                int w = TextRenderer.MeasureText(t, Font).Width + 36;

                if (w < 44)
                    w = 44;

                if (x > 0 && x + w > Width)
                {
                    x = 0;
                    y += ChipHeight + Gap;
                }

                rects.Add(new Rectangle(x, y, w, ChipHeight));
                x += w + Gap;
            }

            return rects;
        }

        private int RowCount()
        {
            List<Rectangle> rects = GetChipRects();

            if (rects.Count == 0)
                return 0;

            Rectangle last = rects[rects.Count - 1];
            return (last.Y - 1) / (ChipHeight + Gap) + 1;
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

        // ---------- Mouse ----------

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
                    string text = items[index];
                    SetChecked(text, !checkedList.Contains(text));
                }
            }

            base.OnMouseDown(e);
        }

        // ---------- Painting ----------

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
                bool isOn = (!isAdd && checkedList.Contains(items[i]));

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
                else if (isOn)
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

                TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix;

                if (isOn)
                {
                    // white check mark on the left, text shifted to the right
                    int cy = r.Y + r.Height / 2;
                    int cx = r.X + 12;

                    using (Pen tick = new Pen(Color.White, 2F))
                    {
                        tick.StartCap = LineCap.Round;
                        tick.EndCap = LineCap.Round;
                        g.DrawLines(tick, new Point[]
                        {
                            new Point(cx, cy),
                            new Point(cx + 3, cy + 3),
                            new Point(cx + 9, cy - 4)
                        });
                    }

                    Rectangle textRect = new Rectangle(r.X + 12, r.Y, r.Width - 12, r.Height);
                    TextRenderer.DrawText(g, texts[i], Font, textRect, textColor, flags);
                }
                else
                {
                    TextRenderer.DrawText(g, texts[i], Font, r, textColor, flags);
                }
            }
        }
    }
}