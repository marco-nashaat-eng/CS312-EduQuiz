using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace QuizSystem
{
    // The "stage" of the photo editor. It shows a picture that can be dragged with
    // the mouse, zoomed and rotated, and a round window that shows what will be kept.
    public class PhotoCanvas : Control
    {
        private Bitmap source;                  // the loaded picture (our own copy)
        private float zoom = 1f;                // 1 = the picture just covers the circle
        private float angle = 0f;               // rotation in degrees
        private PointF offset = new PointF(0, 0);   // how far the picture was dragged
        private bool dragging = false;
        private Point lastMouse;

        public event EventHandler ImageChanged;

        public PhotoCanvas()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            BackColor = Theme.Navy;
            Size = new Size(416, 356);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && source != null)
                source.Dispose();

            base.Dispose(disposing);
        }

        public bool HasImage
        {
            get { return source != null; }
        }

        public int ZoomPercent
        {
            get { return (int)Math.Round(zoom * 100); }
        }

        // ---------- loading ----------

        public void LoadImage(string path)
        {
            // Image.FromFile keeps the file locked, so we work on our own (smaller) copy
            using (Image original = Image.FromFile(path))
            {
                float shrink = Math.Min(1f, 1400f / Math.Max(original.Width, original.Height));
                int w = Math.Max(1, (int)(original.Width * shrink));
                int h = Math.Max(1, (int)(original.Height * shrink));

                Bitmap copy = new Bitmap(w, h);

                using (Graphics g = Graphics.FromImage(copy))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.DrawImage(original, 0, 0, w, h);
                }

                if (source != null)
                    source.Dispose();

                source = copy;
            }

            ResetView();
        }

        // ---------- the three manipulations ----------

        public void ZoomBy(float amount)
        {
            zoom = Math.Max(1f, Math.Min(4f, zoom + amount));
            Changed();
        }

        public void Rotate(float degrees)
        {
            angle = (angle + degrees) % 360f;
            Changed();
        }

        public void ResetView()
        {
            zoom = 1f;
            angle = 0f;
            offset = new PointF(0, 0);
            Changed();
        }

        private void Changed()
        {
            Invalidate();

            if (ImageChanged != null)
                ImageChanged(this, EventArgs.Empty);
        }

        // ---------- geometry ----------

        // diameter of the round window
        private float Diameter()
        {
            return Math.Min(Width, Height) - 56;
        }

        // scale that makes the picture exactly cover the circle (zoom = 1)
        private float BaseScale()
        {
            return Diameter() / Math.Min(source.Width, source.Height);
        }

        // Move the origin to the middle, turn, then scale: the picture is drawn around (0, 0).
        // k lets us reuse the same code for a bigger output picture.
        private void ApplyTransform(Graphics g, float centerX, float centerY, float k)
        {
            g.TranslateTransform(centerX + offset.X * k, centerY + offset.Y * k);
            g.RotateTransform(angle);
            float s = BaseScale() * zoom * k;
            g.ScaleTransform(s, s);
        }

        private void DrawPicture(Graphics g)
        {
            g.DrawImage(source, -source.Width / 2f, -source.Height / 2f, source.Width, source.Height);
        }

        // ---------- painting ----------

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            float d = Diameter();
            RectangleF circle = new RectangleF((Width - d) / 2f, (Height - d) / 2f, d, d);

            if (source == null)
            {
                DrawEmptyState(g, circle);
                return;
            }

            // 1. the picture, moved / turned / scaled
            GraphicsState saved = g.Save();
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            ApplyTransform(g, Width / 2f, Height / 2f, 1f);
            DrawPicture(g);
            g.Restore(saved);

            // 2. dark cover everywhere except inside the circle (rectangle + ellipse, "alternate" fill)
            using (GraphicsPath cover = new GraphicsPath(FillMode.Alternate))
            using (SolidBrush shade = new SolidBrush(Color.FromArgb(170, 15, 23, 42)))
            {
                cover.AddRectangle(new RectangleF(0, 0, Width, Height));
                cover.AddEllipse(circle);
                g.FillPath(shade, cover);
            }

            // 3. outline of the circle and a short hint
            using (Pen outline = new Pen(Color.White, 2))
            {
                g.DrawEllipse(outline, circle);
            }

            TextRenderer.DrawText(g, "Drag to move   |   Mouse wheel to zoom", Theme.SmallFont,
                new Rectangle(0, Height - 28, Width, 22), Color.FromArgb(203, 213, 225),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void DrawEmptyState(Graphics g, RectangleF circle)
        {
            using (Pen dashed = new Pen(Color.FromArgb(100, 116, 139), 2))
            {
                dashed.DashStyle = DashStyle.Dash;
                g.DrawEllipse(dashed, circle);
            }

            TextRenderer.DrawText(g, "Choose a photo to start", Theme.HeadingFont,
                new Rectangle(0, Height / 2 - 22, Width, 28), Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            TextRenderer.DrawText(g, "JPG, PNG, BMP or GIF", Theme.SmallFont,
                new Rectangle(0, Height / 2 + 6, Width, 22), Color.FromArgb(148, 163, 184),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // ---------- mouse ----------

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Focus();    // the mouse wheel only reaches the control that has the focus

            if (source != null)
                Cursor = Cursors.SizeAll;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left && source != null)
            {
                dragging = true;
                lastMouse = e.Location;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!dragging)
                return;

            float limit = Diameter() / 2f;
            float x = offset.X + (e.X - lastMouse.X);
            float y = offset.Y + (e.Y - lastMouse.Y);

            offset = new PointF(Math.Max(-limit, Math.Min(limit, x)),
                                Math.Max(-limit, Math.Min(limit, y)));
            lastMouse = e.Location;
            Changed();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            dragging = false;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (source == null)
                return;

            if (e.Delta > 0)
                ZoomBy(0.1f);
            else
                ZoomBy(-0.1f);
        }

        // ---------- result ----------

        // Draws exactly what is inside the circle into a new square Bitmap of the given size
        public Bitmap Render(int size)
        {
            Bitmap result = new Bitmap(size, size);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.Clear(Color.White);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                float k = size / Diameter();
                ApplyTransform(g, size / 2f, size / 2f, k);
                DrawPicture(g);
            }

            return result;
        }
    }
}