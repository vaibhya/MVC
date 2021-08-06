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
    public class UserRegistration
    {
        private string _username;
        private double _initialBalance;
        private String _password;

        public UserRegistration(String username,Double initialBalance,String password)
        {
            _username = username;
            _initialBalance = initialBalance;
            _password = password;
        }
        public bool RegisterUser()
        {
            //Hash generation
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

            //insert into Bank_Master
            SqlCommand masterComm = new SqlCommand("insert into Bank_Master Values(@username,@balance,@password)", conn);
            SqlParameter[] mParam = new SqlParameter[3];
            mParam[0] = new SqlParameter("@username", _username);
            mParam[1] = new SqlParameter("@balance", _initialBalance);
            mParam[2] = new SqlParameter("@password", hashPass);

            masterComm.Parameters.Add(mParam[0]);
            masterComm.Parameters.Add(mParam[1]);
            masterComm.Parameters.Add(mParam[2]);



            //insert into Bank_Transaction
            SqlCommand transactionComm = new SqlCommand("insert into Bank_Transaction Values(@username,@amount,@type,@datetime)", conn);
            SqlParameter[] tParam = new SqlParameter[4];
            tParam[0] = new SqlParameter("@username", _username);
            tParam[1] = new SqlParameter("@amount", _initialBalance);
            tParam[2] = new SqlParameter("@type",Activity.D.ToString());
            tParam[3] = new SqlParameter("@datetime", DateTime.Now.ToString());
            transactionComm.Parameters.Add(tParam[0]);
            transactionComm.Parameters.Add(tParam[1]);
            transactionComm.Parameters.Add(tParam[2]);
            transactionComm.Parameters.Add(tParam[3]);


            //begin transaction
            SqlTransaction transaction = conn.BeginTransaction();
            transactionComm.Transaction = transaction;
            masterComm.Transaction = transaction;

            try
            {
                masterComm.ExecuteNonQuery();
                transactionComm.ExecuteNonQuery();

                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
                return false;
            }
            //return true;
        }
    }
}