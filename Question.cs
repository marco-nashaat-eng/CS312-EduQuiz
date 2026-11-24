using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    public class Question
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
        public string Difficulty { get; set; }
        public string[] Options { get; set; }
        public int CorrectIndex { get; set; }
        public string Owner { get; set; } = "";

        public Question(int id, string text, string subject, string difficulty,
                        string[] options, int correctIndex)
        {
            ID = id;
            Text = text;
            Subject = subject;
            Difficulty = difficulty;
            Options = options;
            CorrectIndex = correctIndex;
        }

        public bool IsCorrect(int selectedIndex)
        {
            return selectedIndex == CorrectIndex;
        }

        public string GetInfo()
        {
            return ID + " - " + Text + " [" + Subject + " | " + Difficulty + "]";
        }
    }
}
