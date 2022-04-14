using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_project_2021.Models
{
    public class CustomersModel
    {
        [Key]
        public int CustomerId { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string CustomerName { get; set; } 

        [Required]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int YearsExp { get; set; }

        


    }
}