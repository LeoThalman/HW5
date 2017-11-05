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
        public ActionResult Create([Bind(Include = "Permit, FullName,DOB,ResidenceAddress,City,StateAbbreviated,ZipCode,County")] DMV dmv)
        {
            if (ModelState.IsValid)
            {
                db.DMVRecords.Add(dmv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dmv);
        }
    }
}