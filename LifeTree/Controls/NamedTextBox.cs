using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeTree.Controls
{
    public partial class NamedTextBox : UserControl
    {
        private TextBox titleText;
        private Control inputText;

        public string Title
        {
            get
            {
                return this.titleText.Text;
            }
            set
            {
                this.titleText.Text = value;
            }
        }

        public Control InputText
        {
            get
            {
                return this.inputText;
            }
            set
            {
                this.inputText = value;
            }
        }

        public int TitleWidth
        {
            get
            {
                return this.titleText.Width;
            }
            set
            {
                this.titleText.Width = value;
            }
        }

        public Control Control
        {
            get
            {
                return this.inputText;
            }
            set
            {
                this.inputText = value;
            }
        }

        public NamedTextBox(Control control)
        {
            InitializeComponent();

            
            this.titleText = new TextBox();
            this.inputText = control;

            this.titleText.Width = 0;
            this.titleText.ReadOnly = true;
            this.titleText.Enabled = false;
            this.titleText.Resize += TitleText_Resize;

            this.inputText.Width = this.Width;
                    
            this.Controls.Add(titleText);
            this.Controls.Add(inputText);
            }

        private void NamedTextBox_Resize(object sender, EventArgs e)
        {
            this.inputText.Width = this.Width - this.titleText.Width + 1;
            this.Height = this.inputText.Height;
            this.inputText.Left = this.titleText.Location.X + this.titleText.Width - 1;
        }

        private void TitleText_Resize(object sender, EventArgs e)
        {
            this.inputText.Width = this.Width - this.titleText.Width + 1;
            this.inputText.Left = this.titleText.Location.X + this.titleText.Width - 1;
        }

    }
}
