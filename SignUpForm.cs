using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class SignUpForm : Form
    {
        private LoginForm loginForm;
        private string createdUsername = "";

        public SignUpForm(LoginForm login)
        {
            InitializeComponent();
            this.ClientSize = new Size(980, 660);
            loginForm = login;
            this.Icon = Theme.AppIcon;

            WireEvents();
            SetupControls();
        }

        private void WireEvents()
        {
            pnlBrand.Paint += pnlBrand_Paint;
            chipRole.SelectedIndexChanged += chipRole_SelectedIndexChanged;
            chipSubjects.AddChipClicked += chipSubjects_AddChipClicked;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            btnCreate.Click += btnCreate_Click;
            btnBack.Click += btnBack_Click;
            btnSubjectAdd.Click += btnSubjectAdd_Click;
            btnSubjectCancel.Click += btnSubjectCancel_Click;
            this.FormClosed += SignUpForm_FormClosed;

            // Hide the message as soon as the user types again
            txtFullName.TextChanged += ClearError;
            txtUsername.TextChanged += ClearError;
            txtEmail.TextChanged += ClearError;
            txtPassword.TextChanged += ClearError;
            txtConfirm.TextChanged += ClearError;
        }

        private void SetupControls()
        {
            pnlSubjects.FillColor = Color.White;
            pnlSubjects.BorderColor = Theme.Border;
            pnlSubjects.Radius = 8;

            pnlNewSubject.Visible = false;
            chipSubjects.Visible = true;

            foreach (string subject in AppData.Subjects)
                chipSubjects.AddItem(subject);

            lblError.Text = "";

            chipRole.AddItem("Student");
            chipRole.AddItem("Teacher");
            chipRole.SelectItem("Student");
        }

        // ---------- Look ----------

        private void pnlBrand_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush soft = new SolidBrush(Color.FromArgb(35, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(soft, -90, 470, 300, 300);
                e.Graphics.FillEllipse(soft, 200, -100, 240, 240);
            }
        }

        private void chipRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isTeacher = (chipRole.SelectedItem == "Teacher");

            CloseNewSubjectBox();
            pnlSubjects.Visible = isTeacher;
            lblStudentNote.Visible = !isTeacher;
            lblError.Text = "";
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirm.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void ClearError(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        // ---------- Messages ----------

        private void ShowError(string message, ModernTextBox box)
        {
            lblError.ForeColor = Theme.Danger;
            lblError.Text = message;

            if (box != null)
                box.Focus();
        }

        private void ShowHint(string message)
        {
            lblError.ForeColor = Theme.TextMuted;
            lblError.Text = message;
        }

        // ---------- New subject (the + chip) ----------

        private void chipSubjects_AddChipClicked(object sender, EventArgs e)
        {
            chipSubjects.Visible = false;
            pnlNewSubject.Visible = true;
            txtNewSubject.Clear();
            txtNewSubject.Focus();

            ShowHint("Type the new subject name, then press Enter or click Add.");
        }

        private void CloseNewSubjectBox()
        {
            pnlNewSubject.Visible = false;
            chipSubjects.Visible = true;
        }

        private void SaveNewSubject()
        {
            string name = txtNewSubject.Text.Trim();

            if (name == "")
            {
                ShowError("Please type a subject name.", txtNewSubject);
                return;
            }

            if (name.Length > 25)
            {
                ShowError("The subject name is too long (25 characters at most).", txtNewSubject);
                return;
            }

            string existing = chipSubjects.FindItem(name);

            if (existing != null)
            {
                chipSubjects.SetChecked(existing, true);
                CloseNewSubjectBox();
                ShowHint("That subject already exists, so it was selected.");
                return;
            }

            if (!chipSubjects.AddItem(name))
            {
                ShowError("There is no more room for subjects here.", txtNewSubject);
                return;
            }

            chipSubjects.SetChecked(name, true);
            CloseNewSubjectBox();
            ShowHint("Subject \"" + name + "\" added and selected.");
        }

        private void btnSubjectAdd_Click(object sender, EventArgs e)
        {
            SaveNewSubject();
        }

        private void btnSubjectCancel_Click(object sender, EventArgs e)
        {
            CloseNewSubjectBox();
            lblError.Text = "";
        }

        // ---------- Validation helpers ----------

        private bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '.' && c != '-' && c != '\'')
                    return false;
            }

            return true;
        }

        private bool IsStrongEnough(string password)
        {
            bool hasLetter = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                    hasLetter = true;

                if (char.IsDigit(c))
                    hasDigit = true;
            }

            return password.Length >= 6 && hasLetter && hasDigit;
        }

        private bool EmailTaken(string email)
        {
            foreach (UserAccount u in AppData.Users)
            {
                if (u.Email.ToLower() == email.ToLower())
                    return true;
            }

            return false;
        }

        // ---------- Buttons ----------

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Enter is the AcceptButton: while the new-subject row is open,
            // Enter should add the subject, not create the account.
            if (pnlNewSubject.Visible)
            {
                SaveNewSubject();
                return;
            }

            lblError.Text = "";

            string role = chipRole.SelectedItem;
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim().ToLower();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;

            if (fullName == "")
            {
                ShowError("Please enter your full name.", txtFullName);
                return;
            }

            if (fullName.Length < 3)
            {
                ShowError("Full name must be at least 3 characters.", txtFullName);
                return;
            }

            if (!IsValidName(fullName))
            {
                ShowError("Full name can only contain letters and spaces.", txtFullName);
                return;
            }

            if (username == "")
            {
                ShowError("Please choose a username.", txtUsername);
                return;
            }

            if (!Regex.IsMatch(username, "^[a-z][a-z0-9_]{2,19}$"))
            {
                ShowError("Username: 3-20 characters, letters, digits or _, starting with a letter.", txtUsername);
                return;
            }

            if (AppData.FindUser(username) != null)
            {
                ShowError("That username is already taken.", txtUsername);
                return;
            }

            if (email == "")
            {
                ShowError("Please enter your email.", txtEmail);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ShowError("Please enter a valid email (name@example.com).", txtEmail);
                return;
            }

            if (EmailTaken(email))
            {
                ShowError("This email is already registered.", txtEmail);
                return;
            }

            if (password == "")
            {
                ShowError("Please choose a password.", txtPassword);
                return;
            }

            if (!IsStrongEnough(password))
            {
                ShowError("Password: at least 6 characters, with a letter and a number.", txtPassword);
                return;
            }

            if (confirm != password)
            {
                ShowError("The two passwords do not match.", txtConfirm);
                return;
            }

            if (role == "Teacher" && chipSubjects.CheckedItems.Count == 0)
            {
                ShowError("Pick at least one subject you will teach.", null);
                return;
            }

            try
            {
                UserAccount account = new UserAccount(username, password, role, fullName);
                account.Email = email;
                AppData.Users.Add(account);

                if (role == "Teacher")
                {
                    foreach (string subject in chipSubjects.CheckedItems)
                    {
                        // a subject added with the + chip becomes a real subject now
                        if (!AppData.Subjects.Contains(subject))
                            AppData.Subjects.Add(subject);

                        AppData.TeacherSubjects.Add(new TeacherSubject(username, subject));
                    }
                }

                createdUsername = username;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The account could not be created.\n\n" + ex.Message,
                    "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Closing the form sends the user back to the Login form
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Esc (CancelButton) closes the new-subject row first
            if (pnlNewSubject.Visible)
            {
                CloseNewSubjectBox();
                lblError.Text = "";
                return;
            }

            this.Close();
        }

        private void SignUpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (createdUsername != "")
                loginForm.ShowAfterSignUp(createdUsername);
            else
                loginForm.Show();
        }
    }
}