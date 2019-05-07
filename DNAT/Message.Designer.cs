﻿namespace DNAT
{
    partial class Message
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
            this.pBar = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.pMin = new System.Windows.Forms.Panel();
            this.pClose = new System.Windows.Forms.Panel();
            this.pBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBar
            // 
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
            this.lbTitle.Location = new System.Drawing.Point(12, 14);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(41, 12);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "label1";
            // 
            // pMin
            // 
            this.pMin.BackgroundImage = global::DNAT.Properties.Resources.btn_min_nor;
            this.pMin.Location = new System.Drawing.Point(217, 7);
            this.pMin.Name = "pMin";
            this.pMin.Size = new System.Drawing.Size(24, 24);
            this.pMin.TabIndex = 1;
            this.pMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pMin_MouseClick);
            // 
            // pClose
            // 
            this.pClose.BackgroundImage = global::DNAT.Properties.Resources.btn_close_nor;
            this.pClose.Location = new System.Drawing.Point(246, 7);
            this.pClose.Name = "pClose";
            this.pClose.Size = new System.Drawing.Size(24, 24);
            this.pClose.TabIndex = 0;
            this.pClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pClose_MouseClick);
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 200);
            this.Controls.Add(this.pBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Message";
            this.Text = "Message";
            this.pBar.ResumeLayout(false);
            this.pBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pBar;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Panel pMin;
        private System.Windows.Forms.Panel pClose;
    }
}