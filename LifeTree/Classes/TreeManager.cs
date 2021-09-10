using System.Collections.Generic;

namespace LifeTree.Classes
{
    static class TreeManager
    {
        public static List<ProfileTree> GetList(DBManager dbManager, User user = null)
        {
            var command = dbManager.GetOleDbComand();
            if (user != null)
                command.CommandText = $"SELECT ID, Name FROM Trees WHERE Owner = {user.ID}";
            else
            {
                command.CommandText = $"SELECT ID, Name, Owner FROM Trees";
            }
            var reader = command.ExecuteReader();

            List<ProfileTree> treeList = new List<ProfileTree>();
            ProfileTree tree;
            while (reader.Read())
            {
                tree = new ProfileTree()
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

        public static void LoadTree(DBManager dbManager, ProfileTree tree)
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

        public static ProfileTree CreateTree(DBManager dbManager, User user, string name)
        {
            var command = dbManager.GetOleDbComand();
            command.CommandText = $"INSERT INTO Trees ([Owner], [Name], [Root]) VALUES ({user.ID}, '{name}', 0)";
            command.ExecuteNonQuery();

            command.CommandText = $"SELECT ID FROM Trees WHERE Owner = {user.ID} AND Name = '{name}'";
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                return new ProfileTree()
                {
                    ID = reader.GetInt32(0),
                    Owner = user,
                    Name = name,
                    Root = null
                };
            }
            else return null;
        }

        public static ProfileTree RenameTree(DBManager dbManager, ProfileTree tree, string name)
        {
            var command = dbManager.GetOleDbComand();
            command.CommandText = $"UPDATE Trees SET Name = '{name}' WHERE ID = {tree.ID}";
            command.ExecuteNonQuery();

            tree.Name = name;

            return tree;
        }

        public static void DeleteTree(DBManager dbManager, ProfileTree tree)
        {
            var command = dbManager.GetOleDbComand();
            command.CommandText = $"DELETE FROM Trees WHERE ID = {tree.ID}";
            command.ExecuteNonQuery();
        }
    }
}
