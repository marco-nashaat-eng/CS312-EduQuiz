namespace QuizSystem
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnExit = new QuizSystem.SidebarButton();
            this.btnLogout = new QuizSystem.SidebarButton();
            this.btnNavAbout = new QuizSystem.SidebarButton();
            this.btnNavResults = new QuizSystem.SidebarButton();
            this.btnNavDashboard = new QuizSystem.SidebarButton();
            this.lblMenuCaption = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.lblPageSub = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlFooterLine = new System.Windows.Forms.Panel();
            this.lblFooterRight = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlActions = new QuizSystem.RoundedPanel();
            this.btnClearLog = new QuizSystem.ModernButton();
            this.btnQuickResults = new QuizSystem.ModernButton();
            this.lblActionsTitle = new System.Windows.Forms.Label();
            this.pnlLog = new QuizSystem.RoundedPanel();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.flpCards = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBanner = new QuizSystem.RoundedPanel();
            this.lblBannerSub = new System.Windows.Forms.Label();
            this.lblBannerTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.pnlBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSidebar.Controls.Add(this.btnExit);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnNavAbout);
            this.pnlSidebar.Controls.Add(this.btnNavResults);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.lblMenuCaption);
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(230, 613);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExit.Location = new System.Drawing.Point(18, 566);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(194, 44);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.Location = new System.Drawing.Point(18, 520);
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
            this.btnNavAbout.Location = new System.Drawing.Point(18, 208);
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
            this.btnNavResults.Location = new System.Drawing.Point(18, 160);
            this.btnNavResults.Name = "btnNavResults";
            this.btnNavResults.Size = new System.Drawing.Size(194, 44);
            this.btnNavResults.TabIndex = 4;
            this.btnNavResults.Text = "Results";
            this.btnNavResults.UseVisualStyleBackColor = true;
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
            this.pnlHeader.Controls.Add(this.panel2);
            this.pnlHeader.Controls.Add(this.lblClock);
            this.pnlHeader.Controls.Add(this.lblUserName);
            this.pnlHeader.Controls.Add(this.pnlAvatar);
            this.pnlHeader.Controls.Add(this.lblPageSub);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(230, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(872, 72);
            this.pnlHeader.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(872, 1);
            this.panel2.TabIndex = 5;
            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblClock.Location = new System.Drawing.Point(546, 25);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(100, 22);
            this.lblClock.TabIndex = 4;
            this.lblClock.Text = "00:00:00";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblUserName.Location = new System.Drawing.Point(662, 36);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(150, 18);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "Admin";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lblPageSub.Size = new System.Drawing.Size(232, 23);
            this.lblPageSub.TabIndex = 1;
            this.lblPageSub.Text = "Overview of your quiz system";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblPageTitle.Location = new System.Drawing.Point(28, 12);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(159, 38);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Dashboard";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.pnlFooterLine);
            this.pnlFooter.Controls.Add(this.lblFooterRight);
            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(230, 570);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(872, 43);
            this.pnlFooter.TabIndex = 2;
            // 
            // pnlFooterLine
            // 
            this.pnlFooterLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlFooterLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterLine.Location = new System.Drawing.Point(0, 0);
            this.pnlFooterLine.Name = "pnlFooterLine";
            this.pnlFooterLine.Size = new System.Drawing.Size(872, 1);
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
            this.lblFooterRight.Text = "Ctrl+R Results   Ctrl+L Log out";
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
            this.pnlContent.Controls.Add(this.pnlActions);
            this.pnlContent.Controls.Add(this.pnlLog);
            this.pnlContent.Controls.Add(this.flpCards);
            this.pnlContent.Controls.Add(this.pnlBanner);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(230, 72);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(872, 498);
            this.pnlContent.TabIndex = 3;
            // 
            // pnlActions
            // 
            this.pnlActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlActions.Controls.Add(this.btnClearLog);
            this.pnlActions.Controls.Add(this.btnQuickResults);
            this.pnlActions.Controls.Add(this.lblActionsTitle);
            this.pnlActions.FillColor = System.Drawing.Color.White;
            this.pnlActions.Location = new System.Drawing.Point(572, 264);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Radius = 12;
            this.pnlActions.Size = new System.Drawing.Size(290, 262);
            this.pnlActions.TabIndex = 3;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearLog.FlatAppearance.BorderSize = 0;
            this.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLog.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearLog.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnClearLog.Location = new System.Drawing.Point(20, 116);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(250, 46);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "Clear activity log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // btnQuickResults
            // 
            this.btnQuickResults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuickResults.FlatAppearance.BorderSize = 0;
            this.btnQuickResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuickResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickResults.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnQuickResults.Location = new System.Drawing.Point(20, 60);
            this.btnQuickResults.Name = "btnQuickResults";
            this.btnQuickResults.Size = new System.Drawing.Size(250, 46);
            this.btnQuickResults.TabIndex = 2;
            this.btnQuickResults.Text = "View results";
            this.btnQuickResults.UseVisualStyleBackColor = true;
            // 
            // lblActionsTitle
            // 
            this.lblActionsTitle.AutoSize = true;
            this.lblActionsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblActionsTitle.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblActionsTitle.Location = new System.Drawing.Point(20, 16);
            this.lblActionsTitle.Name = "lblActionsTitle";
            this.lblActionsTitle.Size = new System.Drawing.Size(152, 30);
            this.lblActionsTitle.TabIndex = 0;
            this.lblActionsTitle.Text = "Quick actions";
            // 
            // pnlLog
            // 
            this.pnlLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLog.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlLog.Controls.Add(this.txtOutput);
            this.pnlLog.Controls.Add(this.lblLogTitle);
            this.pnlLog.FillColor = System.Drawing.Color.White;
            this.pnlLog.Location = new System.Drawing.Point(28, 264);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Radius = 12;
            this.pnlLog.Size = new System.Drawing.Size(520, 262);
            this.pnlLog.TabIndex = 2;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.Color.White;
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutput.Location = new System.Drawing.Point(20, 52);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(480, 190);
            this.txtOutput.TabIndex = 1;
            // 
            // lblLogTitle
            // 
            this.lblLogTitle.AutoSize = true;
            this.lblLogTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLogTitle.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblLogTitle.Location = new System.Drawing.Point(20, 16);
            this.lblLogTitle.Name = "lblLogTitle";
            this.lblLogTitle.Size = new System.Drawing.Size(93, 30);
            this.lblLogTitle.TabIndex = 0;
            this.lblLogTitle.Text = "Activity";
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
            this.pnlBanner.Controls.Add(this.lblBannerSub);
            this.pnlBanner.Controls.Add(this.lblBannerTitle);
            this.pnlBanner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlBanner.Location = new System.Drawing.Point(28, 24);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Radius = 14;
            this.pnlBanner.Size = new System.Drawing.Size(834, 84);
            this.pnlBanner.TabIndex = 0;
            // 
            // lblBannerSub
            // 
            this.lblBannerSub.AutoSize = true;
            this.lblBannerSub.BackColor = System.Drawing.Color.Transparent;
            this.lblBannerSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.lblBannerSub.Location = new System.Drawing.Point(24, 48);
            this.lblBannerSub.Name = "lblBannerSub";
            this.lblBannerSub.Size = new System.Drawing.Size(358, 23);
            this.lblBannerSub.TabIndex = 3;
            this.lblBannerSub.Text = "Here is an overview of your quiz system today";
            // 
            // lblBannerTitle
            // 
            this.lblBannerTitle.AutoSize = true;
            this.lblBannerTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBannerTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBannerTitle.ForeColor = System.Drawing.Color.White;
            this.lblBannerTitle.Location = new System.Drawing.Point(24, 16);
            this.lblBannerTitle.Name = "lblBannerTitle";
            this.lblBannerTitle.Size = new System.Drawing.Size(408, 38);
            this.lblBannerTitle.TabIndex = 2;
            this.lblBannerTitle.Text = "Welcome back, Administrator";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1102, 613);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1000, 640);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EduQuiz - Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlContent;
        private SidebarButton btnNavDashboard;
        private System.Windows.Forms.Label lblMenuCaption;
        private System.Windows.Forms.Label lblLogo;
        private SidebarButton btnExit;
        private SidebarButton btnLogout;
        private SidebarButton btnNavAbout;
        private SidebarButton btnNavResults;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Panel pnlAvatar;
        private System.Windows.Forms.Label lblPageSub;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFooterRight;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlFooterLine;
        private RoundedPanel pnlBanner;
        private System.Windows.Forms.FlowLayoutPanel flpCards;
        private System.Windows.Forms.Label lblBannerSub;
        private System.Windows.Forms.Label lblBannerTitle;
        private RoundedPanel pnlLog;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblLogTitle;
        private RoundedPanel pnlActions;
        private System.Windows.Forms.Label lblActionsTitle;
        private ModernButton btnClearLog;
        private ModernButton btnQuickResults;
    }
}