using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using LifeTree.Classes;

namespace LifeTree.Controls
{
    public partial class TreeViewPanel : UserControl
    {
        public class SelectedBoxChangeEventArgs : EventArgs
        {
            public ProfileBox OldBox { get; private set; }
            public ProfileBox NewBox { get; private set; }

            public SelectedBoxChangeEventArgs(ProfileBox oldBox, ProfileBox newBox)
            {
                this.OldBox = oldBox;
                this.NewBox = newBox;
            }
        }

        public event EventHandler SelectedBoxChanged;

        private ProfileTreeNode selectedNode;
        private ProfileBox selectedBox;

        public ProfileTreeNode RootElement { get; set; }

        private Dictionary<ProfileTreeNode, ProfileBox> ProfileDictionary;
        private Dictionary<ProfileBox, ProfileTreeNode> NodeDictionary;

        public ProfileBox SelectedBox
        {
            get { return this.selectedBox; }
            private set
            {
                if (this.selectedBox == value) return;

                if (this.selectedBox != null)
                    this.selectedBox.Selected = false;
                if (value != null)
                    value.Selected = true;

                ProfileBox box = this.selectedBox = value;
                this.selectedNode = this.GetNodeByBox(value);

                SelectedBoxChanged?.Invoke(this
                    , new SelectedBoxChangeEventArgs(box, value));
            }
        }
        public ProfileTreeNode SelectedNode
        {
            get { return selectedNode; }
            set
            {
                if (this.SelectedBox != null)
                    this.SelectedBox.Selected = false;

                this.selectedNode = value;
                this.selectedBox = GetBoxByNode(value);
                if (this.selectedBox != null)
                    this.selectedBox.Selected = true;
            }
        }

        public TreeViewPanel()
        {
            InitializeComponent();

            this.ProfileDictionary = new Dictionary<ProfileTreeNode, ProfileBox>();
            this.NodeDictionary = new Dictionary<ProfileBox, ProfileTreeNode>();

            this.Paint += TreeViewPanel_Paint;

        }

        private void TreeViewPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawConnectLine();
        }

        private ProfileTreeNode GetNodeByBox(ProfileBox box)
        {
            NodeDictionary.TryGetValue(box, out ProfileTreeNode node);
            return node;
        }
        private ProfileBox GetBoxByNode(ProfileTreeNode node)
        {
            ProfileDictionary.TryGetValue(node, out ProfileBox box);
            return box;
        }

        private ProfileBox GetProfileBox(ProfileTreeNode node)
        {
            if (!this.ProfileDictionary.TryGetValue(node, out ProfileBox box))
            {
                box = new ProfileBox();
                box.Click += Box_Click;

                this.ProfileDictionary.Add(node, box);
                this.NodeDictionary.Add(box, node);
            }
            this.UpdateBox(box, node);
            return box;
        }

        private void DrawNodeRec(ProfileTreeNode node, int level, int pos)
        {
            if (node == null) return;

            int pos_count = (int)Math.Pow(2, level);
            double block_width = (double)this.Width / pos_count;

            ProfileBox profileBox = GetProfileBox(node);
            profileBox.Left = (int)(block_width * (pos + 1) - block_width / 2
                - TreeViewPanelSettings.ElementWidth / 2);
            profileBox.Top = this.Height
                - (level + 1) * TreeViewPanelSettings.ElementHeight
                - level * TreeViewPanelSettings.Padding
                - TreeViewPanelSettings.Padding;

            this.Controls.Add(profileBox);

            this.DrawNodeRec(node.Father, ++level, 2 * pos);
            this.DrawNodeRec(node.Mother, level, 2 * pos + 1);
        }

        public void DrawLineNodes(int x1, int y1, int x2, int y2, Control Control)
        {
            Graphics g = Control.CreateGraphics();
            g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
        }

        public void RedrawTree()
        {
            int level = this.RootElement.CalculateHeight();
            int max_elements = (int)Math.Pow(2, level - 1);
            int width = max_elements * TreeViewPanelSettings.ElementWidth
                + max_elements * TreeViewPanelSettings.Padding + TreeViewPanelSettings.Padding;
            int height = level * TreeViewPanelSettings.ElementHeight
                + level * TreeViewPanelSettings.Padding + TreeViewPanelSettings.Padding;

            this.Size = new Size(width, height);
            
            this.DrawNodeRec(this.RootElement, 0, 0);

            DrawConnectLine();

        }

        public void DrawConnectLine()
        {
            Dictionary<ProfileBox, ProfileTreeNode>.ValueCollection valueCollection = NodeDictionary.Values;

            var e = this.CreateGraphics();
            e.Clear(Color.White);

            foreach (ProfileTreeNode s in valueCollection)
            {
               
                if (s.ID != 0)
                {
                    var tempBox = GetBoxByNode(s);
                    var tempBoxFat = GetBoxByNode(s.Father);
                    var tempBoxMot = GetBoxByNode(s.Mother);

                    DrawLineNodes(tempBox.Left + tempBox.Width / 2, tempBox.Top, tempBox.Left + tempBox.Width / 2, tempBox.Top - 3, this);

                    DrawLineNodes(tempBoxFat.Left + tempBoxFat.Width / 2, tempBoxFat.Top + tempBoxFat.Height, tempBoxFat.Left + tempBoxFat.Width / 2, tempBoxFat.Top + tempBoxFat.Height + 2, this);
                    DrawLineNodes(tempBox.Left + tempBox.Width / 2, tempBox.Top - 3, tempBoxFat.Left + tempBoxFat.Width / 2, tempBoxFat.Top + tempBoxFat.Height + 2, this);

                    DrawLineNodes(tempBoxMot.Left + tempBoxMot.Width / 2, tempBoxMot.Top + tempBoxMot.Height, tempBoxMot.Left + tempBoxMot.Width / 2, tempBoxMot.Top + tempBoxMot.Height + 2, this);
                    DrawLineNodes(tempBox.Left + tempBox.Width / 2, tempBox.Top - 3, tempBoxMot.Left + tempBoxMot.Width / 2, tempBoxMot.Top + tempBoxMot.Height + 2, this);
                }
            }
        }

        private void Box_Click(object sender, EventArgs e)
        {
            ProfileBox box = (ProfileBox)sender;
            this.SelectedBox = box;
        }

        public void DeleteNode(ProfileTreeNode node)
        {
            if (this.selectedNode == node)
                this.selectedNode = null;

            this.ProfileDictionary.TryGetValue(node, out ProfileBox box);
            this.ProfileDictionary.Remove(node);
            this.NodeDictionary.Remove(box);
            this.Controls.Remove(box);

            if (node.Mother != null)
                DeleteNode(node.Mother);

            if (node.Father != null)
                DeleteNode(node.Father);
        }

        public void UpdateNode(ProfileTreeNode node)
        {
            this.ProfileDictionary.TryGetValue(node, out var box);
        }

        private void UpdateBox(ProfileBox box, ProfileTreeNode node)
        {
            string FIO = node.LastName;
            if (node.FirstName?.Length > 0)
                FIO += " " + node.FirstName[0] + ".";
            if (node.MiddleName?.Length > 0)
                FIO += " " + node.MiddleName[0] + ".";

            box.Image = node.Photo;
            box.FirstLine = FIO;
            if (node.FirstName?.Length > 0)
                box.SecondLine = box.SecondLine
                + node.FirstName[0] + "."
                + " ";
            if (node.MiddleName?.Length > 0)
                box.SecondLine = box.SecondLine
                + node.MiddleName[0] + ".";
            box.BackColor = Color.LightBlue;
            box.SelectedColor = Color.LightGray;
        }
    }

    public static class TreeViewPanelSettings
    {
        // Внешние отступы
        public const int Margin = 5;
        // Внутренние отступы
        public const int Padding = 5;
        // размеры элемента дерева
        public const int ElementWidth = 80;
        public const int ElementHeight = 70;
    }
}
