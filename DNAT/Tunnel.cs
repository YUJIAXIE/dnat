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
    }
}
