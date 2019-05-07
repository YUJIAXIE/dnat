using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DNAT
{
    public partial class AddTunnel : Form
    {
        #region 无边框属性
        private Point mousePoint = new Point();
        private void pClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
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
        #endregion
        public AddTunnel()
        {
            InitializeComponent();
        }

        //验证IP格式
        public static bool IsValidIp(string strIn)
        {
            bool b = Regex.IsMatch(strIn, @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$");
            return b;
        }

        /// <summary>
        /// 验证字符串是否是域名
        /// </summary>
        /// <param name="str">指定字符串</param>
        /// <returns></returns>
        public static bool IsValidDomain(string str)
        {
            string pattern = @"^[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(\.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+$";
            Regex reg = new Regex(pattern);
            if (string.IsNullOrEmpty(str))
                return false;
            return reg.IsMatch(str);
        }
        /// <summary>
        /// 验证端口是否为数字
        /// </summary>
        /// <param name="Prot">端口</param>
        /// <returns></returns>
        public static bool IsValidProt(string Prot)
        {
            Regex regExp = new Regex("^[0-9]*$");
            return regExp.IsMatch(Prot);
        }
        private void RbDiyIpAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (RbDiyIpAddress.Checked)
            {
                TbIpAddress.Enabled = true;
            }
            else
            {
                TbIpAddress.Text = string.Empty;
                TbIpAddress.Enabled = false;
            }
        }

        private void RbDiyUrl_CheckedChanged(object sender, EventArgs e)
        {
            if (RbDiyUrl.Checked)
            {
                TbUrl.Enabled = true;
            }
            else
            {
                TbUrl.Text = string.Empty;
                TbUrl.Enabled = false;
            }
        }

        private void btnPreservation_Click(object sender, EventArgs e)
        {
            var DD = IsValidIp(TbIpAddress.Text);

            var n = IsValidProt("211");
            var FF = IsValidDomain(TbUrl.Text);
            var EE = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
