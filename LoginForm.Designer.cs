namespace QuizSystem
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBrandLogo = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lnkSignUp = new System.Windows.Forms.LinkLabel();
            this.lblSignUpPrompt = new System.Windows.Forms.Label();
            this.lblRoleNote = new System.Windows.Forms.Label();
            this.btnExit = new QuizSystem.ModernButton();
            this.btnLogin = new QuizSystem.ModernButton();
            this.lblError = new System.Windows.Forms.Label();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new QuizSystem.ModernTextBox();
            this.lblPasswordCaption = new System.Windows.Forms.Label();
            this.txtUsername = new QuizSystem.ModernTextBox();
            this.lblUsernameCaption = new System.Windows.Forms.Label();
            this.lblWelcomeSub = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlBrand.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlBrand.Controls.Add(this.lblBrandSub);
            this.pnlBrand.Controls.Add(this.label1);
            this.pnlBrand.Controls.Add(this.lblBrandLogo);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(400, 553);
            this.pnlBrand.TabIndex = 0;
            this.pnlBrand.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBrand_Paint);
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.AutoSize = true;
            this.lblBrandSub.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.lblBrandSub.Location = new System.Drawing.Point(40, 340);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(161, 25);
            this.lblBrandSub.TabIndex = 2;
            this.lblBrandSub.Text = "Sign in to continue";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 130);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exams made simple for teachers and students";
            // 
            // lblBrandLogo
            // 
            this.lblBrandLogo.AutoSize = true;
            this.lblBrandLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandLogo.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandLogo.ForeColor = System.Drawing.Color.White;
            this.lblBrandLogo.Location = new System.Drawing.Point(40, 40);
            this.lblBrandLogo.Name = "lblBrandLogo";
            this.lblBrandLogo.Size = new System.Drawing.Size(166, 50);
            this.lblBrandLogo.TabIndex = 0;
            this.lblBrandLogo.Text = "EduQuiz";
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.lnkSignUp);
            this.pnlForm.Controls.Add(this.lblSignUpPrompt);
            this.pnlForm.Controls.Add(this.lblRoleNote);
            this.pnlForm.Controls.Add(this.btnExit);
            this.pnlForm.Controls.Add(this.btnLogin);
            this.pnlForm.Controls.Add(this.lblError);
            this.pnlForm.Controls.Add(this.chkShowPassword);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.lblPasswordCaption);
            this.pnlForm.Controls.Add(this.txtUsername);
            this.pnlForm.Controls.Add(this.lblUsernameCaption);
            this.pnlForm.Controls.Add(this.lblWelcomeSub);
            this.pnlForm.Controls.Add(this.lblWelcome);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(400, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(482, 553);
            this.pnlForm.TabIndex = 1;
            this.pnlForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlForm_Paint);
            // 
            // lnkSignUp
            // 
            this.lnkSignUp.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(48)))), ((int)(((byte)(163)))));
            this.lnkSignUp.AutoSize = true;
            this.lnkSignUp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSignUp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkSignUp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lnkSignUp.Location = new System.Drawing.Point(209, 484);
            this.lnkSignUp.Name = "lnkSignUp";
            this.lnkSignUp.Size = new System.Drawing.Size(153, 23);
            this.lnkSignUp.TabIndex = 12;
            this.lnkSignUp.TabStop = true;
            this.lnkSignUp.Text = "\tCreate an account";
            this.lnkSignUp.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            // 
            // lblSignUpPrompt
            // 
            this.lblSignUpPrompt.AutoSize = true;
            this.lblSignUpPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSignUpPrompt.Location = new System.Drawing.Point(70, 484);
            this.lblSignUpPrompt.Name = "lblSignUpPrompt";
            this.lblSignUpPrompt.Size = new System.Drawing.Size(142, 23);
            this.lblSignUpPrompt.TabIndex = 11;
            this.lblSignUpPrompt.Text = "New to EduQuiz?";
            // 
            // lblRoleNote
            // 
            this.lblRoleNote.AutoSize = true;
            this.lblRoleNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRoleNote.Location = new System.Drawing.Point(70, 514);
            this.lblRoleNote.Name = "lblRoleNote";
            this.lblRoleNote.Size = new System.Drawing.Size(364, 20);
            this.lblRoleNote.TabIndex = 10;
            this.lblRoleNote.Text = "Your role is detected automatically from your account";
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnExit.Location = new System.Drawing.Point(70, 428);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(360, 42);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(70, 372);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(360, 46);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Sign in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblError.Location = new System.Drawing.Point(70, 340);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(360, 22);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "Error message";
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.chkShowPassword.Location = new System.Drawing.Point(70, 312);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(149, 27);
            this.chkShowPassword.TabIndex = 6;
            this.chkShowPassword.Text = "Show password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(70, 254);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(360, 44);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "modernTextBox1";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPasswordCaption
            // 
            this.lblPasswordCaption.AutoSize = true;
            this.lblPasswordCaption.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPasswordCaption.Location = new System.Drawing.Point(70, 232);
            this.lblPasswordCaption.Name = "lblPasswordCaption";
            this.lblPasswordCaption.Size = new System.Drawing.Size(85, 23);
            this.lblPasswordCaption.TabIndex = 4;
            this.lblPasswordCaption.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(70, 172);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(360, 44);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "eg.marco";
            // 
            // lblUsernameCaption
            // 
            this.lblUsernameCaption.AutoSize = true;
            this.lblUsernameCaption.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblUsernameCaption.Location = new System.Drawing.Point(70, 150);
            this.lblUsernameCaption.Name = "lblUsernameCaption";
            this.lblUsernameCaption.Size = new System.Drawing.Size(89, 23);
            this.lblUsernameCaption.TabIndex = 2;
            this.lblUsernameCaption.Text = "Username";
            // 
            // lblWelcomeSub
            // 
            this.lblWelcomeSub.AutoSize = true;
            this.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblWelcomeSub.Location = new System.Drawing.Point(66, 99);
            this.lblWelcomeSub.Name = "lblWelcomeSub";
            this.lblWelcomeSub.Size = new System.Drawing.Size(302, 23);
            this.lblWelcomeSub.TabIndex = 1;
            this.lblWelcomeSub.Text = "Enter your account details to continue";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblWelcome.Location = new System.Drawing.Point(66, 44);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(244, 45);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome back";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlBrand);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EduQuiz - Sign in";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.pnlBrand.ResumeLayout(false);
            this.pnlBrand.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Label lblBrandLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblUsernameCaption;
        private System.Windows.Forms.Label lblWelcomeSub;
        private System.Windows.Forms.Label lblPasswordCaption;
        private ModernTextBox txtUsername;
        private ModernTextBox txtPassword;
        private ModernButton btnLogin;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private ModernButton btnExit;
        private System.Windows.Forms.Label lblRoleNote;
        private System.Windows.Forms.Label lblSignUpPrompt;
        private System.Windows.Forms.LinkLabel lnkSignUp;
    }
}

