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
    public partial class Main : Form
    {
        public static int adminid;//用户ID，登录成功后保存
        public static string level;//权限，登录成功后保存
        public static string name;//名称，登录成功后保存
        #region 无边框属性
        private Point mousePoint = new Point();
        private void pClose_MouseClick(object sender, MouseEventArgs e)
        {
            Message m = new Message();
            m.lbTitle.Text = "操作提示";
            m.lbContent.Text = "是否退出？";
            m.ShowDialog();
            if (m.DialogResult==DialogResult.Yes)
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
            InitializeComponent();
            dd();
        }
        
        


        void dd()
        {
            //遍历查询到的所有学科集合，将每一行添加一个用户控件
            for (int i = 1; i < 6; i++)
            {
                Tunnel t = new Tunnel();
                t.llbUrl.Text = "http://" + i;
                t.lbIp.Text = "192.168.166." + i;
                t.lbPort.Text = "21" + i;
                //t.Location = new Point(5, 5 + 60 * i);
                flowLayoutPanel1.Controls.Add(t);
                
            }
        }

        private void btn_AddTunnel_Click(object sender, EventArgs e)
        {
            AddTunnel at = new AddTunnel();
            at.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Owner = this;
            l.ShowDialog();
        }
    }
}
