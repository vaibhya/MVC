using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankMvcApp.Models.ViewModel;
using BankMvcApp.Models.Service;
using System.IO;

namespace BankMvcApp.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult DoTransaction()
        {
            //String username = Session["username"].ToString();
            //String password = Session["password"].ToString();
            //BalanceAccessService accBalance = new BalanceAccessService(username, password);
            //Session["balance"] = accBalance.GetBalance();
            return View(new DoTransactionVm());
        }
        [HttpPost]
        public ActionResult DoTransaction(DoTransactionVm tVm)
        {
            Boolean withdrawValidation=false;

            if (!this.ModelState.IsValid)
            {
                return View(tVm);
            }
            String username = Session["username"].ToString();
            String password = Session["password"].ToString();
            BalanceAccessService accBalance = new BalanceAccessService(username, password);
            if (tVm.Activity == "Withdraw")
            {
                
                WithdrawValidation validate = new WithdrawValidation(tVm.Amount, accBalance.GetBalance());
                withdrawValidation = validate.ValidateAmoumt();
            }
            if (!withdrawValidation & tVm.Activity == "Withdraw")
            {
                tVm.Message = "Minimum balance amount reached transaction not permitted!";
                return View(tVm);
            }
            BankDbInsertUpdate activity = new BankDbInsertUpdate(tVm.Amount, tVm.Activity, username, password);
            if (activity.InsertIntoDb())
            {
                tVm.Message = tVm.Activity + " is successful!";
                return View(tVm);
            }
            tVm.Message = tVm.Activity + " was not successful!";
            BalanceAccessService updatedBalance = new BalanceAccessService(username, password);
            Session["balance"] = updatedBalance.GetBalance();
            return View(tVm);
        }
        public ActionResult Passbook()
        {
            
            
            String username = Session["Username"].ToString();
            PassbookVm passBook = new PassbookVm();
            passBook.Username = username;
            UserTransactions transactions = new UserTransactions(passBook);
            ViewBag.logs = transactions.GetTransactions();
            Session["logs"] = transactions.GetTransactions();


            //CsvCreateService csv = new CsvCreateService(transactions.GetTransactions());
            return View(passBook);
        }

        public void ExportToCsv()
        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"Amount\",\"Type\",\"Datetime\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Exported_Users.csv");
            Response.ContentType = "text/csv";

            foreach (var line in Session["logs"] as List<Transaction>)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\"",
                                           line.Amount,
                                           line.Type,
                                           line.Datetime));
            }

            Response.Write(sw.ToString());

            Response.End();
        }
        
    }
}