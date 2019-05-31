using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Main : Form
    {
        //public static string Url = "http://www.xyujia.cn";
        public static string Url = "http://localhost:81";
        public string processName = "ctc";
        public static Main main;
        IniFiles ini = new IniFiles(Application.StartupPath + "\\Config.ini");
        IniFiles Frpini = new IniFiles(Application.StartupPath + "\\CtcConfig.ini");
        public static int Id;//用户ID，登录成功后保存
        public static string Version;
        public static string DoMain;//名称，登录成功后保存
        public static string DoMainInfo;
        /// <summary>
        /// 到期时间
        /// </summary>
        public static string EndDate;
        public static string Pwd;

        System.Timers.Timer pTimer = new System.Timers.Timer(5000);//每隔5秒执行一次，没用winfrom自带的
        System.Timers.Timer StopRun = new System.Timers.Timer(10000);//每隔5秒执行一次，没用winfrom自带的
        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion
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
        /// <summary>
        /// 隧道列表
        /// </summary>
        public void InitializeTunnel()
        {
            flowLayoutPanel1.Controls.Clear();
            var json = HTTP.Get(Url + "/Api/FRPConfig", "?Uid=" + Id + "&Id=1&All=True");
            DataTable dt = Json.Json2DataTable(json);
            foreach (DataRow dr in dt.Rows)
            {
                Tunnel t = new Tunnel();
                t.lbMappingName.Text = dr["MappingName"].ToString();
                t.llbUrl.Text = "http://" + dr["custom_domains"] + ":" + dr["remote_port"];
                t.lbIp.Text = dr["local_ip"].ToString();
                t.lbPort.Text = dr["local_port"].ToString();
                t.lbtype.Text = dr["type"].ToString();
                //t.Location = new Point(5, 5 + 60 * i);
                flowLayoutPanel1.Controls.Add(t);
            }
        }

        void Test()
        {
            var netTime = Convert.ToDateTime(GetNetDateTime());

            int compNum = DateTime.Compare(netTime, Convert.ToDateTime(EndDate));
            //此处加判断是否过期
            if (compNum <= 0)
            {
                var Com = HTTP.Get(Url + "/Api/FRPConfig", "?UId=" + Id + "&Id=0&All=False");
                DataTable Common = Json.Json2DataTable(Com);
                foreach (DataRow dr in Common.Rows)
                {
                    Frpini.IniWriteValue(dr["MappingName"].ToString(), dr["Info"].ToString(), dr["Value"].ToString());
                }
                var frp = HTTP.Get(Url + "/Api/FRPConfig", "?UId=" + Id + "&Id=1&All=False");
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
                        StopRun.Elapsed += Stopctc_Elapsed;//委托，要执行的方法
                        StopRun.AutoReset = true;//获取该定时器自动执行
                        StopRun.Enabled = true;//这个一定要写，要不然定时器不会执行的
                        Control.CheckForIllegalCrossThreadCalls = false;//这个不太懂，有待研究
                        picSus.Image = Properties.Resources.ball_green;
                    }
                    else
                    {
                        picSus.Image = Properties.Resources.ball_grey;
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
            else
            {
                Message m = new Message();
                m.lbTitle.Text = "提示";
                m.lbContent.Text = "域名已过期，请续费！";
                m.ShowDialog();
            }
            File.Delete(Frpini.inipath);//删除ini文件

        }
        /// <summary>
        /// 定时清理内存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ClearMemory();
        }
        /// <summary>
        /// 定时清理内存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stopctc_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var netTime = Convert.ToDateTime(GetNetDateTime());

            int compNum = DateTime.Compare(netTime, Convert.ToDateTime(EndDate));
            //此处加判断是否过期
            if (compNum > 0)
            {
                Main.main.picSus.Image = Properties.Resources.ball_grey;
                Main.main.KillProcess(processName);
                StopRun.Stop();
                Message m = new Message();
                m.lbTitle.Text = "提示";
                m.lbContent.Text = "域名已过期，请续费！";
                m.ShowDialog();

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
                else if (item.ProcessName == "conhost")
                {
                    item.Kill();
                }
            }
        }
        private void btn_AddTunnel_Click(object sender, EventArgs e)
        {
            var result = Convert.ToBoolean(HTTP.Get(Url + "/Api/AddTunnel", "?Id=" + Id));
            if (result)
            {
                AddTunnel at = new AddTunnel();
                at.ShowDialog();
            }
            else
            {
                Message m = new Message();
                m.lbTitle.Text = "提示";
                m.lbContent.Text = "禁止添加\r\n\r\n原因：已超出购买的最大隧道数量";
                m.ShowDialog();
            }

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
                var json = HTTP.Get(Url + "/Api/Login", "?DoMain=" + Name + "&PassWord=" + PassWord + "&Client=True");
                DataTable dt = Json.Json2DataTable(json);
                Login.isLogin = true;
                if (dt.Rows.Count == 1)
                {
                    Main.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                    Main.Version = dt.Rows[0]["ECSType"].ToString();
                    Main.DoMain = dt.Rows[0]["DoMain"].ToString();
                    Main.DoMainInfo = dt.Rows[0]["DoMainName"].ToString() + " [" + Convert.ToDateTime(dt.Rows[0]["RegDate"]).ToShortDateString() + "---" + Convert.ToDateTime(dt.Rows[0]["EndDate"]).ToShortDateString() + "]";
                    Main.EndDate = dt.Rows[0]["EndDate"].ToString();
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
            lbDoMainInfo.Text = DoMainInfo;
            ini.IniWriteValue("Account", "ReLogin", "1");
            InitializeTunnel();
            Test();


            pTimer.Elapsed += pTimer_Elapsed;//委托，要执行的方法
            pTimer.AutoReset = true;//获取该定时器自动执行
            pTimer.Enabled = true;//这个一定要写，要不然定时器不会执行的
            Control.CheckForIllegalCrossThreadCalls = false;//这个不太懂，有待研究
            
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

        private void lbVer_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 获取网络时间
        /// </summary>
        /// <returns></returns>
        public static string GetNetDateTime()
        {
            WebRequest request = null;
            WebResponse response = null;
            WebHeaderCollection headerCollection = null;
            string datetime = string.Empty;
            try
            {
                request = WebRequest.Create("https://www.baidu.com");
                request.Timeout = 3000;
                request.Credentials = CredentialCache.DefaultCredentials;
                response = request.GetResponse();
                headerCollection = response.Headers;
                foreach (var h in headerCollection.AllKeys)
                {
                    if (h == "Date")
                    {
                        datetime = headerCollection[h];
                    }
                }
                return datetime;
            }
            catch (Exception) { return datetime; }
            finally
            {
                if (request != null)
                { request.Abort(); }
                if (response != null)
                { response.Close(); }
                if (headerCollection != null)
                { headerCollection.Clear(); }
            }
        }

        private void llbRenew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Main.Url);
        }
    }
}
