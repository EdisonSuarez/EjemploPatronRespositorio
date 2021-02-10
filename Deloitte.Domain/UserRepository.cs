using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Deloitte.Domain
{
    public class UserRepository : IUserRepository
    {
        private readonly string _cnx;
        public UserRepository(string cnx)
        {
            this._cnx = cnx;
        }

        public User Login(string login, string password)
        {
            DataTable dtUser = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlConnection sqlConnection = new SqlConnection(_cnx);

            try
            {
                sqlConnection.Open();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "stpUsersValidation";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Login", SqlDbType.VarChar, 20).Value = login;
                sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar, 200).Value = password;
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dtUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCommand = null;
                sqlConnection.Close();
            }
            return ConvertirDesdeDataTable(dtUser);
        }

        protected User ConvertirDesdeDataTable(DataTable dtUsers)
        {
            User oUsers = null;
            if (dtUsers.Rows.Count > 0)
            {
                oUsers = new User();
                System.Reflection.PropertyInfo[] Campos = oUsers.GetType().GetProperties();
                for (int i = 0; i < Campos.Length; i++)
                {
                    Campos[i].SetValue(oUsers, dtUsers.Rows[0][Campos[i].Name], null);
                }
            }
            return oUsers;
        }
    }
}
