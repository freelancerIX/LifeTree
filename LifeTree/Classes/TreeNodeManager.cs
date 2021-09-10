using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace LifeTree.Classes
{
    class TreeNodeRow
    {
        private long id;
        private ProfileTree tree;
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
            get { return this.id; }
            set { this.id = value; }
        }

        public ProfileTree ProfileTree
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
        private static ProfileTreeNode GetNode(long ID, List<TreeNodeRow> treeNodeRowList, ProfileTree tree)
        {
            foreach (var nodeRow in treeNodeRowList)
            {
                if (nodeRow.ID == ID)
                    return new ProfileTreeNode()
                    {
                        ID = ID,
                        Mother = GetNode(nodeRow.Mother, treeNodeRowList, tree),
                        Father = GetNode(nodeRow.Father, treeNodeRowList, tree),
                        Photo = nodeRow.Photo,
                        Sex = nodeRow.Sex,
                        FirstName = nodeRow.FirstName,
                        MiddleName = nodeRow.MiddleName,
                        LastName = nodeRow.LastName,
                        BornDate = nodeRow.BornDate,
                        DeathDate = nodeRow.DeathDate,
                        ProfileTree = tree
                    };
            }
            return null;
        }

        public static void LoadNodes(DBManager dbManager, ProfileTree tree, long id)
        {
            var command = dbManager.GetOleDbComand();
            command.CommandText
                = $"SELECT ID, Mother, Father, PhotoSize, Photo, Sex, FirstName" +
                    $", MiddleName, LastName, BornDate, DeathDate" +
                    $" FROM TreeNodes WHERE TreeID = {tree.ID}";
            var reader = command.ExecuteReader();

            TreeNodeRow treeNodeRow;
            List<TreeNodeRow> treeNodeRowList = new List<TreeNodeRow>();
            while (reader.Read())
            {
                treeNodeRow = new TreeNodeRow()
                {

                };

                treeNodeRow.ID = reader.GetInt32(0);
                treeNodeRow.Mother = reader.GetInt32(1);
                treeNodeRow.Father = reader.GetInt32(2);

                int photoSize = reader.GetInt32(3);
                if (photoSize != 0)
                {
                    byte[] buffer = new byte[photoSize];
                    reader.GetBytes(4, 0, buffer, 0, photoSize);
                    MemoryStream stream = new MemoryStream(buffer);
                    treeNodeRow.Photo = new Bitmap(stream);
                }
                if (!reader.IsDBNull(5))
                    treeNodeRow.Sex = reader.GetBoolean(5);
                if (!reader.IsDBNull(6))
                    treeNodeRow.FirstName = reader.GetString(6);
                if (!reader.IsDBNull(7))
                    treeNodeRow.MiddleName = reader.GetString(7);
                if (!reader.IsDBNull(8))
                    treeNodeRow.LastName = reader.GetString(8);
                if (!reader.IsDBNull(9))
                    treeNodeRow.BornDate = reader.GetDateTime(9);
                if (!reader.IsDBNull(10))
                    treeNodeRow.DeathDate = reader.GetDateTime(10);

                treeNodeRowList.Add(treeNodeRow);
            }

            tree.Root = GetNode(id, treeNodeRowList, tree);

        }

        public static void SaveNode(DBManager dbManager, ProfileTreeNode node)
        {
            var command = dbManager.GetOleDbComand();
            ImageConverter converter = new ImageConverter();

            if (node.ID == 0)
            {
                command.CommandText =
                    $"INSERT INTO [TreeNodes] (" +
                        $" [TreeID], [Mother], [Father], [PhotoSize], [Photo], [Sex]" +
                        $", [FirstName], [MiddleName], [LastName]" +
                        $", [BornDate], [DeathDate])" +
                        $" VALUES ({node.ProfileTree.ID}" +
                        $", 0, 0, @photoSize, @photo, {node.Sex}, '{node.FirstName}', '{node.MiddleName}'" +
                        $", '{node.LastName}', '{node.BornDate}', '{node.DeathDate}')";

                byte[] buffer = BitmapToByte(node.Photo);
                command.Parameters.Add("@PhotoSize", OleDbType.Integer).Value = buffer.Length;
                command.Parameters.Add("@photo", OleDbType.Binary).Value = buffer;
            }
            else
            {
                long mother = (node.Mother == null) ? 0 : node.Mother.ID;
                long father = (node.Father == null) ? 0 : node.Father.ID;

                command.CommandText =
                    $"UPDATE [TreeNodes] SET" +
                    $" TreeID = {node.ProfileTree.ID}" +
                    $", Mother = {mother}, Father = {father}" +
                    $", PhotoSize = @PhotoSize" +
                    $", Photo = @photo, Sex = {node.Sex}" +
                    $", FirstName = '{node.FirstName}'" +
                    $", MiddleName = '{node.MiddleName}'" +
                    $", LastName = '{node.LastName}'" +
                    $", BornDate = '{node.BornDate}'" +
                    $", DeathDate = '{node.DeathDate}'" +
                    $" WHERE ID = {node.ID}";

                byte[] buffer = BitmapToByte(node.Photo);
                command.Parameters.Add("@PhotoSize", OleDbType.Integer).Value = buffer.Length;
                command.Parameters.Add("@photo", OleDbType.Binary).Value = buffer;
            }

            command.ExecuteNonQuery();

            if (node.ID == 0)
            {
                command.CommandText = "SELECT @@Identity";
                node.ID = (Int32)command.ExecuteScalar();
            }

            ProfileTreeNode parentNode = node.GetParentNode();
            if (parentNode == null)
            {
                command.CommandText =
                    $"UPDATE [Trees] SET" +
                    $" [Root] = {node.ID}" +
                    $" WHERE ID = {node.ProfileTree.ID}";
                command.ExecuteNonQuery();
            }
            else
            {
                command.CommandText =
                    $"UPDATE [TreeNodes] SET" +
                    $" [Mother] = {parentNode.Mother.ID}" +
                    $", [Father] = {parentNode.Father.ID}" +
                    $" WHERE ID = {parentNode.ID}";
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteNode(DBManager dbManager, ProfileTreeNode node)
        {
            if (node == null) return;
            if (node.ID == 0) return;

            var command = dbManager.GetOleDbComand();

            command.CommandText =
                $"UPDATE [Trees] SET" +
                $" Root = 0" +
                $" WHERE Root = {node.ID}";
            command.ExecuteNonQuery();

            command.CommandText =
                $"UPDATE [TreeNodes] SET" +
                $" Mother = 0" +
                $" WHERE Mother = {node.ID}";
            command.ExecuteNonQuery();

            command.CommandText =
                            $"UPDATE [TreeNodes] SET" +
                            $" Father = 0" +
                            $" WHERE Father = {node.ID}";
            command.ExecuteNonQuery();

            command.CommandText =
                            $"DELETE FROM [TreeNodes]" +
                            $" WHERE ID = {node.ID}";
            command.ExecuteNonQuery();

            node.ID = 0;

            if (node.ProfileTree.Root == node)
                node.ProfileTree.Root = null;
            else
            {
                var parent = node.GetParentNode();
                if (parent.Mother == node)
                    parent.Mother = null;
                else
                    parent.Father = null;
            }

            DeleteNode(dbManager, node.Mother);
            node.Mother = null;

            DeleteNode(dbManager, node.Father);
            node.Father = null;
        }
        private static byte[] BitmapToByte(Bitmap img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
