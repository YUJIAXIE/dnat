namespace DNAT
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pBar = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pMin = new System.Windows.Forms.Panel();
            this.pClose = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_AddTunnel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStats = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbVer = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.llbRenew = new System.Windows.Forms.LinkLabel();
            this.lbDoMainInfo = new System.Windows.Forms.Label();
            this.btnRelogin = new System.Windows.Forms.Button();
            this.pBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.BackColor = System.Drawing.Color.Transparent;
            this.pBar.Controls.Add(this.lbTitle);
            this.pBar.Controls.Add(this.pMin);
            this.pBar.Controls.Add(this.pClose);
            this.pBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBar.Location = new System.Drawing.Point(0, 0);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(280, 40);
            this.pBar.TabIndex = 1;
            this.pBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBar_MouseDown);
            this.pBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBar_MouseMove);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(31, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(44, 17);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "隧道通";
            // 
            // pMin
            // 
            this.pMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pMin.BackgroundImage")));
            this.pMin.Location = new System.Drawing.Point(217, 7);
            this.pMin.Name = "pMin";
            this.pMin.Size = new System.Drawing.Size(24, 24);
            this.pMin.TabIndex = 1;
            this.pMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pMin_MouseClick);
            this.pMin.MouseEnter += new System.EventHandler(this.pMin_MouseEnter);
            this.pMin.MouseLeave += new System.EventHandler(this.pMin_MouseLeave);
            // 
            // pClose
            // 
            this.pClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pClose.BackgroundImage")));
            this.pClose.Location = new System.Drawing.Point(246, 7);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(24, 24);
            this.pClose.TabIndex = 0;
            this.pClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pClose_MouseClick);
            this.pClose.MouseEnter += new System.EventHandler(this.pClose_MouseEnter);
            this.pClose.MouseLeave += new System.EventHandler(this.pClose_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(210)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.btn_AddTunnel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 40);
            this.panel1.TabIndex = 2;
            // 
            // btn_AddTunnel
            // 
            this.btn_AddTunnel.BackColor = System.Drawing.Color.Transparent;
            this.btn_AddTunnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddTunnel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(130)))), ((int)(((byte)(166)))));
            this.btn_AddTunnel.Location = new System.Drawing.Point(182, 9);
            this.btn_AddTunnel.Name = "btn_AddTunnel";
            this.btn_AddTunnel.Size = new System.Drawing.Size(75, 23);
            this.btn_AddTunnel.TabIndex = 2;
            this.btn_AddTunnel.Text = "添加隧道";
            this.btn_AddTunnel.UseVisualStyleBackColor = false;
            this.btn_AddTunnel.Click += new System.EventHandler(this.btn_AddTunnel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "隧道列表:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 1);
            this.panel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(225)))), ((int)(((byte)(238)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-4, 212);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(305, 332);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(188, 561);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "状态：";
            // 
            // lbStats
            // 
            this.lbStats.AutoSize = true;
            this.lbStats.BackColor = System.Drawing.Color.Transparent;
            this.lbStats.Location = new System.Drawing.Point(225, 561);
            this.lbStats.Name = "lbStats";
            this.lbStats.Size = new System.Drawing.Size(41, 12);
            this.lbStats.TabIndex = 5;
            this.lbStats.Text = "未运行";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::DNAT.Properties.Resources.user;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(34, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(52, 46);
            this.panel3.TabIndex = 6;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbName.Location = new System.Drawing.Point(91, 67);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(40, 16);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(188, 579);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "版本：";
            // 
            // lbVer
            // 
            this.lbVer.AutoSize = true;
            this.lbVer.BackColor = System.Drawing.Color.Transparent;
            this.lbVer.Location = new System.Drawing.Point(225, 579);
            this.lbVer.Name = "lbVer";
            this.lbVer.Size = new System.Drawing.Size(23, 12);
            this.lbVer.TabIndex = 9;
            this.lbVer.Text = "Ver";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.AliceBlue;
            this.panel4.Controls.Add(this.llbRenew);
            this.panel4.Controls.Add(this.lbDoMainInfo);
            this.panel4.Location = new System.Drawing.Point(0, 184);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(280, 28);
            this.panel4.TabIndex = 10;
            // 
            // llbRenew
            // 
            this.llbRenew.AutoSize = true;
            this.llbRenew.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbRenew.LinkColor = System.Drawing.Color.Orange;
            this.llbRenew.Location = new System.Drawing.Point(227, 8);
            this.llbRenew.Name = "llbRenew";
            this.llbRenew.Size = new System.Drawing.Size(29, 12);
            this.llbRenew.TabIndex = 1;
            this.llbRenew.TabStop = true;
            this.llbRenew.Text = "续费";
            // 
            // lbDoMainInfo
            // 
            this.lbDoMainInfo.AutoSize = true;
            this.lbDoMainInfo.Location = new System.Drawing.Point(11, 8);
            this.lbDoMainInfo.Name = "lbDoMainInfo";
            this.lbDoMainInfo.Size = new System.Drawing.Size(29, 12);
            this.lbDoMainInfo.TabIndex = 0;
            this.lbDoMainInfo.Text = "Info";
            // 
            // btnRelogin
            // 
            this.btnRelogin.BackColor = System.Drawing.Color.Transparent;
            this.btnRelogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(130)))), ((int)(((byte)(166)))));
            this.btnRelogin.Location = new System.Drawing.Point(181, 106);
            this.btnRelogin.Name = "btnRelogin";
            this.btnRelogin.Size = new System.Drawing.Size(75, 23);
            this.btnRelogin.TabIndex = 3;
            this.btnRelogin.Text = "重新登录";
            this.btnRelogin.UseVisualStyleBackColor = false;
            this.btnRelogin.Click += new System.EventHandler(this.btnRelogin_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(280, 600);
            this.Controls.Add(this.btnRelogin);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lbVer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbStats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.Load += new System.EventHandler(this.Main_Load);
            this.pBar.ResumeLayout(false);
            this.pBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pBar;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pMin;
        private System.Windows.Forms.Panel pClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_AddTunnel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbVer;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel llbRenew;
        private System.Windows.Forms.Label lbDoMainInfo;
        private System.Windows.Forms.Button btnRelogin;
        public System.Windows.Forms.Label lbStats;
    }
}