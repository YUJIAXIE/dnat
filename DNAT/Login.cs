using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Windows.Forms;

namespace DNAT
{
    public partial class Login : Form
    {
        public static bool isLogin = false;
        IniFiles ini = new IniFiles(Application.StartupPath + "\\Config.ini");
        #region 无边框属性
        private Point mousePoint = new Point();
        private void pClose_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
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
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            TbAccount.AutoSize = TbPassWord.AutoSize = false;
            TbAccount.Height = TbPassWord.Height = 35;
            string Name = ini.IniReadValue("Account", "Name");
            if (Name != "")
            {
                TbAccount.Text = Name;
            }
            string SavePwd = ini.IniReadValue("Account", "SavePassWord");
            if (SavePwd == "0")
            {
                TbPassWord.Text = string.Empty;
                cbAutoLogin.Enabled = false;
            }
            else if (SavePwd == "")
            {
                TbPassWord.Text = string.Empty;
                cbAutoLogin.Enabled = false;
            }
            else
            {
                TbPassWord.Text = "12345678910";
                cbSavePwd.Checked = true;
                cbAutoLogin.Enabled = true;
            }
            string AutoLogin = ini.IniReadValue("Account", "AutoLogin");
            if (AutoLogin == "1")
            {
                cbAutoLogin.Checked = true;
            }
        }

        private void TbAccount_MouseEnter(object sender, EventArgs e)
        {
            //if (this.TbAccount.Text == "用户名")
            //{
            //    this.TbAccount.Text = "";
            //}
        }

        private void TbAccount_MouseLeave(object sender, EventArgs e)
        {
            //if (this.TbAccount.Text.Length == 0)
            //{
            //    this.TbAccount.Text = "用户名";
            //}
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool IsLogin = false;
            string Pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(TbPassWord.Text, "MD5");
            string SavePwd = ini.IniReadValue("Account", "SavePassWord");
            string Name = ini.IniReadValue("Account", "Name");
            if (SavePwd == "1" && TbAccount.Text == Name)
            {
                Pwd = ini.IniReadValue("Account", "PassWord");
            }
            var json = HTTP.Get(Main.Url + "/Client/ClientLogin", "?DoMain=" + TbAccount.Text + "&PassWord=" + Pwd + "");
            DataTable dt = Json.Json2DataTable(json);
            if (dt.Rows.Count == 1)
            {
                IsLogin = Convert.ToBoolean(dt.Rows[0]["Login"].ToString());
            }
            if (IsLogin)
            {
                isLogin = true;
                ini.IniWriteValue("Account", "Name", TbAccount.Text);
                if (cbSavePwd.Checked)
                {
                    ini.IniWriteValue("Account", "SavePassWord", "1");
                    ini.IniWriteValue("Account", "PassWord", Pwd);
                }
                else
                {
                    ini.IniWriteValue("Account", "SavePassWord", "0");
                    ini.IniWriteValue("Account", "PassWord", "");
                }
                if (cbAutoLogin.Checked)
                {
                    ini.IniWriteValue("Account", "AutoLogin", "1");
                }
                else
                {
                    ini.IniWriteValue("Account", "AutoLogin", "0");
                }
                Main.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                Main.Pwd = Pwd;
                Main.Version = dt.Rows[0]["Value"].ToString();
                Main.DoMain = dt.Rows[0]["DoMain"].ToString();
                Main.DoMainInfo = dt.Rows[0]["DoMainName"].ToString();
                Main.Date = " [" + dt.Rows[0]["RegDate"] + "---" + dt.Rows[0]["EndDate"].ToString() + "]";
                this.Close();
            }
            else
            {
                Message m = new Message();
                m.lbTitle.Text = "错误提示";
                m.lbContent.Text = "账号或密码错误，请重新输入登录！";
                m.ShowDialog();
            }
        }

        private void cbSavePwd_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbSavePwd.Checked)
            {
                cbAutoLogin.Enabled = cbAutoLogin.Checked = false;
            }
            else
            {
                cbAutoLogin.Enabled = true;
            }
        }

        private void llbReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.baidu.com");
        }
    }
}
