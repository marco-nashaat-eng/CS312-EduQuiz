namespace QuizSystem
{
    partial class AboutForm
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
            this.pnlHeaderLine = new System.Windows.Forms.Panel();
            this.lblTagline = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnOK = new QuizSystem.ModernButton();
            this.pnlInfo = new QuizSystem.RoundedPanel();
            this.lblDeveloperValue = new System.Windows.Forms.Label();
            this.lblDeveloperCaption = new System.Windows.Forms.Label();
            this.lblPlatformValue = new System.Windows.Forms.Label();
            this.lblPlatformCaption = new System.Windows.Forms.Label();
            this.lblProjectValue = new System.Windows.Forms.Label();
            this.lblProjectCaption = new System.Windows.Forms.Label();
            this.lblCourseValue = new System.Windows.Forms.Label();
            this.lblCourseCaption = new System.Windows.Forms.Label();
            this.lblVersionValue = new System.Windows.Forms.Label();
            this.lblVersionCaption = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.pnlHeaderLine);
            this.pnlHeader.Controls.Add(this.lblTagline);
            this.pnlHeader.Controls.Add(this.lblAppName);
            this.pnlHeader.Controls.Add(this.pnlLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(542, 110);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlHeaderLine
            // 
            this.pnlHeaderLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlHeaderLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHeaderLine.Location = new System.Drawing.Point(0, 107);
            this.pnlHeaderLine.Name = "pnlHeaderLine";
            this.pnlHeaderLine.Size = new System.Drawing.Size(542, 3);
            this.pnlHeaderLine.TabIndex = 3;
            // 
            // lblTagline
            // 
            this.lblTagline.AutoSize = true;
            this.lblTagline.BackColor = System.Drawing.Color.Transparent;
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblTagline.Location = new System.Drawing.Point(100, 64);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(359, 23);
            this.lblTagline.TabIndex = 2;
            this.lblTagline.Text = "Exams made simple for teachers and students";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(100, 24);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(153, 46);
            this.lblAppName.TabIndex = 1;
            this.lblAppName.Text = "EduQuiz";
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlLogo.Location = new System.Drawing.Point(28, 27);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(56, 56);
            this.pnlLogo.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.btnOK);
            this.pnlContent.Controls.Add(this.pnlInfo);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 110);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(542, 313);
            this.pnlContent.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOK.Location = new System.Drawing.Point(370, 257);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(160, 44);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Close";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BackColor = System.Drawing.Color.White;
            this.pnlInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlInfo.Controls.Add(this.lblDeveloperValue);
            this.pnlInfo.Controls.Add(this.lblDeveloperCaption);
            this.pnlInfo.Controls.Add(this.lblPlatformValue);
            this.pnlInfo.Controls.Add(this.lblPlatformCaption);
            this.pnlInfo.Controls.Add(this.lblProjectValue);
            this.pnlInfo.Controls.Add(this.lblProjectCaption);
            this.pnlInfo.Controls.Add(this.lblCourseValue);
            this.pnlInfo.Controls.Add(this.lblCourseCaption);
            this.pnlInfo.Controls.Add(this.lblVersionValue);
            this.pnlInfo.Controls.Add(this.lblVersionCaption);
            this.pnlInfo.FillColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(24, 20);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Radius = 12;
            this.pnlInfo.Size = new System.Drawing.Size(512, 230);
            this.pnlInfo.TabIndex = 0;
            // 
            // lblDeveloperValue
            // 
            this.lblDeveloperValue.AutoEllipsis = true;
            this.lblDeveloperValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeveloperValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDeveloperValue.Location = new System.Drawing.Point(170, 192);
            this.lblDeveloperValue.Name = "lblDeveloperValue";
            this.lblDeveloperValue.Size = new System.Drawing.Size(318, 24);
            this.lblDeveloperValue.TabIndex = 9;
            this.lblDeveloperValue.Text = "Marco / Roger / Fady / Peter \r\n";
            // 
            // lblDeveloperCaption
            // 
            this.lblDeveloperCaption.AutoSize = true;
            this.lblDeveloperCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDeveloperCaption.Location = new System.Drawing.Point(24, 192);
            this.lblDeveloperCaption.Name = "lblDeveloperCaption";
            this.lblDeveloperCaption.Size = new System.Drawing.Size(114, 23);
            this.lblDeveloperCaption.TabIndex = 8;
            this.lblDeveloperCaption.Text = "Developed by";
            // 
            // lblPlatformValue
            // 
            this.lblPlatformValue.AutoEllipsis = true;
            this.lblPlatformValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatformValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblPlatformValue.Location = new System.Drawing.Point(170, 150);
            this.lblPlatformValue.Name = "lblPlatformValue";
            this.lblPlatformValue.Size = new System.Drawing.Size(318, 24);
            this.lblPlatformValue.TabIndex = 7;
            this.lblPlatformValue.Text = "C# and Windows Forms";
            // 
            // lblPlatformCaption
            // 
            this.lblPlatformCaption.AutoSize = true;
            this.lblPlatformCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPlatformCaption.Location = new System.Drawing.Point(24, 150);
            this.lblPlatformCaption.Name = "lblPlatformCaption";
            this.lblPlatformCaption.Size = new System.Drawing.Size(75, 23);
            this.lblPlatformCaption.TabIndex = 6;
            this.lblPlatformCaption.Text = "Platform";
            // 
            // lblProjectValue
            // 
            this.lblProjectValue.AutoEllipsis = true;
            this.lblProjectValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblProjectValue.Location = new System.Drawing.Point(170, 108);
            this.lblProjectValue.Name = "lblProjectValue";
            this.lblProjectValue.Size = new System.Drawing.Size(318, 24);
            this.lblProjectValue.TabIndex = 5;
            this.lblProjectValue.Text = "Client-Server Quiz System";
            // 
            // lblProjectCaption
            // 
            this.lblProjectCaption.AutoSize = true;
            this.lblProjectCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblProjectCaption.Location = new System.Drawing.Point(24, 108);
            this.lblProjectCaption.Name = "lblProjectCaption";
            this.lblProjectCaption.Size = new System.Drawing.Size(63, 23);
            this.lblProjectCaption.TabIndex = 4;
            this.lblProjectCaption.Text = "Project";
            // 
            // lblCourseValue
            // 
            this.lblCourseValue.AutoEllipsis = true;
            this.lblCourseValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCourseValue.Location = new System.Drawing.Point(170, 66);
            this.lblCourseValue.Name = "lblCourseValue";
            this.lblCourseValue.Size = new System.Drawing.Size(318, 24);
            this.lblCourseValue.TabIndex = 3;
            this.lblCourseValue.Text = "CS312 - Modern Development Tools";
            // 
            // lblCourseCaption
            // 
            this.lblCourseCaption.AutoSize = true;
            this.lblCourseCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCourseCaption.Location = new System.Drawing.Point(24, 66);
            this.lblCourseCaption.Name = "lblCourseCaption";
            this.lblCourseCaption.Size = new System.Drawing.Size(63, 23);
            this.lblCourseCaption.TabIndex = 2;
            this.lblCourseCaption.Text = "Course";
            // 
            // lblVersionValue
            // 
            this.lblVersionValue.AutoEllipsis = true;
            this.lblVersionValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblVersionValue.Location = new System.Drawing.Point(170, 24);
            this.lblVersionValue.Name = "lblVersionValue";
            this.lblVersionValue.Size = new System.Drawing.Size(318, 24);
            this.lblVersionValue.TabIndex = 1;
            this.lblVersionValue.Text = "1.0";
            // 
            // lblVersionCaption
            // 
            this.lblVersionCaption.AutoSize = true;
            this.lblVersionCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblVersionCaption.Location = new System.Drawing.Point(24, 24);
            this.lblVersionCaption.Name = "lblVersionCaption";
            this.lblVersionCaption.Size = new System.Drawing.Size(66, 23);
            this.lblVersionCaption.TabIndex = 0;
            this.lblVersionCaption.Text = "Version";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(542, 423);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About EduQuiz";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private System.Windows.Forms.Label lblTagline;
        private RoundedPanel pnlInfo;
        private System.Windows.Forms.Label lblDeveloperValue;
        private System.Windows.Forms.Label lblDeveloperCaption;
        private System.Windows.Forms.Label lblPlatformValue;
        private System.Windows.Forms.Label lblPlatformCaption;
        private System.Windows.Forms.Label lblProjectValue;
        private System.Windows.Forms.Label lblProjectCaption;
        private System.Windows.Forms.Label lblCourseValue;
        private System.Windows.Forms.Label lblCourseCaption;
        private System.Windows.Forms.Label lblVersionValue;
        private System.Windows.Forms.Label lblVersionCaption;
        private ModernButton btnOK;
    }
}