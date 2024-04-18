﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TestDBEntities : DbContext
    {
        public TestDBEntities()
            : base("name=TestDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AddressDetail> AddressDetails { get; set; }
        public virtual DbSet<StudentDetail> StudentDetails { get; set; }
        public virtual DbSet<USERDB> USERDBs { get; set; }
    
        public virtual int sp_deleteEmployee(Nullable<int> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_deleteEmployee", studentIDParameter);
        }
    
        public virtual int sp_EmployeeAdd(string studentName, string contact, string emailID, string languagee, string addressLine1, string addressLine2, string statee, string pincode, string country)
        {
            var studentNameParameter = studentName != null ?
                new ObjectParameter("StudentName", studentName) :
                new ObjectParameter("StudentName", typeof(string));
    
            var contactParameter = contact != null ?
                new ObjectParameter("Contact", contact) :
                new ObjectParameter("Contact", typeof(string));
    
            var emailIDParameter = emailID != null ?
                new ObjectParameter("EmailID", emailID) :
                new ObjectParameter("EmailID", typeof(string));
    
            var languageeParameter = languagee != null ?
                new ObjectParameter("Languagee", languagee) :
                new ObjectParameter("Languagee", typeof(string));
    
            var addressLine1Parameter = addressLine1 != null ?
                new ObjectParameter("AddressLine1", addressLine1) :
                new ObjectParameter("AddressLine1", typeof(string));
    
            var addressLine2Parameter = addressLine2 != null ?
                new ObjectParameter("AddressLine2", addressLine2) :
                new ObjectParameter("AddressLine2", typeof(string));
    
            var stateeParameter = statee != null ?
                new ObjectParameter("Statee", statee) :
                new ObjectParameter("Statee", typeof(string));
    
            var pincodeParameter = pincode != null ?
                new ObjectParameter("Pincode", pincode) :
                new ObjectParameter("Pincode", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EmployeeAdd", studentNameParameter, contactParameter, emailIDParameter, languageeParameter, addressLine1Parameter, addressLine2Parameter, stateeParameter, pincodeParameter, countryParameter);
        }
    
        public virtual int sp_updateEmployee(Nullable<int> studentID, string studentName, string contact, string emailID, string languagee, string addressLine1, string addressLine2, string statee, string pincode, string country)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            var studentNameParameter = studentName != null ?
                new ObjectParameter("StudentName", studentName) :
                new ObjectParameter("StudentName", typeof(string));
    
            var contactParameter = contact != null ?
                new ObjectParameter("Contact", contact) :
                new ObjectParameter("Contact", typeof(string));
    
            var emailIDParameter = emailID != null ?
                new ObjectParameter("EmailID", emailID) :
                new ObjectParameter("EmailID", typeof(string));
    
            var languageeParameter = languagee != null ?
                new ObjectParameter("Languagee", languagee) :
                new ObjectParameter("Languagee", typeof(string));
    
            var addressLine1Parameter = addressLine1 != null ?
                new ObjectParameter("AddressLine1", addressLine1) :
                new ObjectParameter("AddressLine1", typeof(string));
    
            var addressLine2Parameter = addressLine2 != null ?
                new ObjectParameter("AddressLine2", addressLine2) :
                new ObjectParameter("AddressLine2", typeof(string));
    
            var stateeParameter = statee != null ?
                new ObjectParameter("Statee", statee) :
                new ObjectParameter("Statee", typeof(string));
    
            var pincodeParameter = pincode != null ?
                new ObjectParameter("Pincode", pincode) :
                new ObjectParameter("Pincode", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_updateEmployee", studentIDParameter, studentNameParameter, contactParameter, emailIDParameter, languageeParameter, addressLine1Parameter, addressLine2Parameter, stateeParameter, pincodeParameter, countryParameter);
        }
    }
}
