using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuizSystem
{
    // Profile photo editor: choose a picture, then move, zoom and rotate it inside a round window.
    // Built entirely in code.
    public class PhotoEditorForm : Form
    {
        private UserAccount account;
        private string initials;

        private PhotoCanvas canvas;
        private Panel pnlPreview;
        private Label lblZoom;
        private ModernButton btnChoose;
        private ModernButton btnZoomOut;
        private ModernButton btnZoomIn;
        private ModernButton btnRotateLeft;
        private ModernButton btnRotateRight;
        private ModernButton btnReset;
        private ModernButton btnRemove;
        private ModernButton btnCancel;
        private ModernButton btnSave;

        private Bitmap previewImage;    // small picture shown in the preview circle

        public PhotoEditorForm(UserAccount user, string userInitials)
        {
            account = user;
            initials = userInitials;

            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Segoe UI", 10F);
            this.Text = "EduQuiz - Profile photo"; this.Icon = Theme.AppIcon;
            this.BackColor = Theme.Background;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(760, 560);

            BuildScreen();

            this.Load += PhotoEditorForm_Load;
            this.FormClosed += PhotoEditorForm_FormClosed;
        }

        private Label MakeLabel(string text, Font font, Color color, Color back, int x, int y)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Text = text;
            lbl.Font = font;
            lbl.ForeColor = color;
            lbl.BackColor = back;
            lbl.Location = new Point(x, y);
            return lbl;
        }

        private ModernButton MakeButton(string text, ButtonKind kind, int x, int y, int w, int h)
        {
            ModernButton button = new ModernButton();
            button.Text = text;
            button.Kind = kind;
            button.SetBounds(x, y, w, h);
            return button;
        }

        private void BuildScreen()
        {
            // header
            Panel header = new Panel();
            header.SetBounds(0, 0, 760, 72);
            header.BackColor = Theme.Navy;
            header.Controls.Add(MakeLabel("Profile photo", new Font("Segoe UI", 15F, FontStyle.Bold),
                Color.White, Theme.Navy, 28, 12));
            header.Controls.Add(MakeLabel("Choose a picture, then drag, zoom and rotate it inside the circle",
                Theme.SmallFont, Color.FromArgb(148, 163, 184), Theme.Navy, 30, 44));
            this.Controls.Add(header);

            Panel line = new Panel();
            line.SetBounds(0, 72, 760, 3);
            line.BackColor = Theme.Primary;
            this.Controls.Add(line);

            // left card: the stage
            RoundedPanel cardStage = new RoundedPanel();
            cardStage.SetBounds(28, 96, 440, 380);
            cardStage.BackColor = Theme.Background;
            cardStage.FillColor = Color.White;

            canvas = new PhotoCanvas();
            canvas.SetBounds(12, 12, 416, 356);
            canvas.ImageChanged += canvas_ImageChanged;
            cardStage.Controls.Add(canvas);
            this.Controls.Add(cardStage);

            // right card: the tools
            RoundedPanel cardTools = new RoundedPanel();
            cardTools.SetBounds(492, 96, 240, 380);
            cardTools.BackColor = Theme.Background;
            cardTools.FillColor = Color.White;

            btnChoose = MakeButton("Choose photo...", ButtonKind.Primary, 20, 20, 200, 44);
            btnChoose.Click += btnChoose_Click;
            cardTools.Controls.Add(btnChoose);

            cardTools.Controls.Add(MakeLabel("Zoom", Theme.BodyBoldFont, Theme.TextDark, Color.White, 22, 76));
            lblZoom = MakeLabel("100%", Theme.SmallFont, Theme.TextMuted, Color.White, 176, 79);
            cardTools.Controls.Add(lblZoom);

            btnZoomOut = MakeButton("-", ButtonKind.Secondary, 20, 100, 96, 40);
            btnZoomOut.Click += btnZoomOut_Click;
            cardTools.Controls.Add(btnZoomOut);

            btnZoomIn = MakeButton("+", ButtonKind.Secondary, 124, 100, 96, 40);
            btnZoomIn.Click += btnZoomIn_Click;
            cardTools.Controls.Add(btnZoomIn);

            cardTools.Controls.Add(MakeLabel("Rotate", Theme.BodyBoldFont, Theme.TextDark, Color.White, 22, 152));

            btnRotateLeft = MakeButton("Left", ButtonKind.Secondary, 20, 176, 96, 40);
            btnRotateLeft.Click += btnRotateLeft_Click;
            cardTools.Controls.Add(btnRotateLeft);

            btnRotateRight = MakeButton("Right", ButtonKind.Secondary, 124, 176, 96, 40);
            btnRotateRight.Click += btnRotateRight_Click;
            cardTools.Controls.Add(btnRotateRight);

            btnReset = MakeButton("Reset position", ButtonKind.Secondary, 20, 228, 200, 40);
            btnReset.Click += btnReset_Click;
            cardTools.Controls.Add(btnReset);

            cardTools.Controls.Add(MakeLabel("Preview", Theme.BodyBoldFont, Theme.TextDark, Color.White, 22, 284));

            pnlPreview = new Panel();
            pnlPreview.SetBounds(22, 308, 56, 56);
            pnlPreview.BackColor = Color.White;
            pnlPreview.Paint += pnlPreview_Paint;
            cardTools.Controls.Add(pnlPreview);

            cardTools.Controls.Add(MakeLabel("This is how your picture\nwill look in the app.",
                Theme.SmallFont, Theme.TextMuted, Color.White, 92, 318));

            this.Controls.Add(cardTools);

            // footer
            Panel footer = new Panel();
            footer.SetBounds(0, 500, 760, 60);
            footer.BackColor = Color.White;
            footer.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.Border))
                {
                    e.Graphics.DrawLine(p, 0, 0, footer.Width, 0);
                }
            };

            btnRemove = MakeButton("Remove photo", ButtonKind.Danger, 28, 9, 160, 42);
            btnRemove.Click += btnRemove_Click;
            footer.Controls.Add(btnRemove);

            btnCancel = MakeButton("Cancel", ButtonKind.Secondary, 466, 9, 120, 42);
            btnCancel.DialogResult = DialogResult.Cancel;
            footer.Controls.Add(btnCancel);

            btnSave = MakeButton("Save photo", ButtonKind.Primary, 598, 9, 134, 42);
            btnSave.Click += btnSave_Click;
            footer.Controls.Add(btnSave);

            this.Controls.Add(footer);
            this.CancelButton = btnCancel;
        }
        private void PhotoEditorForm_Load(object sender, EventArgs e)
        {
            btnRemove.Visible = account.Photo != null;
            UpdateTools();
        }

        private void PhotoEditorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (previewImage != null)
                previewImage.Dispose();
        }

        // ---------- the tools ----------

        private void btnChoose_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Choose a profile photo";
                dlg.Filter = "Pictures|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    canvas.LoadImage(dlg.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show("This file could not be opened as a picture.", "Profile photo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            canvas.ZoomBy(-0.15f);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            canvas.ZoomBy(0.15f);
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            canvas.Rotate(-90f);
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            canvas.Rotate(90f);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            canvas.ResetView();
        }

        // the canvas tells us whenever the picture was moved, zoomed or turned
        private void canvas_ImageChanged(object sender, EventArgs e)
        {
            UpdateTools();
        }

        private void UpdateTools()
        {
            bool has = canvas.HasImage;

            btnZoomOut.Enabled = has;
            btnZoomIn.Enabled = has;
            btnRotateLeft.Enabled = has;
            btnRotateRight.Enabled = has;
            btnReset.Enabled = has;
            btnSave.Enabled = has;

            lblZoom.Text = canvas.ZoomPercent + "%";

            if (has)
            {
                if (previewImage != null)
                    previewImage.Dispose();

                previewImage = canvas.Render(112);
            }

            pnlPreview.Invalidate();
        }

        private void pnlPreview_Paint(object sender, PaintEventArgs e)
        {
            Image shown = previewImage;

            if (shown == null)
                shown = account.Photo;

            AvatarPainter.Draw(e.Graphics, new Rectangle(0, 0, 56, 56), shown, initials, Theme.HeadingFont);
        }

        // ---------- save / remove ----------

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!canvas.HasImage)
                return;

            Bitmap result = canvas.Render(256);

            if (account.Photo != null)
                account.Photo.Dispose();

            account.Photo = result;
            this.DialogResult = DialogResult.OK;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Remove your profile photo?", "Profile photo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
                return;

            if (account.Photo != null)
                account.Photo.Dispose();

            account.Photo = null;
            this.DialogResult = DialogResult.OK;
        }
    }
}