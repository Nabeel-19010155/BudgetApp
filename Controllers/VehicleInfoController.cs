using System;
using System.Threading;
using BudgetCalculationsLibrary;
using BudgetWebApp19010155.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BudgetWebApp19010155.Controllers
{
    public class VehicleInfoController : Controller
    {
        private readonly IConfiguration _configuration;

        BudgetCalc budget = new BudgetCalc();
        public static VehicleInfo vehInfo = new VehicleInfo();

        public VehicleInfoController(IConfiguration configuration)
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
        public IActionResult Index(string model, double purPrice, double deposit, double intRate, double premium)
        {
            if (model != null || purPrice != 0 || deposit != 0 || intRate != 0 || premium != 0)
            {
                StoreVehicleExpenses(model, purPrice, deposit, intRate, premium);

                Thread.Sleep(2 * 1000);

                return RedirectToAction("Display", "DisplayDetails");
            }
            else
            {
                ViewBag.VehicleError = "Failure to capture values - Try again";
                return View();
            }

            
        }

        public void DeleteFromDB()
        {
            string conn = _configuration.GetConnectionString("BudgetServer");

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open(); //opens the database connection

                string query = $"delete from VEHICLE_INFO;";

                SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed
                SqlDataAdapter adapt = new SqlDataAdapter();  //this is used for when user is updating the database
                comm.ExecuteNonQuery();                       //SqlCommand with the ExecuteNonQuery() method
                adapt.InsertCommand = comm;                   //using the SqlDataAdapter with the InsertCommand and having the SqlCommand assigned to it


                adapt.Dispose();    //disposes SqlAdapter
                comm.Dispose();     //disposes SqlCommand
                con.Close();        //closes SqlConnection
            }

        }

        public void StoreVehicleExpenses(string model, double purPrice, double deposit, double intRate, double premium)
        {
            int id = LoginInfoController.info.UId;
            vehInfo.TotRepayment = budget.CalcVehicleRepayment(purPrice, deposit, intRate, premium);
            StoreInClass(model, purPrice, deposit, intRate, premium, vehInfo.TotRepayment);


            string conn = _configuration.GetConnectionString("BudgetServer");

            try 
            {

                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open(); //opens the database connection

                    string query;

                    if (VehicleInfo.counter == 0)
                    {
                        DeleteFromDB();
                        //a string with the necessary SQL query to insert the data into the database
                        query = $"insert into VEHICLE_INFO values ({id}, '{model}', {purPrice}, {deposit}, {intRate}, {premium}, {vehInfo.TotRepayment});";
                    }
                    else
                    {
                        query = $"update VEHICLE_INFO " +
                            $"set model_make = '{model}', pur_price = {purPrice}, tot_deposit = {deposit}, int_rate = {intRate}, insurance_prem = {premium}, tot_repayment = {vehInfo.TotRepayment}" +
                            $"where U_ID = {id};";
                    }

                    SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed
                    SqlDataAdapter adapt = new SqlDataAdapter();  //this is used for when user is updating the database
                    comm.ExecuteNonQuery();                       //SqlCommand with the ExecuteNonQuery() method
                    adapt.InsertCommand = comm;                   //using the SqlDataAdapter with the InsertCommand and having the SqlCommand assigned to it

                    VehicleInfo.counter++;


                    adapt.Dispose();    //disposes SqlAdapter
                    comm.Dispose();     //disposes SqlCommand
                    con.Close();        //closes SqlConnection
                }

            } 
            catch (SqlException ex) 
            {
                Console.WriteLine(ex.ToString());
                DeleteFromDB();
                ViewBag.VehicleError = "Failure to capture values - Try again";
                View();
            } 
        
        
        }

        public void StoreInClass(string model, double purPrice, double deposit, double intRate, double premium, double payment)
        {
            vehInfo = new VehicleInfo(model, purPrice, deposit, intRate, premium, payment);
        }
    }
}
