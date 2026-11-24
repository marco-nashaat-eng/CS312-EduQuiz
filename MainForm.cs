using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class MainForm : Form
    {
        private LoginForm loginForm;
        private bool loggingOut = false;

        private KpiCard cardTeachers;
        private KpiCard cardStudents;
        private KpiCard cardAttempts;
        private KpiCard cardAverage;

        private SidebarButton btnNavStats;
        private ModernButton btnQuickStats;

        public MainForm(LoginForm login)
        {
            InitializeComponent();
            loginForm = login;
            AddStatisticsControls();
            WireEvents();
        }

        // New in V8: created in code, so the Designer is not touched
        private void AddStatisticsControls()
        {
            btnNavStats = new SidebarButton();
            btnNavStats.Text = "Statistics";
            btnNavStats.Location = new Point(18, 160);
            btnNavDashboard.Parent.Controls.Add(btnNavStats);

            btnNavResults.Location = new Point(18, 208);
            btnNavAbout.Location = new Point(18, 256);

            btnQuickStats = new ModernButton();
            btnQuickStats.Text = "Teachers and students";
            btnQuickStats.Size = new Size(250, 46);
            btnQuickStats.Location = new Point(20, 60);
            btnQuickResults.Parent.Controls.Add(btnQuickStats);

            btnQuickResults.Location = new Point(20, 116);
            btnClearLog.Location = new Point(20, 172);
        }

        private void WireEvents()
        {
            btnNavDashboard.Click += btnNavDashboard_Click;
            btnNavStats.Click += btnNavStats_Click;
            btnNavResults.Click += btnNavResults_Click;
            btnNavAbout.Click += btnNavAbout_Click;
            btnLogout.Click += btnLogout_Click;
            btnQuickStats.Click += btnQuickStats_Click;
            btnQuickResults.Click += btnQuickResults_Click;
            btnClearLog.Click += btnClearLog_Click;
            pnlAvatar.Paint += pnlAvatar_Paint;
            tmrClock.Tick += tmrClock_Tick;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetStatus("Ready");
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
            lblFooterRight.Text = "Ctrl+T Statistics   Ctrl+R Results   Ctrl+L Log out";
            txtOutput.AppendText("Admin logged in at " + DateTime.Now.ToString("HH:mm:ss") +
                Environment.NewLine);

            cardTeachers = CreateCard("Teachers", "Click for details", Theme.Primary);
            cardStudents = CreateCard("Students", "Click for details", Theme.Success);
            cardAttempts = CreateCard("Quiz attempts", "Click to view results", Theme.Warning);
            cardAverage = CreateCard("Average score", "Click to view results",
                Color.FromArgb(14, 165, 233));
            RefreshCards();

            SetActiveNav(btnNavDashboard);
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!loggingOut)
                Application.Exit();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                OpenResults();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.T)
            {
                OpenStatistics(0);
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.L)
            {
                Logout();
                e.SuppressKeyPress = true;
            }
        }

        private void pnlAvatar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (SolidBrush brush = new SolidBrush(Theme.Primary))
            {
                e.Graphics.FillEllipse(brush, 0, 0, pnlAvatar.Width - 1, pnlAvatar.Height - 1);
            }

            TextRenderer.DrawText(e.Graphics, "AD", Theme.BodyBoldFont, pnlAvatar.ClientRectangle,
                Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void SetActiveNav(SidebarButton active)
        {
            btnNavDashboard.Active = (active == btnNavDashboard);
            btnNavStats.Active = (active == btnNavStats);
            btnNavResults.Active = (active == btnNavResults);
            btnNavAbout.Active = (active == btnNavAbout);
        }

        private KpiCard CreateCard(string title, string hint, Color accent)
        {
            KpiCard card = new KpiCard();
            card.Title = title;
            card.Hint = hint;
            card.AccentColor = accent;
            card.Size = new Size(190, 112);
            card.Margin = new Padding(0, 0, 20, 0);
            card.Click += Card_Click;
            flpCards.Controls.Add(card);
            return card;
        }

        private int CountRole(string role)
        {
            int count = 0;

            foreach (UserAccount u in AppData.Users)
            {
                if (u.Role == role)
                    count++;
            }

            return count;
        }

        private void RefreshCards()
        {
            int teachers = CountRole("Teacher");
            int students = CountRole("Student");

            cardTeachers.Value = teachers.ToString();
            cardStudents.Value = students.ToString();
            cardAttempts.Value = AppData.Results.Count.ToString();

            if (AppData.Results.Count == 0)
            {
                cardAverage.Value = "-";
            }
            else
            {
                double sum = 0;

                foreach (Student s in AppData.Results)
                    sum += s.GetPercentage();

                cardAverage.Value = (sum / AppData.Results.Count).ToString("F1") + "%";
            }

            lblBannerSub.Text = teachers + " teachers   |   " + students + " students   |   " +
                AppData.Questions.Count + " questions   |   " + AppData.Results.Count + " attempts";
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (sender == cardTeachers)
                OpenStatistics(0);
            else if (sender == cardStudents)
                OpenStatistics(1);
            else
                OpenResults();
        }

        private void OpenStatistics(int tab)
        {
            SetActiveNav(btnNavStats);
            SetStatus("Opening teachers and students...");

            using (AdminStatsForm form = new AdminStatsForm(tab))
            {
                form.ShowDialog(this);
            }

            txtOutput.AppendText("Viewed teachers and students at " +
                DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine);

            SetStatus("Ready");
            RefreshCards();
            SetActiveNav(btnNavDashboard);
        }

        private void OpenResults()
        {
            SetActiveNav(btnNavResults);
            SetStatus("Opening results...");

            ResultForm form = new ResultForm();
            form.ShowDialog();

            SetStatus("Results saved so far: " + AppData.Results.Count);
            RefreshCards();
            SetActiveNav(btnNavDashboard);
        }

        private void ShowAbout()
        {
            SetActiveNav(btnNavAbout);

            AboutForm about = new AboutForm();
            about.ShowDialog();

            SetActiveNav(btnNavDashboard);
        }

        private void ConfirmExit()
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void Logout()
        {
            DialogResult result = MessageBox.Show("Do you want to log out?", "Log Out",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            loggingOut = true;
            loginForm.Show();
            loginForm.ResetForNewLogin();
            this.Close();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnNavDashboard);
            RefreshCards();
            SetStatus("Dashboard");
        }

        private void btnNavStats_Click(object sender, EventArgs e)
        {
            OpenStatistics(0);
        }

        private void btnNavResults_Click(object sender, EventArgs e)
        {
            OpenResults();
        }

        private void btnNavAbout_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ConfirmExit();
        }

        private void btnQuickStats_Click(object sender, EventArgs e)
        {
            OpenStatistics(0);
        }

        private void btnQuickResults_Click(object sender, EventArgs e)
        {
            OpenResults();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            SetStatus("Activity log cleared");
        }
    }
}