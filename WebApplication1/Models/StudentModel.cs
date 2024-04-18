using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class StudentModel
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Student name is required")]
        [MaxLength(20, ErrorMessage = "Student name must be at most 20 characters")]
        public string StudentName { get; set; }

        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Invalid contact number")]
        public string Contact { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Invalid email address")]
        public string EmailID { get; set; }

        [MaxLength(50, ErrorMessage = "Language must be at most 50 characters")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Address Line 1 is required")]
        [MaxLength(30, ErrorMessage = "Address Line 1 must be at most 30 characters")]
        public string AddressLine1 { get; set; }

        [MaxLength(30, ErrorMessage = "Address Line 2 must be at most 30 characters")]
        public string AddressLine2 { get; set; }

       
        public string State { get; set; }

        [Required(ErrorMessage = "Pincode is required")]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Pincode must be 6 digits")]
        public string Pincode { get; set; }

        public string Country { get; set; }
    }
}
