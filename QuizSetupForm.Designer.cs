namespace QuizSystem
{
    partial class QuizSetupForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblFormSub = new System.Windows.Forms.Label();
            this.pnlHeaderLine = new System.Windows.Forms.Panel();
            this.pnlFooterLine = new System.Windows.Forms.Panel();
            this.lblFooterHint = new System.Windows.Forms.Label();
            this.btnCancel = new QuizSystem.ModernButton();
            this.btnSave = new QuizSystem.ModernButton();
            this.pnlCard = new QuizSystem.RoundedPanel();
            this.lblSubjectCaption = new System.Windows.Forms.Label();
            this.chipSubject = new QuizSystem.MultiChipSelector();
            this.lblTitleCaption = new System.Windows.Forms.Label();
            this.txtTitle = new QuizSystem.ModernTextBox();
            this.lblCountCaption = new System.Windows.Forms.Label();
            this.txtCount = new QuizSystem.ModernTextBox();
            this.lblDurationCaption = new System.Windows.Forms.Label();
            this.txtDuration = new QuizSystem.ModernTextBox();
            this.lblPassCaption = new System.Windows.Forms.Label();
            this.txtPass = new QuizSystem.ModernTextBox();
            this.chkShuffle = new System.Windows.Forms.CheckBox();
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.pnlHeaderLine);
            this.pnlHeader.Controls.Add(this.lblFormSub);
            this.pnlHeader.Controls.Add(this.lblFormTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(622, 84);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnSave);
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.lblFooterHint);
            this.pnlFooter.Controls.Add(this.pnlFooterLine);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 503);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(622, 70);
            this.pnlFooter.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlCard);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 84);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(622, 419);
            this.pnlContent.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(28, 14);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(183, 37);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Quiz settings";
            // 
            // lblFormSub
            // 
            this.lblFormSub.AutoSize = true;
            this.lblFormSub.BackColor = System.Drawing.Color.Transparent;
            this.lblFormSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblFormSub.Location = new System.Drawing.Point(28, 48);
            this.lblFormSub.Name = "lblFormSub";
            this.lblFormSub.Size = new System.Drawing.Size(440, 23);
            this.lblFormSub.TabIndex = 1;
            this.lblFormSub.Text = "Choose how the quiz works before you add its questions";
            // 
            // pnlHeaderLine
            // 
            this.pnlHeaderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderLine.Location = new System.Drawing.Point(0, 81);
            this.pnlHeaderLine.Name = "pnlHeaderLine";
            this.pnlHeaderLine.Size = new System.Drawing.Size(622, 3);
            this.pnlHeaderLine.TabIndex = 2;
            // 
            // pnlFooterLine
            // 
            this.pnlFooterLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlFooterLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterLine.Location = new System.Drawing.Point(0, 0);
            this.pnlFooterLine.Name = "pnlFooterLine";
            this.pnlFooterLine.Size = new System.Drawing.Size(622, 1);
            this.pnlFooterLine.TabIndex = 0;
            // 
            // lblFooterHint
            // 
            this.lblFooterHint.AutoSize = true;
            this.lblFooterHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFooterHint.Location = new System.Drawing.Point(28, 26);
            this.lblFooterHint.Name = "lblFooterHint";
            this.lblFooterHint.Size = new System.Drawing.Size(167, 20);
            this.lblFooterHint.TabIndex = 1;
            this.lblFooterHint.Text = "Esc Cancel     Enter Save";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnCancel.Location = new System.Drawing.Point(260, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 42);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(392, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(220, 42);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save settings";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // pnlCard
            // 
            this.pnlCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.lblInfo);
            this.pnlCard.Controls.Add(this.chkOpen);
            this.pnlCard.Controls.Add(this.chkShuffle);
            this.pnlCard.Controls.Add(this.txtPass);
            this.pnlCard.Controls.Add(this.lblPassCaption);
            this.pnlCard.Controls.Add(this.txtDuration);
            this.pnlCard.Controls.Add(this.lblDurationCaption);
            this.pnlCard.Controls.Add(this.txtCount);
            this.pnlCard.Controls.Add(this.lblCountCaption);
            this.pnlCard.Controls.Add(this.txtTitle);
            this.pnlCard.Controls.Add(this.lblTitleCaption);
            this.pnlCard.Controls.Add(this.chipSubject);
            this.pnlCard.Controls.Add(this.lblSubjectCaption);
            this.pnlCard.FillColor = System.Drawing.Color.White;
            this.pnlCard.Location = new System.Drawing.Point(28, 20);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Radius = 12;
            this.pnlCard.Size = new System.Drawing.Size(584, 426);
            this.pnlCard.TabIndex = 0;
            // 
            // lblSubjectCaption
            // 
            this.lblSubjectCaption.AutoSize = true;
            this.lblSubjectCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSubjectCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblSubjectCaption.Location = new System.Drawing.Point(24, 16);
            this.lblSubjectCaption.Name = "lblSubjectCaption";
            this.lblSubjectCaption.Size = new System.Drawing.Size(70, 23);
            this.lblSubjectCaption.TabIndex = 0;
            this.lblSubjectCaption.Text = "Subject";
            // 
            // chipSubject
            // 
            this.chipSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chipSubject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chipSubject.Location = new System.Drawing.Point(24, 40);
            this.chipSubject.Name = "chipSubject";
            this.chipSubject.SingleSelect = true;
            this.chipSubject.Size = new System.Drawing.Size(536, 74);
            this.chipSubject.TabIndex = 1;
            this.chipSubject.Text = "multiChipSelector1";
            // 
            // lblTitleCaption
            // 
            this.lblTitleCaption.AutoSize = true;
            this.lblTitleCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblTitleCaption.Location = new System.Drawing.Point(24, 124);
            this.lblTitleCaption.Name = "lblTitleCaption";
            this.lblTitleCaption.Size = new System.Drawing.Size(84, 23);
            this.lblTitleCaption.TabIndex = 2;
            this.lblTitleCaption.Text = "Quiz title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(24, 146);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(536, 44);
            this.txtTitle.TabIndex = 3;
            this.txtTitle.Text = "title ?";
            // 
            // lblCountCaption
            // 
            this.lblCountCaption.AutoSize = true;
            this.lblCountCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCountCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblCountCaption.Location = new System.Drawing.Point(24, 202);
            this.lblCountCaption.Name = "lblCountCaption";
            this.lblCountCaption.Size = new System.Drawing.Size(179, 23);
            this.lblCountCaption.TabIndex = 4;
            this.lblCountCaption.Text = "Number of questions";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(24, 224);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(168, 44);
            this.txtCount.TabIndex = 5;
            this.txtCount.Text = "choose a number";
            // 
            // lblDurationCaption
            // 
            this.lblDurationCaption.AutoSize = true;
            this.lblDurationCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblDurationCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurationCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblDurationCaption.Location = new System.Drawing.Point(208, 202);
            this.lblDurationCaption.Name = "lblDurationCaption";
            this.lblDurationCaption.Size = new System.Drawing.Size(162, 23);
            this.lblDurationCaption.TabIndex = 6;
            this.lblDurationCaption.Text = "Duration (minutes)";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(208, 224);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(168, 44);
            this.txtDuration.TabIndex = 7;
            this.txtDuration.Text = "Time ?";
            // 
            // lblPassCaption
            // 
            this.lblPassCaption.AutoSize = true;
            this.lblPassCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblPassCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblPassCaption.Location = new System.Drawing.Point(392, 202);
            this.lblPassCaption.Name = "lblPassCaption";
            this.lblPassCaption.Size = new System.Drawing.Size(122, 23);
            this.lblPassCaption.TabIndex = 8;
            this.lblPassCaption.Text = "Pass mark (%)";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(392, 224);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(168, 44);
            this.txtPass.TabIndex = 9;
            this.txtPass.Text = "percentage ?";
            // 
            // chkShuffle
            // 
            this.chkShuffle.AutoSize = true;
            this.chkShuffle.BackColor = System.Drawing.Color.Transparent;
            this.chkShuffle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShuffle.Location = new System.Drawing.Point(24, 284);
            this.chkShuffle.Name = "chkShuffle";
            this.chkShuffle.Size = new System.Drawing.Size(258, 27);
            this.chkShuffle.TabIndex = 10;
            this.chkShuffle.Text = "Shuffle the order of questions";
            this.chkShuffle.UseVisualStyleBackColor = false;
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.BackColor = System.Drawing.Color.Transparent;
            this.chkOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkOpen.Location = new System.Drawing.Point(24, 314);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(420, 27);
            this.chkOpen.TabIndex = 11;
            this.chkOpen.Text = "Open for students (they can see and start the quiz)";
            this.chkOpen.UseVisualStyleBackColor = false;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblInfo.Location = new System.Drawing.Point(24, 350);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(536, 40);
            this.lblInfo.TabIndex = 12;
            this.lblInfo.Text = "Info";
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblError.Location = new System.Drawing.Point(24, 396);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(536, 22);
            this.lblError.TabIndex = 13;
            this.lblError.Text = "Error message";
            // 
            // QuizSetupForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(622, 573);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuizSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EduQuiz - Quiz settings";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblFormSub;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private ModernButton btnCancel;
        private System.Windows.Forms.Label lblFooterHint;
        private System.Windows.Forms.Panel pnlFooterLine;
        private ModernButton btnSave;
        private RoundedPanel pnlCard;
        private ModernTextBox txtCount;
        private System.Windows.Forms.Label lblCountCaption;
        private ModernTextBox txtTitle;
        private System.Windows.Forms.Label lblTitleCaption;
        private MultiChipSelector chipSubject;
        private System.Windows.Forms.Label lblSubjectCaption;
        private ModernTextBox txtPass;
        private System.Windows.Forms.Label lblPassCaption;
        private ModernTextBox txtDuration;
        private System.Windows.Forms.Label lblDurationCaption;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.CheckBox chkOpen;
        private System.Windows.Forms.CheckBox chkShuffle;
    }
}