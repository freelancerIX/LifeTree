using System;

namespace LifeTree.Classes
{
    public class RegistrationExeption : Exception
    {
        public RegistrationExeption(string message) : base(message) { }
    }

    static class UserManager
    {
        public static User DoLogin(DBManager dBmanager, string login, string pass)
        {
            var commandDB = dBmanager.GetOleDbComand();


            commandDB.CommandText = $"SELECT ID FROM Users WHERE Login = '{login}' AND Password = '{pass}'";
            var cell = commandDB.ExecuteScalar();
            if (cell == null)
                return null;
            else
            {
                User user = new User
                {
                    Login = login,
                    ID = (int)cell
                };
                return user;
            }
        }



        public static User Registration(DBManager dBmanager, string login, string pass)
        {
            var commandDB = dBmanager.GetOleDbComand();


            commandDB.CommandText = $"INSERT INTO Users ([Login], [Password]) VALUES ('{login}', '{pass}')";

            try
            {
                commandDB.ExecuteNonQuery();
            }
            catch
            {
                throw new RegistrationExeption("Данный пользователь уже существует.");
            }

            commandDB.CommandText = $"SELECT ID FROM Users WHERE login = '{login}'";
            var cell = commandDB.ExecuteScalar();
            if (cell == null)
                return null;
            else
            {
                User user = new User
                {
                    Login = login,
                    ID = (int)cell
                };
                return user;
            }
        }

        public static User GetUser(DBManager dBmanager, long id)
        {
            var commandDB = dBmanager.GetOleDbComand();
            commandDB.CommandText = $"SELECT Login FROM Users WHERE ID = {id}";
            var cell = commandDB.ExecuteScalar();
            if (cell == null)
                return null;
            else
            {
                User user = new User
                {
                    Login = cell.ToString(),
                    ID = id
                };
                return user;
            }
        }
    }
}
