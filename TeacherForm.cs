using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    public partial class TeacherForm : Form
    {
        // One line of the "My subjects" list
        private class SubjectRow
        {
            public string Name = "";
            public string Meta = "";
            public string Status = "";
            public Color PillBack = Color.White;
            public Color PillText = Color.Black;
        }

        private LoginForm loginForm;
        private UserAccount teacher;
        private string teacherUser;
        private string teacherName;
        private string initials;
        private bool loggingOut = false;

        private List<SubjectRow> rows = new List<SubjectRow>();
        private Timer tmrClock = new Timer();

        private KpiCard cardSubjects;
        private KpiCard cardStudents;
        private KpiCard cardQuestions;
        private KpiCard cardQuizzes;

        // Controls created in code
        private ModernButton btnAddSubject;
        private Label lblSubjectsHint;

        public TeacherForm(LoginForm login, UserAccount account)
        {
            InitializeComponent();
            this.Icon = Theme.AppIcon;
            this.KeyPreview = true;

            loginForm = login;
            teacher = account;
            teacherUser = account.Username;
            teacherName = account.FullName;
            initials = GetInitials(teacherName);

            // Colors the custom buttons use for their corners
            pnlBanner.BackColor = Theme.Primary;
            pnlSubjectsCard.BackColor = Color.White;
            pnlProfile.BackColor = Color.White;

            lstSubjects.DrawMode = DrawMode.OwnerDrawFixed;
            lstSubjects.ItemHeight = 56;
            lstSubjects.IntegralHeight = false;

            CreateExtraControls();

            // This form positions its panels by code (LayoutAll),
            // so the Designer anchors are switched off first.
            FreezeAnchors();
            this.ClientSize = new Size(1120, 660);
            this.PerformLayout();
            LayoutAll();

            WireEvents();
            this.SizeChanged += TeacherForm_SizeChanged;
        }

        private void CreateExtraControls()
        {
            btnAddSubject = new ModernButton();
            btnAddSubject.Text = "+ Add subject";
            btnAddSubject.Kind = ButtonKind.Secondary;
            btnAddSubject.Size = new Size(140, 34);
            pnlSubjectsCard.Controls.Add(btnAddSubject);

            lblSubjectsHint = new Label();
            lblSubjectsHint.AutoSize = true;
            lblSubjectsHint.Text = "Right-click a subject for options";
            lblSubjectsHint.Font = Theme.SmallFont;
            lblSubjectsHint.ForeColor = Theme.TextMuted;
            lblSubjectsHint.BackColor = Color.Transparent;
            lblSubjectsHint.Location = new Point(136, 24);
            pnlSubjectsCard.Controls.Add(lblSubjectsHint);
        }

        private void FreezeAnchors()
        {
            Control[] moving = new Control[]
            {
                btnLogout, btnExit, pnlAvatar, lblUserName, lblUserRole, lblClock,
                lblFooterRight, pnlBanner, btnBannerCreate, flpCards, pnlSubjectsCard,
                lstSubjects, pnlProfile, btnViewResults
            };

            foreach (Control c in moving)
                c.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        private void TeacherForm_SizeChanged(object sender, EventArgs e)
        {
            LayoutAll();
        }

        // Places everything that sits near an edge, based on the real window size
        private void LayoutAll()
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;

            // Sidebar: the two bottom buttons stay near the bottom
            int sideH = pnlSidebar.Height;
            btnLogout.Location = new Point(18, sideH - 112);
            btnExit.Location = new Point(18, sideH - 62);

            // Header: avatar, name and clock stay at the right edge
            int headW = pnlHeader.Width;
            pnlAvatar.Location = new Point(headW - 28 - 40, 16);
            lblUserName.Location = new Point(pnlAvatar.Left - 160, 14);
            lblUserRole.Location = new Point(pnlAvatar.Left - 160, 36);
            lblClock.Location = new Point(pnlAvatar.Left - 276, 25);

            // Footer
            lblFooterRight.Location = new Point(pnlFooter.Width - 28 - 420, 8);

            // Content area
            int w = pnlContent.Width;
            int h = pnlContent.Height;

            pnlBanner.SetBounds(28, 24, Math.Max(w - 56, 300), 84);
            btnBannerCreate.Location = new Point(pnlBanner.Width - 24 - btnBannerCreate.Width, 20);
            flpCards.SetBounds(28, 128, Math.Max(w - 56, 300), 112);

            int profileW = 290;
            int cardsTop = 264;
            int cardsH = Math.Max(h - cardsTop - 28, 200);
            int profileX = w - 28 - profileW;

            pnlSubjectsCard.SetBounds(28, cardsTop, Math.Max(profileX - 24 - 28, 300), cardsH);
            pnlProfile.SetBounds(profileX, cardsTop, profileW, cardsH);

            lstSubjects.SetBounds(20, 52, pnlSubjectsCard.Width - 40, pnlSubjectsCard.Height - 72);
            lblNoSubjects.SetBounds(20, 110, pnlSubjectsCard.Width - 40, 60);
            btnAddSubject.Location = new Point(pnlSubjectsCard.Width - 20 - btnAddSubject.Width, 11);
            btnViewResults.SetBounds(20, pnlProfile.Height - 50, 250, 40);

            // The four cards share the row width equally
            KpiCard[] cards = new KpiCard[] { cardSubjects, cardStudents, cardQuestions, cardQuizzes };
            int cardWidth = (flpCards.Width - 3 * 18) / 4;

            foreach (KpiCard card in cards)
            {
                if (card != null)
                    card.Width = cardWidth;
            }

            pnlProfile.Invalidate();
        }

        private void WireEvents()
        {
            this.Load += TeacherForm_Load;
            this.FormClosed += TeacherForm_FormClosed;
            this.KeyDown += TeacherForm_KeyDown;
            tmrClock.Tick += tmrClock_Tick;

            btnNavDashboard.Click += btnNavDashboard_Click;
            btnNavQuiz.Click += btnNavQuiz_Click;
            btnNavResults.Click += btnNavResults_Click;
            btnNavAbout.Click += btnNavAbout_Click;
            btnLogout.Click += btnLogout_Click;
            btnExit.Click += btnExit_Click;
            btnBannerCreate.Click += btnBannerCreate_Click;
            btnViewResults.Click += btnViewResults_Click;
            btnAddSubject.Click += btnAddSubject_Click;

            pnlAvatar.Paint += pnlAvatar_Paint;
            pnlProfile.Paint += pnlProfile_Paint;
            pnlProfile.MouseMove += pnlProfile_MouseMove;
            pnlProfile.MouseClick += pnlProfile_MouseClick;
            lstSubjects.DrawItem += lstSubjects_DrawItem;
            lstSubjects.MouseDown += lstSubjects_MouseDown;
            lstSubjects.MouseDoubleClick += lstSubjects_MouseDoubleClick;
            lstSubjects.KeyDown += lstSubjects_KeyDown;
        }

        // ---------- Form events ----------

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = teacherName;
            lblUserRole.Text = "Teacher";
            lblBannerTitle.Text = "Welcome back, " + teacherName;
            lblBannerSub.Text = "Manage your subjects, quizzes and your students' results";
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");

            cardSubjects = CreateCard("My subjects", "Subjects you teach", Theme.Primary, false);
            cardStudents = CreateCard("My students", "Click to view results", Theme.Success, true);
            cardQuestions = CreateCard("My questions", "Click to add more", Theme.Warning, true);
            cardQuizzes = CreateCard("Quizzes ready", "Open for students", Color.FromArgb(14, 165, 233), false);
            cardQuizzes.Margin = new Padding(0);
            LayoutAll();

            tmrClock.Interval = 1000;
            tmrClock.Start();

            RefreshAll();
            SetActiveNav(btnNavDashboard);
            SetStatus("Ready");
        }

        private void tmrClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void TeacherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrClock.Stop();
            tmrClock.Dispose();

            if (!loggingOut)
                Application.Exit();
        }

        private void TeacherForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                CreateQuizFlow();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.R)
            {
                OpenResults();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.L)
            {
                Logout();
                e.SuppressKeyPress = true;
            }
        }

        // ---------- Helpers ----------

        private string GetInitials(string name)
        {
            string[] parts = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 0)
                return "?";

            if (parts.Length == 1)
                return parts[0].Substring(0, 1).ToUpper();

            return (parts[0].Substring(0, 1) + parts[1].Substring(0, 1)).ToUpper();
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void SetActiveNav(SidebarButton active)
        {
            btnNavDashboard.Active = (active == btnNavDashboard);
            btnNavQuiz.Active = (active == btnNavQuiz);
            btnNavResults.Active = (active == btnNavResults);
            btnNavAbout.Active = (active == btnNavAbout);
        }

        private KpiCard CreateCard(string title, string hint, Color accent, bool clickable)
        {
            KpiCard card = new KpiCard();
            card.Title = title;
            card.Hint = hint;
            card.AccentColor = accent;
            card.Size = new Size(195, 112);
            card.Margin = new Padding(0, 0, 18, 0);

            if (clickable)
                card.Click += Card_Click;
            else
                card.Cursor = Cursors.Default;

            flpCards.Controls.Add(card);
            return card;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (sender == cardStudents)
                OpenResults();
            else if (sender == cardQuestions)
                OpenQuestionForm("");
        }

        private string SelectedSubject()
        {
            int index = lstSubjects.SelectedIndex;

            if (index < 0 || index >= rows.Count)
                return "";

            return rows[index].Name;
        }

        // ---------- Data ----------

        private void RefreshAll()
        {
            RefreshCards();
            RefreshSubjects();
            pnlProfile.Invalidate();
        }

        private void RefreshCards()
        {
            List<string> mySubjects = AppData.SubjectsOf(teacherUser);

            List<string> students = new List<string>();

            foreach (Enrollment en in AppData.EnrollmentsOfTeacher(teacherUser))
            {
                if (!students.Contains(en.StudentUsername))
                    students.Add(en.StudentUsername);
            }

            int questions = 0;

            foreach (Question q in AppData.Questions)
            {
                if (q.Owner == teacherUser)
                    questions++;
            }

            int ready = 0;

            foreach (string subject in mySubjects)
            {
                if (AppData.IsQuizAvailable(teacherUser, subject))
                    ready++;
            }

            cardSubjects.Value = mySubjects.Count.ToString();
            cardStudents.Value = students.Count.ToString();
            cardQuestions.Value = questions.ToString();
            cardQuizzes.Value = ready.ToString();
        }

        private void RefreshSubjects()
        {
            string keepSelected = SelectedSubject();

            rows.Clear();
            lstSubjects.Items.Clear();

            List<Enrollment> mine = AppData.EnrollmentsOfTeacher(teacherUser);

            foreach (string subject in AppData.SubjectsOf(teacherUser))
            {
                SubjectRow row = new SubjectRow();
                row.Name = subject;

                int students = 0;

                foreach (Enrollment en in mine)
                {
                    if (en.Subject == subject)
                        students++;
                }

                int questions = AppData.QuestionsOf(teacherUser, subject).Count;
                QuizConfig quiz = AppData.FindQuiz(teacherUser, subject);

                string meta = students + (students == 1 ? " student" : " students") + "   |   " +
                    questions + (questions == 1 ? " question" : " questions");

                if (quiz == null)
                {
                    row.Status = "No quiz yet";
                    row.PillBack = Color.FromArgb(241, 245, 249);
                    row.PillText = Color.FromArgb(71, 85, 105);
                }
                else
                {
                    meta += "   |   quiz needs " + quiz.QuestionCount;

                    if (!quiz.IsOpen)
                    {
                        row.Status = "Closed";
                        row.PillBack = Color.FromArgb(254, 243, 199);
                        row.PillText = Color.FromArgb(146, 64, 14);
                    }
                    else if (questions >= quiz.QuestionCount)
                    {
                        row.Status = "Quiz ready";
                        row.PillBack = Color.FromArgb(220, 252, 231);
                        row.PillText = Color.FromArgb(22, 101, 52);
                    }
                    else
                    {
                        row.Status = "Needs " + (quiz.QuestionCount - questions) + " more";
                        row.PillBack = Color.FromArgb(254, 243, 199);
                        row.PillText = Color.FromArgb(146, 64, 14);
                    }
                }

                row.Meta = meta;
                rows.Add(row);
                lstSubjects.Items.Add(row.Name);
            }

            if (keepSelected != "")
            {
                int index = lstSubjects.Items.IndexOf(keepSelected);

                if (index >= 0)
                    lstSubjects.SelectedIndex = index;
            }

            bool empty = (rows.Count == 0);
            lblNoSubjects.Visible = empty;
            lstSubjects.Visible = !empty;
        }

        // ---------- Drawing ----------

        private void pnlAvatar_Paint(object sender, PaintEventArgs e)
        {
            AvatarPainter.Draw(e.Graphics, new Rectangle(0, 0, pnlAvatar.Width - 1, pnlAvatar.Height - 1),
                teacher.Photo, initials, Theme.BodyBoldFont);
        }

        // ---------- profile photo ----------

        private Rectangle AvatarRect()
        {
            return new Rectangle(20, 52, 52, 52);
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
            using (PhotoEditorForm form = new PhotoEditorForm(teacher, initials))
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

            Rectangle avatar = AvatarRect();

            AvatarPainter.Draw(g, avatar, teacher.Photo, initials, Theme.HeadingFont);
            AvatarPainter.DrawEditBadge(g, avatar);

            TextFormatFlags left = TextFormatFlags.Left | TextFormatFlags.EndEllipsis |
                TextFormatFlags.NoPrefix;

            TextRenderer.DrawText(g, teacherName, Theme.BodyBoldFont,
                new Rectangle(84, 56, 190, 24), Theme.TextDark, left);

            TextRenderer.DrawText(g,
                "@" + teacherUser + "  |  since " + teacher.CreatedAt.ToString("MMM yyyy"),
                Theme.SmallFont, new Rectangle(84, 80, 190, 20), Theme.TextMuted, left);

            using (Pen line = new Pen(Theme.Border))
            {
                g.DrawLine(line, 20, 118, 270, 118);
            }

            string subjects = string.Join(", ", AppData.SubjectsOf(teacherUser).ToArray());

            if (subjects == "")
                subjects = "-";

            TextRenderer.DrawText(g, "EMAIL", Theme.SmallFont, new Point(20, 126), Theme.TextMuted);
            TextRenderer.DrawText(g, teacher.Email, Theme.BodyFont,
                new Rectangle(20, 142, 250, 22), Theme.TextDark, left);

            TextRenderer.DrawText(g, "TEACHES", Theme.SmallFont, new Point(20, 168), Theme.TextMuted);
            TextRenderer.DrawText(g, subjects, Theme.BodyFont,
                new Rectangle(20, 184, 250, 22), Theme.TextDark, left);
        }

        // The small "..." button at the right end of each subject row
        private Rectangle MoreButtonRect(Rectangle item)
        {
            return new Rectangle(item.Right - 16 - 30, item.Y + 13, 30, 30);
        }

        private void lstSubjects_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= rows.Count)
                return;

            SubjectRow row = rows[e.Index];
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

            Rectangle more = MoreButtonRect(e.Bounds);
            Rectangle pillRect = new Rectangle(more.Left - 10 - 112, e.Bounds.Y + 16, 112, 24);
            int textWidth = pillRect.Left - (e.Bounds.X + 16) - 10;

            Rectangle nameRect = new Rectangle(e.Bounds.X + 16, e.Bounds.Y + 8, textWidth, 20);
            Rectangle metaRect = new Rectangle(e.Bounds.X + 16, e.Bounds.Y + 30, textWidth, 18);

            TextFormatFlags left = TextFormatFlags.Left | TextFormatFlags.EndEllipsis |
                TextFormatFlags.NoPrefix;

            TextRenderer.DrawText(e.Graphics, row.Name, Theme.BodyBoldFont, nameRect,
                Theme.TextDark, left);

            TextRenderer.DrawText(e.Graphics, row.Meta, Theme.SmallFont, metaRect,
                Theme.TextMuted, left);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath pill = Theme.RoundedRect(pillRect, 12))
            using (SolidBrush pillBrush = new SolidBrush(row.PillBack))
            {
                e.Graphics.FillPath(pillBrush, pill);
            }

            TextRenderer.DrawText(e.Graphics, row.Status, Theme.SmallFont, pillRect, row.PillText,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // the "..." button: a rounded frame with three dots
            using (GraphicsPath frame = Theme.RoundedRect(more, 8))
            using (Pen framePen = new Pen(Theme.Border))
            {
                e.Graphics.DrawPath(framePen, frame);
            }

            int cx = more.X + more.Width / 2;
            int cy = more.Y + more.Height / 2;

            using (SolidBrush dot = new SolidBrush(Theme.TextMuted))
            {
                for (int i = -1; i <= 1; i++)
                    e.Graphics.FillEllipse(dot, cx + i * 7 - 2, cy - 2, 4, 4);
            }
        }

        // ---------- Subject list: mouse and keyboard ----------

        private void lstSubjects_MouseDown(object sender, MouseEventArgs e)
        {
            int index = lstSubjects.IndexFromPoint(e.Location);

            if (index < 0 || index >= rows.Count)
                return;

            lstSubjects.SelectedIndex = index;

            if (e.Button == MouseButtons.Right)
            {
                ShowSubjectMenu(rows[index].Name, e.Location);
            }
            else if (e.Button == MouseButtons.Left)
            {
                Rectangle more = MoreButtonRect(lstSubjects.GetItemRectangle(index));

                if (more.Contains(e.Location))
                    ShowSubjectMenu(rows[index].Name, new Point(more.Left, more.Bottom));
            }
        }

        private void lstSubjects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lstSubjects.IndexFromPoint(e.Location);

            if (e.Button != MouseButtons.Left || index < 0 || index >= rows.Count)
                return;

            Rectangle more = MoreButtonRect(lstSubjects.GetItemRectangle(index));

            if (more.Contains(e.Location))
                return;

            string subject = rows[index].Name;
            OpenQuizSetup(subject, AppData.FindQuiz(teacherUser, subject) == null);
        }

        private void lstSubjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && SelectedSubject() != "")
            {
                DeleteSubject(SelectedSubject());
                e.SuppressKeyPress = true;
            }
        }

        // The menu shown by right-click and by the "..." button
        private void ShowSubjectMenu(string subject, Point where)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Font = Theme.BodyFont;
            menu.ShowImageMargin = false;

            QuizConfig quiz = AppData.FindQuiz(teacherUser, subject);

            ToolStripMenuItem header = new ToolStripMenuItem(subject);
            header.Enabled = false;
            menu.Items.Add(header);
            menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add("Add questions", null, (s, e) => OpenQuestionForm(subject));

            if (quiz == null)
            {
                menu.Items.Add("Create quiz...", null, (s, e) => OpenQuizSetup(subject, true));
            }
            else
            {
                menu.Items.Add("Quiz settings...", null, (s, e) => OpenQuizSetup(subject, false));

                if (quiz.IsOpen)
                    menu.Items.Add("Close quiz", null, (s, e) => SetQuizOpen(subject, false));
                else
                    menu.Items.Add("Open quiz", null, (s, e) => SetQuizOpen(subject, true));

                menu.Items.Add("Delete quiz", null, (s, e) => DeleteQuiz(subject));
            }

            menu.Items.Add(new ToolStripSeparator());

            ToolStripMenuItem delete = new ToolStripMenuItem("Delete subject...");
            delete.ForeColor = Theme.Danger;
            delete.Click += (s, e) => DeleteSubject(subject);
            menu.Items.Add(delete);

            menu.Show(lstSubjects, where);
        }

        // ---------- Subject management ----------

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Font = Theme.BodyFont;
            menu.ShowImageMargin = false;

            bool any = false;

            foreach (string subject in AppData.Subjects)
            {
                if (AppData.TeacherHasSubject(teacherUser, subject))
                    continue;

                if (!any)
                {
                    ToolStripMenuItem header = new ToolStripMenuItem("Subjects on the platform");
                    header.Enabled = false;
                    menu.Items.Add(header);
                    any = true;
                }

                string name = subject;
                menu.Items.Add(name, null, (s, args) => AddExistingSubject(name));
            }

            if (any)
                menu.Items.Add(new ToolStripSeparator());

            menu.Items.Add("New subject...", null, (s, args) => AddNewSubject());

            menu.Show(btnAddSubject, new Point(0, btnAddSubject.Height + 4));
        }

        private void AddExistingSubject(string subject)
        {
            AppData.AddTeacherSubject(teacherUser, subject);
            RefreshAll();
            SetStatus("Subject \"" + subject + "\" added");
        }

        private void AddNewSubject()
        {
            string name = PromptForm.Ask(this, "New subject",
                "Type the name of the subject you want to teach.", 25);

            if (name == null)
                return;

            string existing = null;

            foreach (string s in AppData.Subjects)
            {
                if (s.ToLower() == name.ToLower())
                {
                    existing = s;
                    break;
                }
            }

            if (existing != null)
            {
                if (AppData.TeacherHasSubject(teacherUser, existing))
                {
                    MessageBox.Show("You already teach \"" + existing + "\".", "Add subject",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                name = existing;
            }

            AppData.AddTeacherSubject(teacherUser, name);
            RefreshAll();
            SetStatus("Subject \"" + name + "\" added");
        }

        private void DeleteSubject(string subject)
        {
            int questions = AppData.QuestionsOf(teacherUser, subject).Count;
            int students = 0;

            foreach (Enrollment en in AppData.EnrollmentsOfTeacher(teacherUser))
            {
                if (en.Subject == subject)
                    students++;
            }

            string nl = Environment.NewLine;

            string message = "Delete \"" + subject + "\" from your subjects?" + nl + nl +
                "This also removes:" + nl +
                "   - " + questions + " of your questions in this subject" + nl +
                "   - the quiz settings" + nl +
                "   - " + students + " student enrollment(s) with you" + nl + nl +
                "This cannot be undone.";

            DialogResult result = MessageBox.Show(message, "Delete subject",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result != DialogResult.Yes)
                return;

            AppData.RemoveTeacherSubject(teacherUser, subject);
            RefreshAll();
            SetStatus("Subject \"" + subject + "\" deleted");
        }

        private void DeleteQuiz(string subject)
        {
            DialogResult result = MessageBox.Show(
                "Delete the quiz settings of \"" + subject + "\"?" + Environment.NewLine +
                "Your questions are kept.", "Delete quiz",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            AppData.DeleteQuiz(teacherUser, subject);
            RefreshAll();
            SetStatus("Quiz deleted for " + subject);
        }

        private void SetQuizOpen(string subject, bool open)
        {
            QuizConfig quiz = AppData.FindQuiz(teacherUser, subject);

            if (quiz == null)
                return;

            quiz.IsOpen = open;
            RefreshAll();

            if (open)
                SetStatus("Quiz opened for " + subject);
            else
                SetStatus("Quiz closed for " + subject);
        }

        // ---------- Quiz flow ----------

        // Create quiz button / sidebar / Ctrl+N
        private void CreateQuizFlow()
        {
            if (AppData.SubjectsOf(teacherUser).Count == 0)
            {
                MessageBox.Show("Add a subject first, then create its quiz.", "Create quiz",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OpenQuizSetup(SelectedSubject(), true);
        }

        // Quiz settings window; when continueToQuestions is true it
        // goes on to the Question Manager after saving.
        private void OpenQuizSetup(string subject, bool continueToQuestions)
        {
            SetActiveNav(btnNavQuiz);
            string saved = "";

            using (QuizSetupForm form = new QuizSetupForm(teacherUser, subject, continueToQuestions))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    saved = form.SavedSubject;
            }

            RefreshAll();
            SetActiveNav(btnNavDashboard);

            if (saved == "")
            {
                SetStatus("Ready");
                return;
            }

            SetStatus("Quiz settings saved for " + saved);

            if (continueToQuestions)
                OpenQuestionForm(saved);
        }

        // In stage V5 the Question Manager will use the subject
        // Opens the Question Manager on one subject's quiz
        private void OpenQuestionForm(string subject)
        {
            if (AppData.SubjectsOf(teacherUser).Count == 0)
            {
                MessageBox.Show("Add a subject first, then add its questions.", "Question manager",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // no subject given: use the selected row (the form picks the first one otherwise)
            if (subject == "")
                subject = SelectedSubject();

            SetActiveNav(btnNavQuiz);
            SetStatus("Opening question manager...");

            using (QuestionForm form = new QuestionForm(teacherUser, teacherName, subject))
            {
                form.ShowDialog(this);
            }

            RefreshAll();
            SetStatus("Ready");
            SetActiveNav(btnNavDashboard);
        }

        private void OpenResults()
        {
            SetActiveNav(btnNavResults);
            SetStatus("Opening results...");

            using (ResultForm form = new ResultForm(teacherUser))
            {
                form.ShowDialog(this);
            }

            SetStatus("Ready");
            SetActiveNav(btnNavDashboard);
        }

        private void ShowAbout()
        {
            SetActiveNav(btnNavAbout);

            using (AboutForm about = new AboutForm())
            {
                about.ShowDialog(this);
            }

            SetActiveNav(btnNavDashboard);
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

        private void ConfirmExit()
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        // ---------- Button clicks ----------

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNav(btnNavDashboard);
            RefreshAll();
            SetStatus("Dashboard");
        }

        private void btnNavQuiz_Click(object sender, EventArgs e)
        {
            CreateQuizFlow();
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

        private void btnBannerCreate_Click(object sender, EventArgs e)
        {
            CreateQuizFlow();
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            OpenResults();
        }
    }
}