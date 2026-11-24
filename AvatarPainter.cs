using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    // Draws the round user picture: the photo when the user has one,
    // otherwise the initials on a coloured circle (the old look).
    public static class AvatarPainter
    {
        public static void Draw(Graphics g, Rectangle r, Image photo, string initials, Font font)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (photo == null)
            {
                using (SolidBrush brush = new SolidBrush(Theme.Primary))
                {
                    g.FillEllipse(brush, r);
                }

                TextRenderer.DrawText(g, initials, font, r, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }

            // 1. shrink the photo to the avatar size (high quality)
            using (Bitmap small = new Bitmap(r.Width, r.Height))
            {
                using (Graphics sg = Graphics.FromImage(small))
                {
                    sg.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    sg.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    sg.DrawImage(photo, 0, 0, r.Width, r.Height);
                }

                // 2. fill an ellipse with the photo: a TextureBrush paints with a picture
                using (TextureBrush brush = new TextureBrush(small))
                {
                    brush.WrapMode = WrapMode.Clamp;
                    brush.TranslateTransform(r.X, r.Y);
                    g.FillEllipse(brush, r);
                }
            }

            // 3. thin ring around the photo
            using (Pen ring = new Pen(Theme.Border, 1))
            {
                g.DrawEllipse(ring, r.X, r.Y, r.Width - 1, r.Height - 1);
            }
        }

        // Small round "camera" badge: tells the user that the picture can be changed
        public static void DrawEditBadge(Graphics g, Rectangle avatar)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int d = 24;
            Rectangle badge = new Rectangle(avatar.Right - d + 4, avatar.Bottom - d + 4, d, d);

            using (SolidBrush fill = new SolidBrush(Color.White))
            using (Pen border = new Pen(Theme.Border, 1))
            {
                g.FillEllipse(fill, badge);
                g.DrawEllipse(border, badge);
            }

            using (SolidBrush ink = new SolidBrush(Theme.Primary))
            using (SolidBrush white = new SolidBrush(Color.White))
            {
                // camera body (rounded rectangle) and the little bump on top (polygon)
                Rectangle body = new Rectangle(badge.X + 6, badge.Y + 9, 12, 9);

                using (GraphicsPath path = Theme.RoundedRect(body, 2))
                {
                    g.FillPath(ink, path);
                }

                Point[] bump =
                {
                    new Point(badge.X + 9, badge.Y + 9),
                    new Point(badge.X + 10, badge.Y + 7),
                    new Point(badge.X + 14, badge.Y + 7),
                    new Point(badge.X + 15, badge.Y + 9)
                };
                g.FillPolygon(ink, bump);

                // lens
                g.FillEllipse(white, badge.X + 9, badge.Y + 10, 6, 6);
                g.FillEllipse(ink, badge.X + 10, badge.Y + 11, 4, 4);
            }
        }
    }
}