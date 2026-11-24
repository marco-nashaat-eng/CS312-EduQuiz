using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class QuizSetupForm : Form
    {
        private string teacherUser;
        private bool continueToQuestions;

        // The subject whose quiz was saved (read by the dashboard)
        public string SavedSubject { get; private set; }

        public QuizSetupForm(string teacher, string subject, bool continueToQuestions)
        {
            InitializeComponent();
            this.ClientSize = new Size(640, 620);
            this.Icon = Theme.AppIcon;

            teacherUser = teacher;
            this.continueToQuestions = continueToQuestions;
            SavedSubject = "";

            WireEvents();
            SetupControls(subject);
        }

        private void WireEvents()
        {
            chipSubject.SelectionChanged += chipSubject_SelectionChanged;
            btnSave.Click += btnSave_Click;

            txtTitle.TextChanged += ClearError;
            txtCount.TextChanged += ClearError;
            txtDuration.TextChanged += ClearError;
            txtPass.TextChanged += ClearError;
            chkShuffle.CheckedChanged += ClearError;
            chkOpen.CheckedChanged += ClearError;
        }

        private void SetupControls(string subject)
        {
            pnlCard.FillColor = Color.White;
            pnlCard.BorderColor = Theme.Border;
            pnlCard.Radius = 12;
            pnlCard.BackColor = Color.White;

            txtCount.MaxLength = 3;
            txtDuration.MaxLength = 3;
            txtPass.MaxLength = 3;
            txtTitle.MaxLength = 40;

            if (continueToQuestions)
                btnSave.Text = "Save and add questions";
            else
                btnSave.Text = "Save settings";

            btnCancel.DialogResult = DialogResult.Cancel;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;

            chipSubject.SingleSelect = true;

            foreach (string s in AppData.SubjectsOf(teacherUser))
                chipSubject.AddItem(s);

            lblError.Text = "";

            string start = subject;

            if (start == "" || chipSubject.FindItem(start) == null)
            {
                List<string> mine = AppData.SubjectsOf(teacherUser);

                if (mine.Count > 0)
                    start = mine[0];
                else
                    start = "";
            }

            if (start == "")
            {
                btnSave.Enabled = false;
                lblInfo.Text = "You have no subjects yet. Add a subject on your dashboard first.";
                return;
            }

            chipSubject.SetChecked(start, true);
        }

        private void ClearError(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        private void ShowError(string message, ModernTextBox box)
        {
            lblError.Text = message;

            if (box != null)
                box.Focus();
        }

        // Fills the fields with the existing quiz of this subject, or with defaults
        private void chipSubject_SelectionChanged(object sender, EventArgs e)
        {
            string subject = chipSubject.SelectedItem;

            if (subject == "")
                return;

            QuizConfig quiz = AppData.FindQuiz(teacherUser, subject);
            int have = AppData.QuestionsOf(teacherUser, subject).Count;

            if (quiz != null)
            {
                txtTitle.Text = quiz.Title;
                txtCount.Text = quiz.QuestionCount.ToString();
                txtDuration.Text = quiz.DurationMinutes.ToString();
                txtPass.Text = quiz.PassPercent.ToString();
                chkShuffle.Checked = quiz.ShuffleQuestions;
                chkOpen.Checked = quiz.IsOpen;

                lblInfo.Text = "Editing the existing quiz. You have " + have +
                    " question(s) in " + subject + ".";
            }
            else
            {
                txtTitle.Text = subject + " Quiz";
                txtCount.Text = "10";
                txtDuration.Text = "10";
                txtPass.Text = "50";
                chkShuffle.Checked = false;
                chkOpen.Checked = true;

                lblInfo.Text = "New quiz. You have " + have +
                    " question(s) in " + subject + " so far.";
            }

            lblError.Text = "";
        }

        private bool ReadNumber(ModernTextBox box, string label, int min, int max, out int value)
        {
            if (!int.TryParse(box.Text.Trim(), out value) || value < min || value > max)
            {
                ShowError(label + " must be a whole number from " + min + " to " + max + ".", box);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string subject = chipSubject.SelectedItem;

            if (subject == "")
            {
                ShowError("Please choose a subject.", null);
                return;
            }

            string title = txtTitle.Text.Trim();

            if (title == "")
            {
                ShowError("Please enter a quiz title.", txtTitle);
                return;
            }

            int count;
            int duration;
            int pass;

            if (!ReadNumber(txtCount, "Number of questions", 1, 50, out count))
                return;

            if (!ReadNumber(txtDuration, "Duration", 1, 180, out duration))
                return;

            if (!ReadNumber(txtPass, "Pass mark", 1, 100, out pass))
                return;

            QuizConfig quiz = AppData.FindQuiz(teacherUser, subject);

            if (quiz == null)
            {
                quiz = new QuizConfig(teacherUser, subject, title, count, duration, pass,
                    chkShuffle.Checked);
                AppData.Quizzes.Add(quiz);
            }
            else
            {
                quiz.Title = title;
                quiz.QuestionCount = count;
                quiz.DurationMinutes = duration;
                quiz.PassPercent = pass;
                quiz.ShuffleQuestions = chkShuffle.Checked;
            }

            quiz.IsOpen = chkOpen.Checked;

            SavedSubject = subject;
            this.DialogResult = DialogResult.OK;
        }
    }
}