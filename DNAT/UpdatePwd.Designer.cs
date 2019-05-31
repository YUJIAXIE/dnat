namespace Client
{
    partial class UpdatePwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePwd));
            this.pBar = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pClose = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBOldPwd = new System.Windows.Forms.TextBox();
            this.tBNewPwd = new System.Windows.Forms.TextBox();
            this.tBRePwd = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCannel = new System.Windows.Forms.Button();
            this.pBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.pBar.Controls.Add(this.panel5);
            this.pBar.Controls.Add(this.lbTitle);
            this.pBar.Controls.Add(this.pClose);
            this.pBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBar.Location = new System.Drawing.Point(0, 0);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(274, 40);
            this.pBar.TabIndex = 2;
            this.pBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBar_MouseDown);
            this.pBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBar_MouseMove);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::Client.Properties.Resources.logo1;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel5.Location = new System.Drawing.Point(11, 9);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(25, 25);
            this.panel5.TabIndex = 12;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(38, 14);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(56, 17);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "修改密码";
            // 
            // pClose
            // 
            this.pClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pClose.BackgroundImage")));
            this.pClose.Location = new System.Drawing.Point(235, 7);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(24, 24);
            this.pClose.TabIndex = 0;
            this.pClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pClose_MouseClick);
            this.pClose.MouseEnter += new System.EventHandler(this.pClose_MouseEnter);
            this.pClose.MouseLeave += new System.EventHandler(this.pClose_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "原密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "新密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "确认新密码：";
            // 
            // tBOldPwd
            // 
            this.tBOldPwd.Location = new System.Drawing.Point(100, 62);
            this.tBOldPwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tBOldPwd.Name = "tBOldPwd";
            this.tBOldPwd.PasswordChar = '*';
            this.tBOldPwd.Size = new System.Drawing.Size(142, 21);
            this.tBOldPwd.TabIndex = 6;
            // 
            // tBNewPwd
            // 
            this.tBNewPwd.Location = new System.Drawing.Point(100, 99);
            this.tBNewPwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tBNewPwd.Name = "tBNewPwd";
            this.tBNewPwd.PasswordChar = '*';
            this.tBNewPwd.Size = new System.Drawing.Size(142, 21);
            this.tBNewPwd.TabIndex = 7;
            // 
            // tBRePwd
            // 
            this.tBRePwd.Location = new System.Drawing.Point(100, 131);
            this.tBRePwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tBRePwd.Name = "tBRePwd";
            this.tBRePwd.PasswordChar = '*';
            this.tBRePwd.Size = new System.Drawing.Size(142, 21);
            this.tBRePwd.TabIndex = 8;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(64, 184);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 18);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCannel
            // 
            this.btnCannel.Location = new System.Drawing.Point(161, 184);
            this.btnCannel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCannel.Name = "btnCannel";
            this.btnCannel.Size = new System.Drawing.Size(56, 18);
            this.btnCannel.TabIndex = 10;
            this.btnCannel.Text = "取消";
            this.btnCannel.UseVisualStyleBackColor = true;
            this.btnCannel.Click += new System.EventHandler(this.btnCannel_Click);
            // 
            // UpdatePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 234);
            this.Controls.Add(this.btnCannel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tBRePwd);
            this.Controls.Add(this.tBNewPwd);
            this.Controls.Add(this.tBOldPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UpdatePwd";
            this.Text = "修改密码";
            this.pBar.ResumeLayout(false);
            this.pBar.PerformLayout();
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
        private System.Windows.Forms.TextBox tBOldPwd;
        private System.Windows.Forms.TextBox tBNewPwd;
        private System.Windows.Forms.TextBox tBRePwd;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCannel;
        private System.Windows.Forms.Panel panel5;
    }
}