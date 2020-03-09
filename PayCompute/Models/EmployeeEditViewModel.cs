using Microsoft.AspNetCore.Http;
using PayCompute.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayCompute.Models
{
    public class EmployeeEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee no is required"),
            RegularExpression("^[A-Z]{3,3}[0-9]{3}$")]
        public string EmployeeNo { get; set; }
        [Required(ErrorMessage = "First name is required"), StringLength(25, MinimumLength = 4)]
        [RegularExpression(@"^[A-Z][a-zA-Z""\s-]*$"), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required"), StringLength(25, MinimumLength = 4)]
        [RegularExpression(@"^[A-Z][a-zA-Z""\s-]*$"), Display(Name = "First Name")]
        public string LastName { get; set; }
           
        [Display(Name = "Photo")]
        public IFormFile ImageUrl { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date), Display(Name = "Date Joined")]
        public string PhoneNumber { get; set; }
        public DateTime DateJoined { get; set; } 
        [Required(ErrorMessage = "role is required"), StringLength(maximumLength: 100)]
        public string Designation { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(50), Display(Name = "NI No.")]
        [RegularExpression(@"^[A-CEGHJ-PR-TW-Z]{1}[A-CEGHJ-NPR-TW-Z]{1}[0-9]{6}[A-D\s]$")]
        public string InsuranceNo { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Student Loan")]
        public StudentLoan StudentLoan { get; set; }
        [Display(Name = "Union Member")]
        public UnionMember UnionMember { get; set; }
        [Required, StringLength(150)]

        public string Address { get; set; }
        [Required, StringLength(50)]

        public string City { get; set; }
        [Required, StringLength(50)]
        public int Postcode { get; set; }
        public IEnumerable<PaymentRecord> PaymentRecord { get; set; }

    }
}
