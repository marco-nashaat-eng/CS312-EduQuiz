using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem
{
    public interface IPrintable
    {
        string Print();
    }

    public class Student : Person, IPrintable
    {
        public int Score { get; set; }
        public double PassPercent { get; set; } = AppData.PassMark; public int Total { get; set; }
        public DateTime TakenAt { get; set; }
        public string Username { get; set; } = "";
        public string Subject { get; set; } = "";
        public string TeacherUsername { get; set; } = "";

        public Student(string name)
        {
            Name = name;
            TakenAt = DateTime.Now;
        }

        public double GetPercentage()
        {
            if (Total == 0)
                return 0;

            return Score * 100.0 / Total;
        }

        public bool IsPassed()
        {
            return GetPercentage() >= PassPercent;
        }

        public string Print()
        {
            string status;

            if (IsPassed())
                status = "Passed";
            else
                status = "Failed";

            return Name + " | " + Score + "/" + Total + " | " +
                GetPercentage().ToString("F1") + "% | " + status + " | " +
                TakenAt.ToString("dd/MM HH:mm");
        }
    }
}
