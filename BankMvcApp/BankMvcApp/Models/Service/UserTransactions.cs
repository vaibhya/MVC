using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BankMvcApp.Models.ViewModel;

namespace BankMvcApp.Models.Service
{
    public class UserTransactions
    {
        private String _username;
        public UserTransactions(PassbookVm passbook)
        {
            _username = passbook.Username;
        }
        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactionlist = new List<Transaction>();
            LinkedList<Array> logs = new LinkedList<Array>();
            String connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand logCmd = new SqlCommand("select * from Bank_Transaction where Username=@username", conn);
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@username", _username);
            logCmd.Parameters.Add(Param[0]);

            SqlDataReader reader = logCmd.ExecuteReader();
            while (reader.Read())
            {
                String activity = reader["Type"].ToString() == Activity.D.ToString() ? "Deposit" : "Withdraw";
                String[] log =  {reader["Amount"].ToString(),
                activity,
                reader["Datetime"].ToString() };
                logs.AddLast(log);

                transactionlist.Add(new Transaction(reader["Amount"].ToString(), activity, reader["Datetime"].ToString()));

            }

            conn.Close();

            //return logs;
            return transactionlist;
        }
    }
}