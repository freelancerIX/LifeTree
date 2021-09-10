using System;
using System.Drawing;

namespace LifeTree.Classes
{
    public class ProfileTreeNode
    {
        private long id;
        private ProfileTree tree;
        private ProfileTreeNode mother;
        private ProfileTreeNode father;
        private Bitmap photo;
        private Boolean sex;
        private string firstName;
        private string middleName;
        private string lastName;
        private DateTime bornDate;
        private DateTime deathDate;

        // private List<TreeNode> ChildList;

        public long ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public ProfileTree ProfileTree
        {
            get { return this.tree; }
            set { this.tree = value; }
        }
        public ProfileTreeNode Mother
        {
            get { return this.mother; }
            set
            {
                /*if (this.mother != null)
                    this.mother.ChildList.Remove(this);
                if (value != null)
                    value.ChildList.Add(this);*/
                this.mother = value;
            }
        }
        public ProfileTreeNode Father
        {
            get { return this.father; }
            set
            {
                /*if (this.father != null)
                    this.father.ChildList.Remove(this);
                if (value != null)
                    value.ChildList.Add(this);*/
                this.father = value;
            }
        }
        public Bitmap Photo
        {
            get { return this.photo; }
            set { this.photo = new Bitmap(value); }
        }
        public Boolean Sex
        {
            get { return this.sex; }
            set { this.sex = value; }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string MiddleName
        {
            get { return this.middleName; }
            set { this.middleName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public DateTime BornDate
        {
            get { return this.bornDate; }
            set { this.bornDate = value; }
        }
        public DateTime DeathDate
        {
            get { return this.deathDate; }
            set { this.deathDate = value; }
        }

        public int CalculateHeight()
        {
            return
                Math.Max(
                    (this.Mother == null) ? 0 : this.Mother.CalculateHeight()
                    , (this.Father == null) ? 0 : this.Father.CalculateHeight())
                + 1;
        }

        public void AddEmptyNodes()
        {
            if (this.ID != 0)
            {
                if (this.Mother != null) this.Mother.AddEmptyNodes();
                else this.Mother = new ProfileTreeNode();

                if (this.Father != null) this.Father.AddEmptyNodes();
                else this.Father = new ProfileTreeNode();
            }
        }

        private ProfileTreeNode GetParentNodeRec(ProfileTreeNode node)
        {
            if (this.Father == node || this.Mother == node)
                return this;
            else
            {
                ProfileTreeNode mother;
                ProfileTreeNode father;

                if (this.Mother != null)
                    mother = this.Mother.GetParentNodeRec(node);
                else mother = null;
                if (this.Father != null)
                    father = this.Father.GetParentNodeRec(node);
                else father = null;

                return (mother == null) ? father : mother;
            }
        }

        public ProfileTreeNode GetParentNode()
        {
            return this.ProfileTree.Root?.GetParentNodeRec(this);
        }
    }
}
