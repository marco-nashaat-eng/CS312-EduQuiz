using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class QuestionForm : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private delegate void QuestionAddedHandler(Question question);
        private event QuestionAddedHandler QuestionAdded;

        List<Question> visibleQuestions = new List<Question>();
        Question selectedQuestion = null;

        private LoginForm loginForm = null;
        private string teacherUser = "";
        private string teacherName = "";
        private bool loggingOut = false;

        // Opened from the Teacher dashboard: works on one subject's quiz
        private bool fromDashboard = false;
        private string workSubject = "";
        private QuizHeaderInfo quizInfo;
        private ModernButton btnQuizSettings;

        public QuestionForm()
        {
            InitializeComponent();
            QuestionAdded += OnQuestionAdded;
            WireEvents();
        }

        public QuestionForm(LoginForm login, string username, string fullName) : this()
        {
            loginForm = login;
            teacherUser = username;
            teacherName = fullName;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Opened from the Teacher dashboard (as a dialog) for one subject
        public QuestionForm(string username, string fullName, string subject) : this()
        {
            teacherUser = username;
            teacherName = fullName;
            fromDashboard = true;
            workSubject = subject;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private bool IsTeacherMode()
        {
            return loginForm != null || fromDashboard;
        }

        private bool IsMine(Question q)
        {
            if (fromDashboard)
                return q.Owner == teacherUser && q.Subject == workSubject;

            if (!IsTeacherMode())
                return true;

            return q.Owner == teacherUser;
        }

        private void WireEvents()
        {
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnClose.Click += btnClose_Click;
            btnSubjectAdd.Click += btnSubjectAdd_Click;
            btnSubjectCancel.Click += btnSubjectCancel_Click;
            txtNewSubject.KeyDown += txtNewSubject_KeyDown;
            chipSubject.AddChipClicked += chipSubject_AddChipClicked;
            chipSubject.SelectedIndexChanged += chipSubject_SelectedIndexChanged;
            pnlSearchBox.Click += pnlSearchBox_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            lstQuestions.SelectedIndexChanged += lstQuestions_SelectedIndexChanged;
            lstQuestions.DrawItem += lstQuestions_DrawItem;
            this.FormClosed += QuestionForm_FormClosed;
        }

        private void SetPlaceholder(TextBox box, string text)
        {
            SendMessage(box.Handle, EM_SETCUEBANNER, (IntPtr)1, text);
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            // Subjects are managed on the dashboard, so no "+" chip there
            chipSubject.ShowAddChip = !fromDashboard;

            if (fromDashboard)
            {
                List<string> mine = AppData.SubjectsOf(teacherUser);

                foreach (string subject in mine)
                    chipSubject.AddItem(subject);

                if (workSubject == "" || !mine.Contains(workSubject))
                {
                    if (mine.Count > 0)
                        workSubject = mine[0];
                    else
                        workSubject = "";
                }
            }
            else
            {
                foreach (string subject in AppData.Subjects)
                    chipSubject.AddItem(subject);
            }

            chipDifficulty.AddItem("Easy");
            chipDifficulty.AddItem("Medium");
            chipDifficulty.AddItem("Hard");

            txtNewSubject.MaxLength = 14;
            SetPlaceholder(txtSearch, "Search questions or subjects...");
            SetPlaceholder(txtNewSubject, "New subject name");
            pnlNewSubject.Visible = false;

            toolTip1.SetToolTip(btnAdd, "Add a new question to the bank");
            toolTip1.SetToolTip(btnUpdate, "Save changes to the selected question");
            toolTip1.SetToolTip(btnDelete, "Delete the selected question");
            toolTip1.SetToolTip(btnClear, "Clear the form (Ctrl+N)");
            toolTip1.SetToolTip(txtSearch, "Search by question text or subject (Ctrl+F)");

            if (fromDashboard)
            {
                this.Text = "EduQuiz - Question manager";
                lblPageSub.Text = "Add the questions for your quiz";
                lblHeaderUser.Visible = false;
                btnClose.Text = "Back";
                lblFooterHint.Text = "Esc Back     Ctrl+N New question     Ctrl+F Search     Ctrl+Q Quiz settings";
                BuildHeaderTools();
            }
            else if (IsTeacherMode())
            {
                this.Text = "EduQuiz - Teacher workspace";
                lblPageSub.Text = "Create and manage your own questions";
                lblHeaderUser.Text = "Signed in as " + teacherName;
                btnClose.Text = "Log out";
                lblFooterHint.Text = "Esc Log out     Ctrl+N New question     Ctrl+F Search";
            }
            else
            {
                lblHeaderUser.Text = "";
            }

            lblMessage.Text = "";
            ClearForm();
            RefreshList();
            UpdateQuizInfo();
        }

        // The quiz progress and the Quiz settings button, created in code
        private void BuildHeaderTools()
        {
            quizInfo = new QuizHeaderInfo();
            quizInfo.Location = new Point(360, 10);
            quizInfo.Size = new Size(420, 44);
            pnlHeader.Controls.Add(quizInfo);

            btnQuizSettings = new ModernButton();
            btnQuizSettings.Text = "Quiz settings";
            btnQuizSettings.Kind = ButtonKind.Secondary;
            btnQuizSettings.Size = new Size(132, 42);
            btnQuizSettings.Location = new Point(796, 11);
            pnlHeader.Controls.Add(btnQuizSettings);
            btnQuizSettings.Click += btnQuizSettings_Click;

            toolTip1.SetToolTip(btnQuizSettings,
                "Change the number of questions, duration and more (Ctrl+Q)");
        }

        private void UpdateQuizInfo()
        {
            if (!fromDashboard || quizInfo == null)
                return;

            if (workSubject == "")
            {
                quizInfo.SetState("No subject selected", 0, 0, "No quiz yet", "");
                return;
            }

            int have = AppData.QuestionsOf(teacherUser, workSubject).Count;
            QuizConfig quiz = AppData.FindQuiz(teacherUser, workSubject);
            string status = AppData.QuizStatusText(teacherUser, workSubject);

            if (quiz == null)
            {
                quizInfo.SetState("No quiz for " + workSubject + " yet", have, 0, status, "");
            }
            else
            {
                quizInfo.SetState(quiz.Title, have, quiz.QuestionCount, status,
                    quiz.DurationMinutes + " min   |   pass " + quiz.PassPercent + "%");
            }
        }

        private void OpenQuizSettings()
        {
            if (workSubject == "")
            {
                ShowMessage("Add a subject on your dashboard first.", true);
                return;
            }

            string saved = "";

            using (QuizSetupForm form = new QuizSetupForm(teacherUser, workSubject, false))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    saved = form.SavedSubject;
            }

            // The settings window can also switch subject
            if (saved != "" && saved != workSubject)
                chipSubject.SelectItem(saved);
            else
                UpdateQuizInfo();
        }

        private void btnQuizSettings_Click(object sender, EventArgs e)
        {
            OpenQuizSettings();
        }

        private void QuestionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (pnlNewSubject.Visible && e.KeyCode == Keys.Escape)
            {
                CloseNewSubjectBox();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                CloseOrLogout();
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                ClearForm();
                ShowMessage("Ready for a new question.", false);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                txtSearch.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Q && fromDashboard)
            {
                OpenQuizSettings();
                e.SuppressKeyPress = true;
            }
        }

        private void CloseOrLogout()
        {
            if (!IsTeacherMode() || fromDashboard)
            {
                this.Close();
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to log out?", "Log Out",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            loggingOut = true;
            loginForm.Show();
            loginForm.ResetForNewLogin();
            this.Close();
        }

        private void QuestionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsTeacherMode() && !fromDashboard && !loggingOut)
                Application.Exit();
        }

        private void ShowMessage(string message, bool isError)
        {
            lblMessage.Text = message;

            if (isError)
                lblMessage.ForeColor = Theme.Danger;
            else
                lblMessage.ForeColor = Theme.Success;
        }

        private string GetDifficulty()
        {
            return chipDifficulty.SelectedItem;
        }

        private int GetCorrectIndex()
        {
            if (rdoCorrect1.Checked)
                return 0;
            if (rdoCorrect2.Checked)
                return 1;
            if (rdoCorrect3.Checked)
                return 2;
            if (rdoCorrect4.Checked)
                return 3;
            return -1;
        }

        private string[] GetOptions()
        {
            return new string[]
            {
                txtOption1.Text.Trim(),
                txtOption2.Text.Trim(),
                txtOption3.Text.Trim(),
                txtOption4.Text.Trim()
            };
        }

        private void RefreshList()
        {
            lstQuestions.Items.Clear();
            visibleQuestions.Clear();

            string search = txtSearch.Text.Trim().ToLower();
            int mineCount = 0;

            foreach (Question q in AppData.Questions)
            {
                if (IsMine(q))
                {
                    mineCount++;

                    if (search == "" ||
                        q.Text.ToLower().Contains(search) ||
                        q.Subject.ToLower().Contains(search))
                    {
                        visibleQuestions.Add(q);
                        lstQuestions.Items.Add(q.GetInfo());
                    }
                }
            }

            if (fromDashboard)
                lblListTitle.Text = "Questions in " + workSubject;

            lblCount.Text = "Showing " + visibleQuestions.Count + " of " +
                mineCount + " questions";
        }

        private void ClearForm()
        {
            CloseNewSubjectBox();

            selectedQuestion = null;
            lstQuestions.ClearSelected();

            lblQuestionID.Text = "New question";
            txtQuestionText.Clear();

            // On the dashboard the chip always shows the subject being worked on
            if (fromDashboard)
                chipSubject.SelectItem(workSubject);
            else
                chipSubject.SelectedIndex = -1;

            chipDifficulty.SelectedIndex = -1;

            txtOption1.Clear();
            txtOption2.Clear();
            txtOption3.Clear();
            txtOption4.Clear();

            rdoCorrect1.Checked = false;
            rdoCorrect2.Checked = false;
            rdoCorrect3.Checked = false;
            rdoCorrect4.Checked = false;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtQuestionText.Focus();
        }

        private bool ValidateForm()
        {
            bool missing =
                string.IsNullOrWhiteSpace(txtQuestionText.Text) ||
                chipSubject.SelectedIndex == -1 ||
                chipDifficulty.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtOption1.Text) ||
                string.IsNullOrWhiteSpace(txtOption2.Text) ||
                string.IsNullOrWhiteSpace(txtOption3.Text) ||
                string.IsNullOrWhiteSpace(txtOption4.Text) ||
                GetCorrectIndex() == -1;

            if (missing)
            {
                ShowMessage("Please fill in every field and select the correct answer.", true);
                return false;
            }

            return true;
        }

        private void OnQuestionAdded(Question question)
        {
            RefreshList();
            UpdateQuizInfo();

            string message = "Question added (ID " + question.ID + ").";

            if (fromDashboard)
            {
                QuizConfig quiz = AppData.FindQuiz(teacherUser, workSubject);
                int have = AppData.QuestionsOf(teacherUser, workSubject).Count;

                if (quiz != null)
                {
                    if (have == quiz.QuestionCount)
                        message = "Added. Your quiz is complete: " + have + " of " +
                            quiz.QuestionCount + " questions.";
                    else if (have > quiz.QuestionCount)
                        message = "Added to the pool. The quiz uses " + quiz.QuestionCount +
                            " of your " + have + " questions.";
                    else
                        message = "Added. " + (quiz.QuestionCount - have) +
                            " more to complete the quiz.";
                }
            }

            ShowMessage(message, false);
        }

        private void CloseNewSubjectBox()
        {
            pnlNewSubject.Visible = false;
            chipSubject.Visible = true;
        }

        private void SaveNewSubject()
        {
            string name = txtNewSubject.Text.Trim();

            if (name == "")
            {
                ShowMessage("Please type a subject name.", true);
                txtNewSubject.Focus();
                return;
            }

            foreach (string existing in AppData.Subjects)
            {
                if (existing.ToLower() == name.ToLower())
                {
                    chipSubject.SelectItem(existing);
                    CloseNewSubjectBox();
                    ShowMessage("That subject already exists, so it was selected.", false);
                    return;
                }
            }

            if (!chipSubject.AddItem(name))
            {
                ShowMessage("There is no room for more subjects in this row.", true);
                return;
            }

            AppData.Subjects.Add(name);
            chipSubject.SelectItem(name);
            CloseNewSubjectBox();
            ShowMessage("Subject \"" + name + "\" added.", false);
        }

        private void chipSubject_AddChipClicked(object sender, EventArgs e)
        {
            chipSubject.Visible = false;
            pnlNewSubject.Visible = true;
            txtNewSubject.Clear();
            txtNewSubject.Focus();

            lblMessage.Text = "Type the new subject name, then press Enter or click Add.";
            lblMessage.ForeColor = Theme.TextMuted;
        }

        // On the dashboard, choosing another chip switches the subject being worked on
        private void chipSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fromDashboard)
                return;

            string chosen = chipSubject.SelectedItem;

            if (chosen == "" || chosen == workSubject)
                return;

            workSubject = chosen;

            if (selectedQuestion != null)
                ClearForm();

            RefreshList();
            UpdateQuizInfo();
            ShowMessage("Now working on " + chosen + ".", false);
        }

        private void btnSubjectAdd_Click(object sender, EventArgs e)
        {
            SaveNewSubject();
        }

        private void btnSubjectCancel_Click(object sender, EventArgs e)
        {
            CloseNewSubjectBox();
            lblMessage.Text = "";
        }

        private void txtNewSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveNewSubject();
                e.SuppressKeyPress = true;
            }
        }

        private void pnlSearchBox_Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            Question q = new Question(AppData.NextID, txtQuestionText.Text.Trim(),
                chipSubject.SelectedItem, GetDifficulty(), GetOptions(), GetCorrectIndex());

            q.Owner = teacherUser;

            AppData.NextID++;
            AppData.Questions.Add(q);

            QuestionAdded?.Invoke(q);
            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblMessage.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseOrLogout();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void lstQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstQuestions.SelectedIndex;
            if (index == -1)
                return;

            CloseNewSubjectBox();
            selectedQuestion = visibleQuestions[index];

            lblQuestionID.Text = "Question #" + selectedQuestion.ID;
            txtQuestionText.Text = selectedQuestion.Text;
            chipSubject.SelectItem(selectedQuestion.Subject);
            chipDifficulty.SelectItem(selectedQuestion.Difficulty);

            txtOption1.Text = selectedQuestion.Options[0];
            txtOption2.Text = selectedQuestion.Options[1];
            txtOption3.Text = selectedQuestion.Options[2];
            txtOption4.Text = selectedQuestion.Options[3];

            rdoCorrect1.Checked = (selectedQuestion.CorrectIndex == 0);
            rdoCorrect2.Checked = (selectedQuestion.CorrectIndex == 1);
            rdoCorrect3.Checked = (selectedQuestion.CorrectIndex == 2);
            rdoCorrect4.Checked = (selectedQuestion.CorrectIndex == 3);

            lblMessage.Text = "";

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void lstQuestions_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= visibleQuestions.Count)
                return;

            Question q = visibleQuestions[e.Index];
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color back = Color.White;
            if (selected)
                back = Color.FromArgb(238, 242, 255);

            using (SolidBrush brush = new SolidBrush(back))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            if (selected)
            {
                using (SolidBrush bar = new SolidBrush(Theme.Primary))
                {
                    e.Graphics.FillRectangle(bar, e.Bounds.X, e.Bounds.Y, 4, e.Bounds.Height);
                }
            }

            using (Pen line = new Pen(Theme.Border))
            {
                e.Graphics.DrawLine(line, e.Bounds.X, e.Bounds.Bottom - 1,
                    e.Bounds.Right, e.Bounds.Bottom - 1);
            }

            Rectangle titleRect = new Rectangle(e.Bounds.X + 16, e.Bounds.Y + 8,
                e.Bounds.Width - 28, 20);
            Rectangle metaRect = new Rectangle(e.Bounds.X + 16, e.Bounds.Y + 30,
                e.Bounds.Width - 28, 18);

            TextRenderer.DrawText(e.Graphics, q.Text, Theme.BodyBoldFont, titleRect,
                Theme.TextDark,
                TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);

            TextRenderer.DrawText(e.Graphics,
                "#" + q.ID + "   " + q.Subject + "  |  " + q.Difficulty,
                Theme.SmallFont, metaRect, Theme.TextMuted,
                TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedQuestion == null)
            {
                ShowMessage("Select a question from the list first.", true);
                return;
            }

            if (!ValidateForm())
                return;

            selectedQuestion.Text = txtQuestionText.Text.Trim();
            selectedQuestion.Subject = chipSubject.SelectedItem;
            selectedQuestion.Difficulty = GetDifficulty();
            selectedQuestion.Options = GetOptions();
            selectedQuestion.CorrectIndex = GetCorrectIndex();

            RefreshList();
            ClearForm();
            UpdateQuizInfo();
            ShowMessage("Question updated.", false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedQuestion == null)
                return;

            DialogResult result = MessageBox.Show("Delete this question?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AppData.Questions.Remove(selectedQuestion);
                RefreshList();
                ClearForm();
                UpdateQuizInfo();
                ShowMessage("Question deleted.", false);
            }
        }
    }
}