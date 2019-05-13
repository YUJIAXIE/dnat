namespace Client
{
    partial class Tunnel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbIp = new System.Windows.Forms.Label();
            this.llbUrl = new System.Windows.Forms.LinkLabel();
            this.BtnDelTunnel = new System.Windows.Forms.Button();
            this.lbMappingName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "访问地址:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "内部端口:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP地址:";
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(66, 43);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(35, 12);
            this.lbPort.TabIndex = 3;
            this.lbPort.Text = "65433";
            // 
            // lbIp
            // 
            this.lbIp.AutoSize = true;
            this.lbIp.Location = new System.Drawing.Point(66, 25);
            this.lbIp.Name = "lbIp";
            this.lbIp.Size = new System.Drawing.Size(95, 12);
            this.lbIp.TabIndex = 4;
            this.lbIp.Text = "192.168.168.168";
            // 
            // llbUrl
            // 
            this.llbUrl.AutoSize = true;
            this.llbUrl.Location = new System.Drawing.Point(66, 8);
            this.llbUrl.Name = "llbUrl";
            this.llbUrl.Size = new System.Drawing.Size(41, 12);
            this.llbUrl.TabIndex = 6;
            this.llbUrl.TabStop = true;
            this.llbUrl.Text = "llbUrl";
            // 
            // BtnDelTunnel
            // 
            this.BtnDelTunnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelTunnel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(130)))), ((int)(((byte)(166)))));
            this.BtnDelTunnel.Location = new System.Drawing.Point(229, 25);
            this.BtnDelTunnel.Name = "BtnDelTunnel";
            this.BtnDelTunnel.Size = new System.Drawing.Size(43, 23);
            this.BtnDelTunnel.TabIndex = 7;
            this.BtnDelTunnel.Text = "删除";
            this.BtnDelTunnel.UseVisualStyleBackColor = false;
            this.BtnDelTunnel.Click += new System.EventHandler(this.BtnDelTunnel_Click);
            this.BtnDelTunnel.MouseEnter += new System.EventHandler(this.BtnDelTunnel_MouseEnter);
            // 
            // lbMappingName
            // 
            this.lbMappingName.AutoSize = true;
            this.lbMappingName.Location = new System.Drawing.Point(126, 43);
            this.lbMappingName.Name = "lbMappingName";
            this.lbMappingName.Size = new System.Drawing.Size(0, 12);
            this.lbMappingName.TabIndex = 8;
            this.lbMappingName.Visible = false;
            // 
            // Tunnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbMappingName);
            this.Controls.Add(this.BtnDelTunnel);
            this.Controls.Add(this.llbUrl);
            this.Controls.Add(this.lbIp);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Tunnel";
            this.Size = new System.Drawing.Size(280, 60);
            this.DoubleClick += new System.EventHandler(this.Tunnel_DoubleClick);
            this.MouseEnter += new System.EventHandler(this.Tunnel_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Tunnel_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnDelTunnel;
        public System.Windows.Forms.Label lbPort;
        public System.Windows.Forms.Label lbIp;
        public System.Windows.Forms.LinkLabel llbUrl;
        public System.Windows.Forms.Label lbMappingName;
    }
}
