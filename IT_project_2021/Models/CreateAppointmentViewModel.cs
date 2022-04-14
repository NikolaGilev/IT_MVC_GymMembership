using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_project_2021.Models
{
    public class CreateAppointmentViewModel
    {
        public AppointmentModel Appointment { get; set; }
        public List<CustomersModel> TrainersList { get; set; }
        public List<String> AvailableTrainerList { get; set; }
        public List<DateTime> AvailableDays { get; set; }
        public bool CanAppoint { get; set; }

        public CreateAppointmentViewModel()
        {
            Appointment = new AppointmentModel();
        }
    }
}