using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LearnAzure.Models
{
    public class ExamplesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Examples
        public ActionResult Index()
        {
            return View(db.Examples.ToList());
        }

        // GET: Examples/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Example example = db.Examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // GET: Examples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Examples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Output,Template")] Example example)
        {
            if (ModelState.IsValid)
            {
                db.Examples.Add(example);
                db.SaveChanges();

                //Add Insights Event
                var eventAttributes = new Dictionary<String, Object>();
                NewRelic.Api.Agent.NewRelic.RecordCustomEvent("ExampleCreate", eventAttributes);

                return RedirectToAction("Index");
                
            }

            return View(example);
        }

        // GET: Examples/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Example example = db.Examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // POST: Examples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Output,Template")] Example example)
        {
            if (ModelState.IsValid)
            {
                db.Entry(example).State = EntityState.Modified;
                db.SaveChanges();
                var eventAttributes = new Dictionary<String, Object>() { { "ID", example.Id }, { "Action", "edit" } };
                NewRelic.Api.Agent.NewRelic.RecordCustomEvent("Example", eventAttributes);

                return RedirectToAction("Index");
            }
            return View(example);
        }

        // GET: Examples/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Example example = db.Examples.Find(id);
            if (example == null)
            {
                return HttpNotFound();
            }
            return View(example);
        }

        // POST: Examples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Example example = db.Examples.Find(id);
            db.Examples.Remove(example);
            db.SaveChanges();
            var eventAttributes = new Dictionary<String, Object>() { { "ID", example.Id }, { "Action", "delete" } };
            NewRelic.Api.Agent.NewRelic.RecordCustomEvent("Example", eventAttributes);

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
