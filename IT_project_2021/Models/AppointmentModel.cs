using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_project_2021.Models
{
    public class AppointmentModel
    {
        [Key]
        public int AppointmentId { get; set; }

        [EmailAddress]
        public string EmailOfUser { get; set; }

        [Key]
        [DataType(DataType.DateTime)]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Име на вакцина")]
        public string NameOfTrainer { get; set; }

        public int AppointmentNum { get; set; }

        public bool Confirmed { get; set; }
    }
}