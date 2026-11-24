using System;

namespace QuizSystem
{
    // Which subjects a teacher teaches
    public class TeacherSubject
    {
        public string TeacherUsername { get; set; }
        public string Subject { get; set; }

        public TeacherSubject(string teacherUsername, string subject)
        {
            TeacherUsername = teacherUsername;
            Subject = subject;
        }
    }

    // A student studying one subject with one teacher
    public class Enrollment
    {
        public string StudentUsername { get; set; }
        public string Subject { get; set; }
        public string TeacherUsername { get; set; }
        public DateTime EnrolledAt { get; set; }

        public Enrollment(string studentUsername, string subject, string teacherUsername)
        {
            StudentUsername = studentUsername;
            Subject = subject;
            TeacherUsername = teacherUsername;
            EnrolledAt = DateTime.Now;
        }
    }

    // The settings of one quiz (one quiz per teacher per subject)
    public class QuizConfig
    {
        public string TeacherUsername { get; set; }
        public string Subject { get; set; }
        public string Title { get; set; }
        public int QuestionCount { get; set; }
        public int DurationMinutes { get; set; }
        public int PassPercent { get; set; }
        public bool ShuffleQuestions { get; set; }
        public bool IsOpen { get; set; }

        public QuizConfig(string teacherUsername, string subject, string title,
                          int questionCount, int durationMinutes, int passPercent,
                          bool shuffleQuestions)
        {
            TeacherUsername = teacherUsername;
            Subject = subject;
            Title = title;
            QuestionCount = questionCount;
            DurationMinutes = durationMinutes;
            PassPercent = passPercent;
            ShuffleQuestions = shuffleQuestions;
            IsOpen = true;
        }
    }
}