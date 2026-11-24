using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class QuizForm : Form
    {
        private UserAccount account;
        private QuizConfig quiz;

        private List<Question> quizQuestions = new List<Question>();
        private int currentIndex = 0;
        private int correctCount = 0;
        private int secondsLeft = 0;
        private int totalSeconds = 0;
        private int selectedAnswer = -1;
        private bool quizFinished = false;
        private bool timedOut = false;

        private AnswerCard[] answerCards = new AnswerCard[4];

        private Panel finishHost = null;
        private double finalPercent = 0;
        private bool finalPassed = false;

        // Opened from the Student dashboard for one quiz
        public QuizForm(UserAccount studentAccount, QuizConfig quizConfig)
        {
            InitializeComponent();
            account = studentAccount;
            quiz = quizConfig;

            BuildAnswerCards();
            WireEvents();
        }

        private void WireEvents()
        {
            btnNext.Click += btnNext_Click;
            tmrQuestion.Tick += tmrQuestion_Tick;
            pnlTimer.Paint += pnlTimer_Paint;
            pnlProgress.Paint += pnlProgress_Paint;
        }

        private void BuildAnswerCards()
        {
            string[] letters = { "A", "B", "C", "D" };

            for (int i = 0; i < 4; i++)
            {
                AnswerCard card = new AnswerCard();
                card.Letter = letters[i];
                card.Tag = i;
                card.Size = new Size(496, 100);
                card.Location = new Point((i % 2) * 516, (i / 2) * 116);
                card.Click += AnswerCard_Click;

                pnlAnswers.Controls.Add(card);
                answerCards[i] = card;
            }
        }

        // The quiz uses N questions from the teacher's pool:
        // random N when "shuffle" is on, otherwise the first N
        private List<Question> PickQuestions()
        {
            List<Question> pool = new List<Question>(AppData.QuestionsOf(quiz.TeacherUsername, quiz.Subject));

            if (quiz.ShuffleQuestions)
            {
                Random random = new Random();

                for (int i = pool.Count - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);
                    Question temp = pool[i];
                    pool[i] = pool[j];
                    pool[j] = temp;
                }
            }

            int take = Math.Min(quiz.QuestionCount, pool.Count);
            return pool.GetRange(0, take);
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            string title = quiz.Title;
            if (title.Length > 38)
                title = title.Substring(0, 38) + "...";

            lblPageTitle.Text = title;
            lblStudent.Text = "Student: " + account.FullName + "   |   " + quiz.Subject +
                "   |   Teacher: " + AppData.DisplayName(quiz.TeacherUsername);
            lblFooterHint.Text = "1-4 Choose an answer     Enter Next question     Esc Quit";

            quizQuestions = PickQuestions();

            if (quizQuestions.Count == 0)
            {
                quizFinished = true;
                MessageBox.Show("No Quiz Available", "Quiz", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            currentIndex = 0;
            correctCount = 0;
            totalSeconds = quiz.DurationMinutes * 60;
            secondsLeft = totalSeconds;

            ShowQuestion();
            UpdateTimerCaption();
            tmrQuestion.Start();
        }

        private void QuizForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.SuppressKeyPress = true;
                return;
            }

            if (quizFinished)
                return;

            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                SelectAnswer(0);
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                SelectAnswer(1);
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                SelectAnswer(2);
            else if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                SelectAnswer(3);
        }

        // The clock keeps running while this question is open, so it cannot be used to pause
        private void QuizForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (quizFinished)
                return;

            DialogResult result = MessageBox.Show("Quit the quiz? Your answers will be lost.",
                "Quit Quiz", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void QuizForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrQuestion.Stop();
        }

        private void AnswerCard_Click(object sender, EventArgs e)
        {
            AnswerCard card = (AnswerCard)sender;
            SelectAnswer((int)card.Tag);
        }

        private int GetSelectedAnswer()
        {
            return selectedAnswer;
        }

        private void SelectAnswer(int index)
        {
            selectedAnswer = index;

            for (int i = 0; i < answerCards.Length; i++)
                answerCards[i].Selected = (i == index);

            if (index == -1)
            {
                lblSelectHint.Text = "Choose one answer, or press 1-4.";
                lblSelectHint.ForeColor = Theme.TextMuted;
            }
            else
            {
                lblSelectHint.Text = "Answer " + answerCards[index].Letter +
                    " selected. Press Enter to continue.";
                lblSelectHint.ForeColor = Theme.Success;
            }
        }

        private void ShowQuestion()
        {
            Question q = quizQuestions[currentIndex];

            lblProgress.Text = "Question " + (currentIndex + 1) + " of " + quizQuestions.Count;
            lblQuestionTag.Text = "QUESTION " + (currentIndex + 1) + "   |   " +
                q.Subject.ToUpper() + "   |   " + q.Difficulty.ToUpper();
            lblQuestionText.Text = q.Text;

            for (int i = 0; i < 4; i++)
                answerCards[i].AnswerText = q.Options[i];

            SelectAnswer(-1);

            if (currentIndex == quizQuestions.Count - 1)
                btnNext.Text = "Finish quiz";
            else
                btnNext.Text = "Next question";

            pnlProgress.Invalidate();
        }

        private void CheckCurrentAnswer()
        {
            Question q = quizQuestions[currentIndex];

            if (q.IsCorrect(GetSelectedAnswer()))
                correctCount++;
        }

        private void GoToNext()
        {
            if (quizFinished)
                return;

            CheckCurrentAnswer();

            if (currentIndex == quizQuestions.Count - 1)
            {
                FinishQuiz();
                return;
            }

            currentIndex++;
            ShowQuestion();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (quizFinished)
                return;

            if (GetSelectedAnswer() == -1)
            {
                DialogResult result = MessageBox.Show(
                    "You have not selected an answer. Move on anyway?",
                    "No Answer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                // time may have run out while the message was open
                if (quizFinished)
                    return;
            }

            GoToNext();
        }

        // ---------- the quiz clock ----------

        private string FormatTime(int seconds)
        {
            if (seconds < 0)
                seconds = 0;

            return (seconds / 60).ToString("00") + ":" + (seconds % 60).ToString("00");
        }

        private void UpdateTimerCaption()
        {
            lblTimerCaption.Text = FormatTime(secondsLeft) + " left";
        }

        private void tmrQuestion_Tick(object sender, EventArgs e)
        {
            if (quizFinished)
                return;

            secondsLeft--;
            pnlTimer.Invalidate();
            UpdateTimerCaption();

            if (secondsLeft <= 0)
                TimeUp();
        }

        // Time is over: the question on screen is graded, the rest count as wrong
        private void TimeUp()
        {
            tmrQuestion.Stop();
            timedOut = true;
            CheckCurrentAnswer();
            FinishQuiz();
        }

        private void pnlTimer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle ring = new Rectangle(4, 4, pnlTimer.Width - 9, pnlTimer.Height - 9);

            Color ringColor = Color.FromArgb(129, 140, 248);
            Color textColor = Color.White;

            if (secondsLeft <= 30)
            {
                ringColor = Color.FromArgb(248, 113, 113);
                textColor = Color.FromArgb(252, 165, 165);
            }

            using (Pen track = new Pen(Color.FromArgb(51, 65, 85), 4))
            {
                g.DrawEllipse(track, ring);
            }

            if (totalSeconds > 0)
            {
                float sweep = 360F * Math.Max(0, secondsLeft) / totalSeconds;

                if (sweep > 0)
                {
                    using (Pen arc = new Pen(ringColor, 4))
                    {
                        arc.StartCap = LineCap.Round;
                        arc.EndCap = LineCap.Round;
                        g.DrawArc(arc, ring, -90, sweep);
                    }
                }
            }

            // minutes left, or seconds left in the final minute
            string ringText;

            if (secondsLeft >= 60)
                ringText = ((secondsLeft + 59) / 60).ToString();
            else
                ringText = Math.Max(0, secondsLeft).ToString();

            TextRenderer.DrawText(g, ringText, Theme.BodyBoldFont,
                pnlTimer.ClientRectangle, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void pnlProgress_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle track = new Rectangle(0, 0, pnlProgress.Width - 1, pnlProgress.Height - 1);

            using (GraphicsPath trackPath = Theme.RoundedRect(track, 3))
            using (SolidBrush trackBrush = new SolidBrush(Theme.Border))
            {
                g.FillPath(trackBrush, trackPath);
            }

            if (quizQuestions.Count == 0)
                return;

            int w = (int)(track.Width * (currentIndex + 1) / (double)quizQuestions.Count);

            if (w < 8)
                w = 8;

            Rectangle fill = new Rectangle(0, 0, w, track.Height);

            using (GraphicsPath fillPath = Theme.RoundedRect(fill, 3))
            using (SolidBrush fillBrush = new SolidBrush(Theme.Primary))
            {
                g.FillPath(fillBrush, fillPath);
            }
        }

        // ---------- finishing ----------

        private void FinishQuiz()
        {
            if (quizFinished)
                return;

            quizFinished = true;
            tmrQuestion.Stop();

            // Created now, so its time stamp is the moment the quiz ended
            Student result = new Student(account.FullName);
            result.Username = account.Username;
            result.Subject = quiz.Subject;
            result.TeacherUsername = quiz.TeacherUsername;
            result.PassPercent = quiz.PassPercent;
            result.Score = correctCount;
            result.Total = quizQuestions.Count;

            AppData.Results.Add(result);

            finalPercent = result.GetPercentage();
            finalPassed = result.IsPassed();

            ShowFinishScreen();
        }

        private Label MakeFinishLabel(string text, int top, int height, Font font, Color color)
        {
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.AutoEllipsis = true;
            lbl.Text = text;
            lbl.Font = font;
            lbl.ForeColor = color;
            lbl.BackColor = Color.White;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Size = new Size(480, height);
            lbl.Location = new Point(20, top);
            return lbl;
        }

        private void ShowFinishScreen()
        {
            tmrQuestion.Stop();

            pnlExam.Visible = false;
            pnlTimer.Visible = false;
            lblTimerCaption.Visible = false;
            lblPageTitle.Text = "Quiz completed";
            lblFooterHint.Text = "Your result has been saved.     Esc Back to dashboard";

            finishHost = new Panel();
            finishHost.Dock = DockStyle.Fill;
            finishHost.BackColor = Theme.Background;
            this.Controls.Add(finishHost);
            finishHost.BringToFront();

            RoundedPanel card = new RoundedPanel();
            card.BackColor = Color.White;
            card.FillColor = Color.White;
            card.Size = new Size(520, 440);
            card.Location = new Point(270, 70);
            card.Paint += FinishCard_Paint;
            finishHost.Controls.Add(card);

            string heading = "Quiz completed";
            if (timedOut)
                heading = "Time is up";

            card.Controls.Add(MakeFinishLabel(heading, 196, 36,
                Theme.TitleFont, Theme.TextDark));

            card.Controls.Add(MakeFinishLabel("You answered " + correctCount + " of " +
                quizQuestions.Count + " questions correctly", 238, 26,
                Theme.BodyFont, Theme.TextMuted));

            card.Controls.Add(MakeFinishLabel(quiz.Title + "   |   pass mark " +
                quiz.PassPercent + "%   |   Result saved", 328, 24,
                Theme.SmallFont, Theme.TextMuted));

            ModernButton back = new ModernButton();
            back.Text = "Back to dashboard";
            back.Size = new Size(240, 46);
            back.Location = new Point(140, 372);
            back.Click += btnBack_Click;
            card.Controls.Add(back);

            this.AcceptButton = back;
            this.ActiveControl = back;
        }

        private void FinishCard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color accent;
            Color pillBack;
            Color pillText;
            string statusText;

            if (finalPassed)
            {
                accent = Theme.Success;
                pillBack = Color.FromArgb(220, 252, 231);
                pillText = Color.FromArgb(22, 101, 52);
                statusText = "Passed";
            }
            else
            {
                accent = Theme.Danger;
                pillBack = Color.FromArgb(254, 226, 226);
                pillText = Color.FromArgb(153, 27, 27);
                statusText = "Failed";
            }

            Rectangle ring = new Rectangle(195, 42, 130, 130);

            using (Pen track = new Pen(Color.FromArgb(226, 232, 240), 10))
            {
                g.DrawEllipse(track, ring);
            }

            float sweep = (float)(360.0 * finalPercent / 100.0);

            if (sweep > 0)
            {
                using (Pen arc = new Pen(accent, 10))
                {
                    arc.StartCap = LineCap.Round;
                    arc.EndCap = LineCap.Round;
                    g.DrawArc(arc, ring, -90, sweep);
                }
            }

            TextRenderer.DrawText(g, finalPercent.ToString("F0") + "%", Theme.BigNumberFont,
                ring, Theme.TextDark,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            Rectangle pill = new Rectangle(205, 282, 110, 30);

            using (GraphicsPath pillPath = Theme.RoundedRect(pill, 15))
            using (SolidBrush pillBrush = new SolidBrush(pillBack))
            {
                g.FillPath(pillBrush, pillPath);
            }

            TextRenderer.DrawText(g, statusText, Theme.BodyBoldFont, pill, pillText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}