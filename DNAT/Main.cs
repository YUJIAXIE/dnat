﻿using DNAT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNAT
{
    public partial class Main : Form
    {
        public static Main main;
        IniFiles ini = new IniFiles(Application.StartupPath + "\\Config.ini");
        IniFiles Frpini = new IniFiles(Application.StartupPath + "\\DnatConfig.ini");
        public static int Id;//用户ID，登录成功后保存
        public static string Version;
        public static string DoMain;//名称，登录成功后保存
        public static string DoMainInfo;
        public static string Date;
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
                Application.Exit();
            }
        }

        private void pMin_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            pClose.BackgroundImage = Properties.Resources.btn_close_nor;
        }

        private void pClose_MouseEnter(object sender, EventArgs e)
        {
            pClose.BackgroundImage = Properties.Resources.btn_close_down;
        }

        private void pMin_MouseEnter(object sender, EventArgs e)
        {
            pMin.BackgroundImage = Properties.Resources.btn_min_down;
        }

        private void pMin_MouseLeave(object sender, EventArgs e)
        {
            pMin.BackgroundImage = Properties.Resources.btn_min_nor;
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
            //var json = HTTP.Get("http://localhost:46324/Client/FRPConfig", "?Uid=" + Id + "&Id=0");
            //DataTable dt = Json.Json2DataTable(json);
            var json = HTTP.Get("http://localhost:46324/Client/FRPConfig", "?Uid=" + Id + "&Id=1&All=false");
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
            var Com = HTTP.Get("http://localhost:46324/Client/FRPConfig", "?Uid=" + Id + "&Id=0&All=true");
            DataTable Common = Json.Json2DataTable(Com);
            foreach (DataRow dr in Common.Rows)
            {
                Frpini.IniWriteValue(dr["MappingName"].ToString(),dr["Info"].ToString(), dr["Value"].ToString());
            }
            var frp = HTTP.Get("http://localhost:46324/Client/FRPConfig", "?Uid=" + Id + "&Id=1&All=true");
            DataTable User = Json.Json2DataTable(frp);
            foreach (DataRow dr in User.Rows)
            {
                Frpini.IniWriteValue(dr["MappingName"].ToString(), dr["Info"].ToString(), dr["Value"].ToString());
            }
            var dd = Application.StartupPath + "\\frp.exe";
            RunCmd2(dd,Frpini.inipath);

        }
        
        static bool RunCmd2(string cmdExe,string cmdStr)
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
                    myPro.WaitForExit();
                    result = true;
                }
            }
            catch
            {

            }
            return result;
        }
        private void btn_AddTunnel_Click(object sender, EventArgs e)
        {
            AddTunnel at = new AddTunnel();
            at.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
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
                var json = HTTP.Get("http://localhost:46324/Client/ClientLogin", "?DoMain=" + Name + "&PassWord=" + PassWord + "");
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
    }
}
