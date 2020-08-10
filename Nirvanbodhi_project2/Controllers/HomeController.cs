using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Nirvanbodhi_project2.Models;

namespace Nirvanbodhi_project2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        SqlConnection con;
        SqlCommand com;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login_Form lf)
        {

            con = new SqlConnection("Data Source=.;Initial Catalog=CRM;Integrated Security=True");
            //com = new SqlCommand("select Username, Password from LoginForm where Username=@Username and Password=@Password");
            com = new SqlCommand("EXEC Usr_login @uname='" + lf.Username + "',@pass='" + lf.Password + "'    ");
            com.Connection = con;
            con.Open();
            //com.Parameters.AddWithValue("Username", lf.Username);
            // com.Parameters.AddWithValue("Password", lf.Password);
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                ViewData["data"] = "<script>alert('Login Successful..')</script>";
                ModelState.Clear();
                Session["username"] = lf.Username.ToString();
                return RedirectToAction("welcome");

            }

            else
            {
                ViewBag.insertmessages = "<script>alert('Login faild..')</script>";
                ViewData["message"] = "user loggin Details failed";
            }
            con.Close();

            return View();

        }
        public ActionResult welcome()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(Login_Form lf)
        {
            if (ModelState.IsValid == true)
            {
                con = new SqlConnection("Data Source=.;Initial Catalog=CRM;Integrated Security=True");
                com = new SqlCommand("EXEC Register @uname='" + lf.Username + "',@pass='" + lf.Password + "',@id=" + lf.Id + ",@name='" + lf.Name + "',@gen='" + lf.Gender + "' ");
                con.Open();
                com.Connection = con;
                com.Parameters.AddWithValue("@Username", lf.Username);
                com.Parameters.AddWithValue("@Password", lf.Password);
                com.Parameters.AddWithValue("@Id", lf.Id);
                com.Parameters.AddWithValue("@Name", lf.Name);
                com.Parameters.AddWithValue("@Gender", lf.Gender);
                com.ExecuteNonQuery();
                con.Close();
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }

    }
}
