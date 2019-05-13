using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            //Using System.Threading;
            using (Mutex m = new Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main());
                }
                else
                {
                    Message ma = new Message();
                    ma.lbTitle.Text = "云隧道";
                    ma.lbContent.Text = "云隧道已启动！\t\n请不要启动多个程序！";
                    ma.ShowDialog();
                }
            }
        }
    }
}
