using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizSystem
{
    public static class AppData
    {
        public static List<Question> Questions = new List<Question>();
        public static List<Student> Results = new List<Student>();

        public static List<string> Subjects = new List<string>
        {
            "C#", "Databases", "Networking", "General"
        };

        public static List<UserAccount> Users = new List<UserAccount>
        {
            new UserAccount("admin", "1234", "Admin", "Administrator"),
            new UserAccount("teacher", "1234", "Teacher", "Teacher One"),
            new UserAccount("teacher2", "1234", "Teacher", "Teacher Two"),
            new UserAccount("ahmed", "1234", "Student", "Ahmed Ali"),
            new UserAccount("sara", "1234", "Student", "Sara Omar"),
            new UserAccount("omar", "1234", "Student", "Omar Hassan"),
            new UserAccount("mona", "1234", "Student", "Mona Adel"),
            new UserAccount("youssef", "1234", "Student", "Youssef Samy")
        };

        // Which teacher teaches which subject
        public static List<TeacherSubject> TeacherSubjects = new List<TeacherSubject>
        {
            new TeacherSubject("teacher", "C#"),
            new TeacherSubject("teacher", "Databases"),
            new TeacherSubject("teacher2", "Databases"),
            new TeacherSubject("teacher2", "Networking")
        };

        // Which student studies which subject with which teacher
        public static List<Enrollment> Enrollments = new List<Enrollment>
        {
            new Enrollment("ahmed", "C#", "teacher"),
            new Enrollment("ahmed", "Databases", "teacher2"),
            new Enrollment("sara", "Networking", "teacher2"),
            new Enrollment("sara", "C#", "teacher"),
            new Enrollment("omar", "Networking", "teacher2"),
            new Enrollment("mona", "C#", "teacher"),
            new Enrollment("youssef", "C#", "teacher"),
            new Enrollment("youssef", "Networking", "teacher2")
        };

        // Quiz settings (one per teacher per subject)
        public static List<QuizConfig> Quizzes = new List<QuizConfig>
        {
            new QuizConfig("teacher", "C#", "C# Basics", 3, 3, 50, false),
            new QuizConfig("teacher2", "Networking", "Networking Intro", 2, 2, 50, false)
        };

        public static int NextID = 1;
        public const double PassMark = 50;

        // ---------- Lookups ----------

        public static UserAccount FindUser(string username)
        {
            foreach (UserAccount u in Users)
            {
                if (u.Username.ToLower() == username.ToLower())
                    return u;
            }

            return null;
        }

        public static List<UserAccount> GetByRole(string role)
        {
            return Users.Where(u => u.Role == role).ToList();
        }

        public static List<string> SubjectsOf(string teacher)
        {
            return TeacherSubjects
                .Where(t => t.TeacherUsername == teacher)
                .Select(t => t.Subject)
                .ToList();
        }

        public static List<UserAccount> TeachersOf(string subject)
        {
            List<UserAccount> list = new List<UserAccount>();

            foreach (TeacherSubject ts in TeacherSubjects)
            {
                if (ts.Subject == subject)
                {
                    UserAccount u = FindUser(ts.TeacherUsername);
                    if (u != null)
                        list.Add(u);
                }
            }

            return list;
        }

        public static List<Enrollment> EnrollmentsOfStudent(string student)
        {
            return Enrollments.Where(e => e.StudentUsername == student).ToList();
        }

        public static List<Enrollment> EnrollmentsOfTeacher(string teacher)
        {
            return Enrollments.Where(e => e.TeacherUsername == teacher).ToList();
        }

        public static QuizConfig FindQuiz(string teacher, string subject)
        {
            return Quizzes.FirstOrDefault(q => q.TeacherUsername == teacher && q.Subject == subject);
        }

        public static List<Question> QuestionsOf(string teacher, string subject)
        {
            return Questions.Where(q => q.Owner == teacher && q.Subject == subject).ToList();
        }

        // A quiz is available when it is open AND the teacher has added
        // at least as many questions as the quiz needs.
        public static bool IsQuizAvailable(string teacher, string subject)
        {
            QuizConfig quiz = FindQuiz(teacher, subject);

            if (quiz == null || !quiz.IsOpen)
                return false;

            return QuestionsOf(teacher, subject).Count >= quiz.QuestionCount;
        }

        public static List<Student> ResultsOfTeacher(string teacher)
        {
            return Results.Where(r => r.TeacherUsername == teacher).ToList();
        }

        // ---------- Subject and quiz management ----------

        // The status shown in pills: No quiz yet / Closed / Quiz ready / Needs N more
        public static string QuizStatusText(string teacher, string subject)
        {
            QuizConfig quiz = FindQuiz(teacher, subject);

            if (quiz == null)
                return "No quiz yet";

            if (!quiz.IsOpen)
                return "Closed";

            int have = QuestionsOf(teacher, subject).Count;

            if (have >= quiz.QuestionCount)
                return "Quiz ready";

            return "Needs " + (quiz.QuestionCount - have) + " more";
        }

        // ---------- Student enrollment ----------

        public static string DisplayName(string username)
        {
            UserAccount account = FindUser(username);

            if (account == null)
                return username;

            return account.FullName;
        }

        // Every teacher who teaches this subject
        public static List<string> TeacherUsernamesOf(string subject)
        {
            List<string> result = new List<string>();

            foreach (TeacherSubject link in TeacherSubjects)
            {
                if (link.Subject == subject && !result.Contains(link.TeacherUsername))
                    result.Add(link.TeacherUsername);
            }

            return result;
        }

        public static Enrollment FindEnrollment(string student, string subject)
        {
            foreach (Enrollment item in Enrollments)
            {
                if (item.StudentUsername == student && item.Subject == subject)
                    return item;
            }

            return null;
        }

        // Subjects that have at least one teacher and that the student has not joined yet
        public static List<string> EnrollableSubjects(string student)
        {
            List<string> result = new List<string>();

            foreach (string subject in Subjects)
            {
                if (TeacherUsernamesOf(subject).Count > 0 && FindEnrollment(student, subject) == null)
                    result.Add(subject);
            }

            return result;
        }

        // false = already enrolled, or that teacher does not teach the subject
        public static bool Enroll(string student, string subject, string teacher)
        {
            if (FindEnrollment(student, subject) != null)
                return false;

            bool teaches = false;

            foreach (TeacherSubject link in TeacherSubjects)
            {
                if (link.TeacherUsername == teacher && link.Subject == subject)
                    teaches = true;
            }

            if (!teaches)
                return false;

            Enrollments.Add(new Enrollment(student, subject, teacher)); return true;
        }

        // Results are kept on purpose
        public static void Unenroll(string student, string subject)
        {
            Enrollment item = FindEnrollment(student, subject);

            if (item != null)
                Enrollments.Remove(item);
        }

        // The student's most recent result for this quiz, or null
        public static Student LastResult(string student, string subject, string teacher)
        {
            Student last = null;

            foreach (Student r in Results)
            {
                if (r.Username == student && r.Subject == subject && r.TeacherUsername == teacher)
                    last = r;
            }

            return last;
        }
        public static bool TeacherHasSubject(string teacher, string subject)
        {
            return TeacherSubjects.Any(t => t.TeacherUsername == teacher && t.Subject == subject);
        }

        // Links a subject to a teacher. A new subject also joins the platform list.
        public static void AddTeacherSubject(string teacher, string subject)
        {
            if (!Subjects.Contains(subject))
                Subjects.Add(subject);

            if (!TeacherHasSubject(teacher, subject))
                TeacherSubjects.Add(new TeacherSubject(teacher, subject));
        }

        public static void DeleteQuiz(string teacher, string subject)
        {
            Quizzes.RemoveAll(q => q.TeacherUsername == teacher && q.Subject == subject);
        }

        // Removes a subject from one teacher, with everything that belongs to it
        public static void RemoveTeacherSubject(string teacher, string subject)
        {
            Questions.RemoveAll(q => q.Owner == teacher && q.Subject == subject);
            Enrollments.RemoveAll(en => en.TeacherUsername == teacher && en.Subject == subject);
            DeleteQuiz(teacher, subject);
            TeacherSubjects.RemoveAll(t => t.TeacherUsername == teacher && t.Subject == subject);

            // If nobody teaches it any more, remove it from the platform list too
            bool stillUsed = TeacherSubjects.Any(t => t.Subject == subject) ||
                             Questions.Any(q => q.Subject == subject);

            if (!stillUsed)
                Subjects.Remove(subject);
        }
        // ---------- Demo data (testing only) ----------

        private static void AddSample(string owner, string text, string subject, string difficulty,
                                      string[] options, int correctIndex)
        {
            Question q = new Question(NextID++, text, subject, difficulty, options, correctIndex);
            q.Owner = owner;
            Questions.Add(q);
        }

        public static void AddSampleQuestions()
        {
            if (Questions.Count > 0)
                return;

            AddSample("teacher", "Which keyword creates an object in C#?", "C#", "Easy",
                new string[] { "new", "create", "make", "object" }, 0);

            AddSample("teacher", "Which control shows a list of items?", "C#", "Easy",
                new string[] { "Label", "ListBox", "Timer", "MenuStrip" }, 1);

            AddSample("teacher", "What does TryParse return when conversion fails?", "C#", "Medium",
                new string[] { "true", "false", "null", "an exception" }, 1);

            AddSample("teacher2", "Which protocol is used to load web pages?", "Networking", "Easy",
                new string[] { "FTP", "HTTP", "SMTP", "SSH" }, 1);

            AddSample("teacher2", "What does an IP address identify?", "Networking", "Easy",
                new string[] { "A device on a network", "A website name", "A file", "A password" }, 0);
        }

        public static void AddSampleResults()
        {
            if (Results.Count > 0)
                return;

            string[] users = { "ahmed", "sara", "omar", "mona", "youssef" };
            string[] subjects = { "C#", "Networking", "Networking", "C#", "C#" };
            string[] teachers = { "teacher", "teacher2", "teacher2", "teacher", "teacher" };
            int[] scores = { 3, 1, 0, 2, 3 };
            int[] totals = { 3, 2, 2, 3, 3 };

            for (int i = 0; i < users.Length; i++)
            {
                UserAccount u = FindUser(users[i]);

                Student s = new Student(u.FullName);
                s.Username = u.Username;
                s.Subject = subjects[i];
                s.TeacherUsername = teachers[i];
                s.Score = scores[i];
                s.Total = totals[i];
                s.TakenAt = DateTime.Now.AddMinutes(-15 * (i + 1));
                Results.Add(s);
            }
        }
    }
}