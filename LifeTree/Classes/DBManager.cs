using System.Data.OleDb;

namespace LifeTree.Classes
{
    public class DBManager
    {
        OleDbConnection con;


        public DBManager(string fName)
        {
            this.con = new OleDbConnection($"Provider = Microsoft.Jet.OLEDB.4.0; data source = {fName}");
            this.con.Open();
        }


        public OleDbCommand GetOleDbComand()
        {
            OleDbCommand oleDbCommand = new OleDbCommand();

            oleDbCommand.Connection = this.con;
                
            return oleDbCommand;
        }
    }
}
