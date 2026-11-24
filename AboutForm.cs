using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Icon = Theme.AppIcon;
            pnlLogo.Paint += pnlLogo_Paint;
        }

        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, pnlLogo.Width - 1, pnlLogo.Height - 1);

            using (GraphicsPath path = Theme.RoundedRect(rect, 14))
            using (SolidBrush brush = new SolidBrush(Theme.Primary))
            {
                g.FillPath(brush, path);
            }

            TextRenderer.DrawText(g, "E", Theme.TitleFont, rect, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}