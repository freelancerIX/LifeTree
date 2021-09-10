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
    public partial class TreeEditForm : Form
    {
        public string TreeName
        {
            get
            {
                return textNameTree.Text;
            }
            set
            {
                textNameTree.Text = value;
            }
        }
        public TreeEditForm()
        {
            InitializeComponent();
        }

    }
}
