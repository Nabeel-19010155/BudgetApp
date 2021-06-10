using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BudgetCalculationsLibrary;
using BudgetWebApp19010155.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BudgetWebApp19010155.Controllers
{
    public class DisplayDetailsController : Controller
    {
        BudgetCalc budget = new BudgetCalc();

        

        private readonly IConfiguration _configuration;

        
        public DisplayDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "LoginInfo");
        }

        public IActionResult Display()
        {
            DisplayBasicExpenses();
            IfRentOrBuy();
            DisplayVehicleExpenses1();
            return View();
        }

        public void DisplayBasicExpenses()
        {
            string conn = _configuration.GetConnectionString("BudgetServer");
            int id = LoginInfoController.info.UId;

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open(); //opens the database connection

                string query = query = $"select * from BASIC_INFO where U_ID = {id};";

                SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed

                using (SqlDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        double grossIncome = Convert.ToDouble(read["gross_inc"]);
                        double monthlyTax = Convert.ToDouble(read["monthly_exp"]);
                        double groceries = Convert.ToDouble(read["groceries"]);
                        double waterLights = Convert.ToDouble(read["water_lights"]);
                        double travelCosts = Convert.ToDouble(read["travel_costs"]);
                        double phoneCosts = Convert.ToDouble(read["phone_costs"]);
                        double otherCosts = Convert.ToDouble(read["other_exp"]);
                        double netIncome = Convert.ToDouble(read["net_income"]);

                        //_____________________________code attribution_______________________________
                        //Author:   Abhimanyu K. Vatsa
                        //Link:     https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/
                        var uExp = new List<string>
                        {
                            $"Gross Income:                    R{grossIncome} \n",
                            $"Monthly Tax:                     R{monthlyTax} \n",
                            $"Groceries:                       R{groceries} \n",
                            $"Water and Lights:                R{waterLights} \n",
                            $"Travel Costs (incl. petrol):     R{travelCosts} \n",
                            $"Cellphone and Telephone Costs:   R{phoneCosts} \n",
                            $"Other Expenses:                  R{otherCosts} \n",
                            $"Net Income:                      R{netIncome} \n"
                        };

                        ViewBag.UserExp = uExp;
                        //___________________________________end______________________________________

                    }
                }

                comm.Dispose();     //disposes SqlCommand
                con.Close();        //closes SqlConnection

            }
        }


        public void IfRentOrBuy()
        {
            int i = Property.rentOrBuy;

            switch (i)
            {
                case 1:
                    DisplayRent();
                    DisplayTotalIfRent();
                    break;

                case 2:
                    DisplayBuy();
                    DisplayTotalIfBuy();
                    break;
            }
        }

        public void DisplayRent()
        {
            string conn = _configuration.GetConnectionString("BudgetServer");
            int id = LoginInfoController.info.UId;

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open(); //opens the database connection

                string query = $"select * from PROPERTY_INFO_RENT where U_ID = {id};";

                SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed

                using (SqlDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        double rentAmt = Convert.ToDouble(read["rent_amt"]);

                        //_____________________________code attribution_______________________________
                        //Author:   Abhimanyu K. Vatsa
                        //Link:     https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/
                        var pExp = new List<string>
                        {
                            $"Rent Amount:  R{rentAmt} per month"
                        };

                        ViewBag.PropertyExp = pExp;
                        //___________________________________end______________________________________

                    }
                }

                comm.Dispose();     //disposes SqlCommand
                con.Close();        //closes SqlConnection

            }
        }


        public void DisplayBuy()
        {
            string conn = _configuration.GetConnectionString("BudgetServer");
            int id = LoginInfoController.info.UId;

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open(); //opens the database connection

                string query = query = $"select * from PROPERTY_INFO_BUY where U_ID = {id};";

                SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed

                using (SqlDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        double purPrice = Convert.ToDouble(read["pur_price"]);
                        double deposit = Convert.ToDouble(read["tot_deposit"]);
                        double intRate = Convert.ToDouble(read["int_rate"]);
                        int months = Convert.ToInt32(read["no_of_months"]);
                        double loanPayment = Convert.ToDouble(read["tot_repayment"]);

                        //_____________________________code attribution_______________________________
                        //Author:   Abhimanyu K. Vatsa
                        //Link:     https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/
                        var pExp = new List<string>
                        {
                            $"Purchase Price:              R{purPrice} \n",
                            $"Total Deposit:               R{deposit} \n", 
                            $"Interest Rate:                {intRate}% \n",
                            $"No. of Months to repay:       {months} \n",
                            $"Monthly Amount to repay:     R{loanPayment}"

                        };

                        ViewBag.PropertyExp = pExp;
                        //___________________________________end______________________________________

                    }
                }

                comm.Dispose();     //disposes SqlCommand
                con.Close();        //closes SqlConnection

            }
        }


        public void DisplayVehicleExpenses()
        {
            string conn = _configuration.GetConnectionString("BudgetServer");
            int id = LoginInfoController.info.UId;

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open(); //opens the database connection

                string query = $"select * from VEHICLE_INFO where U_ID = {id};";

                SqlCommand comm = new SqlCommand(query, con); //this is used to communicate with the database so that tasks, or queries can be performed

                using (SqlDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        string model = (read["model_make"].ToString());
                        double purPrice = Convert.ToDouble(read["pur_price"]);
                        double deposit = Convert.ToDouble(read["tot_deposit"]);
                        double intRate = Convert.ToDouble(read["int_rate"]);
                        double premium = Convert.ToDouble(read["insurance_prem"]);
                        double loanPayment = Convert.ToDouble(read["tot_repayment"]);


                        //_____________________________code attribution_______________________________
                        //Author:   Abhimanyu K. Vatsa
                        //Link:     https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/
                        var vExp = new List<string>
                        {
                            $"Model and Make:               {model} \n",
                            $"Purchase Price:              R{purPrice} \n",
                            $"Total Deposit:               R{deposit} \n", 
                            $"Interest Rate:                {intRate}% \n",
                            $"Insurance Premium:            {premium} \n", 
                            $"Monthly Amount to repay:     R{loanPayment}"
                        };

                        ViewBag.VehicleExp = vExp;
                        //___________________________________end______________________________________

                    }
                }

                comm.Dispose();     //disposes SqlCommand
                con.Close();        //closes SqlConnection

            }
        }

        public void DisplayVehicleExpenses1()
        {
            //_____________________________code attribution_______________________________
            //Author:   Abhimanyu K. Vatsa
            //Link:     https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/
            var vExp = new List<string>
                        {
                            $"Model and Make:               {VehicleInfoController.vehInfo.ModelMake} \n",
                            $"Purchase Price:              R{VehicleInfoController.vehInfo.PurPrice} \n",
                            $"Total Deposit:               R{VehicleInfoController.vehInfo.TotDeposit} \n",
                            $"Interest Rate:                {VehicleInfoController.vehInfo.IntRate}% \n",
                            $"Insurance Premium:            {VehicleInfoController.vehInfo.InsurancePrem} \n",
                            $"Monthly Amount to repay:     R{VehicleInfoController.vehInfo.TotRepayment}"
                        };

            ViewBag.VehicleExp = vExp;
            //___________________________________end______________________________________
        }

        public void DisplayTotalIfRent()
        {
            double netInc = Convert.ToDouble(BasicInfoController.basic.NetIncome);
            double grossInc = Convert.ToDouble(BasicInfoController.basic.GrossInc) / 3;
            double vehicleRepay = Convert.ToDouble(VehicleInfoController.vehInfo.TotRepayment);

            double rent = Convert.ToDouble(PropertyController.infoRent.RentAmt);

            double total = netInc - rent - vehicleRepay;

            string warning = "ALERT! Insufficient Gross Monthly Income! Loan approval is unlikely.";

            if (rent > grossInc)
            {
                ViewBag.Total = $"{total}";
                ViewBag.Warning = warning;
            }
            else
            {
                ViewBag.Total = $"{total}";
                ViewBag.Warning = " ";
            }

        }

        public void DisplayTotalIfBuy()
        {
            double netInc = Convert.ToDouble(BasicInfoController.basic.NetIncome);
            double grossInc = Convert.ToDouble(BasicInfoController.basic.GrossInc) / 3;
            double vehicleRepay = Convert.ToDouble(VehicleInfoController.vehInfo.TotRepayment);

            double buy = Convert.ToDouble(PropertyController.infoBuy.TotRepayment);

            double total = netInc - buy - vehicleRepay;

            string warning = "ALERT! Insufficient Gross Monthly Income! Loan approval is unlikely.";

            if (buy > grossInc)
            {
                ViewBag.Total = $"{total}";
                ViewBag.Warning = warning;
            }
            else
            {
                ViewBag.Total = $"{total}";
                ViewBag.Warning = " ";
            }
        }
    }
}
