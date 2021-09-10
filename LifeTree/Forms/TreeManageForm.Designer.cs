namespace LifeTree.Forms
{
    partial class TreeManageForm
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
            this.treeListView = new System.Windows.Forms.ListBox();
            this.openBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeListView
            // 
            this.treeListView.FormattingEnabled = true;
            this.treeListView.Location = new System.Drawing.Point(12, 12);
            this.treeListView.Name = "treeListView";
            this.treeListView.Size = new System.Drawing.Size(299, 251);
            this.treeListView.TabIndex = 0;
            this.treeListView.SelectedIndexChanged += new System.EventHandler(this.treeListView_SelectedIndexChanged);
            // 
            // openBtn
            // 
            this.openBtn.Enabled = false;
            this.openBtn.Location = new System.Drawing.Point(317, 12);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(87, 22);
            this.openBtn.TabIndex = 1;
            this.openBtn.Text = "Открыть";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(317, 40);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(87, 22);
            this.createBtn.TabIndex = 2;
            this.createBtn.Text = "Создать";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Enabled = false;
            this.editBtn.Location = new System.Drawing.Point(317, 68);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(87, 22);
            this.editBtn.TabIndex = 3;
            this.editBtn.Text = "Изменить";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(317, 96);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(87, 22);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "Удалить";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Location = new System.Drawing.Point(317, 243);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(87, 22);
            this.logoutBtn.TabIndex = 5;
            this.logoutBtn.Text = "Выход";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // TreeManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LifeTree.Properties.Resources.bg8;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(416, 277);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.treeListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TreeManageForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Список деревьев";
            this.Shown += new System.EventHandler(this.TreeManageForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox treeListView;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button logoutBtn;
    }
}