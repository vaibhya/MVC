using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BankMvcApp.Models.Service
{
    public class UserAuthetication
    {
        private String _username;
        private String _password;
        public UserAuthetication(String username,String password)
        {
            _username = username;
            _password = password;
        }
        public bool Authenticate()
        {

            MD5 md5pass = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(_password);
            byte[] hashBytes = md5pass.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            String hashPass = sb.ToString();
            String connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand loginCmd = new SqlCommand("select * from Bank_Master where Username=@username and Password = @password", conn);
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@username", _username);
            Param[1] = new SqlParameter("@password", hashPass);
            loginCmd.Parameters.Add(Param[0]);
            loginCmd.Parameters.Add(Param[1]);

            SqlDataReader reader = loginCmd.ExecuteReader();
            while (reader.Read())
            {
                
                return true;
                
            }

            conn.Close();

            return false;
        }

    }
}