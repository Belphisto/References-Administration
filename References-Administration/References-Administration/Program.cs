using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace References_Administration
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogToFile.Activate();
            Log.WriteLog($"Программа запущена");
            Application.Run(new StartForm());
            Log.WriteLog($"Работа программы завершена");
        }
    }
}
