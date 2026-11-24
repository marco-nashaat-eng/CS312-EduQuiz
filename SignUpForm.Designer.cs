namespace QuizSystem
{
    partial class SignUpForm
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
            this.lblBrandTitle = new System.Windows.Forms.Label();
            this.lblBrandLogo = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.btnBack = new QuizSystem.ModernButton();
            this.btnCreate = new QuizSystem.ModernButton();
            this.lblError = new System.Windows.Forms.Label();
            this.pnlSubjects = new QuizSystem.RoundedPanel();
            this.lblSubjectsCaption = new System.Windows.Forms.Label();
            this.lblStudentNote = new System.Windows.Forms.Label();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.txtConfirm = new QuizSystem.ModernTextBox();
            this.lblConfirmCaption = new System.Windows.Forms.Label();
            this.txtPassword = new QuizSystem.ModernTextBox();
            this.lblPassCaption = new System.Windows.Forms.Label();
            this.txtEmail = new QuizSystem.ModernTextBox();
            this.lblEmailCaption = new System.Windows.Forms.Label();
            this.txtUsername = new QuizSystem.ModernTextBox();
            this.lblUserCaption = new System.Windows.Forms.Label();
            this.txtFullName = new QuizSystem.ModernTextBox();
            this.lblNameCaption = new System.Windows.Forms.Label();
            this.chipRole = new QuizSystem.ChipSelector();
            this.lblRoleCaption = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.chipSubjects = new QuizSystem.MultiChipSelector();
            this.pnlNewSubject = new System.Windows.Forms.Panel();
            this.txtNewSubject = new QuizSystem.ModernTextBox();
            this.btnSubjectAdd = new QuizSystem.ModernButton();
            this.btnSubjectCancel = new QuizSystem.ModernButton();
            this.pnlBrand.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlSubjects.SuspendLayout();
            this.pnlNewSubject.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBrand
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlBrand.Controls.Add(this.lblBrandSub);
            this.pnlBrand.Controls.Add(this.lblBrandTitle);
            this.pnlBrand.Controls.Add(this.lblBrandLogo);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Size = new System.Drawing.Size(340, 613);
            this.pnlBrand.TabIndex = 0;
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.lblBrandSub.Location = new System.Drawing.Point(40, 300);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(260, 80);
            this.lblBrandSub.TabIndex = 2;
            this.lblBrandSub.Text = "Teachers build quizzes\r\nStudents take them and track their progress";
            // 
            // lblBrandTitle
            // 
            this.lblBrandTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandTitle.ForeColor = System.Drawing.Color.White;
            this.lblBrandTitle.Location = new System.Drawing.Point(40, 190);
            this.lblBrandTitle.Name = "lblBrandTitle";
            this.lblBrandTitle.Size = new System.Drawing.Size(270, 90);
            this.lblBrandTitle.TabIndex = 1;
            this.lblBrandTitle.Text = "Join EduQuiz today";
            // 
            // lblBrandLogo
            // 
            this.lblBrandLogo.AutoSize = true;
            this.lblBrandLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandLogo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandLogo.ForeColor = System.Drawing.Color.White;
            this.lblBrandLogo.Location = new System.Drawing.Point(40, 40);
            this.lblBrandLogo.Name = "lblBrandLogo";
            this.lblBrandLogo.Size = new System.Drawing.Size(166, 50);
            this.lblBrandLogo.TabIndex = 0;
            this.lblBrandLogo.Text = "EduQuiz";
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.btnBack);
            this.pnlForm.Controls.Add(this.btnCreate);
            this.pnlForm.Controls.Add(this.lblError);
            this.pnlForm.Controls.Add(this.pnlSubjects);
            this.pnlForm.Controls.Add(this.lblStudentNote);
            this.pnlForm.Controls.Add(this.chkShowPassword);
            this.pnlForm.Controls.Add(this.txtConfirm);
            this.pnlForm.Controls.Add(this.lblConfirmCaption);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.lblPassCaption);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.lblEmailCaption);
            this.pnlForm.Controls.Add(this.txtUsername);
            this.pnlForm.Controls.Add(this.lblUserCaption);
            this.pnlForm.Controls.Add(this.txtFullName);
            this.pnlForm.Controls.Add(this.lblNameCaption);
            this.pnlForm.Controls.Add(this.chipRole);
            this.pnlForm.Controls.Add(this.lblRoleCaption);
            this.pnlForm.Controls.Add(this.lblSub);
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(340, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(622, 613);
            this.pnlForm.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnBack.Location = new System.Drawing.Point(330, 584);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(260, 46);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Back to sign in";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.Location = new System.Drawing.Point(50, 584);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(260, 46);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "Create account";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblError.Location = new System.Drawing.Point(50, 556);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(540, 22);
            this.lblError.TabIndex = 17;
            this.lblError.Text = "Error message";
            // 
            // pnlSubjects
            // 
            this.pnlSubjects.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlSubjects.Controls.Add(this.pnlNewSubject);
            this.pnlSubjects.Controls.Add(this.chipSubjects);
            this.pnlSubjects.Controls.Add(this.lblSubjectsCaption);
            this.pnlSubjects.FillColor = System.Drawing.Color.White;
            this.pnlSubjects.Location = new System.Drawing.Point(50, 440);
            this.pnlSubjects.Name = "pnlSubjects";
            this.pnlSubjects.Radius = 12;
            this.pnlSubjects.Size = new System.Drawing.Size(540, 108);
            this.pnlSubjects.TabIndex = 16;
            // 
            // lblSubjectsCaption
            // 
            this.lblSubjectsCaption.AutoSize = true;
            this.lblSubjectsCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSubjectsCaption.Location = new System.Drawing.Point(12, 6);
            this.lblSubjectsCaption.Name = "lblSubjectsCaption";
            this.lblSubjectsCaption.Size = new System.Drawing.Size(321, 23);
            this.lblSubjectsCaption.TabIndex = 0;
            this.lblSubjectsCaption.Text = "Subjects you will teach (pick at least one)";
            // 
            // lblStudentNote
            // 
            this.lblStudentNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStudentNote.Location = new System.Drawing.Point(50, 446);
            this.lblStudentNote.Name = "lblStudentNote";
            this.lblStudentNote.Size = new System.Drawing.Size(540, 60);
            this.lblStudentNote.TabIndex = 15;
            this.lblStudentNote.Text = "You can enroll in subjects and choose your teacher after you sign in";
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.chkShowPassword.Location = new System.Drawing.Point(50, 410);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(156, 27);
            this.chkShowPassword.TabIndex = 14;
            this.chkShowPassword.Text = "Show passwords";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(330, 358);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(260, 44);
            this.txtConfirm.TabIndex = 13;
            this.txtConfirm.Text = "modernTextBox1";
            this.txtConfirm.UseSystemPasswordChar = true;
            // 
            // lblConfirmCaption
            // 
            this.lblConfirmCaption.AutoSize = true;
            this.lblConfirmCaption.Location = new System.Drawing.Point(330, 336);
            this.lblConfirmCaption.Name = "lblConfirmCaption";
            this.lblConfirmCaption.Size = new System.Drawing.Size(147, 23);
            this.lblConfirmCaption.TabIndex = 12;
            this.lblConfirmCaption.Text = "Confirm password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(50, 358);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(260, 44);
            this.txtPassword.TabIndex = 11;
            this.txtPassword.Text = "modernTextBox1";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassCaption
            // 
            this.lblPassCaption.AutoSize = true;
            this.lblPassCaption.Location = new System.Drawing.Point(50, 336);
            this.lblPassCaption.Name = "lblPassCaption";
            this.lblPassCaption.Size = new System.Drawing.Size(80, 23);
            this.lblPassCaption.TabIndex = 10;
            this.lblPassCaption.Text = "Password";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(50, 280);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(540, 44);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.Text = "Enter your Email";
            // 
            // lblEmailCaption
            // 
            this.lblEmailCaption.AutoSize = true;
            this.lblEmailCaption.Location = new System.Drawing.Point(50, 258);
            this.lblEmailCaption.Name = "lblEmailCaption";
            this.lblEmailCaption.Size = new System.Drawing.Size(51, 23);
            this.lblEmailCaption.TabIndex = 8;
            this.lblEmailCaption.Text = "Email";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(330, 202);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(260, 44);
            this.txtUsername.TabIndex = 7;
            this.txtUsername.Text = "Enter username";
            // 
            // lblUserCaption
            // 
            this.lblUserCaption.AutoSize = true;
            this.lblUserCaption.Location = new System.Drawing.Point(330, 180);
            this.lblUserCaption.Name = "lblUserCaption";
            this.lblUserCaption.Size = new System.Drawing.Size(87, 23);
            this.lblUserCaption.TabIndex = 6;
            this.lblUserCaption.Text = "Username";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(50, 202);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(260, 44);
            this.txtFullName.TabIndex = 5;
            this.txtFullName.Text = "Enter your full name ";
            // 
            // lblNameCaption
            // 
            this.lblNameCaption.AutoSize = true;
            this.lblNameCaption.Location = new System.Drawing.Point(50, 180);
            this.lblNameCaption.Name = "lblNameCaption";
            this.lblNameCaption.Size = new System.Drawing.Size(84, 23);
            this.lblNameCaption.TabIndex = 4;
            this.lblNameCaption.Text = "Full name";
            // 
            // chipRole
            // 
            this.chipRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chipRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chipRole.Location = new System.Drawing.Point(50, 126);
            this.chipRole.Name = "chipRole";
            this.chipRole.Size = new System.Drawing.Size(260, 34);
            this.chipRole.TabIndex = 3;
            this.chipRole.Text = "chipSelector1";
            // 
            // lblRoleCaption
            // 
            this.lblRoleCaption.AutoSize = true;
            this.lblRoleCaption.Location = new System.Drawing.Point(50, 104);
            this.lblRoleCaption.Name = "lblRoleCaption";
            this.lblRoleCaption.Size = new System.Drawing.Size(58, 23);
            this.lblRoleCaption.TabIndex = 2;
            this.lblRoleCaption.Text = "I am a";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSub.Location = new System.Drawing.Point(50, 68);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(308, 23);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Choose your role and fill in your details";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(50, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(371, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create your account";
            // 
            // chipSubjects
            // 
            this.chipSubjects.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chipSubjects.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chipSubjects.Location = new System.Drawing.Point(12, 30);
            this.chipSubjects.Name = "chipSubjects";
            this.chipSubjects.ShowAddChip = true;
            this.chipSubjects.Size = new System.Drawing.Size(516, 74);
            this.chipSubjects.TabIndex = 1;
            this.chipSubjects.Text = "multiChipSelector1";
            // 
            // pnlNewSubject
            // 
            this.pnlNewSubject.Controls.Add(this.btnSubjectCancel);
            this.pnlNewSubject.Controls.Add(this.btnSubjectAdd);
            this.pnlNewSubject.Controls.Add(this.txtNewSubject);
            this.pnlNewSubject.Location = new System.Drawing.Point(12, 30);
            this.pnlNewSubject.Name = "pnlNewSubject";
            this.pnlNewSubject.Size = new System.Drawing.Size(516, 44);
            this.pnlNewSubject.TabIndex = 2;
            // 
            // txtNewSubject
            // 
            this.txtNewSubject.Location = new System.Drawing.Point(0, 0);
            this.txtNewSubject.Name = "txtNewSubject";
            this.txtNewSubject.Size = new System.Drawing.Size(330, 44);
            this.txtNewSubject.TabIndex = 0;
            // 
            // btnSubjectAdd
            // 
            this.btnSubjectAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubjectAdd.FlatAppearance.BorderSize = 0;
            this.btnSubjectAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjectAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubjectAdd.Location = new System.Drawing.Point(342, 1);
            this.btnSubjectAdd.Name = "btnSubjectAdd";
            this.btnSubjectAdd.Size = new System.Drawing.Size(80, 42);
            this.btnSubjectAdd.TabIndex = 1;
            this.btnSubjectAdd.Text = "Add";
            this.btnSubjectAdd.UseVisualStyleBackColor = true;
            // 
            // btnSubjectCancel
            // 
            this.btnSubjectCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubjectCancel.FlatAppearance.BorderSize = 0;
            this.btnSubjectCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjectCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubjectCancel.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnSubjectCancel.Location = new System.Drawing.Point(430, 1);
            this.btnSubjectCancel.Name = "btnSubjectCancel";
            this.btnSubjectCancel.Size = new System.Drawing.Size(84, 42);
            this.btnSubjectCancel.TabIndex = 2;
            this.btnSubjectCancel.Text = "Cancel";
            this.btnSubjectCancel.UseVisualStyleBackColor = true;
            // 
            // SignUpForm
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(962, 613);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlBrand);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EduQuiz - Create account";
            this.pnlBrand.ResumeLayout(false);
            this.pnlBrand.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlSubjects.ResumeLayout(false);
            this.pnlSubjects.PerformLayout();
            this.pnlNewSubject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBrand;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Label lblBrandTitle;
        private System.Windows.Forms.Label lblBrandLogo;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblRoleCaption;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblTitle;
        private ChipSelector chipRole;
        private ModernTextBox txtEmail;
        private System.Windows.Forms.Label lblEmailCaption;
        private ModernTextBox txtUsername;
        private System.Windows.Forms.Label lblUserCaption;
        private ModernTextBox txtFullName;
        private System.Windows.Forms.Label lblNameCaption;
        private System.Windows.Forms.Label lblConfirmCaption;
        private ModernTextBox txtPassword;
        private System.Windows.Forms.Label lblPassCaption;
        private RoundedPanel pnlSubjects;
        private System.Windows.Forms.Label lblSubjectsCaption;
        private System.Windows.Forms.Label lblStudentNote;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private ModernTextBox txtConfirm;
        private ModernButton btnBack;
        private ModernButton btnCreate;
        private System.Windows.Forms.Label lblError;
        private MultiChipSelector chipSubjects;
        private System.Windows.Forms.Panel pnlNewSubject;
        private ModernButton btnSubjectCancel;
        private ModernButton btnSubjectAdd;
        private ModernTextBox txtNewSubject;
    }
}