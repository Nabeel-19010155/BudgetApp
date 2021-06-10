using System;
using System.Data.SqlClient;
using System.Threading;
using BudgetCalculationsLibrary;
using BudgetWebApp19010155.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BudgetWebApp19010155.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IConfiguration _configuration;

        BudgetCalc budget = new BudgetCalc();
        public static PropertyInfoBuy infoBuy = new PropertyInfoBuy();
        public static PropertyInfoRent infoRent = new PropertyInfoRent();
        

        public PropertyController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "LoginInfo");
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(double rent, double purPrice, double deposit, double intRate, int months)
        {
            if (rent != 0 || purPrice != 0 || deposit != 0 || intRate != 0 || months != 0)
            {
                StorePropExpenses(rent, purPrice, deposit, intRate, months);

                Thread.Sleep(2 * 1000);

                return RedirectToAction("Index", "VehicleInfo");
            }
            else
            {
                ViewBag.PropertyError = "Failure to capture values - Try again";
                return View();
            }
        }

        public void StorePropExpenses(double rent, double purPrice, double deposit, double intRate, int months)
        {
            int id = LoginInfoController.info.UId;

            if (rent == 0)
            {
                Buy(id, purPrice, deposit, intRate, months);
            }
            else if (purPrice == 0 || deposit == 0 || intRate == 0 || months == 0)
            {
                Rent(id, rent);
            }
        }

        public void DeleteFromDBRent()
        {
            string conn = _configuration.GetConnectionString("BudgetServer");

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open(); //opens the database connection

                string query = $"delete from PROPERTY_INFO_RENT;";

                SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed
                SqlDataAdapter adapt = new SqlDataAdapter();  //this is used for when user is updating the database
                comm.ExecuteNonQuery();                       //SqlCommand with the ExecuteNonQuery() method
                adapt.InsertCommand = comm;                   //using the SqlDataAdapter with the InsertCommand and having the SqlCommand assigned to it


                adapt.Dispose();    //disposes SqlAdapter
                comm.Dispose();     //disposes SqlCommand
                con.Close();        //closes SqlConnection
            }

        }

        public void DeleteFromDBBuy()
        {
            string conn = _configuration.GetConnectionString("BudgetServer");

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open(); //opens the database connection

                string query = $"delete from PROPERTY_INFO_BUY;";

                SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed
                SqlDataAdapter adapt = new SqlDataAdapter();  //this is used for when user is updating the database
                comm.ExecuteNonQuery();                       //SqlCommand with the ExecuteNonQuery() method
                adapt.InsertCommand = comm;                   //using the SqlDataAdapter with the InsertCommand and having the SqlCommand assigned to it


                adapt.Dispose();    //disposes SqlAdapter
                comm.Dispose();     //disposes SqlCommand
                con.Close();        //closes SqlConnection
            }

        }

        public void Rent(int id, double rent)
        {
            string conn = _configuration.GetConnectionString("BudgetServer");
            infoRent.RentAmt = Convert.ToDecimal(rent);

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();

                    string query;

                    if (Property.counter == 0)
                    {
                        DeleteFromDBRent();
                        //a string with the necessary SQL query to insert the data into the database
                        query = $"insert into PROPERTY_INFO_RENT values ({id}, {rent});";
                    }
                    else
                    {
                        query = $"update PROPERTY_INFO_RENT " +
                            $"set rent_amt = {rent}" +
                            $"where U_ID = {id};";
                    }

                    SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed
                    SqlDataAdapter adapt = new SqlDataAdapter();  //this is used for when user is updating the database
                    comm.ExecuteNonQuery();                       //SqlCommand with the ExecuteNonQuery() method
                    adapt.InsertCommand = comm;                   //using the SqlDataAdapter with the InsertCommand and having the SqlCommand assigned to it

                    Property.counter++;
                    Property.rentOrBuy = 1;

                    adapt.Dispose();    //disposes SqlAdapter
                    comm.Dispose();     //disposes SqlCommand
                    con.Close();        //closes SqlConnection
                }
            }
            catch (SqlException ex)
            {
                DeleteFromDBRent();
                ViewBag.PropertyError = "Failure to capture values - Try again";
                View();
            }
        }

        public void Buy(int id, double purPrice, double deposit, double intRate, int months)
        {
            string conn = _configuration.GetConnectionString("BudgetServer");

            infoBuy.TotRepayment = Convert.ToDecimal(budget.CalcHomeLoanRepaymentWhenBuying(purPrice, deposit, intRate, months));

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();

                    string query;

                    if (Property.counter == 0)
                    {
                        DeleteFromDBBuy();
                        //a string with the necessary SQL query to insert the data into the database
                        query = $"insert into PROPERTY_INFO_BUY values ({id}, {purPrice}, {deposit}, {intRate}, {months}, {infoBuy.TotRepayment});";
                    }
                    else
                    {
                        query = $"update PROPERTY_INFO_BUY " +
                        $"set pur_price = {purPrice}, tot_deposit = {deposit}, int_rate = {intRate}, no_of_months = {months}, tot_repayment = {infoBuy.TotRepayment}" +
                        $"where U_ID = {id};";
                    }

                    SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed
                    SqlDataAdapter adapt = new SqlDataAdapter();  //this is used for when user is updating the database
                    comm.ExecuteNonQuery();                       //SqlCommand with the ExecuteNonQuery() method
                    adapt.InsertCommand = comm;                   //using the SqlDataAdapter with the InsertCommand and having the SqlCommand assigned to it

                    Property.counter++;
                    Property.rentOrBuy = 2;

                    adapt.Dispose();    //disposes SqlAdapter
                    comm.Dispose();     //disposes SqlCommand
                    con.Close();        //closes SqlConnection
                }
            }
            catch (SqlException ex)
            {
                DeleteFromDBBuy();
                ViewBag.PropertyError = "Failure to capture values - Try again";
                View();
            }
        }
    }
}
