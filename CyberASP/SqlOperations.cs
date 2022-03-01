using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CyberASP
{
    public class SqlOperations
    {
        public SqlCommand command;
        private int TokenID { get; set; }
        public SqlOperations()
        {

        }
        public void AddUser(string login, string email, DateTime data_registr, string token)
        {
            if (AddToken(token))
            {
                using (command = new SqlCommand($"INSERT INTO [Cyber_User]VALUES('{login}','{email}','{data_registr.ToString("yyyy-MM-dd H:m:s")}','{TakeTokenID(token)}')", ConnectDataBase.conn))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        private bool AddToken(string token)
        {
            using (command = new SqlCommand($"INSERT INTO [CyberUser_Token]VALUES('{token}')", ConnectDataBase.conn))
            {
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        private int TakeTokenID(string token)
        {
            int TokenID = -1;
            using (command = new SqlCommand($"SELECT ID FROM [CyberUser_Token]WHERE [Token]='{token}'", ConnectDataBase.conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TokenID = (int)reader["ID"];
                }
                reader.Close();
                return TokenID;
            }
        }
        public bool LoginByDB(string login, string token)
        {
            if (SearchLoginDB(login))
            {
                if (SearchToken(token))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool SearchLoginDB(string login)
        {
            using (command = new SqlCommand($"SELECT [Token_ID] FROM [Cyber_User]WHERE [Login]='{login}'", ConnectDataBase.conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TokenID = (int)reader["Token_ID"];
                    reader.Close();
                    return true;
                }
                reader.Close();
                return false;
            }
        }
        private bool SearchToken(string token)
        {
            using (command = new SqlCommand($"SELECT [ID] FROM [CyberUser_Token]WHERE [Token]='{token}'", ConnectDataBase.conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (TokenID == (int)reader["ID"])
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                return false;
            }
        }

    }
}
