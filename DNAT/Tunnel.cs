using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNAT
{
    public partial class Tunnel : UserControl
    {
        public Tunnel()
        {
            InitializeComponent();
        }

        private void Tunnel_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor= Color.FromArgb(240, 240, 240);
        }

        private void Tunnel_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void Tunnel_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(llbUrl.Text);
        }

        private void BtnDelTunnel_MouseEnter(object sender, EventArgs e)
        {
            Tunnel_MouseEnter(this,e);
        }

        private void BtnDelTunnel_Click(object sender, EventArgs e)
        {
            Message m = new Message();
            m.lbTitle.Text = "删除隧道提示";
            m.lbContent.Text = "隧道删除后将无法恢复，影响使用是否删除！";
            m.ShowDialog();
            if (m.DialogResult == DialogResult.Yes)
            {
                var json = HTTP.Get("http://localhost:46324/Client/DeleteFrp", "?UId=" + Main.Id.ToString() + "&MappingName=" + lbMappingName.Text + "");
            }
            Main.main.InitializeTunnel();
            Main.main.lbStats.Text = "未运行";
            Main.main.KillProcess();
        }
    }
}
