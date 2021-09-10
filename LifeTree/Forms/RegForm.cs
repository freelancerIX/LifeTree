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
    public partial class RegForm : Form
    {
        private DBManager dbManager;

        public DBManager DBManager
        {
            get { return this.dbManager; }
            set { this.dbManager = value; }
        }

        public User User { get; set; }

        public RegForm()
        {
            InitializeComponent();
        }

        public event EventHandler OnUserRegCancel;
        public event EventHandler OnUserRegistred;

        private void regBtn_Click(object sender, EventArgs e)
        {
            string login = textInputLogin.Text;
            string pass = textInputPass.Text;
            string passSub = textInputPassSub.Text;

            if (pass != passSub)
            {
                MessageBox.Show("Введённые вами пароли не совпадают");
                return;
            }

            try
            {
                this.User = UserManager.Registration(dbManager, login, pass);
                OnUserRegistred?.Invoke(this, new EventArgs());
            }
            catch(RegistrationExeption ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnUserRegCancel?.Invoke(this, new EventArgs());
        }


    }
}
