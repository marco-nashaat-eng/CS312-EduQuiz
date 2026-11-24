using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuizSystem
{
    // Ring chart: passed attempts (green) against failed attempts (red).
    // The ring sweeps open and the number counts up, driven by a Timer.
    public class DonutChart : Control
    {
        private int passed = 0;
        private int failed = 0;
        private float progress = 1f;
        private Timer tmrSweep;

        public DonutChart()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            BackColor = Color.White;
            Size = new Size(278, 250);

            tmrSweep = new Timer();
            tmrSweep.Interval = 16;
            tmrSweep.Tick += tmrSweep_Tick;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && tmrSweep != null)
                tmrSweep.Dispose();

            base.Dispose(disposing);
        }

        public void SetData(int passedCount, int failedCount)
        {
            passed = passedCount;
            failed = failedCount;
            Replay();
        }

        public void Replay()
        {
            progress = 0f;
            tmrSweep.Start();
            Invalidate();
        }

        private void tmrSweep_Tick(object sender, EventArgs e)
        {
            progress += 0.03f;

            if (progress >= 1f)
            {
                progress = 1f;
                tmrSweep.Stop();
            }

            Invalidate();
        }

        private float Eased()
        {
            float left = 1f - progress;
            return 1f - left * left * left;
        }

        private void Write(Graphics g, string text, Font font, Color color, RectangleF r,
                           StringAlignment horizontal)
        {
            using (SolidBrush brush = new SolidBrush(color))
            using (StringFormat format = new StringFormat())
            {
                format.Alignment = horizontal;
                format.LineAlignment = StringAlignment.Center;
                format.FormatFlags = StringFormatFlags.NoWrap;
                g.DrawString(text, font, brush, r, format);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            int total = passed + failed;
            float grow = Eased();

            // the ring is a square in the upper part, the legend goes below it
            int size = Math.Min(Width - 40, Height - 66);
            Rectangle ring = new Rectangle((Width - size) / 2, 8, size, size);
            float thickness = 22f;
            Rectangle track = Rectangle.Inflate(ring, -(int)(thickness / 2), -(int)(thickness / 2));

            using (Pen back = new Pen(Color.FromArgb(226, 232, 240), thickness))
            {
                g.DrawEllipse(back, track);
            }

            if (total > 0)
            {
                float passedSweep = 360f * passed / total * grow;
                float failedSweep = 360f * failed / total * grow;
                float gap = (passed > 0 && failed > 0) ? 3f : 0f;

                using (Pen green = new Pen(Theme.Success, thickness))
                using (Pen red = new Pen(Theme.Danger, thickness))
                {
                    green.StartCap = LineCap.Flat;
                    red.StartCap = LineCap.Flat;

                    if (passedSweep > gap)
                        g.DrawArc(green, track, -90f + gap / 2f, passedSweep - gap);

                    if (failedSweep > gap)
                        g.DrawArc(red, track, -90f + passedSweep + gap / 2f, failedSweep - gap);
                }
            }

            // text in the middle of the ring
            string big = "-";
            string small = "no attempts";

            if (total > 0)
            {
                big = (passed * 100.0 / total * grow).ToString("F0") + "%";
                small = "passed";
            }

            Write(g, big, Theme.BigNumberFont, Theme.TextDark,
                  new RectangleF(ring.X, ring.Y + ring.Height / 2f - 28, ring.Width, 36),
                  StringAlignment.Center);
            Write(g, small, Theme.SmallFont, Theme.TextMuted,
                  new RectangleF(ring.X, ring.Y + ring.Height / 2f + 6, ring.Width, 20),
                  StringAlignment.Center);

            // legend: two coloured dots with their numbers
            int legendY = ring.Bottom + 18;
            int leftX = Width / 2 - 104;
            int rightX = Width / 2 + 8;

            DrawLegend(g, leftX, legendY, Theme.Success, "Passed: " + passed);
            DrawLegend(g, rightX, legendY, Theme.Danger, "Failed: " + failed);
        }

        private void DrawLegend(Graphics g, int x, int y, Color dot, string text)
        {
            using (SolidBrush brush = new SolidBrush(dot))
            {
                g.FillEllipse(brush, x, y + 5, 10, 10);
            }

            Write(g, text, Theme.BodyFont, Theme.TextDark,
                  new RectangleF(x + 16, y, 90, 20), StringAlignment.Near);
        }
    }
}