namespace QuizSystem
{
    partial class QuestionForm
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
            this.lblHeaderUser = new System.Windows.Forms.Label();
            this.pnlHeaderLine = new System.Windows.Forms.Panel();
            this.btnClose = new QuizSystem.ModernButton();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblPageSub = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlEditor = new QuizSystem.RoundedPanel();
            this.pnlNewSubject = new QuizSystem.RoundedPanel();
            this.btnSubjectCancel = new QuizSystem.ModernButton();
            this.btnSubjectAdd = new QuizSystem.ModernButton();
            this.txtNewSubject = new System.Windows.Forms.TextBox();
            this.chipDifficulty = new QuizSystem.ChipSelector();
            this.chipSubject = new QuizSystem.ChipSelector();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClear = new QuizSystem.ModernButton();
            this.btnDelete = new QuizSystem.ModernButton();
            this.btnUpdate = new QuizSystem.ModernButton();
            this.btnAdd = new QuizSystem.ModernButton();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.txtOption4 = new QuizSystem.ModernTextBox();
            this.txtOption3 = new QuizSystem.ModernTextBox();
            this.txtOption2 = new QuizSystem.ModernTextBox();
            this.rdoCorrect4 = new System.Windows.Forms.RadioButton();
            this.rdoCorrect3 = new System.Windows.Forms.RadioButton();
            this.rdoCorrect2 = new System.Windows.Forms.RadioButton();
            this.txtOption1 = new QuizSystem.ModernTextBox();
            this.rdoCorrect1 = new System.Windows.Forms.RadioButton();
            this.lblOptionsCaption = new System.Windows.Forms.Label();
            this.lblSubjectCaption = new System.Windows.Forms.Label();
            this.lblDifficultyCaption = new System.Windows.Forms.Label();
            this.pnlQuestionBox = new QuizSystem.RoundedPanel();
            this.txtQuestionText = new System.Windows.Forms.TextBox();
            this.lblQuestionCaption = new System.Windows.Forms.Label();
            this.lblQuestionID = new System.Windows.Forms.Label();
            this.lblEditorTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooterHint = new System.Windows.Forms.Label();
            this.pnlFooterLine = new System.Windows.Forms.Panel();
            this.pnlList = new QuizSystem.RoundedPanel();
            this.pnlSearchBox = new QuizSystem.RoundedPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lstQuestions = new System.Windows.Forms.ListBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlEditor.SuspendLayout();
            this.pnlNewSubject.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlQuestionBox.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.pnlSearchBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlHeader.Controls.Add(this.lblHeaderUser);
            this.pnlHeader.Controls.Add(this.pnlHeaderLine);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Controls.Add(this.lblPageSub);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1042, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHeaderUser
            // 
            this.lblHeaderUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeaderUser.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblHeaderUser.Location = new System.Drawing.Point(680, 20);
            this.lblHeaderUser.Name = "lblHeaderUser";
            this.lblHeaderUser.Size = new System.Drawing.Size(240, 24);
            this.lblHeaderUser.TabIndex = 4;
            this.lblHeaderUser.Text = "Signed in as";
            this.lblHeaderUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(28, 8);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(253, 37);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Question manager";
            // 
            // lblPageSub
            // 
            this.lblPageSub.AutoSize = true;
            this.lblPageSub.BackColor = System.Drawing.Color.Transparent;
            this.lblPageSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblPageSub.Location = new System.Drawing.Point(28, 38);
            this.lblPageSub.Name = "lblPageSub";
            this.lblPageSub.Size = new System.Drawing.Size(357, 23);
            this.lblPageSub.TabIndex = 1;
            this.lblPageSub.Text = "Create, edit and organize your quiz questions";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlEditor);
            this.pnlContent.Controls.Add(this.pnlFooter);
            this.pnlContent.Controls.Add(this.pnlList);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 64);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1042, 551);
            this.pnlContent.TabIndex = 1;
            // 
            // pnlEditor
            // 
            this.pnlEditor.BackColor = System.Drawing.Color.White;
            this.pnlEditor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlEditor.Controls.Add(this.pnlNewSubject);
            this.pnlEditor.Controls.Add(this.chipDifficulty);
            this.pnlEditor.Controls.Add(this.chipSubject);
            this.pnlEditor.Controls.Add(this.lblMessage);
            this.pnlEditor.Controls.Add(this.btnClear);
            this.pnlEditor.Controls.Add(this.btnDelete);
            this.pnlEditor.Controls.Add(this.btnUpdate);
            this.pnlEditor.Controls.Add(this.btnAdd);
            this.pnlEditor.Controls.Add(this.pnlOptions);
            this.pnlEditor.Controls.Add(this.lblOptionsCaption);
            this.pnlEditor.Controls.Add(this.lblSubjectCaption);
            this.pnlEditor.Controls.Add(this.lblDifficultyCaption);
            this.pnlEditor.Controls.Add(this.pnlQuestionBox);
            this.pnlEditor.Controls.Add(this.lblQuestionCaption);
            this.pnlEditor.Controls.Add(this.lblQuestionID);
            this.pnlEditor.Controls.Add(this.lblEditorTitle);
            this.pnlEditor.FillColor = System.Drawing.Color.White;
            this.pnlEditor.Location = new System.Drawing.Point(24, 16);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Radius = 12;
            this.pnlEditor.Size = new System.Drawing.Size(580, 540);
            this.pnlEditor.TabIndex = 0;
            // 
            // pnlNewSubject
            // 
            this.pnlNewSubject.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlNewSubject.Controls.Add(this.btnSubjectCancel);
            this.pnlNewSubject.Controls.Add(this.btnSubjectAdd);
            this.pnlNewSubject.Controls.Add(this.txtNewSubject);
            this.pnlNewSubject.FillColor = System.Drawing.Color.White;
            this.pnlNewSubject.Location = new System.Drawing.Point(20, 162);
            this.pnlNewSubject.Name = "pnlNewSubject";
            this.pnlNewSubject.Radius = 8;
            this.pnlNewSubject.Size = new System.Drawing.Size(520, 34);
            this.pnlNewSubject.TabIndex = 17;
            // 
            // btnSubjectCancel
            // 
            this.btnSubjectCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubjectCancel.FlatAppearance.BorderSize = 0;
            this.btnSubjectCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjectCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubjectCancel.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnSubjectCancel.Location = new System.Drawing.Point(414, 4);
            this.btnSubjectCancel.Name = "btnSubjectCancel";
            this.btnSubjectCancel.Size = new System.Drawing.Size(76, 26);
            this.btnSubjectCancel.TabIndex = 2;
            this.btnSubjectCancel.Text = "Cancel";
            this.btnSubjectCancel.UseVisualStyleBackColor = true;
            // 
            // btnSubjectAdd
            // 
            this.btnSubjectAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubjectAdd.FlatAppearance.BorderSize = 0;
            this.btnSubjectAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubjectAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubjectAdd.Location = new System.Drawing.Point(330, 4);
            this.btnSubjectAdd.Name = "btnSubjectAdd";
            this.btnSubjectAdd.Size = new System.Drawing.Size(76, 26);
            this.btnSubjectAdd.TabIndex = 1;
            this.btnSubjectAdd.Text = "Add";
            this.btnSubjectAdd.UseVisualStyleBackColor = true;
            // 
            // txtNewSubject
            // 
            this.txtNewSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewSubject.Location = new System.Drawing.Point(12, 7);
            this.txtNewSubject.Name = "txtNewSubject";
            this.txtNewSubject.Size = new System.Drawing.Size(290, 23);
            this.txtNewSubject.TabIndex = 0;
            // 
            // chipDifficulty
            // 
            this.chipDifficulty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chipDifficulty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chipDifficulty.Location = new System.Drawing.Point(20, 224);
            this.chipDifficulty.Name = "chipDifficulty";
            this.chipDifficulty.Size = new System.Drawing.Size(520, 34);
            this.chipDifficulty.TabIndex = 16;
            this.chipDifficulty.Text = "chipSelector1";
            // 
            // chipSubject
            // 
            this.chipSubject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chipSubject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chipSubject.Location = new System.Drawing.Point(20, 162);
            this.chipSubject.Name = "chipSubject";
            this.chipSubject.Size = new System.Drawing.Size(520, 34);
            this.chipSubject.TabIndex = 15;
            this.chipSubject.Text = "chipSelector1";
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMessage.Location = new System.Drawing.Point(20, 509);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(520, 20);
            this.lblMessage.TabIndex = 14;
            this.lblMessage.Text = "Message";
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnClear.Location = new System.Drawing.Point(410, 466);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 42);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Kind = QuizSystem.ButtonKind.Danger;
            this.btnDelete.Location = new System.Drawing.Point(300, 466);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 42);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Kind = QuizSystem.ButtonKind.Secondary;
            this.btnUpdate.Location = new System.Drawing.Point(180, 466);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(110, 42);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(20, 466);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 42);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add question";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.txtOption4);
            this.pnlOptions.Controls.Add(this.txtOption3);
            this.pnlOptions.Controls.Add(this.txtOption2);
            this.pnlOptions.Controls.Add(this.rdoCorrect4);
            this.pnlOptions.Controls.Add(this.rdoCorrect3);
            this.pnlOptions.Controls.Add(this.rdoCorrect2);
            this.pnlOptions.Controls.Add(this.txtOption1);
            this.pnlOptions.Controls.Add(this.rdoCorrect1);
            this.pnlOptions.Location = new System.Drawing.Point(20, 290);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(520, 164);
            this.pnlOptions.TabIndex = 9;
            // 
            // txtOption4
            // 
            this.txtOption4.Location = new System.Drawing.Point(56, 126);
            this.txtOption4.Name = "txtOption4";
            this.txtOption4.Size = new System.Drawing.Size(464, 38);
            this.txtOption4.TabIndex = 7;
            this.txtOption4.Text = "Option 4";
            // 
            // txtOption3
            // 
            this.txtOption3.Location = new System.Drawing.Point(56, 84);
            this.txtOption3.Name = "txtOption3";
            this.txtOption3.Size = new System.Drawing.Size(464, 38);
            this.txtOption3.TabIndex = 5;
            this.txtOption3.Text = "Option 3";
            // 
            // txtOption2
            // 
            this.txtOption2.Location = new System.Drawing.Point(56, 42);
            this.txtOption2.Name = "txtOption2";
            this.txtOption2.Size = new System.Drawing.Size(464, 38);
            this.txtOption2.TabIndex = 3;
            this.txtOption2.Text = "Option 2";
            // 
            // rdoCorrect4
            // 
            this.rdoCorrect4.AutoSize = true;
            this.rdoCorrect4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoCorrect4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCorrect4.Location = new System.Drawing.Point(0, 135);
            this.rdoCorrect4.Name = "rdoCorrect4";
            this.rdoCorrect4.Size = new System.Drawing.Size(44, 27);
            this.rdoCorrect4.TabIndex = 6;
            this.rdoCorrect4.TabStop = true;
            this.rdoCorrect4.Text = "D";
            this.rdoCorrect4.UseVisualStyleBackColor = true;
            // 
            // rdoCorrect3
            // 
            this.rdoCorrect3.AutoSize = true;
            this.rdoCorrect3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoCorrect3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCorrect3.Location = new System.Drawing.Point(0, 93);
            this.rdoCorrect3.Name = "rdoCorrect3";
            this.rdoCorrect3.Size = new System.Drawing.Size(42, 27);
            this.rdoCorrect3.TabIndex = 4;
            this.rdoCorrect3.TabStop = true;
            this.rdoCorrect3.Text = "C";
            this.rdoCorrect3.UseVisualStyleBackColor = true;
            // 
            // rdoCorrect2
            // 
            this.rdoCorrect2.AutoSize = true;
            this.rdoCorrect2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoCorrect2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCorrect2.Location = new System.Drawing.Point(0, 51);
            this.rdoCorrect2.Name = "rdoCorrect2";
            this.rdoCorrect2.Size = new System.Drawing.Size(42, 27);
            this.rdoCorrect2.TabIndex = 2;
            this.rdoCorrect2.TabStop = true;
            this.rdoCorrect2.Text = "B";
            this.rdoCorrect2.UseVisualStyleBackColor = true;
            // 
            // txtOption1
            // 
            this.txtOption1.Location = new System.Drawing.Point(56, 0);
            this.txtOption1.Name = "txtOption1";
            this.txtOption1.Size = new System.Drawing.Size(464, 38);
            this.txtOption1.TabIndex = 1;
            this.txtOption1.Text = "Option 1";
            // 
            // rdoCorrect1
            // 
            this.rdoCorrect1.AutoSize = true;
            this.rdoCorrect1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoCorrect1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoCorrect1.Location = new System.Drawing.Point(0, 9);
            this.rdoCorrect1.Name = "rdoCorrect1";
            this.rdoCorrect1.Size = new System.Drawing.Size(43, 27);
            this.rdoCorrect1.TabIndex = 0;
            this.rdoCorrect1.TabStop = true;
            this.rdoCorrect1.Text = "A";
            this.rdoCorrect1.UseVisualStyleBackColor = true;
            // 
            // lblOptionsCaption
            // 
            this.lblOptionsCaption.AutoSize = true;
            this.lblOptionsCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionsCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblOptionsCaption.Location = new System.Drawing.Point(20, 230);
            this.lblOptionsCaption.Name = "lblOptionsCaption";
            this.lblOptionsCaption.Size = new System.Drawing.Size(322, 23);
            this.lblOptionsCaption.TabIndex = 8;
            this.lblOptionsCaption.Text = "Answer options (select the correct one)";
            // 
            // lblSubjectCaption
            // 
            this.lblSubjectCaption.AutoSize = true;
            this.lblSubjectCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblSubjectCaption.Location = new System.Drawing.Point(20, 142);
            this.lblSubjectCaption.Name = "lblSubjectCaption";
            this.lblSubjectCaption.Size = new System.Drawing.Size(70, 23);
            this.lblSubjectCaption.TabIndex = 4;
            this.lblSubjectCaption.Text = "Subject";
            // 
            // lblDifficultyCaption
            // 
            this.lblDifficultyCaption.AutoSize = true;
            this.lblDifficultyCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficultyCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblDifficultyCaption.Location = new System.Drawing.Point(20, 204);
            this.lblDifficultyCaption.Name = "lblDifficultyCaption";
            this.lblDifficultyCaption.Size = new System.Drawing.Size(86, 23);
            this.lblDifficultyCaption.TabIndex = 6;
            this.lblDifficultyCaption.Text = "Difficulty";
            // 
            // pnlQuestionBox
            // 
            this.pnlQuestionBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlQuestionBox.Controls.Add(this.txtQuestionText);
            this.pnlQuestionBox.FillColor = System.Drawing.Color.White;
            this.pnlQuestionBox.Location = new System.Drawing.Point(20, 68);
            this.pnlQuestionBox.Name = "pnlQuestionBox";
            this.pnlQuestionBox.Radius = 8;
            this.pnlQuestionBox.Size = new System.Drawing.Size(520, 64);
            this.pnlQuestionBox.TabIndex = 0;
            // 
            // txtQuestionText
            // 
            this.txtQuestionText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuestionText.Location = new System.Drawing.Point(12, 8);
            this.txtQuestionText.MaxLength = 200;
            this.txtQuestionText.Multiline = true;
            this.txtQuestionText.Name = "txtQuestionText";
            this.txtQuestionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuestionText.Size = new System.Drawing.Size(496, 48);
            this.txtQuestionText.TabIndex = 0;
            // 
            // lblQuestionCaption
            // 
            this.lblQuestionCaption.AutoSize = true;
            this.lblQuestionCaption.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.lblQuestionCaption.Location = new System.Drawing.Point(20, 46);
            this.lblQuestionCaption.Name = "lblQuestionCaption";
            this.lblQuestionCaption.Size = new System.Drawing.Size(81, 23);
            this.lblQuestionCaption.TabIndex = 2;
            this.lblQuestionCaption.Text = "Question";
            // 
            // lblQuestionID
            // 
            this.lblQuestionID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblQuestionID.Location = new System.Drawing.Point(380, 18);
            this.lblQuestionID.Name = "lblQuestionID";
            this.lblQuestionID.Size = new System.Drawing.Size(160, 22);
            this.lblQuestionID.TabIndex = 1;
            this.lblQuestionID.Text = "New question";
            this.lblQuestionID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEditorTitle
            // 
            this.lblEditorTitle.AutoSize = true;
            this.lblEditorTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditorTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblEditorTitle.Location = new System.Drawing.Point(20, 14);
            this.lblEditorTitle.Name = "lblEditorTitle";
            this.lblEditorTitle.Size = new System.Drawing.Size(181, 30);
            this.lblEditorTitle.TabIndex = 0;
            this.lblEditorTitle.Text = "Question details";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.lblFooterHint);
            this.pnlFooter.Controls.Add(this.pnlFooterLine);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 521);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1042, 30);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblFooterHint
            // 
            this.lblFooterHint.AutoSize = true;
            this.lblFooterHint.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFooterHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooterHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFooterHint.Location = new System.Drawing.Point(705, 1);
            this.lblFooterHint.Name = "lblFooterHint";
            this.lblFooterHint.Size = new System.Drawing.Size(337, 20);
            this.lblFooterHint.TabIndex = 1;
            this.lblFooterHint.Text = "Esc Close     Ctrl+N New question     Ctrl+F Search";
            // 
            // pnlFooterLine
            // 
            this.pnlFooterLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooterLine.Location = new System.Drawing.Point(0, 0);
            this.pnlFooterLine.Name = "pnlFooterLine";
            this.pnlFooterLine.Size = new System.Drawing.Size(1042, 1);
            this.pnlFooterLine.TabIndex = 0;
            // 
            // pnlList
            // 
            this.pnlList.BackColor = System.Drawing.Color.White;
            this.pnlList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlList.Controls.Add(this.pnlSearchBox);
            this.pnlList.Controls.Add(this.lstQuestions);
            this.pnlList.Controls.Add(this.lblCount);
            this.pnlList.Controls.Add(this.lblListTitle);
            this.pnlList.FillColor = System.Drawing.Color.White;
            this.pnlList.Location = new System.Drawing.Point(628, 16);
            this.pnlList.Name = "pnlList";
            this.pnlList.Radius = 12;
            this.pnlList.Size = new System.Drawing.Size(408, 540);
            this.pnlList.TabIndex = 1;
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlSearchBox.Controls.Add(this.txtSearch);
            this.pnlSearchBox.FillColor = System.Drawing.Color.White;
            this.pnlSearchBox.Location = new System.Drawing.Point(20, 72);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Radius = 8;
            this.pnlSearchBox.Size = new System.Drawing.Size(368, 40);
            this.pnlSearchBox.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtSearch.Location = new System.Drawing.Point(14, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(340, 23);
            this.txtSearch.TabIndex = 0;
            // 
            // lstQuestions
            // 
            this.lstQuestions.BackColor = System.Drawing.Color.White;
            this.lstQuestions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstQuestions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstQuestions.FormattingEnabled = true;
            this.lstQuestions.IntegralHeight = false;
            this.lstQuestions.ItemHeight = 56;
            this.lstQuestions.Location = new System.Drawing.Point(20, 124);
            this.lstQuestions.Name = "lstQuestions";
            this.lstQuestions.Size = new System.Drawing.Size(368, 400);
            this.lstQuestions.TabIndex = 0;
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCount.Location = new System.Drawing.Point(20, 44);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(368, 20);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Showing 0 of 0 questions";
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblListTitle.Location = new System.Drawing.Point(20, 14);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(146, 30);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "All questions";
            // 
            // QuestionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1042, 615);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EduQuiz - Question Manager";
            this.Load += new System.EventHandler(this.QuestionForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuestionForm_KeyDown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlEditor.ResumeLayout(false);
            this.pnlEditor.PerformLayout();
            this.pnlNewSubject.ResumeLayout(false);
            this.pnlNewSubject.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlQuestionBox.ResumeLayout(false);
            this.pnlQuestionBox.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            this.pnlSearchBox.ResumeLayout(false);
            this.pnlSearchBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private ModernButton btnClose;
        private System.Windows.Forms.Label lblPageSub;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlHeaderLine;
        private RoundedPanel pnlList;
        private RoundedPanel pnlEditor;
        private System.Windows.Forms.Label lblEditorTitle;
        private RoundedPanel pnlQuestionBox;
        private System.Windows.Forms.Label lblQuestionCaption;
        private System.Windows.Forms.Label lblQuestionID;
        private System.Windows.Forms.Label lblDifficultyCaption;
        private System.Windows.Forms.Label lblSubjectCaption;
        private System.Windows.Forms.TextBox txtQuestionText;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblOptionsCaption;
        private ModernTextBox txtOption1;
        private System.Windows.Forms.RadioButton rdoCorrect1;
        private ModernTextBox txtOption4;
        private ModernTextBox txtOption3;
        private ModernTextBox txtOption2;
        private System.Windows.Forms.RadioButton rdoCorrect4;
        private System.Windows.Forms.RadioButton rdoCorrect3;
        private System.Windows.Forms.RadioButton rdoCorrect2;
        private ModernButton btnClear;
        private ModernButton btnDelete;
        private ModernButton btnUpdate;
        private ModernButton btnAdd;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ListBox lstQuestions;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooterHint;
        private System.Windows.Forms.Panel pnlFooterLine;
        private ChipSelector chipDifficulty;
        private ChipSelector chipSubject;
        private System.Windows.Forms.Label lblHeaderUser;
        private RoundedPanel pnlSearchBox;
        private System.Windows.Forms.TextBox txtSearch;
        private RoundedPanel pnlNewSubject;
        private System.Windows.Forms.TextBox txtNewSubject;
        private ModernButton btnSubjectCancel;
        private ModernButton btnSubjectAdd;
    }
}