using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_MVCapp_SERAFIN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["isLogged"] = "false";
            return View();
        }

        //public ActionResult Index(int a)
        //{
        //    Session["isLogged"] = "true";
        //    return View();
        //}

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            //Session["userName"] = collection["userName"].ToString();
            //Session["passWord"] = collection["passWord"].ToString();
            string userNameLOGIN = collection["userName"].ToString();
            string passWordLOGIN = collection["passWord"].ToString();

            SqlConnection connecLOGIN = new SqlConnection();
            connecLOGIN.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;

            try
            {
                Session["isLogged"] = "false";
                connecLOGIN.Open();
                string queryLogin = "SELECT passWord FROM Nutella.logins WHERE userName ='" + userNameLOGIN + "';";

                SqlCommand commLOGIN = new SqlCommand(queryLogin, connecLOGIN);
                SqlDataReader ResultOfTheSelect = commLOGIN.ExecuteReader();

                while (ResultOfTheSelect.Read())
                {
                    if (ResultOfTheSelect["passWord"].ToString() == passWordLOGIN)
                    {
                        Session["isLogged"] = "true";
                        RedirectToAction("Index");
                    }
                    else
                    {
                        Session["isLogged"] = "false";
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                connecLOGIN.Close();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}