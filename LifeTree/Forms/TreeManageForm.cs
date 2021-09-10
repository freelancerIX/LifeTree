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
    public partial class TreeManageForm : Form
    {
        private ProfileTree selectedTree;
        private List<ProfileTree> treeList;
        
        public User User { get; set; }
        public DBManager DBManager { get; set; }
        public ProfileTree SelectedTree
        {
            get
            {
                return this.selectedTree;
            }
        }

        public event EventHandler OnUserOpenTree;
        public event EventHandler OnUserLogout;

        public TreeManageForm()
        {
            InitializeComponent();
        }

        private string ShowTreeEditForm(string name)
        {
            TreeEditForm form = new TreeEditForm();

            form.TreeName = name;

            DialogResult diaResult = form.ShowDialog();
            if (diaResult == DialogResult.OK)
                return form.TreeName;
            else
                return null;
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OnUserOpenTree?.Invoke(this, new EventArgs());
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            string name = ShowTreeEditForm(null);
            if (name != null)
            {
                ProfileTree tree = TreeManager.CreateTree(this.DBManager, this.User, name);
                this.treeList.Add(tree);
                this.treeListView.Items.Add(tree.Name);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            string name = ShowTreeEditForm(this.selectedTree.Name);
            if (name != null)
            {
                TreeManager.RenameTree(this.DBManager, this.selectedTree, name);
                this.treeListView.Items[this.treeListView.SelectedIndex] = name;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            TreeManager.DeleteTree(this.DBManager, this.selectedTree);
            this.treeList.Remove(this.selectedTree);
            this.treeListView.Items.RemoveAt(this.treeListView.SelectedIndex);
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            OnUserLogout?.Invoke(this, new EventArgs());
        }

        private void treeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.treeListView.SelectedIndex != -1)
            {
                this.selectedTree = this.treeList[this.treeListView.SelectedIndex];

                this.openBtn.Enabled = true;
                this.editBtn.Enabled = true;
                this.deleteBtn.Enabled = true;
            }
            else
            {
                this.openBtn.Enabled = false;
                this.editBtn.Enabled = false;
                this.deleteBtn.Enabled = false;
            }
        }

        private void TreeManageForm_Shown(object sender, EventArgs e)
        {
            this.treeList = TreeManager.GetList(DBManager, User);
            foreach (var tree in this.treeList)
            {
                this.treeListView.Items.Add(tree.Name);
            }
        }
    }
}
