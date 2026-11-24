using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public static class Theme
    {
        public static readonly Color Primary = Color.FromArgb(79, 70, 229);
        public static readonly Color PrimaryHover = Color.FromArgb(67, 56, 202);
        public static readonly Color PrimaryPressed = Color.FromArgb(55, 48, 163);
        public static readonly Color Navy = Color.FromArgb(15, 23, 42);
        public static readonly Color Background = Color.FromArgb(244, 246, 251);
        public static readonly Color Border = Color.FromArgb(226, 232, 240);
        public static readonly Color TextDark = Color.FromArgb(15, 23, 42);
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);
        public static readonly Color Success = Color.FromArgb(22, 163, 74);
        public static readonly Color Danger = Color.FromArgb(220, 38, 38);
        public static readonly Color Warning = Color.FromArgb(245, 158, 11);

        public static readonly Font TitleFont = new Font("Segoe UI", 20F, FontStyle.Bold);
        public static readonly Font HeadingFont = new Font("Segoe UI", 13F, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 10F);
        public static readonly Font BodyBoldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
        public static readonly Font SmallFont = new Font("Segoe UI", 9F);
        public static readonly Font BigNumberFont = new Font("Segoe UI", 24F, FontStyle.Bold);

        public const int Radius = 10;

        private static Icon appIcon = null;

        public static Icon AppIcon
        {
            get
            {
                if (appIcon == null)
                {
                    Bitmap bmp = new Bitmap(32, 32);

                    using (Graphics g = Graphics.FromImage(bmp))
                    using (GraphicsPath path = RoundedRect(new Rectangle(0, 0, 31, 31), 8))
                    using (SolidBrush brush = new SolidBrush(Primary))
                    using (Font font = new Font("Segoe UI", 16F, FontStyle.Bold))
                    using (StringFormat format = new StringFormat())
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                        g.FillPath(brush, path);

                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Center;

                        g.DrawString("E", font, Brushes.White, new RectangleF(0, 0, 32, 32), format);
                    }

                    appIcon = Icon.FromHandle(bmp.GetHicon());
                }

                return appIcon;
            }
        }

        public static Color BackdropOf(Control c)
        {
            Control p = c.Parent;

            while (p != null)
            {
                RoundedPanel card = p as RoundedPanel;

                if (card != null)
                    return card.FillColor;

                if (p.BackColor != Color.Transparent)
                    return p.BackColor;

                p = p.Parent;
            }

            return Color.White;
        }

        public static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}