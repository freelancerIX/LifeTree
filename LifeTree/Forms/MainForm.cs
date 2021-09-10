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
    public partial class MainForm : Form
    {
        Form ActiveContentForm;
        DBManager dbManager;
        User user;

        public MainForm()
        {
            InitializeComponent();

            dbManager = new DBManager("LT.mdb");

            this.Icon = Properties.Resources.logoTree;
        }

        private void ShowForm(Form form)
        {
            this.Controls.Remove(ActiveContentForm);

            ActiveContentForm = form;

            ActiveContentForm.Location = new Point(0, 0);
            ActiveContentForm.TopLevel = false;

            this.MaximumSize = ActiveContentForm.MaximumSize;
            this.MinimumSize = ActiveContentForm.MinimumSize;
            ActiveContentForm.MinimumSize = new Size(0, 0);

            this.MinimizeBox = ActiveContentForm.MinimizeBox;
            this.MaximizeBox = ActiveContentForm.MaximizeBox;

            this.FormBorderStyle = ActiveContentForm.FormBorderStyle;
            ActiveContentForm.FormBorderStyle = FormBorderStyle.None;

            this.Text = $"{Application.ProductName} - {ActiveContentForm.Text}";

            this.ClientSize = ActiveContentForm.Size;
            this.Controls.Add(ActiveContentForm);

            ActiveContentForm.Visible = true;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void ShowTreeViewForm(ProfileTree tree)
        {
            TreeViewForm form = new TreeViewForm
            {
                DBManager = this.dbManager,
                User = this.user,
                ProfileTree = tree
            };

            form.OnUserBack += OnUserBack;
            form.OnUserLogout += OnUserLogout;


            ShowForm(form);
        }

        private void ShowTreeManageForm()
        {
            TreeManageForm form = new TreeManageForm
            {
                DBManager = this.dbManager,
                User = this.user
            };

            form.OnUserOpenTree += OnUserOpenTree;
            form.OnUserLogout += OnUserLogout;

            ShowForm(form);
        }

        private void ShowLoginForm()
        { 
            LoginForm form = new LoginForm
            {
                DBManager = this.dbManager
            };

            form.OnUserRequestRegistr += OnUserRequestRegistr;
            form.OnUserLogin += OnUserLogin;

            ShowForm(form);
        }


        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ActiveContentForm.Size = this.ClientSize;
        }

        private void OnUserRequestRegistr(object sender, EventArgs e)
        {
            RegForm form = new RegForm
            {
                DBManager = this.dbManager                
            };

            form.OnUserRegistred += OnUserRegistred;
            form.OnUserRegCancel += OnUserRegCancel;

            ShowForm(form);   
        }

        private void OnUserLogin(object sender, EventArgs e)
        {
            this.user = ((LoginForm)ActiveContentForm).User;
            ShowTreeManageForm();
        }

        private void OnUserBack(object sender, EventArgs e)
        {
            ShowTreeManageForm();
        }

        private void OnUserRegistred(object sender, EventArgs e)
        {
            this.user = ((RegForm)ActiveContentForm).User;
            ShowTreeManageForm();
        }

        private void OnUserRegCancel(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void OnUserOpenTree(object sender, EventArgs e)
        {
            ProfileTree tree = ((TreeManageForm)ActiveContentForm).SelectedTree;
            ShowTreeViewForm(tree);
        }


        private void OnUserLogout(object sender, EventArgs e)
        {
            this.user = null;
            ShowLoginForm();
        }
    }
}
