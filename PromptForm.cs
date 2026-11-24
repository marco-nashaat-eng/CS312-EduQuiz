using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuizSystem
{
    // A small "type a value" window built entirely in code
    public class PromptForm : Form
    {
        private Label lblHeading = new Label();
        private Label lblMessage = new Label();
        private Label lblError = new Label();
        private ModernTextBox txtValue = new ModernTextBox();
        private ModernButton btnOk = new ModernButton();
        private ModernButton btnCancel = new ModernButton();

        public string Value { get; private set; }

        // Returns the text the user typed, or null if they cancelled
        public static string Ask(IWin32Window owner, string title, string message, int maxLength)
        {
            using (PromptForm form = new PromptForm(title, message, maxLength))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                    return form.Value;

                return null;
            }
        }

        private PromptForm(string title, string message, int maxLength)
        {
            Value = "";

            this.Text = "EduQuiz";
            this.Font = Theme.BodyFont;
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(420, 236);
            this.Icon = Theme.AppIcon;

            lblHeading.Text = title;
            lblHeading.Font = Theme.HeadingFont;
            lblHeading.ForeColor = Theme.TextDark;
            lblHeading.AutoSize = true;
            lblHeading.Location = new Point(24, 20);

            lblMessage.Text = message;
            lblMessage.AutoSize = false;
            lblMessage.Size = new Size(372, 40);
            lblMessage.Location = new Point(24, 56);
            lblMessage.ForeColor = Theme.TextMuted;

            txtValue.Location = new Point(24, 100);
            txtValue.Size = new Size(372, 44);
            txtValue.MaxLength = maxLength;

            lblError.Text = "";
            lblError.AutoSize = false;
            lblError.Size = new Size(372, 20);
            lblError.Location = new Point(24, 152);
            lblError.ForeColor = Theme.Danger;

            btnOk.Text = "OK";
            btnOk.Size = new Size(100, 40);
            btnOk.Location = new Point(186, 176);

            btnCancel.Text = "Cancel";
            btnCancel.Kind = ButtonKind.Secondary;
            btnCancel.Size = new Size(100, 40);
            btnCancel.Location = new Point(296, 176);
            btnCancel.DialogResult = DialogResult.Cancel;

            Controls.Add(lblHeading);
            Controls.Add(lblMessage);
            Controls.Add(txtValue);
            Controls.Add(lblError);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;

            btnOk.Click += btnOk_Click;
            txtValue.TextChanged += txtValue_TextChanged;
            this.Shown += PromptForm_Shown;
        }

        private void PromptForm_Shown(object sender, EventArgs e)
        {
            txtValue.Focus();
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string text = txtValue.Text.Trim();

            if (text == "")
            {
                lblError.Text = "Please type a value.";
                txtValue.Focus();
                return;
            }

            Value = text;
            this.DialogResult = DialogResult.OK;
        }
    }
}