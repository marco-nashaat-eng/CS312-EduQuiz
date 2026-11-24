namespace QuizSystem
{
    partial class ResultForm
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
            this.btnClose = new QuizSystem.ModernButton();
            this.lblPageSub = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterHint = new System.Windows.Forms.Label();
            this.pnlFooterLine = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlActions = new QuizSystem.RoundedPanel();
            this.lblExportNote = new System.Windows.Forms.Label();
            this.btnClearResults = new QuizSystem.ModernButton();
            this.btnExport = new QuizSystem.ModernButton();
            this.lblActionsTitle = new System.Windows.Forms.Label();
            this.pnlPass = new QuizSystem.RoundedPanel();
            this.lblPassTitle = new System.Windows.Forms.Label();
            this.pnlResults = new QuizSystem.RoundedPanel();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.pnlSearchBox = new QuizSystem.RoundedPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chipFilter = new QuizSystem.ChipSelector();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.flpStats = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlPass.SuspendLayout();
            this.pnlResults.SuspendLayout();
            this.pnlSearchBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.pnlHeaderLine);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblPageSub);
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
            this.pnlHeaderLine.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnClose.Location = new System.Drawing.Point(936, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 42);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblPageSub
            // 
            this.lblPageSub.AutoSize = true;
            this.lblPageSub.BackColor = System.Drawing.Color.Transparent;
            this.lblPageSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblPageSub.Location = new System.Drawing.Point(28, 38);
            this.lblPageSub.Name = "lblPageSub";
            this.lblPageSub.Size = new System.Drawing.Size(324, 23);
            this.lblPageSub.TabIndex = 1;
            this.lblPageSub.Text = "Review student scores and export reports";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(28, 8);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(283, 37);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Results and statistics";
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
            this.lblFooterHint.Size = new System.Drawing.Size(286, 20);
            this.lblFooterHint.TabIndex = 1;
            this.lblFooterHint.Text = "Esc Close     Ctrl+F Search     Ctrl+E Export";
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
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlActions);
            this.pnlContent.Controls.Add(this.pnlPass);
            this.pnlContent.Controls.Add(this.pnlResults);
            this.pnlContent.Controls.Add(this.flpStats);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 64);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1042, 531);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlActions.Controls.Add(this.lblExportNote);
            this.pnlActions.Controls.Add(this.btnClearResults);
            this.pnlActions.Controls.Add(this.btnExport);
            this.pnlActions.Controls.Add(this.lblActionsTitle);
            this.pnlActions.FillColor = System.Drawing.Color.White;
            this.pnlActions.Location = new System.Drawing.Point(738, 352);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Radius = 12;
            this.pnlActions.Size = new System.Drawing.Size(298, 206);
            this.pnlActions.TabIndex = 3;
            // 
            // lblExportNote
            // 
            this.lblExportNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblExportNote.Location = new System.Drawing.Point(20, 161);
            this.lblExportNote.Name = "lblExportNote";
            this.lblExportNote.Size = new System.Drawing.Size(258, 20);
            this.lblExportNote.TabIndex = 3;
            this.lblExportNote.Text = "Export uses the current filter";
            // 
            // btnClearResults
            // 
            this.btnClearResults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearResults.FlatAppearance.BorderSize = 0;
            this.btnClearResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearResults.Kind = QuizSystem.ButtonKind.Danger;
            this.btnClearResults.Location = new System.Drawing.Point(20, 112);
            this.btnClearResults.Name = "btnClearResults";
            this.btnClearResults.Size = new System.Drawing.Size(258, 46);
            this.btnClearResults.TabIndex = 1;
            this.btnClearResults.Text = "Clear all results";
            this.btnClearResults.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.Location = new System.Drawing.Point(20, 56);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(258, 46);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export to file";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // lblActionsTitle
            // 
            this.lblActionsTitle.AutoSize = true;
            this.lblActionsTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActionsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblActionsTitle.Location = new System.Drawing.Point(20, 14);
            this.lblActionsTitle.Name = "lblActionsTitle";
            this.lblActionsTitle.Size = new System.Drawing.Size(164, 30);
            this.lblActionsTitle.TabIndex = 0;
            this.lblActionsTitle.Text = "Report actions";
            // 
            // pnlPass
            // 
            this.pnlPass.BackColor = System.Drawing.Color.White;
            this.pnlPass.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlPass.Controls.Add(this.lblPassTitle);
            this.pnlPass.FillColor = System.Drawing.Color.White;
            this.pnlPass.Location = new System.Drawing.Point(738, 152);
            this.pnlPass.Name = "pnlPass";
            this.pnlPass.Radius = 12;
            this.pnlPass.Size = new System.Drawing.Size(298, 180);
            this.pnlPass.TabIndex = 2;
            // 
            // lblPassTitle
            // 
            this.lblPassTitle.AutoSize = true;
            this.lblPassTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblPassTitle.Location = new System.Drawing.Point(20, 14);
            this.lblPassTitle.Name = "lblPassTitle";
            this.lblPassTitle.Size = new System.Drawing.Size(106, 30);
            this.lblPassTitle.TabIndex = 0;
            this.lblPassTitle.Text = "Pass rate";
            // 
            // pnlResults
            // 
            this.pnlResults.BackColor = System.Drawing.Color.White;
            this.pnlResults.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlResults.Controls.Add(this.lblEmpty);
            this.pnlResults.Controls.Add(this.lstResults);
            this.pnlResults.Controls.Add(this.pnlSearchBox);
            this.pnlResults.Controls.Add(this.chipFilter);
            this.pnlResults.Controls.Add(this.lblCount);
            this.pnlResults.Controls.Add(this.lblListTitle);
            this.pnlResults.FillColor = System.Drawing.Color.White;
            this.pnlResults.Location = new System.Drawing.Point(24, 152);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Radius = 12;
            this.pnlResults.Size = new System.Drawing.Size(690, 406);
            this.pnlResults.TabIndex = 1;
            // 
            // lblEmpty
            // 
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblEmpty.Location = new System.Drawing.Point(20, 200);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(650, 70);
            this.lblEmpty.TabIndex = 5;
            this.lblEmpty.Text = "No results";
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstResults
            // 
            this.lstResults.BackColor = System.Drawing.Color.White;
            this.lstResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstResults.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstResults.FormattingEnabled = true;
            this.lstResults.IntegralHeight = false;
            this.lstResults.ItemHeight = 52;
            this.lstResults.Location = new System.Drawing.Point(20, 124);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(650, 264);
            this.lstResults.TabIndex = 4;
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlSearchBox.Controls.Add(this.txtSearch);
            this.pnlSearchBox.FillColor = System.Drawing.Color.White;
            this.pnlSearchBox.Location = new System.Drawing.Point(304, 73);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Radius = 8;
            this.pnlSearchBox.Size = new System.Drawing.Size(366, 40);
            this.pnlSearchBox.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtSearch.Location = new System.Drawing.Point(14, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(338, 23);
            this.txtSearch.TabIndex = 0;
            // 
            // chipFilter
            // 
            this.chipFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chipFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chipFilter.Location = new System.Drawing.Point(20, 76);
            this.chipFilter.Name = "chipFilter";
            this.chipFilter.Size = new System.Drawing.Size(260, 34);
            this.chipFilter.TabIndex = 2;
            this.chipFilter.Text = "chipSelector1";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCount.Location = new System.Drawing.Point(20, 44);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(650, 20);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Showing 0 of 0 attempts";
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblListTitle.Location = new System.Drawing.Point(20, 14);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(161, 30);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Quiz attempts";
            // 
            // flpStats
            // 
            this.flpStats.Location = new System.Drawing.Point(24, 20);
            this.flpStats.Name = "flpStats";
            this.flpStats.Size = new System.Drawing.Size(1012, 112);
            this.flpStats.TabIndex = 0;
            this.flpStats.WrapContents = false;
            // 
            // ResultForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1042, 625);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EduQuiz - Results";
            this.Load += new System.EventHandler(this.ResultForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResultForm_KeyDown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.pnlPass.ResumeLayout(false);
            this.pnlPass.PerformLayout();
            this.pnlResults.ResumeLayout(false);
            this.pnlResults.PerformLayout();
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private ModernButton btnClose;
        private System.Windows.Forms.Label lblPageSub;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlFooterLine;
        private System.Windows.Forms.Label lblFooterHint;
        private RoundedPanel pnlResults;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.FlowLayoutPanel flpStats;
        private System.Windows.Forms.ListBox lstResults;
        private RoundedPanel pnlSearchBox;
        private System.Windows.Forms.TextBox txtSearch;
        private ChipSelector chipFilter;
        private System.Windows.Forms.Label lblEmpty;
        private RoundedPanel pnlPass;
        private System.Windows.Forms.Label lblPassTitle;
        private RoundedPanel pnlActions;
        private System.Windows.Forms.Label lblActionsTitle;
        private System.Windows.Forms.Label lblExportNote;
        private ModernButton btnClearResults;
        private ModernButton btnExport;
    }
}