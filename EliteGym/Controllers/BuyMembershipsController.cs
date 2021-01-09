using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EliteGym.Models;

namespace EliteGym.Controllers
{
    public class BuyMembershipsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BuyMemberships
        public ActionResult Index()
        {
            var buyMemberships = db.BuyMemberships.Include(b => b.ApplicationUser).Include(b => b.Facility).Include(b => b.Membership);
            return View(buyMemberships.ToList());
        }

        // GET: BuyMemberships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyMembership buyMembership = db.BuyMemberships.Find(id);
            if (buyMembership == null)
            {
                return HttpNotFound();
            }
            return View(buyMembership);
        }

        // GET: BuyMemberships/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.FacilityId = new SelectList(db.Facilities, "Id", "FacilityName");
            ViewBag.MembershipId = new SelectList(db.Memberships, "Id", "MembershipDuration");
            return View();
        }

        // POST: BuyMemberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PurchaseDate,MembershipId,FacilityId,ApplicationUserId")] BuyMembership buyMembership)
        {
            if (ModelState.IsValid)
            {
                db.BuyMemberships.Add(buyMembership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserName", buyMembership.ApplicationUserId);
            ViewBag.FacilityId = new SelectList(db.Facilities, "Id", "FacilityName", buyMembership.FacilityId);
            ViewBag.MembershipId = new SelectList(db.Memberships, "Id", "MembershipDuration", buyMembership.MembershipId);
            return View(buyMembership);
        }

        // GET: BuyMemberships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyMembership buyMembership = db.BuyMemberships.Find(id);
            if (buyMembership == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserName", buyMembership.ApplicationUserId);
            ViewBag.FacilityId = new SelectList(db.Facilities, "Id", "FacilityName", buyMembership.FacilityId);
            ViewBag.MembershipId = new SelectList(db.Memberships, "Id", "MembershipDuration", buyMembership.MembershipId);
            return View(buyMembership);
        }

        // POST: BuyMemberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PurchaseDate,MembershipId,FacilityId,ApplicationUserId")] BuyMembership buyMembership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyMembership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "UserName", buyMembership.ApplicationUserId);
            ViewBag.FacilityId = new SelectList(db.Facilities, "Id", "FacilityName", buyMembership.FacilityId);
            ViewBag.MembershipId = new SelectList(db.Memberships, "Id", "MembershipDuration", buyMembership.MembershipId);
            return View(buyMembership);
        }

        // GET: BuyMemberships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuyMembership buyMembership = db.BuyMemberships.Find(id);
            if (buyMembership == null)
            {
                return HttpNotFound();
            }
            return View(buyMembership);
        }

        // POST: BuyMemberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuyMembership buyMembership = db.BuyMemberships.Find(id);
            db.BuyMemberships.Remove(buyMembership);
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
