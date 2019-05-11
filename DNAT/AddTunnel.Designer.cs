namespace DNAT
{
    partial class AddTunnel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTunnel));
            this.pBar = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pClose = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.RbIpAddress = new System.Windows.Forms.RadioButton();
            this.RbDiyIpAddress = new System.Windows.Forms.RadioButton();
            this.TbIpAddress = new System.Windows.Forms.TextBox();
            this.tbNProt = new System.Windows.Forms.TextBox();
            this.tbWProt = new System.Windows.Forms.TextBox();
            this.TbUrl = new System.Windows.Forms.TextBox();
            this.RbDiyUrl = new System.Windows.Forms.RadioButton();
            this.RbUrl = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPreservation = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.pBar.Controls.Add(this.lbTitle);
            this.pBar.Controls.Add(this.pClose);
            this.pBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBar.Location = new System.Drawing.Point(0, 0);
            this.pBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(373, 50);
            this.pBar.TabIndex = 1;
            this.pBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBar_MouseDown);
            this.pBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBar_MouseMove);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(16, 18);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(67, 15);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "添加隧道";
            // 
            // pClose
            // 
            this.pClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pClose.BackgroundImage")));
            this.pClose.Location = new System.Drawing.Point(329, 9);
            this.pClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(32, 30);
            this.pClose.TabIndex = 0;
            this.pClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pClose_MouseClick);
            this.pClose.MouseEnter += new System.EventHandler(this.pClose_MouseEnter);
            this.pClose.MouseLeave += new System.EventHandler(this.pClose_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "隧道类型:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP地址:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "程序端口:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "外网端口:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "访问域名:";
            // 
            // cbbType
            // 
            this.cbbType.BackColor = System.Drawing.SystemColors.Control;
            this.cbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Items.AddRange(new object[] {
            "TCP",
            "HTTP"});
            this.cbbType.Location = new System.Drawing.Point(103, 60);
            this.cbbType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(247, 23);
            this.cbbType.TabIndex = 9;
            // 
            // RbIpAddress
            // 
            this.RbIpAddress.AutoSize = true;
            this.RbIpAddress.Checked = true;
            this.RbIpAddress.Location = new System.Drawing.Point(13, 4);
            this.RbIpAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RbIpAddress.Name = "RbIpAddress";
            this.RbIpAddress.Size = new System.Drawing.Size(58, 19);
            this.RbIpAddress.TabIndex = 10;
            this.RbIpAddress.TabStop = true;
            this.RbIpAddress.Text = "本机";
            this.RbIpAddress.UseVisualStyleBackColor = true;
            // 
            // RbDiyIpAddress
            // 
            this.RbDiyIpAddress.AutoSize = true;
            this.RbDiyIpAddress.Location = new System.Drawing.Point(72, 4);
            this.RbDiyIpAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RbDiyIpAddress.Name = "RbDiyIpAddress";
            this.RbDiyIpAddress.Size = new System.Drawing.Size(58, 19);
            this.RbDiyIpAddress.TabIndex = 11;
            this.RbDiyIpAddress.Text = "其他";
            this.RbDiyIpAddress.UseVisualStyleBackColor = true;
            this.RbDiyIpAddress.CheckedChanged += new System.EventHandler(this.RbDiyIpAddress_CheckedChanged);
            // 
            // TbIpAddress
            // 
            this.TbIpAddress.Enabled = false;
            this.TbIpAddress.Location = new System.Drawing.Point(103, 118);
            this.TbIpAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbIpAddress.Name = "TbIpAddress";
            this.TbIpAddress.Size = new System.Drawing.Size(247, 25);
            this.TbIpAddress.TabIndex = 12;
            // 
            // tbNProt
            // 
            this.tbNProt.Location = new System.Drawing.Point(101, 151);
            this.tbNProt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbNProt.Name = "tbNProt";
            this.tbNProt.Size = new System.Drawing.Size(248, 25);
            this.tbNProt.TabIndex = 13;
            // 
            // tbWProt
            // 
            this.tbWProt.Location = new System.Drawing.Point(103, 185);
            this.tbWProt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbWProt.Name = "tbWProt";
            this.tbWProt.Size = new System.Drawing.Size(247, 25);
            this.tbWProt.TabIndex = 14;
            // 
            // TbUrl
            // 
            this.TbUrl.Enabled = false;
            this.TbUrl.Location = new System.Drawing.Point(103, 246);
            this.TbUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbUrl.Name = "TbUrl";
            this.TbUrl.Size = new System.Drawing.Size(247, 25);
            this.TbUrl.TabIndex = 17;
            // 
            // RbDiyUrl
            // 
            this.RbDiyUrl.AutoSize = true;
            this.RbDiyUrl.Location = new System.Drawing.Point(72, 4);
            this.RbDiyUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RbDiyUrl.Name = "RbDiyUrl";
            this.RbDiyUrl.Size = new System.Drawing.Size(73, 19);
            this.RbDiyUrl.TabIndex = 16;
            this.RbDiyUrl.Text = "自定义";
            this.RbDiyUrl.UseVisualStyleBackColor = true;
            this.RbDiyUrl.CheckedChanged += new System.EventHandler(this.RbDiyUrl_CheckedChanged);
            // 
            // RbUrl
            // 
            this.RbUrl.AutoSize = true;
            this.RbUrl.Checked = true;
            this.RbUrl.Location = new System.Drawing.Point(13, 4);
            this.RbUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RbUrl.Name = "RbUrl";
            this.RbUrl.Size = new System.Drawing.Size(58, 19);
            this.RbUrl.TabIndex = 15;
            this.RbUrl.TabStop = true;
            this.RbUrl.Text = "默认";
            this.RbUrl.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.RbDiyIpAddress);
            this.panel1.Controls.Add(this.RbIpAddress);
            this.panel1.Location = new System.Drawing.Point(92, 90);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 32);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RbDiyUrl);
            this.panel2.Controls.Add(this.RbUrl);
            this.panel2.Location = new System.Drawing.Point(92, 219);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 36);
            this.panel2.TabIndex = 19;
            // 
            // btnPreservation
            // 
            this.btnPreservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(130)))), ((int)(((byte)(166)))));
            this.btnPreservation.Location = new System.Drawing.Point(101, 280);
            this.btnPreservation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreservation.Name = "btnPreservation";
            this.btnPreservation.Size = new System.Drawing.Size(100, 29);
            this.btnPreservation.TabIndex = 20;
            this.btnPreservation.Text = "确定";
            this.btnPreservation.UseVisualStyleBackColor = true;
            this.btnPreservation.Click += new System.EventHandler(this.btnPreservation_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(130)))), ((int)(((byte)(166)))));
            this.btnCancel.Location = new System.Drawing.Point(251, 280);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddTunnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 325);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPreservation);
            this.Controls.Add(this.TbUrl);
            this.Controls.Add(this.tbWProt);
            this.Controls.Add(this.tbNProt);
            this.Controls.Add(this.TbIpAddress);
            this.Controls.Add(this.cbbType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddTunnel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加隧道";
            this.pBar.ResumeLayout(false);
            this.pBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pBar;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.RadioButton RbIpAddress;
        private System.Windows.Forms.RadioButton RbDiyIpAddress;
        private System.Windows.Forms.TextBox TbIpAddress;
        private System.Windows.Forms.TextBox tbNProt;
        private System.Windows.Forms.TextBox tbWProt;
        private System.Windows.Forms.TextBox TbUrl;
        private System.Windows.Forms.RadioButton RbDiyUrl;
        private System.Windows.Forms.RadioButton RbUrl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPreservation;
        private System.Windows.Forms.Button btnCancel;
    }
}