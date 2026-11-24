using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizSystem
{
    internal static class Program
    {
        private static void ShowCrash(Exception ex)
        {
            string detail = "Unknown error";

            if (ex != null)
                detail = ex.Message;

            MessageBox.Show("Something went wrong, but your data in this session is still here.\n\n" +
                detail, "EduQuiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => ShowCrash(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => ShowCrash(e.ExceptionObject as Exception);
            Application.Run(new LoginForm());
        }
    }
}
