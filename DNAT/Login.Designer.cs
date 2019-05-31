namespace Client
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pBar = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pMin = new System.Windows.Forms.Panel();
            this.pClose = new System.Windows.Forms.Panel();
            this.TbAccount = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TbPassWord = new System.Windows.Forms.TextBox();
            this.cbSavePwd = new System.Windows.Forms.CheckBox();
            this.cbAutoLogin = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.llbReg = new System.Windows.Forms.LinkLabel();
            this.llbResetPassWord = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.BackColor = System.Drawing.Color.Transparent;
            this.pBar.Controls.Add(this.panel5);
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
            // panel5
            // 
            this.panel5.BackgroundImage = global::Client.Properties.Resources.logo1;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Location = new System.Drawing.Point(11, 9);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(25, 25);
            this.panel5.TabIndex = 12;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(38, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(44, 17);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "云隧道";
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
            // TbAccount
            // 
            this.TbAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(176)))), ((int)(((byte)(248)))));
            this.TbAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbAccount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbAccount.ForeColor = System.Drawing.Color.Snow;
            this.TbAccount.Location = new System.Drawing.Point(5, 9);
            this.TbAccount.Name = "TbAccount";
            this.TbAccount.Size = new System.Drawing.Size(156, 16);
            this.TbAccount.TabIndex = 2;
            this.TbAccount.MouseEnter += new System.EventHandler(this.TbAccount_MouseEnter);
            this.TbAccount.MouseLeave += new System.EventHandler(this.TbAccount_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(176)))), ((int)(((byte)(248)))));
            this.panel1.Controls.Add(this.TbAccount);
            this.panel1.Location = new System.Drawing.Point(75, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 36);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(176)))), ((int)(((byte)(248)))));
            this.panel2.Controls.Add(this.TbPassWord);
            this.panel2.Location = new System.Drawing.Point(75, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 36);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // TbPassWord
            // 
            this.TbPassWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(176)))), ((int)(((byte)(248)))));
            this.TbPassWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbPassWord.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbPassWord.ForeColor = System.Drawing.Color.Snow;
            this.TbPassWord.Location = new System.Drawing.Point(3, 9);
            this.TbPassWord.Name = "TbPassWord";
            this.TbPassWord.PasswordChar = '*';
            this.TbPassWord.Size = new System.Drawing.Size(157, 16);
            this.TbPassWord.TabIndex = 2;
            // 
            // cbSavePwd
            // 
            this.cbSavePwd.AutoSize = true;
            this.cbSavePwd.BackColor = System.Drawing.Color.Transparent;
            this.cbSavePwd.ForeColor = System.Drawing.Color.White;
            this.cbSavePwd.Location = new System.Drawing.Point(42, 341);
            this.cbSavePwd.Name = "cbSavePwd";
            this.cbSavePwd.Size = new System.Drawing.Size(72, 16);
            this.cbSavePwd.TabIndex = 6;
            this.cbSavePwd.Text = "记住密码";
            this.cbSavePwd.UseVisualStyleBackColor = false;
            this.cbSavePwd.CheckedChanged += new System.EventHandler(this.cbSavePwd_CheckedChanged);
            // 
            // cbAutoLogin
            // 
            this.cbAutoLogin.AutoSize = true;
            this.cbAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.cbAutoLogin.Enabled = false;
            this.cbAutoLogin.ForeColor = System.Drawing.Color.White;
            this.cbAutoLogin.Location = new System.Drawing.Point(168, 341);
            this.cbAutoLogin.Name = "cbAutoLogin";
            this.cbAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.cbAutoLogin.TabIndex = 7;
            this.cbAutoLogin.Text = "自动登录";
            this.cbAutoLogin.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Location = new System.Drawing.Point(42, 373);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(200, 31);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "登  录";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // llbReg
            // 
            this.llbReg.ActiveLinkColor = System.Drawing.Color.Blue;
            this.llbReg.AutoSize = true;
            this.llbReg.BackColor = System.Drawing.Color.Transparent;
            this.llbReg.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbReg.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.llbReg.Location = new System.Drawing.Point(40, 417);
            this.llbReg.Name = "llbReg";
            this.llbReg.Size = new System.Drawing.Size(53, 12);
            this.llbReg.TabIndex = 9;
            this.llbReg.TabStop = true;
            this.llbReg.Text = "注册账户";
            this.llbReg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbReg_LinkClicked);
            // 
            // llbResetPassWord
            // 
            this.llbResetPassWord.ActiveLinkColor = System.Drawing.Color.Blue;
            this.llbResetPassWord.AutoSize = true;
            this.llbResetPassWord.BackColor = System.Drawing.Color.Transparent;
            this.llbResetPassWord.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbResetPassWord.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.llbResetPassWord.Location = new System.Drawing.Point(187, 417);
            this.llbResetPassWord.Name = "llbResetPassWord";
            this.llbResetPassWord.Size = new System.Drawing.Size(53, 12);
            this.llbResetPassWord.TabIndex = 10;
            this.llbResetPassWord.TabStop = true;
            this.llbResetPassWord.Text = "找回密码";
            this.llbResetPassWord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbResetPassWord_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(40, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(40, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "密码";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Location = new System.Drawing.Point(38, 81);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(210, 100);
            this.panel3.TabIndex = 13;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(280, 600);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llbResetPassWord);
            this.Controls.Add(this.llbReg);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbAutoLogin);
            this.Controls.Add(this.cbSavePwd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "云隧道登录";
            this.Load += new System.EventHandler(this.Login_Load);
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
        private System.Windows.Forms.Panel pMin;
        private System.Windows.Forms.Panel pClose;
        private System.Windows.Forms.TextBox TbAccount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TbPassWord;
        private System.Windows.Forms.CheckBox cbSavePwd;
        private System.Windows.Forms.CheckBox cbAutoLogin;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.LinkLabel llbReg;
        private System.Windows.Forms.LinkLabel llbResetPassWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
    }
}