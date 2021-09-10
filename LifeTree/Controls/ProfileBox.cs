using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeTree.Controls
{
    public partial class ProfileBox : UserControl
    {
        private PictureBox picture;
        private Label firstLine;
        private Label secondLine;

        private bool selected;

        private Color backColor;
        private Color selectedColor;

        public object Owner { get; set; }
        public bool Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                if (this.selected != value)
                    this.selected = value;

                if (value)
                    this.BackColor = selectedColor;
                else
                    this.BackColor = this.DefaultColor;
            }
        }
        public Color DefaultColor
        {
            get
            {
                // return this.backColor;
                return Color.LightBlue;
            }
            set
            {
                if (!this.selected)
                    this.BackColor = value;
                this.backColor = value;
            }
        }
        public Color SelectedColor
        {
            get
            {
                return this.backColor;
            }
            set
            {
                if (this.selected)
                    this.BackColor = value;
                this.selectedColor = value;
            }
        }

        public Image Image
        {
            get { return this.picture?.Image; }
            set { this.picture.Image = value; }
        }
        public string FirstLine
        {
            get { return this.firstLine.Text; }
            set { this.firstLine.Text = value; }
        }
        public string SecondLine
        {
            get { return this.secondLine.Text; }
            set { this.secondLine.Text = value; }
        }

        public ProfileBox()
        {
            InitializeComponent();

            this.Width = 80;
            this.Height = 70;

            this.picture = new PictureBox();
            this.firstLine = new Label();
            this.secondLine = new Label();

            this.picture.Size = new Size(35, 45);
            this.picture.Top = this.Margin.Top;
            this.picture.BackColor = Color.LightSlateGray;
            this.picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picture.Click += Controls_Clicked;
            this.picture.Left = this.Width / 2 - this.picture.Width / 2;
            
            this.firstLine.Top = this.picture.Top + this.picture.Height + 5;
            this.firstLine.Resize += OnLineResize;
            this.firstLine.Click += Controls_Clicked;

            this.secondLine.Top = this.firstLine.Top + this.firstLine.Height;
            this.secondLine.Resize += OnLineResize;
            this.secondLine.Click += Controls_Clicked;

            this.Controls.Add(this.picture);
            this.Controls.Add(this.firstLine);
            this.Controls.Add(this.secondLine);

            this.BackColor = Color.Yellow;
        }

        private void OnLineResize(object Sender, EventArgs e)
        {
            Label line = (Label)Sender;
            if (line.Width > this.Width)
                line.Left = 0;
            else
                line.Left = this.Width / 2 - line.Width / 2;
        }

        private void Controls_Clicked(object Sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
