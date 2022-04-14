using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IT_project_2021.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        // da izbere od poveke exercises koj gi pravi on + za sekoj exercise da ima rep+set+kg krenato
        public List<ExercisesModel> Exercise = new List<ExercisesModel>();

        [Required]
        public string Name { get; set; }

        public List<string> Trainers = new List<string>();

        [Required]
        public string Surname{ get; set; }

        public int Age { get; set; }

 
        public int HeightInCm { get; set; }

        public int Bodyweight { get; set; }

        // ako selektira tip na workout na desniot del od stranata mu se pokazuvaat vezhbite i regimentot
        public TypeOfWorkout TypeOfWorkout { get; set; }

        public Gender Sex { get; set; }

        [Required]
        public int MembershipDaysLeft { get; set; }

    }
    public enum Gender
    {
        Male,
        Female
    }
    public enum TypeOfWorkout
    {
        nSuns=1,
        [Description("Starting Strength (5x5)")] SS5x5 = 2,
        [Description("Starting Strength (3x5)")] SS3x5 = 3,
        PushPullLegs = 4,
        UpperLower= 5
    }

}