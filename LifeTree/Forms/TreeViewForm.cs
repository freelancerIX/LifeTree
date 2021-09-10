using LifeTree.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LifeTree.Classes;
using LifeTree.Controls;

namespace LifeTree.Forms
{
    public partial class TreeViewForm : Form
    {
        private Panel treePanel;
        private Panel controlsPanel;
        private TreeViewPanel treeViewPanel;

        private PictureBox photoTreeNode;
        private LinkLabel linkOpenPhoto;
        private RadioButton changeSexBtnMale;
        private RadioButton changeSexBtnFemale;
        private Button backBtn;
        private Button logoutBtn;
        private Button printBtn;
        private Button saveInfoBtn;
        private Button deleteInfoBtn;
        private Button cancelBtn;

        private NamedTextBox lastNameTextBox;
        private NamedTextBox firstNameTextBox;
        private NamedTextBox middleNameTextBox;
        private NamedTextBox dateBornInputBox;
        private NamedTextBox dateDeadthInputBox;



        public User User { get; set; }
        public DBManager DBManager { get; set; }
        public ProfileTree ProfileTree { get; set; }

        public event EventHandler OnUserLogout;
        public event EventHandler OnUserBack;

        public TreeViewForm()
        {
            InitializeComponent();

            this.treePanel = new Panel();
            this.controlsPanel = new Panel();
            this.treeViewPanel = new TreeViewPanel();

            this.treeViewPanel.SelectedBoxChanged += TreeViewPanel_SelectedBoxChanged;

            this.treePanel.Name = "TreeViewPanel";
            this.treePanel.Location = new Point(
                MainFormSettings.Margin, MainFormSettings.Margin);
            this.treePanel.BackColor = Color.White;
            this.treePanel.AutoScroll = true;

            this.controlsPanel.Name = "ControlsPanel";
            this.controlsPanel.BackColor = Color.LightGray;

            this.treePanel.Resize += TreePanel_Resize;
            this.treeViewPanel.Resize += TreeViewPanel_Resize;

            this.Controls.Add(treePanel);
            this.Controls.Add(controlsPanel);
            this.treePanel.Controls.Add(treeViewPanel);

            //this.Left = this.Location.X - 200;
            //this.Top = this.Location.Y - 150;

            this.MinimumSize = new Size(
               MainFormSettings.ControlPanelWidth
                   + 2 * MainFormSettings.Margin + 16 + 550
               , 600);

            this.RearrangeForm();

            AddElementControls(controlsPanel);
        }

        private void TreeViewPanel_SelectedBoxChanged(object sender, EventArgs e)
        {
            LoadSelectedNode();
        }

        private void RearangeTreeViewPanel()
        {
            if (this.treeViewPanel.Width <= this.treePanel.Width)
                this.treeViewPanel.Left = this.treePanel.Width / 2 - this.treeViewPanel.Width / 2 ;
            if (this.treeViewPanel.Height <= this.treePanel.Height)
                this.treeViewPanel.Top = this.treePanel.Height / 2 - this.treeViewPanel.Height / 2;
        }

        private void TreePanel_Resize(object sender, EventArgs e)
        {
            RearangeTreeViewPanel();
        }

        private void TreeViewPanel_Resize(object sender, EventArgs e)
        {
            RearangeTreeViewPanel();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            this.RearrangeForm();
        }

        private void RearrangeForm()
        {
            this.treePanel.Size = new Size(
                this.ClientSize.Width - MainFormSettings.ControlPanelWidth - (2 * MainFormSettings.Margin)
                , this.ClientSize.Height - (2 * MainFormSettings.Margin));

            this.controlsPanel.Location = new Point(
                this.treePanel.Left + this.treePanel.Width
                , MainFormSettings.Margin);

            this.controlsPanel.Size = new Size(
                MainFormSettings.ControlPanelWidth
                , this.ClientSize.Height - (2 * MainFormSettings.Margin));
        }

        private void TreeViewForm_Shown(object sender, EventArgs e)
        {
            TreeManager.LoadTree(DBManager, ProfileTree);
            AddEmptyNodes(this.ProfileTree);
            this.treeViewPanel.RootElement = this.ProfileTree.Root;
            this.treeViewPanel.RedrawTree();

        }

        private void AddEmptyNodes(ProfileTree tree)
        {
            if (this.ProfileTree.Root != null)
            {
                tree.Root.AddEmptyNodes();
            }
            else
            {
                this.ProfileTree.Root = new ProfileTreeNode();
            }
        }

        private void AddElementControls(Control control)
        {
            this.photoTreeNode = new PictureBox();
            this.linkOpenPhoto = new LinkLabel();
            this.changeSexBtnMale = new RadioButton();
            this.changeSexBtnFemale = new RadioButton();
            this.backBtn = new Button();
            this.logoutBtn = new Button();
            this.printBtn = new Button();
            this.saveInfoBtn = new Button();
            this.deleteInfoBtn = new Button();
            this.cancelBtn = new Button();

            this.lastNameTextBox = new NamedTextBox(new TextBox());
            this.firstNameTextBox = new NamedTextBox(new TextBox());
            this.middleNameTextBox = new NamedTextBox(new TextBox());
            this.dateBornInputBox = new NamedTextBox(new DateTimePicker());
            this.dateDeadthInputBox = new NamedTextBox(new DateTimePicker());

            //PictureBox
            this.photoTreeNode.Name = "nodePhoto";
            this.photoTreeNode.Size = new System.Drawing.Size(35*3, 45*3);
            this.photoTreeNode.Location = new System.Drawing.Point(control.Width / 2 - photoTreeNode.Width / 2, 8);
            this.photoTreeNode.TabIndex = 0;
            this.photoTreeNode.TabStop = false;
            this.photoTreeNode.BackColor = System.Drawing.Color.White;
            this.photoTreeNode.SizeMode = PictureBoxSizeMode.StretchImage;

            

            //LinkLable
            this.linkOpenPhoto.LinkColor = System.Drawing.Color.Gray;
            this.linkOpenPhoto.Text = "Открыть";
            this.linkOpenPhoto.TextAlign = ContentAlignment.MiddleCenter;
            this.linkOpenPhoto.Name = "linkOpenPhoto";
            this.linkOpenPhoto.Size = new System.Drawing.Size(photoTreeNode.Width, 13);
            this.linkOpenPhoto.Location = new System.Drawing.Point(control.Width / 2 - linkOpenPhoto.Width / 2, photoTreeNode.Height+8);
            this.linkOpenPhoto.TabIndex = 1;
            this.linkOpenPhoto.TabStop = true;
            this.linkOpenPhoto.Click += LinkOpenPhoto_Click;

            //SexChangeMale
            this.changeSexBtnMale.Name = "SexMale";
            this.changeSexBtnMale.Size = new System.Drawing.Size(35, 17);
            this.changeSexBtnMale.Location = new System.Drawing.Point(control.Width / 2 - changeSexBtnMale.Width - 8
                , photoTreeNode.Height + linkOpenPhoto.Height + 16);
            this.changeSexBtnMale.TabIndex = 2;
            this.changeSexBtnMale.TabStop = true;
            this.changeSexBtnMale.Text = "М";
            this.changeSexBtnMale.UseVisualStyleBackColor = true;
            this.changeSexBtnMale.CheckedChanged += ChangeSexBtnMale_CheckedChanged;

            //SexChangeFemale
            this.changeSexBtnFemale.Name = "SexFemale";
            this.changeSexBtnFemale.Size = new System.Drawing.Size(35, 17);
            this.changeSexBtnFemale.Location = new System.Drawing.Point(control.Width / 2 + 8
                , photoTreeNode.Height + linkOpenPhoto.Height + 16);
            this.changeSexBtnFemale.TabIndex = 3;
            this.changeSexBtnFemale.TabStop = true;
            this.changeSexBtnFemale.Text = "Ж";
            this.changeSexBtnFemale.UseVisualStyleBackColor = true;
            this.changeSexBtnFemale.CheckedChanged += ChangeSexBtnFemale_CheckedChanged;

            //lastNameBox
            this.lastNameTextBox.Title = "Фамилия";
            this.lastNameTextBox.Width = control.Width;
            this.lastNameTextBox.TitleWidth = control.Width/2;
            this.lastNameTextBox.Location = new Point(control.Width / 2 - lastNameTextBox.Width / 2
                , photoTreeNode.Height + linkOpenPhoto.Height + changeSexBtnMale.Height + 24);
            this.lastNameTextBox.TabIndex = 4;

            //FirstNameBox
            this.firstNameTextBox.Title = "Имя";
            this.firstNameTextBox.Width = control.Width;
            this.firstNameTextBox.TitleWidth = control.Width / 2;
            this.firstNameTextBox.Location = new Point(control.Width / 2 - firstNameTextBox.Width / 2
                , photoTreeNode.Height + linkOpenPhoto.Height + changeSexBtnMale.Height
                + lastNameTextBox.Height + 32);
            this.firstNameTextBox.TabIndex = 5;

            //MiddleNameBox
            this.middleNameTextBox.Title = "Отчество";
            this.middleNameTextBox.Width = control.Width;
            this.middleNameTextBox.TitleWidth = control.Width / 2;
            this.middleNameTextBox.Location = new Point(control.Width / 2 - middleNameTextBox.Width / 2
                , photoTreeNode.Height + linkOpenPhoto.Height + changeSexBtnMale.Height + lastNameTextBox.Height 
                + firstNameTextBox.Height + 40);
            this.middleNameTextBox.TabIndex = 5;

           
            //DateBornBox
            this.dateBornInputBox.Title = "Дата рождения";
            this.dateBornInputBox.Width = control.Width;
            this.dateBornInputBox.TitleWidth = control.Width / 2;
            this.dateBornInputBox.Location = new Point(control.Width / 2 - dateBornInputBox.Width / 2
                , photoTreeNode.Height + linkOpenPhoto.Height + lastNameTextBox.Height + firstNameTextBox.Height 
                + middleNameTextBox.Height + changeSexBtnMale.Height + 48);
            ((DateTimePicker)this.dateBornInputBox.InputText).Value = DateTime.Today;
            ((DateTimePicker)this.dateBornInputBox.InputText).Value = DateTime.Today;
            this.dateBornInputBox.TabIndex = 6;


            //DateDeathBox
            this.dateDeadthInputBox.Title = "Дата рождения";
            this.dateDeadthInputBox.Width = control.Width;
            this.dateDeadthInputBox.TitleWidth = control.Width / 2;
            this.dateDeadthInputBox.Location = new Point(control.Width / 2 - dateDeadthInputBox.Width / 2
                , photoTreeNode.Height + linkOpenPhoto.Height + lastNameTextBox.Height + firstNameTextBox.Height 
                + middleNameTextBox.Height + dateBornInputBox.Height + changeSexBtnFemale.Height + 56);
            ((DateTimePicker)this.dateDeadthInputBox.InputText).Value = DateTime.Today;
            ((DateTimePicker)this.dateDeadthInputBox.InputText).Value = DateTime.Today;
            this.dateDeadthInputBox.TabIndex = 7;

            //ButtonSave
            this.saveInfoBtn.Name = "SaveButton";
            this.saveInfoBtn.Size = new System.Drawing.Size(control.Width - 16, 25);
            this.saveInfoBtn.Location = new System.Drawing.Point(control.Width / 2 - saveInfoBtn.Width / 2
                , photoTreeNode.Height + linkOpenPhoto.Height + lastNameTextBox.Height + firstNameTextBox.Height
                + middleNameTextBox.Height + dateBornInputBox.Height + changeSexBtnFemale.Height 
                + dateDeadthInputBox.Height + 64);
            this.saveInfoBtn.TabIndex = 8;
            this.saveInfoBtn.Text = "Сохранить";
            this.saveInfoBtn.Click += SaveInfoBtn_Click;

            //ButtonDelete
            this.deleteInfoBtn.Name = "DeleteButton";
            this.deleteInfoBtn.Size = new System.Drawing.Size(control.Width - 16, 25);
            this.deleteInfoBtn.Location = new System.Drawing.Point(control.Width / 2 - deleteInfoBtn.Width / 2
                , photoTreeNode.Height + linkOpenPhoto.Height + lastNameTextBox.Height + firstNameTextBox.Height
                + middleNameTextBox.Height + dateBornInputBox.Height + changeSexBtnFemale.Height
                + dateDeadthInputBox.Height + saveInfoBtn.Height + 72);
            this.deleteInfoBtn.TabIndex = 9;
            this.deleteInfoBtn.Text = "Удалить";
            this.deleteInfoBtn.Click += DeleteInfoBtn_Click;

            //ButtonCancel
            this.cancelBtn.Name = "CancelButton";
            this.cancelBtn.Size = new System.Drawing.Size(control.Width - 16, 25);
            this.cancelBtn.Location = new System.Drawing.Point(control.Width / 2 - cancelBtn.Width / 2
                , photoTreeNode.Height + linkOpenPhoto.Height + lastNameTextBox.Height + firstNameTextBox.Height
                + middleNameTextBox.Height + dateBornInputBox.Height + changeSexBtnFemale.Height
                + dateDeadthInputBox.Height + saveInfoBtn.Height + deleteInfoBtn.Height + 80);
            this.cancelBtn.TabIndex = 10;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += CancelBtn_Click;

            //PrintBtn
            //this.printBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printBtn.Size = new System.Drawing.Size(control.Width - 16, 25);
            this.printBtn.Location = new System.Drawing.Point(control.Width / 2 - cancelBtn.Width / 2
                , photoTreeNode.Height + linkOpenPhoto.Height + lastNameTextBox.Height + firstNameTextBox.Height
                + middleNameTextBox.Height + dateBornInputBox.Height + changeSexBtnFemale.Height
                + dateDeadthInputBox.Height + saveInfoBtn.Height + deleteInfoBtn.Height + cancelBtn.Height + 100);
            this.printBtn.TabIndex = 11;
            this.printBtn.Text = "Печать";
            this.printBtn.Click += PrintBtn_Click;


            //ButtonBack
            this.backBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backBtn.Name = "BackButton";
            this.backBtn.Size = new System.Drawing.Size(control.Width - 16, 25);
            this.backBtn.Location = new System.Drawing.Point(control.Width / 2 - backBtn.Width / 2, control.Height - logoutBtn.Height - backBtn.Height - 16);
            this.backBtn.TabIndex = 12;
            this.backBtn.Text = "Назад";
            this.backBtn.Click += BackBtn_Click;

            //ButtonLogout
            this.logoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutBtn.Name = "LogoutButton";
            this.logoutBtn.Size = new System.Drawing.Size(control.Width - 16, 25);
            this.logoutBtn.Location = new System.Drawing.Point(control.Width / 2 - backBtn.Width / 2, control.Height - logoutBtn.Height - 8);
            this.logoutBtn.TabIndex = 13;
            this.logoutBtn.Text = "Выход";
            this.logoutBtn.Click += LogoutBtn_Click;


            //Take contols
            control.Controls.Add(photoTreeNode);
            control.Controls.Add(linkOpenPhoto);
            control.Controls.Add(changeSexBtnMale);
            control.Controls.Add(changeSexBtnFemale);
            control.Controls.Add(lastNameTextBox);
            control.Controls.Add(firstNameTextBox);
            control.Controls.Add(middleNameTextBox);
            control.Controls.Add(dateBornInputBox);
            control.Controls.Add(dateDeadthInputBox);
            control.Controls.Add(saveInfoBtn);
            control.Controls.Add(deleteInfoBtn);
            control.Controls.Add(cancelBtn);

            control.Controls.Add(printBtn);

            control.Controls.Add(backBtn);
            control.Controls.Add(logoutBtn);
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(doc_PrintPage);
            doc.Print();
        }

        private void ChangeSexBtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            this.photoTreeNode.Image = new Bitmap(Properties.Resources.EmptyFemaleNodeImage);
        }

        private void ChangeSexBtnMale_CheckedChanged(object sender, EventArgs e)
        {
            this.photoTreeNode.Image = new Bitmap(Properties.Resources.EmptyMaleNodeImage);
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            OnUserLogout?.Invoke(this, new EventArgs());
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            OnUserBack?.Invoke(this, new EventArgs());
            
        }
        //--------------------------------------
        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            TreeViewPanel grd = this.treeViewPanel;

            Bitmap bmp = new Bitmap(grd.Width, grd.Height, grd.CreateGraphics());
            grd.DrawToBitmap(bmp, new Rectangle(0, 0, grd.Width, grd.Height));
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            RectangleF bounds = e.PageSettings.PrintableArea;
            bounds.Size = bmp.Size;
            float difference = e.PageSettings.PrintableArea.Width / bmp.Width;

            float factor = ((float)bmp.Width / (float)bmp.Height);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, factor * bounds.Width * difference, bounds.Width * difference);
        }
        //----------------------------------------
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            LoadSelectedNode();
        }

        private void DeleteInfoBtn_Click(object sender, EventArgs e)
        {
            if (this.treeViewPanel.SelectedNode == null) return;
            if (this.treeViewPanel.SelectedNode.ID == 0) return;

            var node = this.treeViewPanel.SelectedNode;
            this.treeViewPanel.DeleteNode(node);
            TreeNodeManager.DeleteNode(DBManager, node);

            this.AddEmptyNodes(this.ProfileTree);
            treeViewPanel.RedrawTree();
        }

        private void SaveInfoBtn_Click(object sender, EventArgs e)
        {
            var node = this.treeViewPanel.SelectedNode;
            if (node == null) return;
            node.Photo = new Bitmap(this.photoTreeNode.Image);
            node.FirstName = this.firstNameTextBox.InputText.Text;
            node.MiddleName = this.middleNameTextBox.InputText.Text;
            node.LastName = this.lastNameTextBox.InputText.Text;
            node.Sex = this.changeSexBtnMale.Checked;
            node.BornDate = ((DateTimePicker)this.dateBornInputBox.InputText).Value;
            node.DeathDate = ((DateTimePicker)this.dateDeadthInputBox.InputText).Value;
            node.ProfileTree = this.ProfileTree;
            TreeNodeManager.SaveNode(DBManager, node);
            treeViewPanel.UpdateNode(node);
            node.AddEmptyNodes();
            treeViewPanel.RedrawTree();
        }

        private void LinkOpenPhoto_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
                photoTreeNode.Load(openDialog.FileName);

        }

        private void LoadSelectedNode()
        {
            var node = this.treeViewPanel.SelectedNode;
            if (node == null) return;
            if (node.ID != 0)
            {
                this.photoTreeNode.Image = node.Photo;
                this.firstNameTextBox.InputText.Text = node.FirstName;
                this.middleNameTextBox.InputText.Text = node.MiddleName;
                this.lastNameTextBox.InputText.Text = node.LastName;
                if (node.Sex)
                    this.changeSexBtnMale.Checked = true;
                else
                    this.changeSexBtnFemale.Checked = true;

                ((DateTimePicker)this.dateBornInputBox.InputText).Value = node.BornDate;
                ((DateTimePicker)this.dateDeadthInputBox.InputText).Value = node.DeathDate;
            }
            else
            {
                this.photoTreeNode.Image = new Bitmap(Properties.Resources.EmptyFemaleNodeImage);
                this.firstNameTextBox.InputText.Text = "";
                this.middleNameTextBox.InputText.Text = "";
                this.lastNameTextBox.InputText.Text = "";
                this.changeSexBtnFemale.Checked = true;

                ((DateTimePicker)this.dateBornInputBox.InputText).Value = DateTime.Today;
                ((DateTimePicker)this.dateDeadthInputBox.InputText).Value = DateTime.Today;
            }
        }
    }

    public partial class MainFormSettings
    {
        public const int ControlPanelWidth = 220;
        // Внешние отступы
        public const int Margin = 5;
        // Внутренние отступы
        public const int Padding = 5;
    }
}
