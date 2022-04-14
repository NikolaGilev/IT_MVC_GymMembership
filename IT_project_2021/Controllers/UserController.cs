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
    [Authorize(Roles = "Administrator,Manager")]
    public class UserController : Controller
    {
        private UserContext db = new UserContext();
        private CustomersContext trainerdb = new CustomersContext();

        // GET: User
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = db.User.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,Surname,Age,HeightInCm,Bodyweight,Sex")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {

                userModel.MembershipDaysLeft = 31;
                db.User.Add(userModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userModel);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = db.User.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,Surname,Age,HeightInCm,Bodyweight,Sex")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userModel);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = db.User.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserModel userModel = db.User.Find(id);
            db.User.Remove(userModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: User/UserWorkout/5
        public ActionResult UserWorkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserModel userModel = db.User.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }
            return View(userModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUserWorkout(int? id, [Bind(Include = "UserId,ExerciseDate,ExerciseName,kgLifted,Reps,Sets,ChooseExercises")] ExercisesModel exercisesModel)
        {
            if (ModelState.IsValid)
            {

                UserModel userModel = db.User.Find(exercisesModel.ExercisesId);

                exercisesModel.ExerciseDate = DateTime.Now;
                userModel.Exercise.Add(exercisesModel);

                db.Entry(userModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index"); // valjda dr link treba
            }

            return View(exercisesModel);

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
