using System.Collections.Generic;
using BudgetCalculationsLibrary;
using BudgetWebApp19010155.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetWebApp19010155.Controllers
{
    public class SavingsController : Controller
    {
        BudgetCalc budget = new BudgetCalc();
        public static Savings save = new Savings();

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
        public IActionResult Index(double goalAmt, double intRate, int years, string reason)
        {
            
            if (goalAmt != 0 && intRate != 0 && years != 0 && reason != null)
            {
                StoreSavings(goalAmt, intRate, years, reason);
                return RedirectToAction("Details", "Savings");
            }
            else
            {
                ViewBag.SavingsError = "Failure to capture values - Try again";
                return View();
            }
        }


        public IActionResult Details()
        {
            DisplayMonthlyAmount();
            return View();
        }

        public void DisplayMonthlyAmount()
        {
            //_____________________________code attribution_______________________________
            //Author:   Abhimanyu K. Vatsa
            //Link:     https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/
            var savings = new List<string>
                        {
                            $"Goal Amount:                     R{save.GoalAmt} \n",
                            $"Interest Rate (%):                {save.IntRate} \n",
                            $"Years:                            {save.NoOfYears} \n",
                            $"Reason for Savings:               {save.Reason} \n",
                            $"Amount to Save Monthly:          R{save.MonthlyAmt} \n"
                        };

            ViewBag.Save = savings;
            //___________________________________end______________________________________

        }

        public void StoreSavings(double goalAmt, double intRate, int years, string reason)
        {
            double monthlyAmt = budget.CalcMonthlySavingsAmount(goalAmt, intRate, years);

            save = new Savings(goalAmt, monthlyAmt, intRate, years, reason);

        }
    }
}
