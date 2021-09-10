
namespace LifeTree.Classes
{
    public class ProfileTree
    {
        private long id;
        private User owner;
        private string name;
        private ProfileTreeNode root;

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

        public ProfileTreeNode Root
        {
            get { return this.root; }
            set { this.root = value; }
        }

        public DBManager DBManager
        {
            get { return this.dbManager; }
            set { this.dbManager = value; }
        }

        public int CalculateHeight()
        {
            return this.Root.CalculateHeight();
        }
    }
}
