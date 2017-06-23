namespace MDReplacer
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HideFromTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.LoadWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkNemexStudios = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "This utility allows you to move between windows 10 desktops easily.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HideFromTrayCheckBox);
            this.groupBox1.Controls.Add(this.LoadWithWindowsCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurations";
            // 
            // HideFromTrayCheckBox
            // 
            this.HideFromTrayCheckBox.AutoSize = true;
            this.HideFromTrayCheckBox.Location = new System.Drawing.Point(6, 51);
            this.HideFromTrayCheckBox.Name = "HideFromTrayCheckBox";
            this.HideFromTrayCheckBox.Size = new System.Drawing.Size(91, 17);
            this.HideFromTrayCheckBox.TabIndex = 6;
            this.HideFromTrayCheckBox.Text = "Hide from tray";
            this.HideFromTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoadWithWindowsCheckBox
            // 
            this.LoadWithWindowsCheckBox.AutoSize = true;
            this.LoadWithWindowsCheckBox.Location = new System.Drawing.Point(6, 28);
            this.LoadWithWindowsCheckBox.Name = "LoadWithWindowsCheckBox";
            this.LoadWithWindowsCheckBox.Size = new System.Drawing.Size(119, 17);
            this.LoadWithWindowsCheckBox.TabIndex = 5;
            this.LoadWithWindowsCheckBox.Text = "Load with Windows";
            this.LoadWithWindowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MDReplacer";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(30, 276);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(228, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "http://www.wallpaperfx.com";
            this.linkLabel1.Text = "(Icons credits to - http://www.wallpaperfx.com)";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // linkNemexStudios
            // 
            this.linkNemexStudios.AutoSize = true;
            this.linkNemexStudios.Location = new System.Drawing.Point(38, 256);
            this.linkNemexStudios.Name = "linkNemexStudios";
            this.linkNemexStudios.Size = new System.Drawing.Size(210, 13);
            this.linkNemexStudios.TabIndex = 4;
            this.linkNemexStudios.TabStop = true;
            this.linkNemexStudios.Tag = "http://byshynet.com";
            this.linkNemexStudios.Text = "http://www.byshynet.com - Nemex Studios";
            this.linkNemexStudios.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(15, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 97);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Use combination of:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "SHIFT + WHEEL UP\\DOWN";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 303);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkNemexStudios);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDReplacer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox HideFromTrayCheckBox;
        private System.Windows.Forms.CheckBox LoadWithWindowsCheckBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkNemexStudios;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

