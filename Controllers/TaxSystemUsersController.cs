using FinalProject_MVCapp_SERAFIN.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_MVCapp_SERAFIN.Controllers
{
    public class TaxSystemUsersController : Controller
    {
        private List<TaxSystemUsersMODEL> userLogin;
        string myConnectionStringSRFN = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
        public TaxSystemUsersController()
        {
        }
        // GET: TaxSystemUsers


        //[Route("")]
        public ActionResult Manage()
        {
            List<TaxSystemUsersMODEL> allUsersListed = new List<TaxSystemUsersMODEL>();
            allUsersListed = ReadAllUsersFromDB();
            return View("Manage", allUsersListed);
        }

        // GET: TaxSystemUsers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaxSystemUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaxSystemUsers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            TaxSystemUsersMODEL CreateNewUser = new TaxSystemUsersMODEL();
            SqlConnection myconnCREATE = new SqlConnection();

            try
            {  // TODO: Add insert logic here
                myconnCREATE.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
                myconnCREATE.Open();

                CreateNewUser.userName = collection["userName"];
                CreateNewUser.passWord = collection["passWord"];
                CreateNewUser.description = collection["description"];
                CreateNewUser.isAdmin = collection["isAdmin"];

                //INSERT INTO Contact(ID, FirstName, LastName) VALUES(1, 'serafin', 'g');
                string queryCREATE = "INSERT INTO Nutella.logins (userName,passWord,description,isAdmin) VALUES ('" +
                    CreateNewUser.userName + "','" +
                    CreateNewUser.passWord + "','" +
                    CreateNewUser.description + "','" +
                    CreateNewUser.isAdmin + "');";

                SqlCommand commCREATE = new SqlCommand(queryCREATE, myconnCREATE);
                int numRowsAffected = commCREATE.ExecuteNonQuery();
                myconnCREATE.Close();

                return RedirectToAction("Manage");
            }
            catch
            {
                return View();
            }
        }

        //  THIS ReadAllUsersFromDB METHOD SELECTS ALL THE FIELDS FROM logins DATABASE and 
        //  STORES THEM INTO A LIST OF USERS MODELS
        static List<TaxSystemUsersMODEL> ReadAllUsersFromDB()
        {
            List<TaxSystemUsersMODEL> myUsers = new List<TaxSystemUsersMODEL>();
            SqlConnection myConnSRFN = new SqlConnection();
            try
            {
                myConnSRFN.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
                myConnSRFN.Open();

                string queryString = "SELECT loginId,userName,passWord,description,isAdmin FROM Nutella.logins;";
                SqlCommand commandSRFN = new SqlCommand(queryString, myConnSRFN);

                SqlDataReader myUsersResults = commandSRFN.ExecuteReader();
                while (myUsersResults.Read())
                {
                    TaxSystemUsersMODEL newUser = new TaxSystemUsersMODEL();
                    newUser.loginId = int.Parse(myUsersResults["loginId"].ToString());
                    newUser.userName = myUsersResults["userName"].ToString();
                    newUser.passWord = myUsersResults["passWord"].ToString();
                    newUser.description = myUsersResults["description"].ToString();
                    newUser.isAdmin = myUsersResults["isAdmin"].ToString();
                    myUsers.Add(newUser);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                myConnSRFN.Close();
            }
            return myUsers;
        }

        // GET: TaxSystemUsers/Edit/5
        public ActionResult Edit(int id)
        {
            //I configure the connection to the DB
            SqlConnection connEDITget = new SqlConnection();
            connEDITget.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;
            TaxSystemUsersMODEL UserToEdit = new TaxSystemUsersMODEL();

            try
            {
                string queryEDITget = "SELECT userName,passWord,description,isAdmin FROM Nutella.logins WHERE loginId=" + id + ";";
                SqlCommand commandEDITget = new SqlCommand(queryEDITget, connEDITget);

                connEDITget.Open();
                SqlDataReader UserWeWannaEdit = commandEDITget.ExecuteReader();

                //now I assign the result of the select to the Database to each element of the object
                //UserToEdit, recently created above
                while (UserWeWannaEdit.Read())
                {
                    UserToEdit.userName = UserWeWannaEdit["userName"].ToString();
                    UserToEdit.passWord = UserWeWannaEdit["passWord"].ToString();
                    UserToEdit.description = UserWeWannaEdit["description"].ToString();
                    UserToEdit.isAdmin = UserWeWannaEdit["isAdmin"].ToString();
                }

            }
            catch
            {
                return null;
            }
            finally
            {
                connEDITget.Close();
            }

            return View(UserToEdit);
        }

        // POST: TaxSystemUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SqlConnection connEDITpost = new SqlConnection();
            connEDITpost.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;

            TaxSystemUsersMODEL ModifiedUserToUpload = new TaxSystemUsersMODEL();

            try
            {
                connEDITpost.Open();
                string queryEDITpost = "UPDATE Nutella.logins SET " +
                "userName = '" + collection["userName"] + "', " +
                "passWord = '" + collection["passWord"] + "', " +
                "description = '" + collection["description"] + "', " +
                "isAdmin = '" + collection["isAdmin"] + "' " +
                "WHERE loginId = " + id + ";";

                SqlCommand commandEDITpost = new SqlCommand(queryEDITpost, connEDITpost);
                commandEDITpost.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connEDITpost.Close();
            }
            return RedirectToAction("Manage");
        }

        // GET: TaxSystemUsers/Delete/5
        public ActionResult Delete(int id)
        {
            //Here I open the connection to the DB and I execute the delete query
            SqlConnection connDELETEPost = new SqlConnection();
            connDELETEPost.ConnectionString = ConfigurationManager.ConnectionStrings["SRFNconnection"].ConnectionString;

            try
            {
                connDELETEPost.Open();
                SqlCommand commDELETEpost = new SqlCommand("DELETE FROM Nutella.logins WHERE loginId = " + id + ";", connDELETEPost);
                int a = commDELETEpost.ExecuteNonQuery();
            }
            catch
            {
                return null;
            }
            finally
            {
                connDELETEPost.Close();
            }

            //After actually deleting that user's row, 
            //I call the Manage method again to show the updated list of Users or logins

            //return View("Manage", aa);
            return RedirectToAction("Manage");
        }

    }
}
