using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AuthenticationController : Controller
    {

        private TestDBEntities _db = new TestDBEntities();
        // GET: Authentication
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(USERDB _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.USERDBs.FirstOrDefault(s => s.EmailID == _user.EmailID);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.USERDBs.Add(_user);
                    _db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        /*
         Login
         */

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin _userLogin)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(_userLogin.Password);
                var data = _db.USERDBs.Where(s => s.EmailID.Equals(_userLogin.EmailID) && s.Password.Equals(f_password)).ToList();

                Debug.WriteLine($"Email: {_userLogin.EmailID}, Password Hash: {f_password}");
                Debug.WriteLine($"Data Count: {data.Count()}");

                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["EmailID"] = data.FirstOrDefault().EmailID;
                    Session["UserID"] = data.FirstOrDefault().UserID;
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public ActionResult UserLoginAccountHandler()
        {
            return View();
        }

        public ActionResult UserLoginAccountHandler(UserLogin _userLogin)
        {
            if(ModelState.IsValid)
            {
                var f_password = GetMD5(_userLogin.Password);
                var data = _db.USERDBs.Where(s => s.EmailID.Equals(_userLogin.EmailID) && s.Password.Equals(f_password)).ToList();
                if(data.Count > 0)
                {

                }

            }
            return View();
        }

    }
}