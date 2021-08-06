using BankMvcCoreLib.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BankMvcCoreLib.Repository
{
    class BankRepository
    {
        private SqlConnection _conn;
        public BankRepository()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ToString();
            _conn = new SqlConnection(connectionString);
            _conn.Open();

        }
        public String GenerateHash(String password)
        {
            MD5 md5pass = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5pass.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            String hashPass = sb.ToString();
            return hashPass;
        }
        
        public bool UserAuthentication(String username, String password)
        {
            string hashPass = this.GenerateHash(password);
            SqlCommand loginCmd = new SqlCommand("select * from Bank_Master where Username=@username and Password = @password", _conn);
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@username", username);
            Param[1] = new SqlParameter("@password", hashPass);
            loginCmd.Parameters.Add(Param[0]);
            loginCmd.Parameters.Add(Param[1]);

            SqlDataReader reader = loginCmd.ExecuteReader();
            while (reader.Read())
            {
                return true;

            }
            return false;

        }
        public bool UserRegistration(String username,Double initialBalance,String password)
        {
            string hashPass = this.GenerateHash(password);

            //insert into Bank_Master
            SqlCommand masterComm = new SqlCommand("insert into Bank_Master Values(@username,@balance,@password)", _conn);
            SqlParameter[] mParam = new SqlParameter[3];
            mParam[0] = new SqlParameter("@username", username);
            mParam[1] = new SqlParameter("@balance", initialBalance);
            mParam[2] = new SqlParameter("@password", hashPass);

            masterComm.Parameters.Add(mParam[0]);
            masterComm.Parameters.Add(mParam[1]);
            masterComm.Parameters.Add(mParam[2]);

            //insert into Bank_Transaction
            SqlCommand transactionComm = new SqlCommand("insert into Bank_Transaction Values(@username,@amount,@type,@datetime)", _conn);
            SqlParameter[] tParam = new SqlParameter[4];
            tParam[0] = new SqlParameter("@username", username);
            tParam[1] = new SqlParameter("@amount", initialBalance);
            tParam[2] = new SqlParameter("@type", Activity.D.ToString());
            tParam[3] = new SqlParameter("@datetime", DateTime.Now.ToString());
            transactionComm.Parameters.Add(tParam[0]);
            transactionComm.Parameters.Add(tParam[1]);
            transactionComm.Parameters.Add(tParam[2]);
            transactionComm.Parameters.Add(tParam[3]);

            SqlTransaction transaction = _conn.BeginTransaction();
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

        }
        public List<Transaction> GetTransaction(String username)
        {
            List<Transaction> transactionlist = new List<Transaction>();
            SqlCommand logCmd = new SqlCommand("select * from Bank_Transaction where Username=@username", _conn);
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@username", username);
            logCmd.Parameters.Add(Param[0]);

            SqlDataReader reader = logCmd.ExecuteReader();
            while (reader.Read())
            {
                String activity = reader["Type"].ToString() == Activity.D.ToString() ? "Deposit" : "Withdraw";
                String[] log =  {reader["Amount"].ToString(),
                activity,
                reader["Datetime"].ToString() };

                transactionlist.Add(new Transaction { Amount=double.Parse(reader["Amount"].ToString()), Type = activity, Datetime = reader["Datetime"].ToString(),Username = username });

            }
            return transactionlist;
        }
        public double GetBalance(String username,String password)
        {
            double balance = 0;
            string hashPass = this.GenerateHash(password);
            SqlCommand balanceCmd = new SqlCommand("select Balance from Bank_Master where Username=@username and Password = @password", _conn);
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@username", username);
            Param[1] = new SqlParameter("@password", hashPass);
            balanceCmd.Parameters.Add(Param[0]);
            balanceCmd.Parameters.Add(Param[1]);

            SqlDataReader reader = balanceCmd.ExecuteReader();
            while (reader.Read())
            {
                balance = Double.Parse(reader["Balance"].ToString());
                
            }
            return balance;
        }
        public bool ValidateWithdraw(double amount,double balance)
        {
            if (balance - amount < 500)
            {
                return false;
            }
            return true;
        }
        public bool BankDbInsertUpdate(Double amount, String activity, String username, String password)
        {
            string hashPass = this.GenerateHash(password);
            //insert into Bank_Transaction
            SqlCommand transactionComm = new SqlCommand("insert into Bank_Transaction Values(@username,@amount,@type,@datetime)", _conn);
            SqlParameter[] tParam = new SqlParameter[4];
            tParam[0] = new SqlParameter("@username", username);
            tParam[1] = new SqlParameter("@amount", amount);
            tParam[2] = new SqlParameter("@type", activity == "Deposit" ? Activity.D.ToString() : Activity.W.ToString());
            tParam[3] = new SqlParameter("@datetime", DateTime.Now.ToString());
            transactionComm.Parameters.Add(tParam[0]);
            transactionComm.Parameters.Add(tParam[1]);
            transactionComm.Parameters.Add(tParam[2]);
            transactionComm.Parameters.Add(tParam[3]);

            //update Bank_Master
            double accBalance = this.GetBalance(username, password);
            SqlCommand updateComm = new SqlCommand("Update Bank_Master Set Balance=@updatedBalance where Username = @username and Password = @password", _conn);
            SqlParameter[] uParam = new SqlParameter[3];
            uParam[0] = new SqlParameter("@updatedBalance", activity == "Deposit" ? accBalance + amount : accBalance - amount);
            uParam[1] = new SqlParameter("@username", username);
            uParam[2] = new SqlParameter("@password", hashPass);
            updateComm.Parameters.Add(uParam[0]);
            updateComm.Parameters.Add(uParam[1]);
            updateComm.Parameters.Add(uParam[2]);


            //begin transaction
            SqlTransaction transaction = _conn.BeginTransaction();
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
