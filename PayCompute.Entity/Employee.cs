﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayCompute.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeNo { get; set; }
        [Required, MaxLength(25)]
        public string FirstName { get; set; }
        [Required, MaxLength(25)]
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public string PhoneNumber { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string InsuranceNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StudentLoan StudentLoan { get; set; }
        public UnionMember UnionMember { get; set; }
        [Required, MaxLength(150)]
        public string Address { get; set; }
        public string City { get; set; }
        [Required, MaxLength(15)]
        public int Postcode { get; set; }
        public IEnumerable<PaymentRecord> PaymentRecord { get; set; }
    }
}
