using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeTree
{
    public class Tree
    {
        private long id;
        private User owner;
        private string name;
        private TreeNode root;

        private DBManager dbManager;

        public long ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public User Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name= value; }
        }

        public TreeNode Root
        {
            get { return this.root; }
            set { this.root = value; }
        }

        public DBManager DBManager
        {
            get { return this.dbManager; }
            set { this.dbManager = value; }
        }

        public Tree()
        {

        }

        public void LoadFromDB()
        {

        }

        public void SaveToDB()
        {

        }

        public void CreateNode()
        {

        }

        public void DeleteNode()
        {

        }
    }

    static class TreeManager
    {
        public static List<Tree> GetList(DBManager dbManager, User user = null)
        {
            var command = dbManager.GetOleDbComand();
            if (user != null)
                command.CommandText = $"SELECT ID, Name FROM Trees WHERE Owner = {user.ID}";
            else
            {
                command.CommandText = $"SELECT ID, Name, Owner FROM Trees";
            }
            var reader = command.ExecuteReader();

            List<Tree> treeList = new List<Tree>();
            Tree tree;
            while (reader.Read())
            {
                tree = new Tree()
                {
                    
                    
                };
                tree.ID = reader.GetInt32(0);
                tree.Name = reader.GetString(1);

                if (user == null)
                    tree.Owner = UserManager.GetUser(dbManager, reader.GetInt64(2));
                else
                    tree.Owner = user;

                treeList.Add(tree);
            }
            reader.Close();
            return treeList;
        }

        public static void LoadTree(DBManager dbManager, Tree tree)
        {
            var command = dbManager.GetOleDbComand();
            command.CommandText = $"SELECT Root FROM Trees WHERE id = {tree.ID}";
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                TreeNodeManager.LoadNodes(dbManager, tree, reader.GetInt32(0));
            }
        }

        public static Tree CreateTree(DBManager dbManager, User user, string name)
        {
            var command = dbManager.GetOleDbComand();
            command.CommandText = $"INSERT INTO Trees ([Owner], [Name], [Root]) VALUES ({user.ID}, '{name}', 0)";
            command.ExecuteNonQuery();

            command.CommandText = $"SELECT ID FROM Trees WHERE Owner = {user.ID} AND Name = '{name}'";
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                return new Tree()
                {
                    ID = reader.GetInt32(0),
                    Owner = user,
                    Name = name,
                    Root = null
                };
            }
            else return null;
        }

        public static Tree RenameTree(DBManager dbManager, Tree tree, string name)
        {
            var command = dbManager.GetOleDbComand();
            command.CommandText = $"UPDATE Trees SET Name = '{name}' WHERE ID = {tree.ID}";
            command.ExecuteNonQuery();

            tree.Name = name;

            return tree;
        }

        public static void DeleteTree(DBManager dbManager, Tree tree)
        {
            var command = dbManager.GetOleDbComand();
            command.CommandText = $"DELETE FROM Trees WHERE ID = {tree.ID}";
            command.ExecuteNonQuery();
        }
    }
}
