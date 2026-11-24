using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(900, 540);
            lnkSignUp.Click += lnkSignUp_Click;
            this.Icon = Theme.AppIcon;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            AppData.AddSampleQuestions();
            lblError.Text = "";
            txtUsername.Focus();
        }

        private void pnlBrand_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush soft = new SolidBrush(Color.FromArgb(35, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(soft, -80, 380, 300, 300);
                e.Graphics.FillEllipse(soft, 230, -90, 240, 240);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.ForeColor = Theme.Danger;
            lblError.Text = "";
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "" || password == "")
            {
                lblError.Text = "Please enter your username and password.";

                if (username == "")
                    txtUsername.Focus();
                else
                    txtPassword.Focus();

                return;
            }

            UserAccount account = AppData.FindUser(username);

            if (account == null || account.Password != password)
            {
                lblError.Text = "Incorrect username or password.";
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            if (account.Role == "Admin")
            {
                MainForm main = new MainForm(this);
                main.Show();
                this.Hide();
            }
            else if (account.Role == "Teacher")
            {
                TeacherForm dashboard = new TeacherForm(this, account);
                dashboard.Show();
                this.Hide();
            }
            else
            {
              
                StudentForm studentHome = new StudentForm(this, account);
                studentHome.Show();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }
        private void lnkSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUp = new SignUpForm(this);
            signUp.Show();
            this.Hide();
        }

        // Called by the Sign Up form after an account was created
        public void ShowAfterSignUp(string username)
        {
            ResetForNewLogin();
            txtUsername.Text = username;
            lblError.ForeColor = Theme.Success;
            lblError.Text = "Account created. Please sign in.";
            Show();
            txtPassword.Focus();
        }
        public void ResetForNewLogin()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            chkShowPassword.Checked = false;
            lblError.Text = "";
            txtUsername.Focus();
        }

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}