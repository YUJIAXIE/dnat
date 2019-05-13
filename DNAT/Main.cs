using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Main : Form
    {
        public static string Url = "http://www.xyujia.cn";//"http://localhost:46324"
        public string processName = "ctc";
        public static Main main;
        IniFiles ini = new IniFiles(Application.StartupPath + "\\Config.ini");
        IniFiles Frpini = new IniFiles(Application.StartupPath + "\\CtcConfig.ini");
        public static int Id;//用户ID，登录成功后保存
        public static string Version;
        public static string DoMain;//名称，登录成功后保存
        public static string DoMainInfo;
        public static string Date;
        public static string Pwd;
        #region 无边框属性
        private Point mousePoint = new Point();
        private void pClose_MouseClick(object sender, MouseEventArgs e)
        {
            Message m = new Message();
            m.lbTitle.Text = "操作提示";
            m.lbContent.Text = "是否退出？";
            m.ShowDialog();
            if (m.DialogResult == DialogResult.Yes)
            {
                if (notifyIcon1 != null)
                {
                    //e.Cancel = true;
                    this.Visible = false;
                }
                KillProcess(processName);
                Application.Exit();
            }
        }

        private void pMin_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }

        }

        private void pBar_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
        }

        private void pBar_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }
        }

        private void pClose_MouseLeave(object sender, EventArgs e)
        {
            pClose.BackgroundImage = Client.Properties.Resources.btn_close_nor;
        }

        private void pClose_MouseEnter(object sender, EventArgs e)
        {
            pClose.BackgroundImage = Client.Properties.Resources.btn_close_down;
        }

        private void pMin_MouseEnter(object sender, EventArgs e)
        {
            pMin.BackgroundImage = Client.Properties.Resources.btn_min_down;
        }

        private void pMin_MouseLeave(object sender, EventArgs e)
        {
            pMin.BackgroundImage = Client.Properties.Resources.btn_min_nor;
        }
        #endregion
        public Main()
        {
            //InitializeComponent();
            InitializeComponent();
            main = this;
        }

        public void InitializeTunnel()
        {
            flowLayoutPanel1.Controls.Clear();
            var json = HTTP.Get(Url + "/Client/FRPConfig", "?Uid=" + Id + "&Id=1&All=false");
            DataTable dt = Json.Json2DataTable(json);
            foreach (DataRow dr in dt.Rows)
            {
                Tunnel t = new Tunnel();
                t.lbMappingName.Text = dr["MappingName"].ToString();
                t.llbUrl.Text = "http://" + dr["custom_domains"] + ":" + dr["remote_port"];
                t.lbIp.Text = dr["local_ip"].ToString();
                t.lbPort.Text = dr["local_port"].ToString();
                //t.Location = new Point(5, 5 + 60 * i);
                flowLayoutPanel1.Controls.Add(t);
            }
        }

        void Test()
        {
            var Com = HTTP.Get(Url + "/Client/FRPConfig", "?Uid=" + Id + "&Id=0&All=false");
            DataTable Common = Json.Json2DataTable(Com);
            foreach (DataRow dr in Common.Rows)
            {
                Frpini.IniWriteValue(dr["MappingName"].ToString(), dr["Info"].ToString(), dr["Value"].ToString());
            }
            var frp = HTTP.Get(Url + "/Client/FRPConfig", "?Uid=" + Id + "&Id=1&All=false");
            DataTable User = Json.Json2DataTable(frp);
            foreach (DataRow dr in User.Rows)
            {
                Frpini.IniWriteValue(dr["MappingName"].ToString(), dr["Info"].ToString(), dr["Value"].ToString());
            }
            var dd = Application.StartupPath + "\\" + processName + ".exe";

            if (File.Exists(dd))
            {
                if (RunCmd(dd, Frpini.inipath))
                {
                    lbStats.Text = "运行中";
                    File.Delete(Frpini.inipath);
                }
                else
                {
                    lbStats.Text = "未运行";
                }
            }
            else
            {
                Message m = new Message();
                m.lbTitle.Text = "程序故障";
                m.lbContent.Text = "程序已被篡改，请重新安装程序！";
                m.ShowDialog();
                Application.Exit();
            }

        }

        bool RunCmd(string cmdExe, string cmdStr)
        {
            bool result = false;
            try
            {
                using (Process myPro = new Process())
                {
                    myPro.StartInfo.FileName = "cmd.exe";
                    myPro.StartInfo.UseShellExecute = false;
                    myPro.StartInfo.RedirectStandardInput = true;
                    myPro.StartInfo.RedirectStandardOutput = true;
                    myPro.StartInfo.RedirectStandardError = true;
                    myPro.StartInfo.CreateNoWindow = true;
                    myPro.Start();
                    //如果调用程序路径中有空格时，cmd命令执行失败，可以用双引号括起来 ，在这里两个引号表示一个引号（转义）
                    string str = string.Format(@"""{0}"" -c {1} {2}", cmdExe, cmdStr, "&exit");

                    myPro.StandardInput.WriteLine(str);
                    myPro.StandardInput.AutoFlush = true;
                    //string output = myPro.StandardOutput.ReadToEnd();
                    myPro.Close();
                    myPro.Dispose();//释放资源
                    Thread.Sleep(3000);
                    KillProcess("cmd");
                    //myPro.WaitForExit();
                    Process[] myproc = Process.GetProcesses();
                    foreach (Process item in myproc)
                    {
                        if (item.ProcessName == processName)
                        {
                            result = true;
                        }
                    }

                }
            }
            catch
            {

            }
            return result;
        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="processName">进程名</param>
        public void KillProcess(string processName)
        {
            Process[] myproc = Process.GetProcesses();
            foreach (Process item in myproc)
            {
                if (item.ProcessName == processName)
                {
                    item.Kill();
                }
            }
        }
        private void btn_AddTunnel_Click(object sender, EventArgs e)
        {
            AddTunnel at = new AddTunnel();
            at.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string Windows = ini.IniReadValue("Account", "Windows");
            开机启动ToolStripMenuItem.Checked = Windows == "1" ? true : false;
            File.Delete(Frpini.inipath);
            KillProcess(processName);
            string AutoLogin = ini.IniReadValue("Account", "AutoLogin");
            string ReLogin = ini.IniReadValue("Account", "ReLogin");
            if (AutoLogin != "1" || ReLogin != "1")
            {
                Login l = new Login();
                l.Owner = this;
                l.ShowDialog();
            }
            else
            {
                string Name = ini.IniReadValue("Account", "Name");
                string PassWord = ini.IniReadValue("Account", "PassWord");
                var json = HTTP.Get(Url + "/Client/ClientLogin", "?DoMain=" + Name + "&PassWord=" + PassWord + "");
                DataTable dt = Json.Json2DataTable(json);
                if (dt.Rows.Count == 1)
                {
                    Main.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                    Main.Version = dt.Rows[0]["Value"].ToString();
                    Main.DoMain = dt.Rows[0]["DoMain"].ToString();
                    Main.DoMainInfo = dt.Rows[0]["DoMainName"].ToString() + " [" + dt.Rows[0]["RegDate"] + "---" + dt.Rows[0]["EndDate"].ToString() + "]";
                }
                else
                {
                    Login l = new Login();
                    l.Owner = this;
                    l.ShowDialog();
                }

            }
            lbName.Text = DoMain;
            lbVer.Text = Version;
            lbDoMainInfo.Text = DoMainInfo + Date;
            if (Version == "永久版")
            {
                llbRenew.Visible = false;
            }
            ini.IniWriteValue("Account", "ReLogin", "1");
            InitializeTunnel();
            Test();
        }

        private void btnRelogin_Click(object sender, EventArgs e)
        {
            ini.IniWriteValue("Account", "ReLogin", "0");
            Application.Exit();
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            lbName.Focus();
        }
        
        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.isLogin)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                Application.Exit();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1 = null;

            this.Close();

        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.isLogin)
            {
                UpdatePwd up = new UpdatePwd();
                up.ShowDialog();
            }
            else
            {
                Message m = new Message();
                m.lbTitle.Text = "提示";
                m.lbContent.Text = "请登录后进行修改密码";
                m.Show();
            }
        }

        private void 开机启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Application.ExecutablePath; //将当前程序起动路径
                string name = Path.GetFileName(path);  //获得应用程序名称
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey Run = rk.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                if (开机启动ToolStripMenuItem.Checked)
                {
                    开机启动ToolStripMenuItem.Checked = false;
                    Run.DeleteValue(name);
                    rk.Close();
                    ini.IniWriteValue("Account", "Windows", "0");
                }
                else
                {
                    开机启动ToolStripMenuItem.Checked = true;
                    Run.SetValue(name, path);
                    rk.Close();
                    ini.IniWriteValue("Account", "Windows", "1");
                }
            }
            catch (Exception)
            {
                Message m = new Message();
                m.lbTitle.Text = "权限提示";
                m.lbContent.Text = "请用管理员运行云隧道！";
                m.ShowDialog();
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Login.isLogin)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                Application.Exit();
                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }
    }
}
