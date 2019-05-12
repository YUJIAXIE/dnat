namespace DNAT
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
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
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
            this.pBar.Controls.Add(this.lbTitle);
            this.pBar.Controls.Add(this.pMin);
            this.pBar.Controls.Add(this.pClose);
            this.pBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBar.Location = new System.Drawing.Point(0, 0);
            this.pBar.Margin = new System.Windows.Forms.Padding(4);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(373, 50);
            this.pBar.TabIndex = 1;
            this.pBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBar_MouseDown);
            this.pBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBar_MouseMove);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(40, 15);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(54, 20);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "隧道通";
            // 
            // pMin
            // 
            this.pMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pMin.BackgroundImage")));
            this.pMin.Location = new System.Drawing.Point(289, 9);
            this.pMin.Margin = new System.Windows.Forms.Padding(4);
            this.pMin.Name = "pMin";
            this.pMin.Size = new System.Drawing.Size(32, 30);
            this.pMin.TabIndex = 1;
            this.pMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pMin_MouseClick);
            this.pMin.MouseEnter += new System.EventHandler(this.pMin_MouseEnter);
            this.pMin.MouseLeave += new System.EventHandler(this.pMin_MouseLeave);
            // 
            // pClose
            // 
            this.pClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pClose.BackgroundImage")));
            this.pClose.Location = new System.Drawing.Point(328, 9);
            this.pClose.Margin = new System.Windows.Forms.Padding(4);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(32, 30);
            this.pClose.TabIndex = 0;
            this.pClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pClose_MouseClick);
            this.pClose.MouseEnter += new System.EventHandler(this.pClose_MouseEnter);
            this.pClose.MouseLeave += new System.EventHandler(this.pClose_MouseLeave);
            // 
            // TbAccount
            // 
            this.TbAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.TbAccount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbAccount.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbAccount.ForeColor = System.Drawing.Color.Snow;
            this.TbAccount.Location = new System.Drawing.Point(7, 11);
            this.TbAccount.Margin = new System.Windows.Forms.Padding(4);
            this.TbAccount.Name = "TbAccount";
            this.TbAccount.Size = new System.Drawing.Size(208, 20);
            this.TbAccount.TabIndex = 2;
            this.TbAccount.MouseEnter += new System.EventHandler(this.TbAccount_MouseEnter);
            this.TbAccount.MouseLeave += new System.EventHandler(this.TbAccount_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TbAccount);
            this.panel1.Location = new System.Drawing.Point(105, 296);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 44);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.TbPassWord);
            this.panel2.Location = new System.Drawing.Point(105, 356);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 44);
            this.panel2.TabIndex = 5;
            // 
            // TbPassWord
            // 
            this.TbPassWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.TbPassWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbPassWord.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TbPassWord.ForeColor = System.Drawing.Color.Snow;
            this.TbPassWord.Location = new System.Drawing.Point(4, 11);
            this.TbPassWord.Margin = new System.Windows.Forms.Padding(4);
            this.TbPassWord.Name = "TbPassWord";
            this.TbPassWord.PasswordChar = '*';
            this.TbPassWord.Size = new System.Drawing.Size(209, 20);
            this.TbPassWord.TabIndex = 2;
            // 
            // cbSavePwd
            // 
            this.cbSavePwd.AutoSize = true;
            this.cbSavePwd.BackColor = System.Drawing.Color.Transparent;
            this.cbSavePwd.ForeColor = System.Drawing.Color.White;
            this.cbSavePwd.Location = new System.Drawing.Point(61, 426);
            this.cbSavePwd.Margin = new System.Windows.Forms.Padding(4);
            this.cbSavePwd.Name = "cbSavePwd";
            this.cbSavePwd.Size = new System.Drawing.Size(89, 19);
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
            this.cbAutoLogin.Location = new System.Drawing.Point(229, 426);
            this.cbAutoLogin.Margin = new System.Windows.Forms.Padding(4);
            this.cbAutoLogin.Name = "cbAutoLogin";
            this.cbAutoLogin.Size = new System.Drawing.Size(89, 19);
            this.cbAutoLogin.TabIndex = 7;
            this.cbAutoLogin.Text = "自动登录";
            this.cbAutoLogin.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Location = new System.Drawing.Point(61, 466);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(267, 39);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "登  录";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // llbReg
            // 
            this.llbReg.AutoSize = true;
            this.llbReg.BackColor = System.Drawing.Color.Transparent;
            this.llbReg.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbReg.Location = new System.Drawing.Point(59, 521);
            this.llbReg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llbReg.Name = "llbReg";
            this.llbReg.Size = new System.Drawing.Size(67, 15);
            this.llbReg.TabIndex = 9;
            this.llbReg.TabStop = true;
            this.llbReg.Text = "注册账户";
            this.llbReg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbReg_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.Location = new System.Drawing.Point(255, 521);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(67, 15);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "找回密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(59, 312);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(59, 372);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "密码";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::DNAT.Properties.Resources.Banner;
            this.panel3.Location = new System.Drawing.Point(51, 125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 100);
            this.panel3.TabIndex = 13;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(100)))), ((int)(((byte)(158)))));
            this.BackgroundImage = global::DNAT.Properties.Resources.login1;
            this.ClientSize = new System.Drawing.Size(373, 750);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.llbReg);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbAutoLogin);
            this.Controls.Add(this.cbSavePwd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "隧道通登录";
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
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
    }
}