using System;
using System.Data;
using System.Data.Entity;
using System.Net;
using HW5.DAL;
using HW5.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Instance of the database
        /// </summary>
        private DmvContext db = new DmvContext();

        /// <summary>
        /// Returns the index page which shows all rows in the database
        /// </summary>
        /// <returns>The index page</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "DMV Records";            
            return View(db.DMVs.ToList());
        }

        /// <summary>
        /// Returns the base page to allow the user to enter
        /// a new resident
        /// </summary>
        /// <returns>The Create Page</returns>
        public ActionResult Create()
        {
            ViewBag.Title = "Add a new resident";
            return View();
        }

        /// <summary>
        /// After all data has been entered sends the data to the
        /// database to be entered in a new row and returns the user to the
        /// index page.
        /// </summary>
        /// <param name="dmv">A dmv object representing one of the rows in the database</param>
        /// <returns>The index page if data was enter correctly, or returns the Create page with error messages</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, Permit, FullName,DOB,ResidenceAddress,City,StateAbbreviated,ZipCode,County")] DMV dmv)
        {
            ViewBag.Title = "Add a new resident";
            if (ModelState.IsValid)
            {
                db.DMVs.Add(dmv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dmv);
        }

        /// <summary>
        /// Returns the data row associated with the ID passed.
        /// If not ID was passed returns HttpBadRequest, if ID isn't part
        /// of the table returns HttpNotFound, else allows you to edit that row
        /// </summary>
        /// <param name="id">ID of row to edit</param>
        /// <returns>The Edit page with the rows data filled in the form</returns>
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit a resident";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMV dmv = db.DMVs.Find(id);
            if (dmv == null)
            {
                return HttpNotFound();
            }
            return View(dmv);
        }

        /// <summary>
        /// After all data has been entered correctly updates the row in the
        /// database and returns the user to the index page. If data has been entered
        /// incorrectly returns the user to the Edit page with error messages marked.
        /// </summary>
        /// <param name="dmv">The data to be updated in the database</param>
        /// <returns>Index page if data was entered correctly, or the Edit page if not</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Permit, FullName,DOB,ResidenceAddress,City,StateAbbreviated,ZipCode,County")] DMV dmv)
        {
            ViewBag.Title = "Edit a resident";
            if (ModelState.IsValid)
            {
                db.Entry(dmv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dmv);
        }
    }
}