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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.HideInTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.LoadWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "This utility allows you to move between windows 10 desktops easily using your mou" +
    "se wheel and a shortcut key assigned.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HideInTrayCheckBox);
            this.groupBox1.Controls.Add(this.LoadWithWindowsCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 83);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurations";
            // 
            // HideInTrayCheckBox
            // 
            this.HideInTrayCheckBox.AutoSize = true;
            this.HideInTrayCheckBox.Location = new System.Drawing.Point(6, 51);
            this.HideInTrayCheckBox.Name = "HideInTrayCheckBox";
            this.HideInTrayCheckBox.Size = new System.Drawing.Size(79, 17);
            this.HideInTrayCheckBox.TabIndex = 6;
            this.HideInTrayCheckBox.Text = "Hide in tray";
            this.HideInTrayCheckBox.UseVisualStyleBackColor = true;
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
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 201);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MDReplacer - Replace desktops using your mouse";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox HideInTrayCheckBox;
        private System.Windows.Forms.CheckBox LoadWithWindowsCheckBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

