using System;
using Microsoft.AspNetCore.Mvc;
using BudgetWebApp19010155.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BudgetWebApp19010155.Controllers
{
    public class LoginInfoController : Controller
    {
        private readonly IConfiguration _configuration;
        public static LoginInfo info = new LoginInfo();
        public static string passHash;
        public string loggedIn;

        public LoginInfoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "LoginInfo");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            if (ModelState.IsValid)
            {
                LoginAccount(username, password);

                if (loggedIn != null)
                {
                    return RedirectToAction("Options", "BasicInfo");
                }
                else if (loggedIn == null)
                {
                    ViewBag.LoginError = "Incorrect details entered - Try again";
                    return View();
                }
            }
            else
            {
                return View();
            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            if (ModelState.IsValid)
            {
                AddAccount(username, password);

                if (username != null || password != null)
                {
                    return RedirectToAction("Login", "LoginInfo");
                }
                else
                {
                    ViewBag.LoginError = "Please fill in all details";
                    return View();
                }
                
            }
            return View();
        }


        public string LoginAccount(string username, string password)
        {
            string conn = _configuration.GetConnectionString("BudgetServer");

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();

                    info.GetHash(password);

                    passHash = info.GetHashString(password);

                    string query = $"select * from LOGIN_INFO where username='{username}' and password='{passHash}';";

                    ObtainID(username);

                    SqlCommand comm = new SqlCommand(query, con);   //this is used to communicate with the database so that tasks, or queries can be performed
                    SqlDataReader reader = comm.ExecuteReader();    //reads the data of the table stated in the query

                    while (reader.Read())
                    {
                        loggedIn = reader["U_ID"].ToString();
                    }

                    reader.Close(); //closes SqlDataReader
                    comm.Dispose(); //disposes SqlCommand
                    
                }
                return loggedIn;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                ViewBag.LoginError = "Incorrect details entered - Try again";
                View();

                return loggedIn;
            }
        }


        public void AddAccount(string username, string password)
        {
            string conn = _configuration.GetConnectionString("BudgetServer");

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();

                    info.GetHash(password);

                    passHash = info.GetHashString(password);

                    string query = $"insert into LOGIN_INFO values('{username}', '{passHash}');";

                    ObtainID(username);

                    SqlCommand comm = new SqlCommand(query, con);   //this is used to communicate with the database so that tasks, or queries can be performed
                    SqlDataAdapter adapt = new SqlDataAdapter();    //this is used for when user is updating the database
                    comm.ExecuteNonQuery();                         //SqlCommand with the ExecuteNonQuery() method
                    adapt.InsertCommand = comm;                     //using the SqlDataAdapter with the InsertCommand and having the SqlCommand assigned to it

                    adapt.Dispose();    //disposes SqlAdapter
                    comm.Dispose();     //disposes SqlCommand
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                ViewBag.LoginError = "Registration fail - Try again";
                View();
            }

        }

        public void ObtainID(string username)
        {
            string conn = _configuration.GetConnectionString("BudgetServer");

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                string query = $"select U_ID from LOGIN_INFO where username='{username}'";
                SqlCommand comm = new SqlCommand(query, con);   //this is used to communicate with the database so that tasks, or queries can be performed
                SqlDataReader reader = comm.ExecuteReader();    //reads the data of the table stated in the query

                //-----------------------------code attribution---------------------------------
                //Author:   Adil Mammadov
                //Link:     https://stackoverflow.com/questions/16565035/how-do-i-get-values-from-a-sql-database-into-textboxes-using-c
                while (reader.Read())
                {
                    info.UId = Convert.ToInt32(reader["U_ID"].ToString());
                }
                //-----------------------------------end-----------------------------------------


                reader.Close(); //closes SqlDataReader
                comm.Dispose(); //disposes SqlCommand
            }
            
        }
    }
}
