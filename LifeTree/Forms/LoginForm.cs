using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LifeTree.Classes;
using LifeTree.Controls;

namespace LifeTree.Forms
{
    public partial class LoginForm : Form
    {

        private DBManager dbManager;

        public DBManager DBManager
        {
            get { return this.dbManager; }
            set { this.dbManager = value; }
        }

        public User User { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string login = textInputLogin.Text;
            string pass = textInputPass.Text;
            bool error = false;


            if (login.Length == 0)
            {
                textInputLogin.BackColor = Color.Red;
                error = true;
            }
            if (pass.Length == 0)
            {
                textInputPass.BackColor = Color.Red;
                error = true;
            }

            if (!error)
                this.User = UserManager.DoLogin(DBManager, login, pass);

            if (this.User != null)
                OnUserLogin?.Invoke(this, new EventArgs());
        }

        private void textInputLogin_TextChanged(object sender, EventArgs e)
        {
            textInputLogin.BackColor = Color.White;
        }

        private void textInputPass_TextChanged(object sender, EventArgs e)
        {
            textInputPass.BackColor = Color.White;
        }

        private void reglinkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnUserRequestRegistr?.Invoke(this, new EventArgs());
        }

        public event EventHandler OnUserRequestRegistr;
        public event EventHandler OnUserLogin;

        private void textInputPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                loginBtn_Click(sender, e);
        }
    }
}
