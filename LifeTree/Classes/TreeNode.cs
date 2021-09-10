using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTree
{
    public class TreeNode
    {
        private long id;
        private Tree tree;
        private TreeNode mother;
        private TreeNode father;
        private Bitmap photo;
        private Boolean sex;
        private string firstName;
        private string middleName;
        private string lastName;
        private DateTime bornDate;
        private DateTime deathDate;

        private List<TreeNode> ChildList;

        public long ID
        {
            get { return this.ID; }
            set { this.ID = value; }
        }

        public Tree Tree
        {
            get { return this.tree; }
            set { this.tree = value; }
        }
        public TreeNode Mother
        {
            get { return this.mother; }
            set
            {
                if (this.mother != null)
                    this.mother.ChildList.Remove(this);
                if (value != null)
                    value.ChildList.Add(this);
                this.mother = value;
            }
        }
        public TreeNode Father
        {
            get { return this.father; }
            set
            {
                if (this.father != null)
                    this.father.ChildList.Remove(this);
                if (value != null)
                    value.ChildList.Add(this);
                this.father = value;
            }
        }
        public Bitmap Photo
        {
            get { return this.photo; }
            set { this.photo = value; }
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

        public void CreateFather()
        {

        }
        public void CreateMother()
        {

        }
        public void SetFather()
        {

        }
        public void SetMother()
        {

        }
        public void CreateChild()
        {

        }
    }

    class TreeNodeRow
    {
        private long id;
        private Tree tree;
        private long mother;
        private long father;
        private Bitmap photo;
        private Boolean sex;
        private string firstName;
        private string middleName;
        private string lastName;
        private DateTime bornDate;
        private DateTime deathDate;

        public long ID
        {
            get { return this.ID; }
            set { this.ID = value; }
        }

        public Tree Tree
        {
            get { return this.tree; }
            set { this.tree = value; }
        }
        public long Mother
        {
            get { return this.mother; }
            set { this.mother = value; }
        }
        public long Father
        {
            get { return this.father; }
            set { this.father = value; }
        }
        public Bitmap Photo
        {
            get { return this.photo; }
            set { this.photo = value; }
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
    }

    static class TreeNodeManager
    {
        private static TreeNode GetNode(long ID, List<TreeNodeRow> treeNodeRowList)
        {
            foreach (var nodeRow in treeNodeRowList)
            {
                if (nodeRow.ID == ID)
                    return new TreeNode()
                    {
                        ID = ID,
                        Mother = GetNode(nodeRow.Mother, treeNodeRowList),
                        Father = GetNode(nodeRow.Father, treeNodeRowList)
                    };
            }
            return null;
        }

        public static void LoadNodes(DBManager dbManager, Tree tree, long id)
        {
            var command = dbManager.GetOleDbComand();
            command.CommandText
                = $"SELECT ID, Mother, Father, Photo, Sex, FirstName" +
                    $", MiddleName, LastName, BornDate, DeathDate" +
                    $" FROM TreeNodes WHERE TreeID = {tree.ID}";
            var reader = command.ExecuteReader();

            TreeNodeRow treeNodeRow;
            List<TreeNodeRow> treeNodeRowList = new List<TreeNodeRow>();
            while (reader.Read())
            {
               treeNodeRow = new TreeNodeRow()
                {
                    ID = reader.GetInt32(0),
                    Mother = reader.GetInt32(1),
                    Father = reader.GetInt32(2)
                };
                treeNodeRowList.Add(treeNodeRow);
            }

            tree.Root = GetNode(id, treeNodeRowList);
        }
    }
}
