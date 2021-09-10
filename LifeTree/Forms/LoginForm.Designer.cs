namespace LifeTree.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.textInputLogin = new System.Windows.Forms.TextBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textInputPass = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.reglinkLbl = new System.Windows.Forms.LinkLabel();
            this.regAsklbl = new System.Windows.Forms.Label();
            this.dataInputPanel = new System.Windows.Forms.Panel();
            this.regPanel = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataInputPanel.SuspendLayout();
            this.regPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textInputLogin
            // 
            this.textInputLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textInputLogin.Location = new System.Drawing.Point(49, 0);
            this.textInputLogin.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.textInputLogin.Name = "textInputLogin";
            this.textInputLogin.Size = new System.Drawing.Size(100, 20);
            this.textInputLogin.TabIndex = 1;
            this.textInputLogin.TextChanged += new System.EventHandler(this.textInputLogin_TextChanged);
            // 
            // textLogin
            // 
            this.textLogin.Enabled = false;
            this.textLogin.Location = new System.Drawing.Point(0, 0);
            this.textLogin.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.textLogin.Name = "textLogin";
            this.textLogin.ReadOnly = true;
            this.textLogin.Size = new System.Drawing.Size(50, 20);
            this.textLogin.TabIndex = 4;
            this.textLogin.Text = "Логин";
            // 
            // textPassword
            // 
            this.textPassword.Enabled = false;
            this.textPassword.Location = new System.Drawing.Point(0, 26);
            this.textPassword.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.textPassword.Name = "textPassword";
            this.textPassword.ReadOnly = true;
            this.textPassword.Size = new System.Drawing.Size(50, 20);
            this.textPassword.TabIndex = 5;
            this.textPassword.Text = "Пароль";
            // 
            // textInputPass
            // 
            this.textInputPass.Location = new System.Drawing.Point(49, 26);
            this.textInputPass.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.textInputPass.Name = "textInputPass";
            this.textInputPass.PasswordChar = '*';
            this.textInputPass.Size = new System.Drawing.Size(100, 20);
            this.textInputPass.TabIndex = 2;
            this.textInputPass.TextChanged += new System.EventHandler(this.textInputPass_TextChanged);
            this.textInputPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textInputPass_KeyDown);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(112, 115);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(76, 23);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Войти";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // reglinkLbl
            // 
            this.reglinkLbl.AutoSize = true;
            this.reglinkLbl.BackColor = System.Drawing.Color.Transparent;
            this.reglinkLbl.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.reglinkLbl.Location = new System.Drawing.Point(107, 0);
            this.reglinkLbl.Name = "reglinkLbl";
            this.reglinkLbl.Size = new System.Drawing.Size(101, 13);
            this.reglinkLbl.TabIndex = 5;
            this.reglinkLbl.TabStop = true;
            this.reglinkLbl.Text = "Зарегистроваться";
            this.reglinkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.reglinkLbl_LinkClicked);
            // 
            // regAsklbl
            // 
            this.regAsklbl.AutoSize = true;
            this.regAsklbl.BackColor = System.Drawing.Color.Transparent;
            this.regAsklbl.Location = new System.Drawing.Point(0, 0);
            this.regAsklbl.Name = "regAsklbl";
            this.regAsklbl.Size = new System.Drawing.Size(107, 13);
            this.regAsklbl.TabIndex = 8;
            this.regAsklbl.Text = "Первый раз здесь?";
            // 
            // dataInputPanel
            // 
            this.dataInputPanel.BackColor = System.Drawing.Color.Transparent;
            this.dataInputPanel.Controls.Add(this.textPassword);
            this.dataInputPanel.Controls.Add(this.textInputPass);
            this.dataInputPanel.Controls.Add(this.textLogin);
            this.dataInputPanel.Controls.Add(this.textInputLogin);
            this.dataInputPanel.Location = new System.Drawing.Point(75, 43);
            this.dataInputPanel.Name = "dataInputPanel";
            this.dataInputPanel.Size = new System.Drawing.Size(149, 46);
            this.dataInputPanel.TabIndex = 0;
            // 
            // regPanel
            // 
            this.regPanel.BackColor = System.Drawing.Color.Transparent;
            this.regPanel.Controls.Add(this.reglinkLbl);
            this.regPanel.Controls.Add(this.regAsklbl);
            this.regPanel.Location = new System.Drawing.Point(46, 159);
            this.regPanel.Name = "regPanel";
            this.regPanel.Size = new System.Drawing.Size(208, 13);
            this.regPanel.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 213);
            this.Controls.Add(this.regPanel);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.dataInputPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Авторизация";
            this.dataInputPanel.ResumeLayout(false);
            this.dataInputPanel.PerformLayout();
            this.regPanel.ResumeLayout(false);
            this.regPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox textInputLogin;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textInputPass;
        private System.Windows.Forms.LinkLabel reglinkLbl;
        private System.Windows.Forms.Label regAsklbl;
        private System.Windows.Forms.Panel dataInputPanel;
        private System.Windows.Forms.Panel regPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

