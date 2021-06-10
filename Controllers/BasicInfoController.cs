using System;
using Microsoft.AspNetCore.Mvc;
using BudgetWebApp19010155.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using BudgetCalculationsLibrary;
using System.Threading;

namespace BudgetWebApp19010155.Controllers
{
    public class BasicInfoController : Controller
    {
        private readonly IConfiguration _configuration;

        BudgetCalc budget = new BudgetCalc();
        public static BasicInfo basic = new BasicInfo();

        public BasicInfoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Options()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(double grossIncome, double monthlyTax, double groceries, double waterLights, double travelCosts, double phoneCosts, double otherCosts)
        {

            if (grossIncome != 0 || monthlyTax != 0 || groceries != 0 || waterLights != 0 || travelCosts != 0 || phoneCosts != 0 || otherCosts != 0)
            {
                StoreExpenses(grossIncome, monthlyTax, groceries, waterLights, travelCosts, phoneCosts, otherCosts);

                Thread.Sleep(2 * 1000);
                
                return RedirectToAction("Index", "Property");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "LoginInfo");
        }

        public void DeleteFromDB()
        {
            string conn = _configuration.GetConnectionString("BudgetServer");

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open(); //opens the database connection

                string query = $"delete from BASIC_INFO;";

                SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed
                SqlDataAdapter adapt = new SqlDataAdapter();  //this is used for when user is updating the database
                comm.ExecuteNonQuery();                       //SqlCommand with the ExecuteNonQuery() method
                adapt.InsertCommand = comm;                   //using the SqlDataAdapter with the InsertCommand and having the SqlCommand assigned to it


                adapt.Dispose();    //disposes SqlAdapter
                comm.Dispose();     //disposes SqlCommand
                con.Close();        //closes SqlConnection
            }

        }

        public void StoreExpenses(double gross, double tax, double groceries, double waterLights, double travel, double phone, double other)
        {
            string conn = _configuration.GetConnectionString("BudgetServer");
            
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();

                    int id = LoginInfoController.info.UId;
                    basic.NetIncome = Convert.ToDecimal(budget.CalcNetIncome(gross, tax, groceries, waterLights, travel, phone, other));
                    basic.GrossInc = Convert.ToDecimal(gross);

                    string query;

                    if (BasicInfo.counter == 0)
                    {
                        DeleteFromDB();
                        //a string with the necessary SQL query to insert the data into the database
                        query = $"insert into BASIC_INFO values ({id}, {gross}, {tax}, {groceries}, {waterLights}, {travel}, {phone}, {other}, {basic.NetIncome});";
                    }
                    else
                    {
                        query = $"update BASIC_INFO " +
                            $"set gross_inc = {gross}, monthly_exp = {tax}, groceries = {groceries}, water_lights = {waterLights}, travel_costs = {travel}, phone_costs = {phone}, other_exp = {other}, net_income = {basic.NetIncome}" +
                            $"where U_ID = {id};";
                    }

                    SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed
                    SqlDataAdapter adapt = new SqlDataAdapter();  //this is used for when user is updating the database
                    comm.ExecuteNonQuery();                       //SqlCommand with the ExecuteNonQuery() method
                    adapt.InsertCommand = comm;                   //using the SqlDataAdapter with the InsertCommand and having the SqlCommand assigned to it

                    BasicInfo.counter++;

                    adapt.Dispose();    //disposes SqlAdapter
                    comm.Dispose();     //disposes SqlCommand
                    con.Close();        //closes SqlConnection
                }
            }
            catch (SqlException ex)
            {
                DeleteFromDB();
                ViewBag.InputError = "Failure to capture values - Try again";
                View();
            }
        }

        
    }
}
