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
        private DmvContext db = new DmvContext();

        // GET: Home
        public ActionResult Index()
        {
            
            return View(db.DMVs.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, Permit, FullName,DOB,ResidenceAddress,City,StateAbbreviated,ZipCode,County")] DMV dmv)
        {
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
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Permit, FullName,DOB,ResidenceAddress,City,StateAbbreviated,ZipCode,County")] DMV dmv)
        {
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