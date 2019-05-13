using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Client
{
    public partial class AddTunnel : Form
    {
        public string processName = "frp";
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
            pClose.BackgroundImage = Client.Properties.Resources.btn_close_nor;
        }

        private void pClose_MouseEnter(object sender, EventArgs e)
        {
            pClose.BackgroundImage = Client.Properties.Resources.btn_close_down;
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
            if (Prot == "")
            {
                return false;
            }
            else
            {
                Regex regExp = new Regex("^[0-9]*$");
                return regExp.IsMatch(Prot);
            }

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
            string type, ip, nprot, wprot, url;
            if (cbbType.Text != "")
                type = cbbType.Text;
            else
                type = "";
            if (RbIpAddress.Checked)
                ip = "0.0.0.0";
            else
                ip = TbIpAddress.Text;
            if (tbNProt.Text != "")
                nprot = tbNProt.Text;
            else
                nprot = "";
            if (tbWProt.Text != "")
                wprot = tbWProt.Text;
            else
                wprot = "";
            if (RbUrl.Checked)
                url = Main.DoMain + "." + Main.DoMainInfo;
            else
                url = TbUrl.Text;

            if (type != "" && IsValidIp(ip) && IsValidProt(nprot) && IsValidProt(wprot) && IsValidDomain(url))
            {
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("UId", Type.GetType("System.String"));
                DataColumn dc2 = new DataColumn("Info", Type.GetType("System.String"));
                DataColumn dc3 = new DataColumn("Value", Type.GetType("System.String"));
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dt.Rows.Add(new object[] { Main.Id, "type", type.ToLower() });
                dt.Rows.Add(new object[] { Main.Id, "local_ip", ip });
                dt.Rows.Add(new object[] { Main.Id, "local_port", nprot });
                dt.Rows.Add(new object[] { Main.Id, "remote_port", wprot });
                dt.Rows.Add(new object[] { Main.Id, "custom_domains", url });

                var Json = JsonConvert.SerializeObject(dt);
                var json = HTTP.Get(Main.Url + "/Client/InsertFrp", "?Tunnel=" + Json);
                if (json == "true")
                {
                    Main.main.InitializeTunnel();
                    Main.main.lbStats.Text = "未运行";
                    Main.main.KillProcess(processName);
                    this.Close();
                }
                else
                {
                    Message m = new Message();
                    m.lbTitle.Text = "添加错误提示";
                    m.lbContent.Text = "请检查外网端口已添加！";
                    m.ShowDialog();
                }
            }
            else
            {
                Message m = new Message();
                m.lbTitle.Text = "添加错误提示";
                m.lbContent.Text = "任意一项不能为空";
                m.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
