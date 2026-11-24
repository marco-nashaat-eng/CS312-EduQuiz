using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    // The student's home screen. Built entirely in code, so there is no Designer file.
    public class StudentForm : Form
    {
        private LoginForm loginForm;
        private UserAccount account;
        private string studentUser;
        private string studentName;
        private bool loggingOut = false;

        // one entry per row of the subject list
        private List<Enrollment> rows = new List<Enrollment>();

        private Panel pnlSidebar;
        private Panel pnlSideBottom;
        private Panel pnlHeader;
        private Panel pnlFooter;
        private Panel pnlContent;
        private Panel pnlUser;
        private Panel pnlAvatar;

        private SidebarButton btnNavDashboard;
        private SidebarButton btnNavEnroll;
        private SidebarButton btnNavAbout;
        private SidebarButton btnLogout;
        private SidebarButton btnExit;

        private Label lblPageTitle;
        private Label lblPageSub;
        private Label lblUserName;
        private Label lblUserRole;
        private Label lblStatus;
        private Label lblClock;

        private RoundedPanel pnlBanner;
        private Label lblBannerTitle;
        private Label lblBannerSub;
        private ModernButton btnBannerEnroll;

        private KpiCard kpiSubjects;
        private KpiCard kpiAvailable;
        private KpiCard kpiTaken;

        private RoundedPanel pnlSubjectsCard;
        private Label lblSubjectsTitle;
        private ListBox lstSubjects;
        private Label lblNoSubjects;
        private ModernButton btnStart;
        private ModernButton btnLeave;

        private RoundedPanel pnlProfile;
        private Label lblProfileTitle;

        private Timer tmrClock;

        public StudentForm(LoginForm login, UserAccount studentAccount)
        {
            loginForm = login;
            account = studentAccount;
            studentUser = account.Username;
            studentName = account.FullName;

            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Segoe UI", 10F);
            this.Text = "EduQuiz - Student dashboard";
            this.Icon = Theme.AppIcon;
            this.BackColor = Theme.Background;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1120, 680);
            this.MinimumSize = new Size(1000, 640);
            this.KeyPreview = true;

            BuildSidebar();
            BuildHeader();
            BuildFooter();
            BuildContent();

            // Order matters for docking: the content (Fill) first, the sidebar last
            this.Controls.Add(pnlContent);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(pnlSidebar);

            tmrClock = new Timer();
            tmrClock.Interval = 1000;
            tmrClock.Tick += tmrClock_Tick;

            this.Load += StudentForm_Load;
            this.KeyDown += StudentForm_KeyDown;
            this.FormClosed += StudentForm_FormClosed;
        }

        // ---------- building the screen ----------

        private Label MakeLabel(string text, Font font, Color color, Color back, int x, int y)
        {
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Text = text;
            lbl.Font = font;
            lbl.ForeColor = color;
            lbl.BackColor = back;
            lbl.Location = new Point(x, y);
            return lbl;
        }

        private SidebarButton MakeNav(string text, int y)
        {
            SidebarButton button = new SidebarButton();
            button.Text = text;
            button.Size = new Size(194, 44);
            button.Location = new Point(13, y);
            return button;
        }

        private void BuildSidebar()
        {
            pnlSidebar = new Panel();
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 220;
            pnlSidebar.BackColor = Theme.Navy;

            pnlSidebar.Controls.Add(MakeLabel("EduQuiz", Theme.HeadingFont,
                Color.White, Theme.Navy, 24, 22));
            pnlSidebar.Controls.Add(MakeLabel("Student portal", Theme.SmallFont,
                Color.FromArgb(148, 163, 184), Theme.Navy, 25, 50));

            btnNavDashboard = MakeNav("My dashboard", 100);
            btnNavEnroll = MakeNav("Enroll in a subject", 152);
            btnNavAbout = MakeNav("About", 204);
            btnNavDashboard.Active = true;

            btnNavDashboard.Click += btnNavDashboard_Click;
            btnNavEnroll.Click += btnNavEnroll_Click;
            btnNavAbout.Click += btnNavAbout_Click;

            pnlSidebar.Controls.Add(btnNavDashboard);
            pnlSidebar.Controls.Add(btnNavEnroll);
            pnlSidebar.Controls.Add(btnNavAbout);

            pnlSideBottom = new Panel();
            pnlSideBottom.Dock = DockStyle.Bottom;
            pnlSideBottom.Height = 116;
            pnlSideBottom.BackColor = Theme.Navy;

            btnLogout = MakeNav("Log out", 8);
            btnExit = MakeNav("Exit", 60);
            btnLogout.Click += btnLogout_Click;
            btnExit.Click += btnExit_Click;

            pnlSideBottom.Controls.Add(btnLogout);
            pnlSideBottom.Controls.Add(btnExit);
            pnlSidebar.Controls.Add(pnlSideBottom);
        }

        private void BuildHeader()
        {
            pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 72;
            pnlHeader.BackColor = Color.White;

            lblPageTitle = MakeLabel("My dashboard", Theme.TitleFont, Theme.TextDark,
                Color.White, 28, 6);
            lblPageSub = MakeLabel("Your subjects, teachers and quizzes", Theme.SmallFont,
                Theme.TextMuted, Color.White, 30, 44);
            pnlHeader.Controls.Add(lblPageTitle);
            pnlHeader.Controls.Add(lblPageSub);

            pnlUser = new Panel();
            pnlUser.Size = new Size(260, 48);
            pnlUser.BackColor = Color.White;

            pnlAvatar = new Panel();
            pnlAvatar.SetBounds(0, 4, 40, 40);
            pnlAvatar.BackColor = Color.White;
            pnlAvatar.Paint += pnlAvatar_Paint;
            pnlUser.Controls.Add(pnlAvatar);

            lblUserName = MakeLabel(studentName, Theme.BodyBoldFont, Theme.TextDark,
                Color.White, 52, 4);
            lblUserName.AutoSize = false;
            lblUserName.Size = new Size(206, 20);
            lblUserName.AutoEllipsis = true;
            pnlUser.Controls.Add(lblUserName);

            lblUserRole = MakeLabel("Student", Theme.SmallFont, Theme.TextMuted,
                Color.White, 52, 25);
            pnlUser.Controls.Add(lblUserRole);

            pnlHeader.Controls.Add(pnlUser);

            pnlHeader.SizeChanged += (s, e) =>
            {
                pnlUser.Location = new Point(pnlHeader.Width - pnlUser.Width - 28, 12);
            };

            pnlHeader.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.Border))
                {
                    e.Graphics.DrawLine(p, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
                }
            };
        }

        private void BuildFooter()
        {
            pnlFooter = new Panel();
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Height = 34;
            pnlFooter.BackColor = Color.White;

            lblStatus = new Label();
            lblStatus.AutoSize = false;
            lblStatus.SetBounds(28, 0, 500, 34);
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.Font = Theme.SmallFont;
            lblStatus.ForeColor = Theme.TextMuted;
            lblStatus.BackColor = Color.White;
            lblStatus.Text = "Ready";
            pnlFooter.Controls.Add(lblStatus);

            lblClock = new Label();
            lblClock.AutoSize = false;
            lblClock.Size = new Size(300, 34);
            lblClock.TextAlign = ContentAlignment.MiddleRight;
            lblClock.Font = Theme.SmallFont;
            lblClock.ForeColor = Theme.TextMuted;
            lblClock.BackColor = Color.White;
            pnlFooter.Controls.Add(lblClock);

            pnlFooter.SizeChanged += (s, e) =>
            {
                lblClock.Location = new Point(pnlFooter.Width - lblClock.Width - 28, 0);
            };

            pnlFooter.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.Border))
                {
                    e.Graphics.DrawLine(p, 0, 0, pnlFooter.Width, 0);
                }
            };
        }

        private void BuildContent()
        {
            pnlContent = new Panel();
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.BackColor = Theme.Background;

            // Banner
            pnlBanner = new RoundedPanel();
            pnlBanner.BackColor = Theme.Background;
            pnlBanner.FillColor = Theme.Primary;
            pnlBanner.BorderColor = Theme.Primary;

            lblBannerTitle = MakeLabel("Welcome", Theme.TitleFont, Color.White, Theme.Primary, 28, 14);
            lblBannerSub = MakeLabel("", Theme.BodyFont, Color.FromArgb(199, 210, 254),
                Theme.Primary, 30, 54);
            pnlBanner.Controls.Add(lblBannerTitle);
            pnlBanner.Controls.Add(lblBannerSub);

            btnBannerEnroll = new ModernButton();
            btnBannerEnroll.Text = "Enroll in a subject";
            btnBannerEnroll.Kind = ButtonKind.Secondary;
            btnBannerEnroll.Size = new Size(190, 42);
            btnBannerEnroll.Click += btnNavEnroll_Click;
            pnlBanner.Controls.Add(btnBannerEnroll);

            pnlContent.Controls.Add(pnlBanner);

            // Three number cards
            kpiSubjects = new KpiCard();
            kpiSubjects.Title = "Enrolled subjects";
            kpiSubjects.AccentColor = Theme.Primary;
            kpiSubjects.Click += btnNavEnroll_Click;

            kpiAvailable = new KpiCard();
            kpiAvailable.Title = "Quizzes available";
            kpiAvailable.AccentColor = Theme.Success;
            kpiAvailable.Click += kpiAvailable_Click;

            kpiTaken = new KpiCard();
            kpiTaken.Title = "Quizzes taken";
            kpiTaken.AccentColor = Theme.Warning;

            pnlContent.Controls.Add(kpiSubjects);
            pnlContent.Controls.Add(kpiAvailable);
            pnlContent.Controls.Add(kpiTaken);

            // My subjects card
            pnlSubjectsCard = new RoundedPanel();
            pnlSubjectsCard.BackColor = Theme.Background;
            pnlSubjectsCard.FillColor = Color.White;

            lblSubjectsTitle = MakeLabel("My subjects", Theme.HeadingFont, Theme.TextDark,
                Color.White, 20, 14);
            pnlSubjectsCard.Controls.Add(lblSubjectsTitle);

            lstSubjects = new ListBox();
            lstSubjects.DrawMode = DrawMode.OwnerDrawFixed;
            lstSubjects.ItemHeight = 68;
            lstSubjects.BorderStyle = BorderStyle.None;
            lstSubjects.IntegralHeight = false;
            lstSubjects.BackColor = Color.White;
            lstSubjects.DrawItem += lstSubjects_DrawItem;
            lstSubjects.SelectedIndexChanged += lstSubjects_SelectedIndexChanged;
            lstSubjects.DoubleClick += lstSubjects_DoubleClick;
            pnlSubjectsCard.Controls.Add(lstSubjects);

            lblNoSubjects = new Label();
            lblNoSubjects.AutoSize = false;
            lblNoSubjects.TextAlign = ContentAlignment.MiddleCenter;
            lblNoSubjects.Font = Theme.BodyFont;
            lblNoSubjects.ForeColor = Theme.TextMuted;
            lblNoSubjects.BackColor = Color.White;
            lblNoSubjects.Text = "You are not enrolled in any subject yet.\r\n" +
                "Click \"Enroll in a subject\" to pick a subject and your teacher.";
            pnlSubjectsCard.Controls.Add(lblNoSubjects);

            btnStart = new ModernButton();
            btnStart.Text = "Start quiz";
            btnStart.Size = new Size(140, 42);
            btnStart.Click += btnStart_Click;
            pnlSubjectsCard.Controls.Add(btnStart);

            btnLeave = new ModernButton();
            btnLeave.Text = "Leave subject";
            btnLeave.Kind = ButtonKind.Danger;
            btnLeave.Size = new Size(150, 42);
            btnLeave.Click += btnLeave_Click;
            pnlSubjectsCard.Controls.Add(btnLeave);

            pnlContent.Controls.Add(pnlSubjectsCard);

            // Profile card
            pnlProfile = new RoundedPanel();
            pnlProfile.BackColor = Theme.Background;
            pnlProfile.FillColor = Color.White;
            pnlProfile.Paint += pnlProfile_Paint;
            pnlProfile.MouseMove += pnlProfile_MouseMove;
            pnlProfile.MouseClick += pnlProfile_MouseClick;

            lblProfileTitle = MakeLabel("My profile", Theme.HeadingFont, Theme.TextDark,
                Color.White, 20, 14);
            pnlProfile.Controls.Add(lblProfileTitle);

            pnlContent.Controls.Add(pnlProfile);

            pnlContent.SizeChanged += (s, e) => LayoutContent();
        }

        // Every size and position is worked out from the real window size
        private void LayoutContent()
        {
            int w = pnlContent.ClientSize.Width;
            int h = pnlContent.ClientSize.Height;
            int margin = 28;
            int gap = 20;
            int inner = w - 2 * margin;

            if (inner < 600 || h < 300)
                return;

            pnlBanner.SetBounds(margin, 20, inner, 88);
            btnBannerEnroll.Location = new Point(pnlBanner.Width - btnBannerEnroll.Width - 24,
                (pnlBanner.Height - btnBannerEnroll.Height) / 2);

            int cardW = (inner - 2 * gap) / 3;
            kpiSubjects.SetBounds(margin, 124, cardW, 112);
            kpiAvailable.SetBounds(margin + cardW + gap, 124, cardW, 112);
            kpiTaken.SetBounds(margin + 2 * (cardW + gap), 124, inner - 2 * cardW - 2 * gap, 112);

            int top = 252;
            int cardH = h - top - 20;
            if (cardH < 200)
                cardH = 200;

            int profileW = 320;
            pnlSubjectsCard.SetBounds(margin, top, inner - profileW - gap, cardH);
            pnlProfile.SetBounds(margin + inner - profileW, top, profileW, cardH);

            int cw = pnlSubjectsCard.Width;
            int ch = pnlSubjectsCard.Height;

            lstSubjects.SetBounds(1, 52, cw - 2, ch - 52 - 64);
            lblNoSubjects.SetBounds(20, 70, cw - 40, 110);
            btnStart.Location = new Point(20, ch - 54);
            btnLeave.Location = new Point(20 + btnStart.Width + 12, ch - 54);
        }

        // ---------- loading and refreshing ----------

        private void StudentForm_Load(object sender, EventArgs e)
        {
            LayoutContent();
            RefreshAll();

            if (lstSubjects.Items.Count > 0)
                lstSubjects.SelectedIndex = 0;

            tmrClock_Tick(null, EventArgs.Empty);
            tmrClock.Start();
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("ddd, dd MMM yyyy   HH:mm:ss");
        }

        private Enrollment SelectedEnrollment()
        {
            int i = lstSubjects.SelectedIndex;

            if (i < 0 || i >= rows.Count)
                return null;

            return rows[i];
        }

        private void RefreshAll()
        {
            Enrollment current = SelectedEnrollment();
            string keep = "";
            if (current != null)
                keep = current.Subject;

            rows.Clear();
            lstSubjects.Items.Clear();

            foreach (Enrollment item in AppData.Enrollments)
            {
                if (item.StudentUsername == studentUser)
                {
                    rows.Add(item);
                    lstSubjects.Items.Add(item.Subject);
                }
            }

            int available = 0;
            int taken = 0;
            double sum = 0;

            for (int i = 0; i < rows.Count; i++)
            {
                if (AppData.IsQuizAvailable(rows[i].TeacherUsername, rows[i].Subject))
                    available++;

                Student last = AppData.LastResult(studentUser, rows[i].Subject, rows[i].TeacherUsername);

                if (last != null)
                {
                    taken++;
                    sum += last.GetPercentage();
                }

                if (rows[i].Subject == keep)
                    lstSubjects.SelectedIndex = i;
            }

            kpiSubjects.Value = rows.Count.ToString();
            kpiSubjects.Hint = "Click to enroll in more";

            kpiAvailable.Value = available.ToString();
            if (available > 0)
                kpiAvailable.Hint = "Ready to start";
            else
                kpiAvailable.Hint = "No quiz available";

            kpiTaken.Value = taken.ToString();
            if (taken > 0)
                kpiTaken.Hint = "Average " + (sum / taken).ToString("F0") + "%";
            else
                kpiTaken.Hint = "No results yet";

            string firstName = studentName.Trim().Split(' ')[0];
            lblBannerTitle.Text = "Welcome back, " + firstName;

            if (rows.Count == 0)
                lblBannerSub.Text = "Enroll in a subject to get started.";
            else if (available == 0)
                lblBannerSub.Text = "You are enrolled in " + rows.Count + " subject(s). " +
                    "No quiz is available right now.";
            else
                lblBannerSub.Text = "You are enrolled in " + rows.Count + " subject(s) and " +
                    available + " quiz(zes) are ready to start.";

            bool empty = (rows.Count == 0);
            lblNoSubjects.Visible = empty;
            lstSubjects.Visible = !empty;
            btnStart.Enabled = !empty && SelectedEnrollment() != null;
            btnLeave.Enabled = btnStart.Enabled;

            pnlProfile.Invalidate();
            lstSubjects.Invalidate();
        }

        private void SetStatus(string text)
        {
            lblStatus.Text = text;
        }

        private void SetActiveNav(SidebarButton active)
        {
            btnNavDashboard.Active = (active == btnNavDashboard);
            btnNavEnroll.Active = (active == btnNavEnroll);
            btnNavAbout.Active = (active == btnNavAbout);
        }

        // ---------- actions ----------

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnNavDashboard);
            RefreshAll();
            SetStatus("Ready");
        }

        private void btnNavEnroll_Click(object sender, EventArgs e)
        {
            OpenEnroll();
        }

        private void btnNavAbout_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnNavAbout);

            AboutForm about = new AboutForm();
            about.ShowDialog();

            SetActiveNav(btnNavDashboard);
        }

        private void kpiAvailable_Click(object sender, EventArgs e)
        {
            // jump to the first subject that has a quiz ready
            for (int i = 0; i < rows.Count; i++)
            {
                if (AppData.IsQuizAvailable(rows[i].TeacherUsername, rows[i].Subject))
                {
                    lstSubjects.SelectedIndex = i;
                    SetStatus("Selected " + rows[i].Subject + ". Click Start quiz when you are ready.");
                    return;
                }
            }

            SetStatus("No quiz is available right now.");
        }

        private void OpenEnroll()
        {
            if (AppData.EnrollableSubjects(studentUser).Count == 0)
            {
                MessageBox.Show("You are already enrolled in every available subject.",
                    "Enroll in a subject", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SetActiveNav(btnNavEnroll);

            string enrolled = "";

            using (EnrollForm form = new EnrollForm(studentUser))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    enrolled = form.EnrolledSubject;
            }

            RefreshAll();

            if (enrolled != "")
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    if (rows[i].Subject == enrolled)
                        lstSubjects.SelectedIndex = i;
                }

                SetStatus("You are now enrolled in " + enrolled + ".");
            }
            else
            {
                SetStatus("Ready");
            }

            SetActiveNav(btnNavDashboard);
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            Enrollment en = SelectedEnrollment();

            if (en == null)
                return;

            DialogResult result = MessageBox.Show(
                "Leave " + en.Subject + " with " + AppData.DisplayName(en.TeacherUsername) + "?\n" +
                "Your past results are kept.",
                "Leave subject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            AppData.Unenroll(studentUser, en.Subject);
            RefreshAll();
            SetStatus("You left " + en.Subject + ".");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartSelectedQuiz();
        }

        private void lstSubjects_DoubleClick(object sender, EventArgs e)
        {
            StartSelectedQuiz();
        }

        // TEMPORARY: stage V6b replaces this method with the real Start / Quit window
        // Start quiz: the info popup first, then the quiz itself
        private void StartSelectedQuiz()
        {
            Enrollment en = SelectedEnrollment();

            if (en == null)
            {
                SetStatus("Select a subject first.");
                return;
            }

            bool start = false;

            using (QuizInfoForm info = new QuizInfoForm(studentUser, en))
            {
                start = (info.ShowDialog(this) == DialogResult.OK);
            }

            if (!start)
            {
                SetStatus("Ready");
                return;
            }

            QuizConfig quiz = AppData.FindQuiz(en.TeacherUsername, en.Subject);

            if (quiz == null)
            {
                RefreshAll();
                return;
            }

            int before = AppData.Results.Count;

            SetStatus("Quiz in progress...");

            using (QuizForm form = new QuizForm(account, quiz))
            {
                form.ShowDialog(this);
            }

            RefreshAll();

            if (AppData.Results.Count > before)
                SetStatus("Result saved. Well done!");
            else
                SetStatus("Quiz quit. No result was saved.");
        }

        

        private void lstSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool has = (SelectedEnrollment() != null);
            btnStart.Enabled = has;
            btnLeave.Enabled = has;
        }

        // ---------- log out / exit ----------

        private void btnLogout_Click(object sender, EventArgs e)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit EduQuiz?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.Close();
        }

        private void StudentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                OpenEnroll();
                e.SuppressKeyPress = true;
            }
        }

        private void StudentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrClock.Stop();

            if (!loggingOut)
                Application.Exit();
        }

        // ---------- drawing ----------

        private string Initial()
        {
            string name = studentName.Trim();

            if (name == "")
                return "S";

            return name.Substring(0, 1).ToUpper();
        }

        private void pnlAvatar_Paint(object sender, PaintEventArgs e)
        {
            AvatarPainter.Draw(e.Graphics, new Rectangle(0, 0, 38, 38), account.Photo, Initial(), Theme.BodyBoldFont);
        }

        private void lstSubjects_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= rows.Count)
                return;

            Enrollment en = rows[e.Index];
            Graphics g = e.Graphics;
            Rectangle b = e.Bounds;
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            bool available = AppData.IsQuizAvailable(en.TeacherUsername, en.Subject);

            Color back = Color.White;
            if (selected)
                back = Color.FromArgb(238, 242, 255);

            using (SolidBrush brush = new SolidBrush(back))
            {
                g.FillRectangle(brush, b);
            }

            if (selected)
            {
                using (SolidBrush bar = new SolidBrush(Theme.Primary))
                {
                    g.FillRectangle(bar, b.X, b.Y, 4, b.Height);
                }
            }

            using (Pen line = new Pen(Theme.Border))
            {
                g.DrawLine(line, b.X, b.Bottom - 1, b.Right, b.Bottom - 1);
            }

            int textWidth = b.Width - 20 - 170;

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix;

            TextRenderer.DrawText(g, en.Subject, Theme.BodyBoldFont,
                new Rectangle(b.X + 20, b.Y + 8, textWidth, 20), Theme.TextDark, flags);

            TextRenderer.DrawText(g, "Teacher: " + AppData.DisplayName(en.TeacherUsername),
                Theme.SmallFont, new Rectangle(b.X + 20, b.Y + 29, textWidth, 16),
                Theme.TextMuted, flags);

            TextRenderer.DrawText(g, QuizLine(en), Theme.SmallFont,
                new Rectangle(b.X + 20, b.Y + 46, textWidth, 16), Theme.TextMuted, flags);

            // Quiz availability pill
            Color pillBack = Color.FromArgb(241, 245, 249);
            Color pillText = Color.FromArgb(71, 85, 105);
            string text = "No quiz available";

            if (available)
            {
                pillBack = Color.FromArgb(220, 252, 231);
                pillText = Color.FromArgb(22, 101, 52);
                text = "Quiz available";
            }

            Rectangle pill = new Rectangle(b.Right - 160, b.Y + (b.Height - 28) / 2, 144, 28);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = Theme.RoundedRect(pill, 14))
            using (SolidBrush pillBrush = new SolidBrush(pillBack))
            {
                g.FillPath(pillBrush, path);
            }

            TextRenderer.DrawText(g, text, Theme.SmallFont, pill, pillText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private string QuizLine(Enrollment en)
        {
            QuizConfig quiz = AppData.FindQuiz(en.TeacherUsername, en.Subject);
            string text;

            if (quiz == null)
                text = "Your teacher has not created a quiz yet";
            else if (!quiz.IsOpen)
                text = quiz.Title + "  |  closed by your teacher";
            else if (!AppData.IsQuizAvailable(en.TeacherUsername, en.Subject))
                text = quiz.Title + "  |  teacher is still adding questions";
            else
                text = quiz.Title + "  |  " + quiz.QuestionCount + " questions  |  " +
                    quiz.DurationMinutes + " min";

            Student last = AppData.LastResult(studentUser, en.Subject, en.TeacherUsername);

            if (last != null)
                text += "  |  last score " + last.GetPercentage().ToString("F0") + "%";

            return text;
        }

        // ---------- profile photo ----------

        private Rectangle AvatarRect()
        {
            return new Rectangle(24, 56, 60, 60);
        }

        private void pnlProfile_MouseMove(object sender, MouseEventArgs e)
        {
            if (AvatarRect().Contains(e.Location))
                pnlProfile.Cursor = Cursors.Hand;
            else
                pnlProfile.Cursor = Cursors.Default;
        }

        private void pnlProfile_MouseClick(object sender, MouseEventArgs e)
        {
            if (AvatarRect().Contains(e.Location))
                ChangePhoto();
        }

        private void ChangePhoto()
        {
            using (PhotoEditorForm form = new PhotoEditorForm(account, Initial()))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    pnlAvatar.Invalidate();
                    pnlProfile.Invalidate();
                    SetStatus("Profile photo updated.");
                }
            }
        }
        private void pnlProfile_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = pnlProfile.Width;

            Rectangle avatar = AvatarRect();

            AvatarPainter.Draw(g, avatar, account.Photo, Initial(), Theme.HeadingFont);
            AvatarPainter.DrawEditBadge(g, avatar);

            TextFormatFlags left = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix;

            TextRenderer.DrawText(g, studentName, Theme.HeadingFont,
                new Rectangle(98, 60, w - 114, 28), Theme.TextDark, left);
            TextRenderer.DrawText(g, "@" + studentUser, Theme.SmallFont,
                new Rectangle(98, 88, w - 114, 22), Theme.TextMuted, left);

            using (Pen line = new Pen(Theme.Border))
            {
                g.DrawLine(line, 24, 132, w - 24, 132);
            }

            // number of different teachers
            List<string> teacherNames = new List<string>();
            foreach (Enrollment en in rows)
            {
                if (!teacherNames.Contains(en.TeacherUsername))
                    teacherNames.Add(en.TeacherUsername);
            }

            string teachersText = "None yet";
            if (teacherNames.Count == 1)
                teachersText = "1 teacher";
            else if (teacherNames.Count > 1)
                teachersText = teacherNames.Count + " teachers";

            string[] labels = { "Email", "Member since", "Teachers" };
            string[] values =
            {
                account.Email,
                account.CreatedAt.ToString("dd MMM yyyy"),
                teachersText
            };

            int y = 146;

            for (int i = 0; i < labels.Length; i++)
            {
                if (y + 40 > pnlProfile.Height - 6)
                    break;

                TextRenderer.DrawText(g, labels[i], Theme.SmallFont,
                    new Rectangle(24, y, w - 48, 18), Theme.TextMuted, left);
                TextRenderer.DrawText(g, values[i], Theme.BodyFont,
                    new Rectangle(24, y + 18, w - 48, 22), Theme.TextDark, left);

                y += 46;
            }
        }
    }
}