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
    public class BankDbInsertUpdate
    {
        private double _amount;
        private String _activity;
        private String _username;
        private String _password;
        public BankDbInsertUpdate(Double amount,String activity,String username,String password)
        {
            _amount = amount;
            _activity = activity;
            _username = username;
            _password = password;
        }
        public bool InsertIntoDb()
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


            //insert into Bank_Transaction
            SqlCommand transactionComm = new SqlCommand("insert into Bank_Transaction Values(@username,@amount,@type,@datetime)", conn);
            SqlParameter[] tParam = new SqlParameter[4];
            tParam[0] = new SqlParameter("@username", _username);
            tParam[1] = new SqlParameter("@amount", _amount);
            tParam[2] = new SqlParameter("@type", _activity=="Deposit"? Activity.D.ToString(): Activity.W.ToString());
            tParam[3] = new SqlParameter("@datetime", DateTime.Now.ToString());
            transactionComm.Parameters.Add(tParam[0]);
            transactionComm.Parameters.Add(tParam[1]);
            transactionComm.Parameters.Add(tParam[2]);
            transactionComm.Parameters.Add(tParam[3]);

            //update Bank_Master
            BalanceAccessService accBalance = new BalanceAccessService(_username, _password);
            SqlCommand updateComm = new SqlCommand("Update Bank_Master Set Balance=@updatedBalance where Username = @username and Password = @password", conn);
            SqlParameter[] uParam = new SqlParameter[3];
            uParam[0] = new SqlParameter("@updatedBalance", _activity == "Deposit" ? accBalance.GetBalance() + _amount: accBalance.GetBalance() - _amount);
            uParam[1] = new SqlParameter("@username", _username);
            uParam[2] = new SqlParameter("@password", hashPass);
            updateComm.Parameters.Add(uParam[0]);
            updateComm.Parameters.Add(uParam[1]);
            updateComm.Parameters.Add(uParam[2]);


            //begin transaction
            SqlTransaction transaction = conn.BeginTransaction();
            transactionComm.Transaction = transaction;
            updateComm.Transaction = transaction;

            try
            {
                updateComm.ExecuteNonQuery();
                transactionComm.ExecuteNonQuery();

                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
            return false;
        }
    }
}