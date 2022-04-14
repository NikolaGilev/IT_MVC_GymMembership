using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IT_project_2021.Models
{
    public class ExercisesModel
    {
        [Key]
        public int ExercisesId { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExerciseDate { get; set; }

        [Required]
        public string ExerciseName { get; set; }
        
        [Required]
        public int kgLifted { get; set; }

        [Required]
        public int Reps { get; set; }

        [Required]
        public int Sets { get; set; }

        public SelectWorkouts ChooseExercises { get; set; }

    }
    public enum SelectWorkouts
    {
        [Description("Bench Press")] BenchPress = 1,
        [Description("Overhead press")] Ohp = 2,
        [Description("Incline Bench Press")] InclineBP = 3,
        Dip=4,
        Deadlift=5,
        [Description("Sumo Deadlift")] SumoDL = 6,
        [Description("Power Clean")] PowerClean = 7,
        [Description("Back Squat")] BackSquat = 8,
        [Description("Front Squat")] FrontSquat =9,
        [Description("Chin-up")] ChinUp=10,
        [Description("Pull-up")] PullUp=11,
        [Description("Pendlay-row")] PendlayRow=12,
        [Description("Bent-over rows")] BentOverRow=13
    }
}