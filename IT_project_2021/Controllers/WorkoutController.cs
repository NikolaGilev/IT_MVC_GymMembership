using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IT_project_2021.Models;
using IT_project_2021.Models.repo;

namespace IT_project_2021.Controllers
{
    public class WorkoutController : Controller
    {
        private UserContext db = new UserContext();
        public DateTime ExerciseDate { get; set; }

        // GET: Workout
        public ActionResult Index()
        {
            return View(db.Exercises.ToList());
        }

        // GET: Workout/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercisesModel exercisesModel = db.Exercises.Find(id);
            if (exercisesModel == null)
            {
                return HttpNotFound();
            }
            return View(exercisesModel);
        }

        // GET: Workout/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workout/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExerciseDate,ExerciseName,kgLifted,Reps,Sets,ChooseExercises")] ExercisesModel exercisesModel)
        {
            if (ModelState.IsValid)
            {
                var newDate = new TimeSpan(DateTime.UtcNow.Ticks-ExerciseDate.Ticks);
                
                exercisesModel.ExerciseDate = DateTime.Now;
                db.Exercises.Add(exercisesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exercisesModel);
        }


        // GET: Workout/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercisesModel exercisesModel = db.Exercises.Find(id);
            if (exercisesModel == null)
            {
                return HttpNotFound();
            }
            return View(exercisesModel);
        }

        // POST: Workout/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseDate,ExerciseName,kgLifted,Reps,Sets")] ExercisesModel exercisesModel)
        {
            if (ModelState.IsValid)
            {
                exercisesModel.ExerciseDate=ExerciseDate;
                db.Entry(exercisesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exercisesModel);
        }

        // GET: Workout/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExercisesModel exercisesModel = db.Exercises.Find(id);
            if (exercisesModel == null)
            {
                return HttpNotFound();
            }
            return View(exercisesModel);
        }

        // POST: Workout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExercisesModel exercisesModel = db.Exercises.Find(id);
            db.Exercises.Remove(exercisesModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
