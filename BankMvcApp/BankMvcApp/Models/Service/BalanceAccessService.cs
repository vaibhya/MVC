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
    public class BalanceAccessService
    {
        private String _username;
        private String _password;
        public BalanceAccessService( String username, String password)
        {
            _username = username;
            _password = password;
        }
        public double GetBalance()
        {
            double balance = 0;
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
            SqlCommand balanceCmd = new SqlCommand("select Balance from Bank_Master where Username=@username and Password = @password", conn);
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@username", _username);
            Param[1] = new SqlParameter("@password", hashPass);
            balanceCmd.Parameters.Add(Param[0]);
            balanceCmd.Parameters.Add(Param[1]);

            SqlDataReader reader = balanceCmd.ExecuteReader();
            while (reader.Read())
            {
                balance = Double.Parse(reader["Balance"].ToString());
                return balance;

            }

            conn.Close();
            return balance;
        }
    }
}