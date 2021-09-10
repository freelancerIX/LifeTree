namespace LifeTree.Forms
{
    partial class RegForm
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
            this.dataInputPanel = new System.Windows.Forms.Panel();
            this.textInputPassSub = new System.Windows.Forms.TextBox();
            this.textPassword2 = new System.Windows.Forms.TextBox();
            this.textInputPass = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textInputLogin = new System.Windows.Forms.TextBox();
            this.regBtn = new System.Windows.Forms.Button();
            this.linkBack = new System.Windows.Forms.LinkLabel();
            this.dataInputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataInputPanel
            // 
            this.dataInputPanel.BackColor = System.Drawing.Color.Transparent;
            this.dataInputPanel.Controls.Add(this.textPassword2);
            this.dataInputPanel.Controls.Add(this.textPassword);
            this.dataInputPanel.Controls.Add(this.textInputPassSub);
            this.dataInputPanel.Controls.Add(this.textInputPass);
            this.dataInputPanel.Controls.Add(this.textLogin);
            this.dataInputPanel.Controls.Add(this.textInputLogin);
            this.dataInputPanel.Location = new System.Drawing.Point(54, 28);
            this.dataInputPanel.Name = "dataInputPanel";
            this.dataInputPanel.Size = new System.Drawing.Size(192, 72);
            this.dataInputPanel.TabIndex = 11;
            // 
            // textInputPassSub
            // 
            this.textInputPassSub.Location = new System.Drawing.Point(81, 52);
            this.textInputPassSub.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.textInputPassSub.Name = "textInputPassSub";
            this.textInputPassSub.PasswordChar = '*';
            this.textInputPassSub.Size = new System.Drawing.Size(111, 20);
            this.textInputPassSub.TabIndex = 3;
            // 
            // textPassword2
            // 
            this.textPassword2.Enabled = false;
            this.textPassword2.Location = new System.Drawing.Point(0, 52);
            this.textPassword2.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.textPassword2.Name = "textPassword2";
            this.textPassword2.ReadOnly = true;
            this.textPassword2.Size = new System.Drawing.Size(82, 20);
            this.textPassword2.TabIndex = 7;
            this.textPassword2.Text = "Повтор пароля";
            // 
            // textInputPass
            // 
            this.textInputPass.Location = new System.Drawing.Point(81, 26);
            this.textInputPass.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.textInputPass.Name = "textInputPass";
            this.textInputPass.PasswordChar = '*';
            this.textInputPass.Size = new System.Drawing.Size(111, 20);
            this.textInputPass.TabIndex = 2;
            // 
            // textPassword
            // 
            this.textPassword.Enabled = false;
            this.textPassword.Location = new System.Drawing.Point(0, 26);
            this.textPassword.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.textPassword.Name = "textPassword";
            this.textPassword.ReadOnly = true;
            this.textPassword.Size = new System.Drawing.Size(82, 20);
            this.textPassword.TabIndex = 5;
            this.textPassword.Text = "Пароль";
            // 
            // textLogin
            // 
            this.textLogin.Enabled = false;
            this.textLogin.Location = new System.Drawing.Point(0, 0);
            this.textLogin.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.textLogin.Name = "textLogin";
            this.textLogin.ReadOnly = true;
            this.textLogin.Size = new System.Drawing.Size(82, 20);
            this.textLogin.TabIndex = 4;
            this.textLogin.Text = "Логин";
            // 
            // textInputLogin
            // 
            this.textInputLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputLogin.Location = new System.Drawing.Point(81, 0);
            this.textInputLogin.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.textInputLogin.Name = "textInputLogin";
            this.textInputLogin.Size = new System.Drawing.Size(111, 20);
            this.textInputLogin.TabIndex = 1;
            // 
            // regBtn
            // 
            this.regBtn.Location = new System.Drawing.Point(85, 124);
            this.regBtn.Name = "regBtn";
            this.regBtn.Size = new System.Drawing.Size(130, 23);
            this.regBtn.TabIndex = 4;
            this.regBtn.Text = "Зарегестрироваться";
            this.regBtn.UseVisualStyleBackColor = true;
            this.regBtn.Click += new System.EventHandler(this.regBtn_Click);
            // 
            // linkBack
            // 
            this.linkBack.AutoSize = true;
            this.linkBack.BackColor = System.Drawing.Color.Transparent;
            this.linkBack.Location = new System.Drawing.Point(127, 165);
            this.linkBack.Name = "linkBack";
            this.linkBack.Size = new System.Drawing.Size(46, 13);
            this.linkBack.TabIndex = 5;
            this.linkBack.TabStop = true;
            this.linkBack.Text = "Отмена";
            this.linkBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBack_LinkClicked);
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LifeTree.Properties.Resources.bg8;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 213);
            this.Controls.Add(this.linkBack);
            this.Controls.Add(this.dataInputPanel);
            this.Controls.Add(this.regBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.dataInputPanel.ResumeLayout(false);
            this.dataInputPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel dataInputPanel;
        private System.Windows.Forms.TextBox textInputPassSub;
        private System.Windows.Forms.TextBox textPassword2;
        private System.Windows.Forms.TextBox textInputPass;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.TextBox textInputLogin;
        private System.Windows.Forms.Button regBtn;
        private System.Windows.Forms.LinkLabel linkBack;
    }
}