using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNAT
{
    public partial class Login : Form
    {
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
        }

        private void TbAccount_MouseEnter(object sender, EventArgs e)
        {
            if (this.TbAccount.Text == "用户名")
            {
                this.TbAccount.Text = "";
            }
        }

        private void TbAccount_MouseLeave(object sender, EventArgs e)
        {
            if (this.TbAccount.Text.Length == 0)
            {
                this.TbAccount.Text = "用户名";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (TbAccount.Text=="123"&&TbPassWord.Text=="123")
            {
                Main.adminid = 123;
                Main.name = TbAccount.Text;
                this.Close();
            }
        }
    }
}
