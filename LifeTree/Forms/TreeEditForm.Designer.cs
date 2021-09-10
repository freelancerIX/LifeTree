namespace LifeTree.Forms
{
    partial class TreeEditForm
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
            this.textNameStatic = new System.Windows.Forms.TextBox();
            this.textNameTree = new System.Windows.Forms.TextBox();
            this.okNameBtn = new System.Windows.Forms.Button();
            this.cancelNameBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textNameStatic
            // 
            this.textNameStatic.Enabled = false;
            this.textNameStatic.Location = new System.Drawing.Point(56, 31);
            this.textNameStatic.Name = "textNameStatic";
            this.textNameStatic.ReadOnly = true;
            this.textNameStatic.Size = new System.Drawing.Size(100, 20);
            this.textNameStatic.TabIndex = 0;
            this.textNameStatic.Text = "Название";
            // 
            // textNameTree
            // 
            this.textNameTree.Location = new System.Drawing.Point(155, 31);
            this.textNameTree.Name = "textNameTree";
            this.textNameTree.Size = new System.Drawing.Size(100, 20);
            this.textNameTree.TabIndex = 0;
            // 
            // okNameBtn
            // 
            this.okNameBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okNameBtn.Location = new System.Drawing.Point(66, 81);
            this.okNameBtn.Name = "okNameBtn";
            this.okNameBtn.Size = new System.Drawing.Size(75, 23);
            this.okNameBtn.TabIndex = 1;
            this.okNameBtn.Text = "ОК";
            this.okNameBtn.UseVisualStyleBackColor = true;
            // 
            // cancelNameBtn
            // 
            this.cancelNameBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelNameBtn.Location = new System.Drawing.Point(171, 81);
            this.cancelNameBtn.Name = "cancelNameBtn";
            this.cancelNameBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelNameBtn.TabIndex = 2;
            this.cancelNameBtn.Text = "Отмена";
            this.cancelNameBtn.UseVisualStyleBackColor = true;
            // 
            // TreeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LifeTree.Properties.Resources.bg8;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(312, 119);
            this.Controls.Add(this.cancelNameBtn);
            this.Controls.Add(this.okNameBtn);
            this.Controls.Add(this.textNameTree);
            this.Controls.Add(this.textNameStatic);
            this.Name = "TreeEditForm";
            this.Text = "Редактирование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textNameStatic;
        private System.Windows.Forms.TextBox textNameTree;
        private System.Windows.Forms.Button okNameBtn;
        private System.Windows.Forms.Button cancelNameBtn;
    }
}