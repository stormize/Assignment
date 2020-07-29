using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Context;
using Entities;

namespace Assignment.Controllers
{
    public class DevicesController : Controller
    {
        
        UnitOfWork db = new UnitOfWork();

        // GET: Devices
        public ActionResult Index()
        {
            // var devices = db.Devices.Include(d => d.Category);
            var devices = db.Devices.Get();
            return View(devices.ToList());
        }

        // GET: Devices/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.GetById(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // GET: Devices/Create
        public ActionResult Create()
        {
            ViewBag.FK_Category = new SelectList(db.Categories.Get(), "Id", "Name");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AcquisitionDate,Memo,FK_Category")] Device device)
        {
            if (ModelState.IsValid)
            {
                device.Id = Guid.NewGuid();
               
                db.Devices.Create(device);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Category = new SelectList(db.Categories.Get(), "Id", "Name", device.FK_Category);
            return View(device);
        }

        // GET: Devices/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.GetById(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Category = new SelectList(db.Categories.Get(), "Id", "Name", device.FK_Category);
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AcquisitionDate,Memo,FK_Category")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Devices.Update(device);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Category = new SelectList(db.Categories.Get(), "Id", "Name", device.FK_Category);
            return View(device);
        }

        // GET: Devices/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.GetById(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Device device = db.Devices.GetById(id);
            db.Devices.Delete(device);
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
