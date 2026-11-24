using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizSystem
{
    // Step 1: choose a subject.  Step 2: choose the teacher.  Built entirely in code.
    public class EnrollForm : Form
    {
        private string studentUser;
        private List<string> subjects = new List<string>();
        private List<string> teachers = new List<string>();

        private ListBox lstSubjects;
        private ListBox lstTeachers;
        private Label lblInfo;
        private Label lblError;
        private ModernButton btnEnroll;
        private ModernButton btnCancel;

        public string EnrolledSubject { get; private set; }

        public EnrollForm(string student)
        {
            studentUser = student;
            EnrolledSubject = "";

            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Segoe UI", 10F);
            this.Text = "EduQuiz - Enroll in a subject"; this.Icon = Theme.AppIcon;
            this.BackColor = Theme.Background;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new Size(700, 560);

            BuildScreen();

            this.Load += EnrollForm_Load;
        }

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

        private ListBox MakeList(int itemHeight)
        {
            ListBox box = new ListBox();
            box.DrawMode = DrawMode.OwnerDrawFixed;
            box.ItemHeight = itemHeight;
            box.BorderStyle = BorderStyle.None;
            box.IntegralHeight = false;
            box.BackColor = Color.White;
            return box;
        }

        private void BuildScreen()
        {
            // Header
            Panel header = new Panel();
            header.SetBounds(0, 0, 700, 72);
            header.BackColor = Theme.Navy;
            header.Controls.Add(MakeLabel("Enroll in a subject",
                new Font("Segoe UI", 15F, FontStyle.Bold), Color.White, Theme.Navy, 28, 12));
            header.Controls.Add(MakeLabel("Pick a subject, then choose the teacher you want to study with",
                Theme.SmallFont, Color.FromArgb(148, 163, 184), Theme.Navy, 30, 44));
            this.Controls.Add(header);

            Panel line = new Panel();
            line.SetBounds(0, 72, 700, 3);
            line.BackColor = Theme.Primary;
            this.Controls.Add(line);

            // Step labels
            this.Controls.Add(MakeLabel("1   Choose a subject", Theme.BodyBoldFont,
                Theme.TextDark, Theme.Background, 28, 94));
            this.Controls.Add(MakeLabel("2   Choose your teacher", Theme.BodyBoldFont,
                Theme.TextDark, Theme.Background, 288, 94));

            // Subject card
            RoundedPanel cardSubjects = new RoundedPanel();
            cardSubjects.SetBounds(28, 124, 240, 308);
            cardSubjects.BackColor = Theme.Background;
            cardSubjects.FillColor = Color.White;

            lstSubjects = MakeList(56);
            lstSubjects.SetBounds(6, 6, 228, 296);
            lstSubjects.DrawItem += lstSubjects_DrawItem;
            lstSubjects.SelectedIndexChanged += lstSubjects_SelectedIndexChanged;
            cardSubjects.Controls.Add(lstSubjects);
            this.Controls.Add(cardSubjects);

            // Teacher card
            RoundedPanel cardTeachers = new RoundedPanel();
            cardTeachers.SetBounds(288, 124, 384, 308);
            cardTeachers.BackColor = Theme.Background;
            cardTeachers.FillColor = Color.White;

            lstTeachers = MakeList(64);
            lstTeachers.SetBounds(6, 6, 372, 296);
            lstTeachers.DrawItem += lstTeachers_DrawItem;
            lstTeachers.SelectedIndexChanged += lstTeachers_SelectedIndexChanged;
            cardTeachers.Controls.Add(lstTeachers);
            this.Controls.Add(cardTeachers);

            // Messages
            lblInfo = new Label();
            lblInfo.AutoSize = false;
            lblInfo.SetBounds(28, 444, 644, 22);
            lblInfo.Font = Theme.BodyFont;
            lblInfo.ForeColor = Theme.TextMuted;
            lblInfo.BackColor = Theme.Background;
            this.Controls.Add(lblInfo);

            lblError = new Label();
            lblError.AutoSize = false;
            lblError.SetBounds(28, 468, 644, 22);
            lblError.Font = Theme.BodyFont;
            lblError.ForeColor = Theme.Danger;
            lblError.BackColor = Theme.Background;
            this.Controls.Add(lblError);

            // Footer
            Panel footer = new Panel();
            footer.SetBounds(0, 500, 700, 60);
            footer.BackColor = Color.White;
            footer.Paint += (s, e) =>
            {
                using (Pen p = new Pen(Theme.Border))
                {
                    e.Graphics.DrawLine(p, 0, 0, footer.Width, 0);
                }
            };

            btnCancel = new ModernButton();
            btnCancel.Text = "Cancel";
            btnCancel.Kind = ButtonKind.Secondary;
            btnCancel.Size = new Size(130, 42);
            btnCancel.Location = new Point(380, 9);
            btnCancel.DialogResult = DialogResult.Cancel;
            footer.Controls.Add(btnCancel);

            btnEnroll = new ModernButton();
            btnEnroll.Text = "Enroll";
            btnEnroll.Size = new Size(150, 42);
            btnEnroll.Location = new Point(522, 9);
            btnEnroll.Click += btnEnroll_Click;
            footer.Controls.Add(btnEnroll);

            this.Controls.Add(footer);

            this.AcceptButton = btnEnroll;
            this.CancelButton = btnCancel;
        }

        private void EnrollForm_Load(object sender, EventArgs e)
        {
            subjects = AppData.EnrollableSubjects(studentUser);

            foreach (string subject in subjects)
                lstSubjects.Items.Add(subject);

            if (subjects.Count == 0)
            {
                lblInfo.Text = "You are already enrolled in every available subject.";
                btnEnroll.Enabled = false;
            }
            else
            {
                UpdateInfo();
            }
        }

        private void lstSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            teachers = new List<string>();
            lstTeachers.Items.Clear();
            lblError.Text = "";

            int s = lstSubjects.SelectedIndex;

            if (s >= 0 && s < subjects.Count)
            {
                teachers = AppData.TeacherUsernamesOf(subjects[s]);

                foreach (string teacher in teachers)
                    lstTeachers.Items.Add(teacher);

                // only one teacher: nothing to choose
                if (teachers.Count == 1)
                    lstTeachers.SelectedIndex = 0;
            }

            UpdateInfo();
        }

        private void lstTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Text = "";
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            int s = lstSubjects.SelectedIndex;
            int t = lstTeachers.SelectedIndex;

            if (s < 0 || s >= subjects.Count)
                lblInfo.Text = "Pick a subject on the left.";
            else if (t < 0 || t >= teachers.Count)
                lblInfo.Text = "Now choose the teacher you want for " + subjects[s] + ".";
            else
                lblInfo.Text = "You will study " + subjects[s] + " with " +
                    AppData.DisplayName(teachers[t]) + ".";
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            int s = lstSubjects.SelectedIndex;
            int t = lstTeachers.SelectedIndex;

            if (s < 0 || s >= subjects.Count)
            {
                lblError.Text = "Please choose a subject first.";
                return;
            }

            if (t < 0 || t >= teachers.Count)
            {
                lblError.Text = "Please choose your teacher.";
                return;
            }

            try
            {
                bool done = AppData.Enroll(studentUser, subjects[s], teachers[t]);

                if (!done)
                {
                    lblError.Text = "You are already enrolled in " + subjects[s] + ".";
                    return;
                }

                EnrolledSubject = subjects[s];
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                lblError.Text = "Could not enroll: " + ex.Message;
            }
        }

        // ---------- drawing ----------

        private void DrawRow(DrawItemEventArgs e, string line1, string line2,
                             string pillText, bool pillGood)
        {
            Graphics g = e.Graphics;
            Rectangle b = e.Bounds;
            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

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

            int textWidth = b.Width - 32;
            if (pillText != "")
                textWidth -= 108;

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix;

            TextRenderer.DrawText(g, line1, Theme.BodyBoldFont,
                new Rectangle(b.X + 16, b.Y + 10, textWidth, 22), Theme.TextDark, flags);

            TextRenderer.DrawText(g, line2, Theme.SmallFont,
                new Rectangle(b.X + 16, b.Y + 32, textWidth, 20), Theme.TextMuted, flags);

            if (pillText != "")
            {
                Color pillBack = Color.FromArgb(241, 245, 249);
                Color pillColor = Color.FromArgb(71, 85, 105);

                if (pillGood)
                {
                    pillBack = Color.FromArgb(220, 252, 231);
                    pillColor = Color.FromArgb(22, 101, 52);
                }

                Rectangle pill = new Rectangle(b.Right - 108, b.Y + (b.Height - 24) / 2, 96, 24);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (GraphicsPath path = Theme.RoundedRect(pill, 12))
                using (SolidBrush pillBrush = new SolidBrush(pillBack))
                {
                    g.FillPath(pillBrush, path);
                }

                TextRenderer.DrawText(g, pillText, Theme.SmallFont, pill, pillColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void lstSubjects_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= subjects.Count)
                return;

            int count = AppData.TeacherUsernamesOf(subjects[e.Index]).Count;
            string info = count + (count == 1 ? " teacher" : " teachers");

            DrawRow(e, subjects[e.Index], info, "", false);
        }

        private void lstTeachers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= teachers.Count)
                return;

            int s = lstSubjects.SelectedIndex;
            if (s < 0 || s >= subjects.Count)
                return;

            string teacher = teachers[e.Index];
            string subject = subjects[s];

            QuizConfig quiz = AppData.FindQuiz(teacher, subject);
            bool ready = AppData.IsQuizAvailable(teacher, subject);

            string line2;
            if (ready)
                line2 = quiz.Title + "  |  " + quiz.QuestionCount + " questions  |  " +
                    quiz.DurationMinutes + " min";
            else
                line2 = "No quiz available yet";

            string pill = "No quiz yet";
            if (ready)
                pill = "Quiz ready";

            DrawRow(e, AppData.DisplayName(teacher), line2, pill, ready);
        }
    }
}