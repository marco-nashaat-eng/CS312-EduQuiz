namespace QuizSystem
{
    partial class QuizForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderLine = new System.Windows.Forms.Panel();
            this.pnlTimer = new System.Windows.Forms.Panel();
            this.lblTimerCaption = new System.Windows.Forms.Label();
            this.lblStudent = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterHint = new System.Windows.Forms.Label();
            this.pnlFooterLine = new System.Windows.Forms.Panel();
            this.pnlExam = new System.Windows.Forms.Panel();
            this.btnNext = new QuizSystem.ModernButton();
            this.lblSelectHint = new System.Windows.Forms.Label();
            this.pnlAnswers = new System.Windows.Forms.Panel();
            this.pnlQuestion = new QuizSystem.RoundedPanel();
            this.lblQuestionText = new System.Windows.Forms.Label();
            this.lblQuestionTag = new System.Windows.Forms.Label();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.tmrQuestion = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlExam.SuspendLayout();
            this.pnlQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.pnlHeaderLine);
            this.pnlHeader.Controls.Add(this.pnlTimer);
            this.pnlHeader.Controls.Add(this.lblTimerCaption);
            this.pnlHeader.Controls.Add(this.lblStudent);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1042, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlHeaderLine
            // 
            this.pnlHeaderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderLine.Location = new System.Drawing.Point(0, 61);
            this.pnlHeaderLine.Name = "pnlHeaderLine";
            this.pnlHeaderLine.Size = new System.Drawing.Size(1042, 3);
            this.pnlHeaderLine.TabIndex = 4;
            // 
            // pnlTimer
            // 
            this.pnlTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTimer.Location = new System.Drawing.Point(984, 8);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new System.Drawing.Size(48, 48);
            this.pnlTimer.TabIndex = 3;
            // 
            // lblTimerCaption
            // 
            this.lblTimerCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimerCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblTimerCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTimerCaption.Location = new System.Drawing.Point(856, 22);
            this.lblTimerCaption.Name = "lblTimerCaption";
            this.lblTimerCaption.Size = new System.Drawing.Size(120, 20);
            this.lblTimerCaption.TabIndex = 2;
            this.lblTimerCaption.Text = "Time left";
            this.lblTimerCaption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.BackColor = System.Drawing.Color.Transparent;
            this.lblStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblStudent.Location = new System.Drawing.Point(28, 38);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(73, 23);
            this.lblStudent.TabIndex = 1;
            this.lblStudent.Text = "Student:";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(28, 8);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(224, 37);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Quiz in progress";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblFooterHint);
            this.pnlFooter.Controls.Add(this.pnlFooterLine);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 595);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1042, 30);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblFooterHint
            // 
            this.lblFooterHint.AutoSize = true;
            this.lblFooterHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFooterHint.Location = new System.Drawing.Point(28, 7);
            this.lblFooterHint.Name = "lblFooterHint";
            this.lblFooterHint.Size = new System.Drawing.Size(304, 20);
            this.lblFooterHint.TabIndex = 1;
            this.lblFooterHint.Text = "1-4 Choose an answer     Enter Next question";
            // 
            // pnlFooterLine
            // 
            this.pnlFooterLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlFooterLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterLine.Location = new System.Drawing.Point(0, 0);
            this.pnlFooterLine.Name = "pnlFooterLine";
            this.pnlFooterLine.Size = new System.Drawing.Size(1042, 1);
            this.pnlFooterLine.TabIndex = 0;
            // 
            // pnlExam
            // 
            this.pnlExam.Controls.Add(this.btnNext);
            this.pnlExam.Controls.Add(this.lblSelectHint);
            this.pnlExam.Controls.Add(this.pnlAnswers);
            this.pnlExam.Controls.Add(this.pnlQuestion);
            this.pnlExam.Controls.Add(this.pnlProgress);
            this.pnlExam.Controls.Add(this.lblProgress);
            this.pnlExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExam.Location = new System.Drawing.Point(0, 64);
            this.pnlExam.Name = "pnlExam";
            this.pnlExam.Size = new System.Drawing.Size(1042, 531);
            this.pnlExam.TabIndex = 2;
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNext.Location = new System.Drawing.Point(876, 462);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(160, 46);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next question";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // lblSelectHint
            // 
            this.lblSelectHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSelectHint.Location = new System.Drawing.Point(24, 462);
            this.lblSelectHint.Name = "lblSelectHint";
            this.lblSelectHint.Size = new System.Drawing.Size(700, 46);
            this.lblSelectHint.TabIndex = 4;
            this.lblSelectHint.Text = "Choose one answer, or press 1-4";
            this.lblSelectHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAnswers
            // 
            this.pnlAnswers.Location = new System.Drawing.Point(24, 222);
            this.pnlAnswers.Name = "pnlAnswers";
            this.pnlAnswers.Size = new System.Drawing.Size(1012, 216);
            this.pnlAnswers.TabIndex = 3;
            // 
            // pnlQuestion
            // 
            this.pnlQuestion.BackColor = System.Drawing.Color.White;
            this.pnlQuestion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlQuestion.Controls.Add(this.lblQuestionText);
            this.pnlQuestion.Controls.Add(this.lblQuestionTag);
            this.pnlQuestion.FillColor = System.Drawing.Color.White;
            this.pnlQuestion.Location = new System.Drawing.Point(24, 72);
            this.pnlQuestion.Name = "pnlQuestion";
            this.pnlQuestion.Radius = 12;
            this.pnlQuestion.Size = new System.Drawing.Size(1012, 130);
            this.pnlQuestion.TabIndex = 2;
            // 
            // lblQuestionText
            // 
            this.lblQuestionText.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblQuestionText.Location = new System.Drawing.Point(24, 42);
            this.lblQuestionText.Name = "lblQuestionText";
            this.lblQuestionText.Size = new System.Drawing.Size(964, 80);
            this.lblQuestionText.TabIndex = 1;
            this.lblQuestionText.Text = "Question text appears here";
            // 
            // lblQuestionTag
            // 
            this.lblQuestionTag.AutoSize = true;
            this.lblQuestionTag.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblQuestionTag.Location = new System.Drawing.Point(24, 16);
            this.lblQuestionTag.Name = "lblQuestionTag";
            this.lblQuestionTag.Size = new System.Drawing.Size(97, 20);
            this.lblQuestionTag.TabIndex = 0;
            this.lblQuestionTag.Text = "QUESTION 1";
            // 
            // pnlProgress
            // 
            this.pnlProgress.Location = new System.Drawing.Point(24, 48);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(1012, 8);
            this.pnlProgress.TabIndex = 1;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblProgress.Location = new System.Drawing.Point(24, 18);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(148, 25);
            this.lblProgress.TabIndex = 0;
            this.lblProgress.Text = "Question 1 of 1";
            // 
            // tmrQuestion
            // 
            this.tmrQuestion.Interval = 1000;
            // 
            // QuizForm
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1042, 625);
            this.Controls.Add(this.pnlExam);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuizForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EduQuiz - Quiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuizForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.QuizForm_FormClosed);
            this.Load += new System.EventHandler(this.QuizForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuizForm_KeyDown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlExam.ResumeLayout(false);
            this.pnlExam.PerformLayout();
            this.pnlQuestion.ResumeLayout(false);
            this.pnlQuestion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlTimer;
        private System.Windows.Forms.Label lblTimerCaption;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlExam;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private System.Windows.Forms.Label lblFooterHint;
        private System.Windows.Forms.Panel pnlFooterLine;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblSelectHint;
        private System.Windows.Forms.Panel pnlAnswers;
        private RoundedPanel pnlQuestion;
        private System.Windows.Forms.Label lblQuestionText;
        private System.Windows.Forms.Label lblQuestionTag;
        private ModernButton btnNext;
        private System.Windows.Forms.Timer tmrQuestion;
    }
}