using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Splash
{
    public static class Log
    {
        public static void Info(string info)
        {
            StreamWriter sw = null;
            try
            {
                string filename = DateTime.Now.ToString("yyyyMMdd") + ".txt";
                FileInfo file = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + filename); //如果是web程序，这个的变成Http什么的

                if (!file.Exists)
                {
                    sw = file.CreateText();
                    sw.WriteLine(info.ToString());
                }
                else
                {
                    sw = file.AppendText();
                    sw.WriteLine(info.ToString());
                }
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            catch (Exception e)
            {
                sw.Close();
                sw.Dispose();
            }
        }
    }
}
