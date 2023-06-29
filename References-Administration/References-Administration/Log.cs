using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace References_Administration
{
    public class Log
    {
        public delegate void Adding(string message);

        public static event Adding onLog;
        public static void WriteLog(string message)
        {
            var outp = string.Format($"LogInfo: {DateTime.Now.ToShortDateString()} / {DateTime.Now.ToLongTimeString()} / {message}");
            onLog?.Invoke(outp);
        }

        public static void WriteLog(Exception exception)
        {
            var outp = string.Format($" LogWrong: {DateTime.Now.ToShortDateString()} / {DateTime.Now.ToLongTimeString()} / {exception.Message}");
            onLog?.Invoke(outp);
        }
        
    }
    public class LogToFile
    {
        public static void Activate()
        {
            Log.onLog += Print;
        }
        private static void Print(string inp)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path: Config.LOG_PATH, append: true))
                {
                    writer.WriteLine(inp);
                    writer.Close();
                }
            }
            catch { throw new FileNotFoundException(); }
        }
    }
}
