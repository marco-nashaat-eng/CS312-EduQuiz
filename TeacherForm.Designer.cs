namespace QuizSystem
{
    partial class TeacherForm
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnExit = new QuizSystem.SidebarButton();
            this.btnLogout = new QuizSystem.SidebarButton();
            this.btnNavAbout = new QuizSystem.SidebarButton();
            this.btnNavResults = new QuizSystem.SidebarButton();
            this.btnNavQuiz = new QuizSystem.SidebarButton();
            this.btnNavDashboard = new QuizSystem.SidebarButton();
            this.lblMenuCaption = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderLine = new System.Windows.Forms.Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.lblPageSub = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterLine = new System.Windows.Forms.Panel();
            this.lblFooterRight = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlProfile = new QuizSystem.RoundedPanel();
            this.btnViewResults = new QuizSystem.ModernButton();
            this.lblProfileTitle = new System.Windows.Forms.Label();
            this.pnlSubjectsCard = new QuizSystem.RoundedPanel();
            this.lblNoSubjects = new System.Windows.Forms.Label();
            this.lstSubjects = new System.Windows.Forms.ListBox();
            this.lblSubjectsTitle = new System.Windows.Forms.Label();
            this.flpCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBanner = new QuizSystem.RoundedPanel();
            this.btnBannerCreate = new QuizSystem.ModernButton();
            this.lblBannerSub = new System.Windows.Forms.Label();
            this.lblBannerTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.pnlSubjectsCard.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSidebar.Controls.Add(this.btnExit);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnNavAbout);
            this.pnlSidebar.Controls.Add(this.btnNavResults);
            this.pnlSidebar.Controls.Add(this.btnNavQuiz);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.lblMenuCaption);
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(230, 593);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExit.Location = new System.Drawing.Point(18, 598);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(194, 44);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.Location = new System.Drawing.Point(18, 548);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(194, 44);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnNavAbout
            // 
            this.btnNavAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavAbout.FlatAppearance.BorderSize = 0;
            this.btnNavAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavAbout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavAbout.Location = new System.Drawing.Point(18, 256);
            this.btnNavAbout.Name = "btnNavAbout";
            this.btnNavAbout.Size = new System.Drawing.Size(194, 44);
            this.btnNavAbout.TabIndex = 5;
            this.btnNavAbout.Text = "About";
            this.btnNavAbout.UseVisualStyleBackColor = true;
            // 
            // btnNavResults
            // 
            this.btnNavResults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavResults.FlatAppearance.BorderSize = 0;
            this.btnNavResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavResults.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavResults.Location = new System.Drawing.Point(18, 208);
            this.btnNavResults.Name = "btnNavResults";
            this.btnNavResults.Size = new System.Drawing.Size(194, 44);
            this.btnNavResults.TabIndex = 4;
            this.btnNavResults.Text = "Results";
            this.btnNavResults.UseVisualStyleBackColor = true;
            // 
            // btnNavQuiz
            // 
            this.btnNavQuiz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavQuiz.FlatAppearance.BorderSize = 0;
            this.btnNavQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavQuiz.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavQuiz.Location = new System.Drawing.Point(18, 160);
            this.btnNavQuiz.Name = "btnNavQuiz";
            this.btnNavQuiz.Size = new System.Drawing.Size(194, 44);
            this.btnNavQuiz.TabIndex = 3;
            this.btnNavQuiz.Text = "Create quiz";
            this.btnNavQuiz.UseVisualStyleBackColor = true;
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavDashboard.Location = new System.Drawing.Point(18, 112);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(194, 44);
            this.btnNavDashboard.TabIndex = 2;
            this.btnNavDashboard.Text = "Dashboard";
            this.btnNavDashboard.UseVisualStyleBackColor = true;
            // 
            // lblMenuCaption
            // 
            this.lblMenuCaption.AutoSize = true;
            this.lblMenuCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblMenuCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMenuCaption.Location = new System.Drawing.Point(28, 86);
            this.lblMenuCaption.Name = "lblMenuCaption";
            this.lblMenuCaption.Size = new System.Drawing.Size(54, 20);
            this.lblMenuCaption.TabIndex = 1;
            this.lblMenuCaption.Text = "MENU";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(28, 26);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(135, 41);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "EduQuiz";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.pnlHeaderLine);
            this.pnlHeader.Controls.Add(this.lblClock);
            this.pnlHeader.Controls.Add(this.lblUserRole);
            this.pnlHeader.Controls.Add(this.lblUserName);
            this.pnlHeader.Controls.Add(this.pnlAvatar);
            this.pnlHeader.Controls.Add(this.lblPageSub);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(230, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(852, 72);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlHeaderLine
            // 
            this.pnlHeaderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderLine.Location = new System.Drawing.Point(0, 71);
            this.pnlHeaderLine.Name = "pnlHeaderLine";
            this.pnlHeaderLine.Size = new System.Drawing.Size(852, 1);
            this.pnlHeaderLine.TabIndex = 6;
            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblClock.Location = new System.Drawing.Point(546, 25);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(100, 22);
            this.lblClock.TabIndex = 5;
            this.lblClock.Text = "00:00:00";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserRole
            // 
            this.lblUserRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblUserRole.Location = new System.Drawing.Point(662, 36);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(150, 18);
            this.lblUserRole.TabIndex = 4;
            this.lblUserRole.Text = "Teacher";
            this.lblUserRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(662, 14);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(150, 20);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "Teacher";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAvatar.BackColor = System.Drawing.Color.White;
            this.pnlAvatar.Location = new System.Drawing.Point(822, 16);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(40, 40);
            this.pnlAvatar.TabIndex = 2;
            // 
            // lblPageSub
            // 
            this.lblPageSub.AutoSize = true;
            this.lblPageSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPageSub.Location = new System.Drawing.Point(28, 44);
            this.lblPageSub.Name = "lblPageSub";
            this.lblPageSub.Size = new System.Drawing.Size(279, 23);
            this.lblPageSub.TabIndex = 1;
            this.lblPageSub.Text = "Your subjects, quizzes and students";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblPageTitle.Location = new System.Drawing.Point(28, 12);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(260, 37);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Teacher dashboard";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.pnlFooterLine);
            this.pnlFooter.Controls.Add(this.lblFooterRight);
            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(230, 559);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(852, 34);
            this.pnlFooter.TabIndex = 2;
            // 
            // pnlFooterLine
            // 
            this.pnlFooterLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlFooterLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterLine.Location = new System.Drawing.Point(0, 0);
            this.pnlFooterLine.Name = "pnlFooterLine";
            this.pnlFooterLine.Size = new System.Drawing.Size(852, 1);
            this.pnlFooterLine.TabIndex = 2;
            // 
            // lblFooterRight
            // 
            this.lblFooterRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFooterRight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFooterRight.Location = new System.Drawing.Point(442, 8);
            this.lblFooterRight.Name = "lblFooterRight";
            this.lblFooterRight.Size = new System.Drawing.Size(420, 18);
            this.lblFooterRight.TabIndex = 1;
            this.lblFooterRight.Text = "Ctrl+N Create quiz   Ctrl+R Results   Ctrl+L Log out";
            this.lblFooterRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStatus.Location = new System.Drawing.Point(28, 8);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 20);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Ready";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlProfile);
            this.pnlContent.Controls.Add(this.pnlSubjectsCard);
            this.pnlContent.Controls.Add(this.flpCards);
            this.pnlContent.Controls.Add(this.pnlBanner);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(230, 72);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(852, 487);
            this.pnlContent.TabIndex = 3;
            // 
            // pnlProfile
            // 
            this.pnlProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProfile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlProfile.Controls.Add(this.btnViewResults);
            this.pnlProfile.Controls.Add(this.lblProfileTitle);
            this.pnlProfile.FillColor = System.Drawing.Color.White;
            this.pnlProfile.Location = new System.Drawing.Point(572, 264);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Radius = 12;
            this.pnlProfile.Size = new System.Drawing.Size(290, 262);
            this.pnlProfile.TabIndex = 3;
            // 
            // btnViewResults
            // 
            this.btnViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewResults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewResults.FlatAppearance.BorderSize = 0;
            this.btnViewResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewResults.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnViewResults.Location = new System.Drawing.Point(20, 212);
            this.btnViewResults.Name = "btnViewResults";
            this.btnViewResults.Size = new System.Drawing.Size(250, 40);
            this.btnViewResults.TabIndex = 1;
            this.btnViewResults.Text = "View my students\' results";
            this.btnViewResults.UseVisualStyleBackColor = true;
            // 
            // lblProfileTitle
            // 
            this.lblProfileTitle.AutoSize = true;
            this.lblProfileTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblProfileTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblProfileTitle.Location = new System.Drawing.Point(20, 16);
            this.lblProfileTitle.Name = "lblProfileTitle";
            this.lblProfileTitle.Size = new System.Drawing.Size(221, 30);
            this.lblProfileTitle.TabIndex = 0;
            this.lblProfileTitle.Text = "Teacher information";
            // 
            // pnlSubjectsCard
            // 
            this.pnlSubjectsCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSubjectsCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlSubjectsCard.Controls.Add(this.lblNoSubjects);
            this.pnlSubjectsCard.Controls.Add(this.lstSubjects);
            this.pnlSubjectsCard.Controls.Add(this.lblSubjectsTitle);
            this.pnlSubjectsCard.FillColor = System.Drawing.Color.White;
            this.pnlSubjectsCard.Location = new System.Drawing.Point(28, 264);
            this.pnlSubjectsCard.Name = "pnlSubjectsCard";
            this.pnlSubjectsCard.Radius = 12;
            this.pnlSubjectsCard.Size = new System.Drawing.Size(520, 262);
            this.pnlSubjectsCard.TabIndex = 2;
            // 
            // lblNoSubjects
            // 
            this.lblNoSubjects.BackColor = System.Drawing.Color.Transparent;
            this.lblNoSubjects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNoSubjects.Location = new System.Drawing.Point(20, 110);
            this.lblNoSubjects.Name = "lblNoSubjects";
            this.lblNoSubjects.Size = new System.Drawing.Size(480, 60);
            this.lblNoSubjects.TabIndex = 2;
            this.lblNoSubjects.Text = "You have no subjects yet";
            this.lblNoSubjects.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstSubjects
            // 
            this.lstSubjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSubjects.BackColor = System.Drawing.Color.White;
            this.lstSubjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstSubjects.FormattingEnabled = true;
            this.lstSubjects.ItemHeight = 23;
            this.lstSubjects.Location = new System.Drawing.Point(20, 52);
            this.lstSubjects.Name = "lstSubjects";
            this.lstSubjects.Size = new System.Drawing.Size(380, 184);
            this.lstSubjects.TabIndex = 1;
            // 
            // lblSubjectsTitle
            // 
            this.lblSubjectsTitle.AutoSize = true;
            this.lblSubjectsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubjectsTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSubjectsTitle.Location = new System.Drawing.Point(20, 16);
            this.lblSubjectsTitle.Name = "lblSubjectsTitle";
            this.lblSubjectsTitle.Size = new System.Drawing.Size(137, 30);
            this.lblSubjectsTitle.TabIndex = 0;
            this.lblSubjectsTitle.Text = "My subjects";
            // 
            // flpCards
            // 
            this.flpCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCards.Location = new System.Drawing.Point(28, 128);
            this.flpCards.Name = "flpCards";
            this.flpCards.Size = new System.Drawing.Size(834, 112);
            this.flpCards.TabIndex = 1;
            this.flpCards.WrapContents = false;
            // 
            // pnlBanner
            // 
            this.pnlBanner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBanner.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlBanner.Controls.Add(this.btnBannerCreate);
            this.pnlBanner.Controls.Add(this.lblBannerSub);
            this.pnlBanner.Controls.Add(this.lblBannerTitle);
            this.pnlBanner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlBanner.Location = new System.Drawing.Point(28, 24);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Radius = 14;
            this.pnlBanner.Size = new System.Drawing.Size(834, 84);
            this.pnlBanner.TabIndex = 0;
            // 
            // btnBannerCreate
            // 
            this.btnBannerCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBannerCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBannerCreate.FlatAppearance.BorderSize = 0;
            this.btnBannerCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBannerCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBannerCreate.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnBannerCreate.Location = new System.Drawing.Point(768, 17);
            this.btnBannerCreate.Name = "btnBannerCreate";
            this.btnBannerCreate.Size = new System.Drawing.Size(146, 44);
            this.btnBannerCreate.TabIndex = 2;
            this.btnBannerCreate.Text = "Create quiz";
            this.btnBannerCreate.UseVisualStyleBackColor = true;
            // 
            // lblBannerSub
            // 
            this.lblBannerSub.AutoSize = true;
            this.lblBannerSub.BackColor = System.Drawing.Color.Transparent;
            this.lblBannerSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.lblBannerSub.Location = new System.Drawing.Point(24, 48);
            this.lblBannerSub.Name = "lblBannerSub";
            this.lblBannerSub.Size = new System.Drawing.Size(272, 23);
            this.lblBannerSub.TabIndex = 1;
            this.lblBannerSub.Text = "Manage your subjects and quizzes";
            // 
            // lblBannerTitle
            // 
            this.lblBannerTitle.AutoSize = true;
            this.lblBannerTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBannerTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBannerTitle.ForeColor = System.Drawing.Color.White;
            this.lblBannerTitle.Location = new System.Drawing.Point(24, 16);
            this.lblBannerTitle.Name = "lblBannerTitle";
            this.lblBannerTitle.Size = new System.Drawing.Size(203, 37);
            this.lblBannerTitle.TabIndex = 0;
            this.lblBannerTitle.Text = "Welcome back";
            // 
            // TeacherForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1082, 593);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EduQuiz - Teacher dashboard";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlProfile.ResumeLayout(false);
            this.pnlProfile.PerformLayout();
            this.pnlSubjectsCard.ResumeLayout(false);
            this.pnlSubjectsCard.PerformLayout();
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblMenuCaption;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlContent;
        private SidebarButton btnNavDashboard;
        private SidebarButton btnExit;
        private SidebarButton btnLogout;
        private SidebarButton btnNavAbout;
        private SidebarButton btnNavResults;
        private SidebarButton btnNavQuiz;
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.Label lblPageSub;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private System.Windows.Forms.Panel pnlFooterLine;
        private System.Windows.Forms.Label lblFooterRight;
        private System.Windows.Forms.Label lblStatus;
        private RoundedPanel pnlBanner;
        private System.Windows.Forms.FlowLayoutPanel flpCards;
        private ModernButton btnBannerCreate;
        private System.Windows.Forms.Label lblBannerSub;
        private System.Windows.Forms.Label lblBannerTitle;
        private RoundedPanel pnlSubjectsCard;
        private System.Windows.Forms.Label lblNoSubjects;
        private System.Windows.Forms.ListBox lstSubjects;
        private System.Windows.Forms.Label lblSubjectsTitle;
        private RoundedPanel pnlProfile;
        private ModernButton btnViewResults;
        private System.Windows.Forms.Label lblProfileTitle;
    }
}