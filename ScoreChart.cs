using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuizSystem
{
    // Column chart: how many quiz attempts fall into each score range.
    // Everything is drawn with GDI+ (Graphics, Pen, brushes, transforms),
    // it grows with a Timer animation and reacts to the mouse.
    public class ScoreChart : Control
    {
        private static readonly string[] BandNames = { "0-19", "20-39", "40-59", "60-79", "80-100" };

        private int[] counts = new int[5];
        private int total = 0;
        private int axisTop = 4;
        private int axisStep = 1;
        private double passMark = -1;     // -1 = do not draw the pass-mark line
        private float progress = 1f;      // 0 .. 1, drives the grow animation
        private int hoverBand = -1;       // column under the mouse, -1 = none
        private Timer tmrGrow;

        public ScoreChart()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            BackColor = Color.White;
            Size = new Size(640, 400);

            tmrGrow = new Timer();
            tmrGrow.Interval = 16;
            tmrGrow.Tick += tmrGrow_Tick;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && tmrGrow != null)
                tmrGrow.Dispose();

            base.Dispose(disposing);
        }

        // ---------- data ----------

        public void SetData(List<Student> results, double pass)
        {
            counts = new int[BandNames.Length];
            total = 0;

            foreach (Student s in results)
            {
                int band = (int)(s.GetPercentage() / 20.0);

                if (band > BandNames.Length - 1)
                    band = BandNames.Length - 1;

                if (band < 0)
                    band = 0;

                counts[band]++;
                total++;
            }

            passMark = pass;
            hoverBand = -1;
            ComputeAxis();
            Replay();
        }

        // Nice vertical axis: whole numbers, and always a little room above the tallest column
        private void ComputeAxis()
        {
            int max = 3;

            foreach (int c in counts)
            {
                if (c > max)
                    max = c;
            }

            if (max <= 5)
                axisStep = 1;
            else if (max <= 10)
                axisStep = 2;
            else
                axisStep = (int)Math.Ceiling(max / 5.0);

            axisTop = (max / axisStep + 1) * axisStep;
        }

        // ---------- animation ----------

        public void Replay()
        {
            progress = 0f;
            tmrGrow.Start();
            Invalidate();
        }

        private void tmrGrow_Tick(object sender, EventArgs e)
        {
            progress += 0.04f;

            if (progress >= 1f)
            {
                progress = 1f;
                tmrGrow.Stop();
            }

            Invalidate();
        }

        // starts fast, slows down at the end ("ease out")
        private float Eased()
        {
            float left = 1f - progress;
            return 1f - left * left * left;
        }

        // ---------- geometry ----------

        private Rectangle PlotRect()
        {
            return new Rectangle(64, 44, Math.Max(10, Width - 64 - 24), Math.Max(10, Height - 44 - 66));
        }

        // ---------- painting ----------

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawChart(e.Graphics, Eased(), hoverBand);
        }

        // Small helper: draw text inside a rectangle with the chosen alignment
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

        private void DrawChart(Graphics g, float grow, int hover)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            Rectangle plot = PlotRect();
            float slot = plot.Width / (float)BandNames.Length;
            float barWidth = slot * 0.56f;

            // 1. coloured zones: below / above the pass mark
            int passX = -1;

            if (passMark >= 0 && passMark <= 100)
            {
                passX = plot.Left + (int)(plot.Width * passMark / 100.0);

                using (SolidBrush fail = new SolidBrush(Color.FromArgb(16, Theme.Danger)))
                using (SolidBrush pass = new SolidBrush(Color.FromArgb(16, Theme.Success)))
                {
                    g.FillRectangle(fail, plot.Left, plot.Top, passX - plot.Left, plot.Height);
                    g.FillRectangle(pass, passX, plot.Top, plot.Right - passX, plot.Height);
                }
            }

            // 2. highlight the column under the mouse
            if (hover >= 0)
            {
                using (SolidBrush lane = new SolidBrush(Color.FromArgb(18, Theme.Primary)))
                {
                    g.FillRectangle(lane, plot.Left + slot * hover, plot.Top, slot, plot.Height);
                }
            }

            // 3. horizontal grid lines and the numbers on the left
            for (int v = 0; v <= axisTop; v += axisStep)
            {
                int y = plot.Bottom - (int)(plot.Height * v / (double)axisTop);
                Color lineColor = Theme.Border;

                if (v == 0)
                    lineColor = Color.FromArgb(203, 213, 225);

                using (Pen grid = new Pen(lineColor, 1))
                {
                    g.DrawLine(grid, plot.Left, y, plot.Right, y);
                }

                Write(g, v.ToString(), Theme.SmallFont, Theme.TextMuted,
                      new RectangleF(plot.Left - 46, y - 10, 38, 20), StringAlignment.Far);
            }

            // 3b. dashed pass-mark line (drawn before the columns, so they stay in front of it)
            if (passX >= 0)
            {
                using (Pen dash = new Pen(Theme.TextDark, 1.5f))
                {
                    dash.DashStyle = DashStyle.Dash;
                    g.DrawLine(dash, passX, plot.Top - 12, passX, plot.Bottom);
                }
            }

            // 4. vertical axis title: Translate to the spot, Rotate, draw, then Restore
            GraphicsState saved = g.Save();
            g.TranslateTransform(14, plot.Top + plot.Height / 2f);
            g.RotateTransform(-90f);
            Write(g, "Number of attempts", Theme.SmallFont, Theme.TextMuted,
                  new RectangleF(-90, -10, 180, 20), StringAlignment.Center);
            g.Restore(saved);

            // 5. x axis texts
            for (int i = 0; i < BandNames.Length; i++)
            {
                Write(g, BandNames[i] + "%", Theme.SmallFont, Theme.TextDark,
                      new RectangleF(plot.Left + slot * i, plot.Bottom + 8, slot, 20),
                      StringAlignment.Center);
            }

            Write(g, "Score range", Theme.SmallFont, Theme.TextMuted,
                  new RectangleF(plot.Left, plot.Bottom + 34, plot.Width, 20), StringAlignment.Center);

            // 6. nothing to show yet
            if (total == 0)
            {
                Write(g, "No attempts to chart yet", Theme.HeadingFont, Theme.TextDark,
                      new RectangleF(plot.Left, plot.Top + plot.Height / 2f - 26, plot.Width, 28),
                      StringAlignment.Center);
                Write(g, "Quiz results will appear here as students finish quizzes.", Theme.SmallFont,
                      Theme.TextMuted,
                      new RectangleF(plot.Left, plot.Top + plot.Height / 2f + 4, plot.Width, 22),
                      StringAlignment.Center);
                return;
            }

            // 7. the columns (only the top corners are rounded)
            for (int i = 0; i < BandNames.Length; i++)
            {
                int full = (int)(plot.Height * counts[i] / (double)axisTop);
                int h = (int)(full * grow);

                if (h <= 0)
                    continue;

                float centerX = plot.Left + slot * i + slot / 2f;
                int radius = Math.Min(8, h);
                Rectangle bar = new Rectangle((int)(centerX - barWidth / 2f), plot.Bottom - h,
                                              (int)barWidth, h);

                Color topColor = Color.FromArgb(129, 140, 248);
                Color bottomColor = Theme.Primary;

                if (i == hover)
                {
                    topColor = Color.FromArgb(99, 102, 241);
                    bottomColor = Theme.PrimaryPressed;
                }

                // the gradient rectangle is 1 pixel bigger than the column: this avoids a faint dotted edge
                Rectangle gradientArea = Rectangle.Inflate(bar, 1, 1);

                using (GraphicsPath path = TopRoundedBar(bar, radius))
                using (LinearGradientBrush brush =
                       new LinearGradientBrush(gradientArea, topColor, bottomColor, LinearGradientMode.Vertical))
                {
                    brush.WrapMode = WrapMode.TileFlipXY;
                    g.FillPath(brush, path);
                }
            }

            // 8. the numbers on top of the columns (after the animation ends)
            if (grow >= 0.999f)
            {
                for (int i = 0; i < BandNames.Length; i++)
                {
                    if (counts[i] == 0)
                        continue;

                    float centerX = plot.Left + slot * i + slot / 2f;
                    int full = (int)(plot.Height * counts[i] / (double)axisTop);

                    RectangleF spot = new RectangleF(centerX - 24, plot.Bottom - full - 24, 48, 20);

                    // a thin white "halo" keeps the number readable when the dashed line passes behind it
                    foreach (int d in new int[] { -1, 1 })
                    {
                        Write(g, counts[i].ToString(), Theme.BodyBoldFont, Color.White,
                              new RectangleF(spot.X + d, spot.Y, spot.Width, spot.Height), StringAlignment.Center);
                        Write(g, counts[i].ToString(), Theme.BodyBoldFont, Color.White,
                              new RectangleF(spot.X, spot.Y + d, spot.Width, spot.Height), StringAlignment.Center);
                    }

                    Write(g, counts[i].ToString(), Theme.BodyBoldFont, Theme.TextDark, spot,
                          StringAlignment.Center);
                }
            }

            // 9. label of the pass-mark line
            if (passX >= 0)
            {
                string label = "Pass mark " + passMark.ToString("F0") + "%";
                SizeF size = g.MeasureString(label, Theme.SmallFont);
                int pillW = (int)size.Width + 18;
                int pillX = Math.Max(2, Math.Min(Width - pillW - 2, passX - pillW / 2));
                Rectangle pill = new Rectangle(pillX, plot.Top - 36, pillW, 24);

                using (GraphicsPath path = Theme.RoundedRect(pill, 12))
                using (SolidBrush fill = new SolidBrush(Theme.TextDark))
                {
                    g.FillPath(fill, path);
                }

                Write(g, label, Theme.SmallFont, Color.White, pill, StringAlignment.Center);
            }

            // 10. tooltip bubble with a little arrow (a polygon)
            if (hover >= 0 && grow >= 0.999f)
                DrawTooltip(g, plot, slot, hover);
        }

        // Rectangle whose two TOP corners are rounded and whose bottom corners are square
        private GraphicsPath TopRoundedBar(Rectangle r, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddLine(r.Right, r.Y + radius, r.Right, r.Bottom);
            path.AddLine(r.Right, r.Bottom, r.X, r.Bottom);
            path.CloseFigure();
            return path;
        }

        private void DrawTooltip(Graphics g, Rectangle plot, float slot, int band)
        {
            int count = counts[band];
            int percent = (int)Math.Round(count * 100.0 / total);

            string line1 = "Score " + BandNames[band] + "%";
            string line2 = count + (count == 1 ? " attempt" : " attempts") + "  (" + percent + "%)";

            float textWidth = Math.Max(g.MeasureString(line1, Theme.BodyBoldFont).Width,
                                       g.MeasureString(line2, Theme.SmallFont).Width);
            int w = (int)textWidth + 26;
            int h = 50;

            float centerX = plot.Left + slot * band + slot / 2f;
            int barTop = plot.Bottom - (int)(plot.Height * count / (double)axisTop);

            int x = (int)centerX - w / 2;
            x = Math.Max(4, Math.Min(Width - w - 4, x));
            int y = Math.Max(4, barTop - h - 16);

            Rectangle bubble = new Rectangle(x, y, w, h);

            using (GraphicsPath path = Theme.RoundedRect(bubble, 8))
            using (SolidBrush fill = new SolidBrush(Theme.Navy))
            {
                g.FillPath(fill, path);
            }

            Point[] arrow =
            {
                new Point((int)centerX - 7, bubble.Bottom - 1),
                new Point((int)centerX + 7, bubble.Bottom - 1),
                new Point((int)centerX, bubble.Bottom + 7)
            };

            using (SolidBrush fill = new SolidBrush(Theme.Navy))
            {
                g.FillPolygon(fill, arrow);
            }

            Write(g, line1, Theme.BodyBoldFont, Color.White,
                  new RectangleF(bubble.X, bubble.Y + 5, bubble.Width, 20), StringAlignment.Center);
            Write(g, line2, Theme.SmallFont, Color.FromArgb(203, 213, 225),
                  new RectangleF(bubble.X, bubble.Y + 25, bubble.Width, 20), StringAlignment.Center);
        }

        // ---------- mouse ----------

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            int band = -1;
            Rectangle plot = PlotRect();

            if (total > 0 && plot.Contains(e.Location))
            {
                band = (int)((e.X - plot.Left) / (plot.Width / (float)BandNames.Length));

                if (band > BandNames.Length - 1)
                    band = BandNames.Length - 1;
            }

            if (band != hoverBand)
            {
                hoverBand = band;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (hoverBand != -1)
            {
                hoverBand = -1;
                Invalidate();
            }
        }

        // ---------- export ----------

        // Draws the chart (finished, no mouse) into a Bitmap twice as big, with a title on top
        public Bitmap ToBitmap(string title)
        {
            const int scale = 2;
            const int titleHeight = 44;

            Bitmap bitmap = new Bitmap(Width * scale, (Height + titleHeight) * scale);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                g.ScaleTransform(scale, scale);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                Write(g, title, Theme.HeadingFont, Theme.TextDark,
                      new RectangleF(20, 10, Width - 40, 28), StringAlignment.Near);

                g.TranslateTransform(0, titleHeight);
                DrawChart(g, 1f, -1);
            }

            return bitmap;
        }
    }
}