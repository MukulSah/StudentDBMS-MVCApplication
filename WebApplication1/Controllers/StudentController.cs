using Microsoft.AspNetCore.Mvc;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.Http.Results;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        TestDBEntities _dbContext = new TestDBEntities();

        [System.Web.Http.HttpGet]
        public string CheckStatus()
        {
            return "We got the connection.";
        }

        public ActionResult CreateStudentView()
        {
            return View();
        }

        public ActionResult CreateStudentRecordAPI(StudentModel _studentmodel)
        {

                string connectionString = "data source=192.168.1.98\\SQL2019;initial catalog=TestDB;persist security info=True;user id=trinity;password=trinity;multipleactiveresultsets=True;trustservercertificate=True;application name=EntityFramework";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        if (ModelState != null)
                        {
                            SqlCommand com = new SqlCommand("sp_EmployeeAdd", conn);
                            com.CommandType = CommandType.StoredProcedure;
                            com.Parameters.AddWithValue("@StudentName", _studentmodel.StudentName);
                            com.Parameters.AddWithValue("@Contact", _studentmodel.Contact);
                            com.Parameters.AddWithValue("@EmailID", _studentmodel.EmailID);
                            com.Parameters.AddWithValue("@Languagee", _studentmodel.Language);
                            com.Parameters.AddWithValue("@AddressLine1", _studentmodel.AddressLine1);
                            com.Parameters.AddWithValue("@AddressLine2", _studentmodel.AddressLine2);
                            com.Parameters.AddWithValue("@Statee", _studentmodel.State);
                            com.Parameters.AddWithValue("@Pincode", _studentmodel.Pincode);
                            com.Parameters.AddWithValue("@Country", _studentmodel.Country);

                            conn.Open();
                            com.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "An error occurred while saving data. Please try again later.");
                        return View("CreateStudentView", _studentmodel);
                    }
                    
                }
            
            return RedirectToAction("ViewAllRecords");

        }


        [System.Web.Http.HttpGet]
        public ActionResult ViewAllRecords()
        {
            var query = (from S in _dbContext.StudentDetails
                         join Ad in _dbContext.AddressDetails on S.StudentID equals Ad.StudentID

                         select new StudentModel()
                         {
                             StudentID = S.StudentID,
                             StudentName = S.StudentName,
                             Contact = S.Contact,
                             EmailID = S.EmailID,
                             Language = S.Languagee,
                             AddressLine1 = Ad.AddressLine1,
                             AddressLine2 = Ad.AddressLine2,
                             State = Ad.Statee,
                             Pincode = Ad.Pincode,
                             Country = Ad.Country
                         }).ToList();

            ViewBag.listofstudentdata = query;
            return View();
        }

        [System.Web.Http.HttpGet]
        public ActionResult GetStudentbyID(int id)
        {
            var query = (from S in _dbContext.StudentDetails
                         join Ad in _dbContext.AddressDetails on S.StudentID equals Ad.StudentID
                         where S.StudentID == id

                         select new StudentModel()
                         {
                             StudentID = S.StudentID,
                             StudentName = S.StudentName,
                             Contact = S.Contact,
                             EmailID = S.EmailID,
                             Language = S.Languagee,
                             AddressLine1 = Ad.AddressLine1,
                             AddressLine2 = Ad.AddressLine2,
                             State = Ad.Statee,
                             Pincode = Ad.Pincode,
                             Country = Ad.Country
                         }).FirstOrDefault();
            
            if (query == null)
            {
                return HttpNotFound(); 
            }

            ViewBag.listofstudentdatabyid = query;
            return View(query);
        }

        [System.Web.Http.HttpGet]
        public ActionResult EditRecord(int id,StudentModel studentModel)
        {
            if (id == null)
                return HttpNotFound();
            var query = (from S in _dbContext.StudentDetails
                         join Ad in _dbContext.AddressDetails on S.StudentID equals Ad.StudentID
                         where S.StudentID == id

                         select new StudentModel()
                         {
                             StudentID = S.StudentID,
                             StudentName = S.StudentName,
                             Contact = S.Contact,
                             EmailID = S.EmailID,
                             Language = S.Languagee,
                             AddressLine1 = Ad.AddressLine1,
                             AddressLine2 = Ad.AddressLine2,
                             State = Ad.Statee,
                             Pincode = Ad.Pincode,
                             Country = Ad.Country
                         }).FirstOrDefault();

            ViewBag.updatestudentdatabyid = query;
            return View(query); 
        }

        [System.Web.Http.HttpPut]
        public ActionResult EditRecordsAPI(StudentModel _studentmodel)
        {
                    string connectionString = "data source=192.168.1.98\\SQL2019;initial catalog=TestDB;persist security info=True;user id=trinity;password=trinity;multipleactiveresultsets=True;trustservercertificate=True;application name=EntityFramework";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand com = new SqlCommand("sp_updateEmployee", conn);
                        com.CommandType = CommandType.StoredProcedure;

                        com.Parameters.AddWithValue("@StudentID", _studentmodel.StudentID);
                        com.Parameters.AddWithValue("@StudentName", _studentmodel.StudentName);
                        com.Parameters.AddWithValue("@Contact", _studentmodel.Contact);
                        com.Parameters.AddWithValue("@EmailID", _studentmodel.EmailID);
                        com.Parameters.AddWithValue("@Languagee", _studentmodel.Language);
                        com.Parameters.AddWithValue("@AddressLine1", _studentmodel.AddressLine1);
                        com.Parameters.AddWithValue("@AddressLine2", _studentmodel.AddressLine2);
                        com.Parameters.AddWithValue("@Statee", _studentmodel.State);
                        com.Parameters.AddWithValue("@Pincode", _studentmodel.Pincode);
                        com.Parameters.AddWithValue("@Country", _studentmodel.Country);

                        conn.Open();

                        int rowsAffected = com.ExecuteNonQuery();
                        conn.Close();

                    }
                
                return View();
           
        }

    }
}
