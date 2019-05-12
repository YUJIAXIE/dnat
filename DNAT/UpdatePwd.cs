using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;

namespace DNAT
{
    public partial class UpdatePwd : Form
    {
        IniFiles ini = new IniFiles(Application.StartupPath + "\\Config.ini");
        #region 无边框属性
        private Point mousePoint = new Point();
        private void pClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
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

        #endregion
        public UpdatePwd()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string OldPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(tBOldPwd.Text, "MD5");
            string NewPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(tBNewPwd.Text, "MD5");
            string ReNewPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(tBRePwd.Text, "MD5");
            if (OldPwd != Main.Pwd)
            {
                Message m = new Message();
                m.lbTitle.Text = "密码修改提示";
                m.lbContent.Text = "新密码与确认密码不一致!";
                m.ShowDialog();
            }
            else if (NewPwd != ReNewPwd)
            {
                Message m = new Message();
                m.lbTitle.Text = "密码修改提示";
                m.lbContent.Text = "新密码与确认密码不一致!";
                m.ShowDialog();
            }
            else
            {
                var result = HTTP.Get(Main.Url + "/Client/UpdatePwd", "?Id=" + Main.Id + "&PassWord=" + ReNewPwd);
                if (result=="true")
                {
                    ini.IniWriteValue("Account", "PassWord", ReNewPwd);
                    ini.IniWriteValue("Account", "ReLogin", "0");
                    Application.Exit();
                    System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                }
                else
                {
                    Message m = new Message();
                    m.lbTitle.Text = "密码修改提示";
                    m.lbContent.Text = "修改失败!";
                    m.ShowDialog();
                }
                
            }

        }

        private void btnCannel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
