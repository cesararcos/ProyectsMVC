using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectsMVC.DAL.Models;

namespace ProyectsMVC.Controllers
{
    public class tbPruebasController : Controller
    {
        private ProyectsMVCEntities db = new ProyectsMVCEntities();

        // GET: tbPruebas
        public ActionResult Index()
        {
            var tbPrueba = db.tbPrueba.Include(t => t.tbNiveles);
            return View(tbPrueba.ToList());
        }

        // GET: tbPruebas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPrueba tbPrueba = db.tbPrueba.Find(id);
            if (tbPrueba == null)
            {
                return HttpNotFound();
            }
            return View(tbPrueba);
        }

        // GET: tbPruebas/Create
        public ActionResult Create()
        {
            ViewBag.niveCodigo = new SelectList(db.tbNiveles, "niveCodigo", "niveDescripcion");
            return View();
        }

        // POST: tbPruebas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "prueCodigo,niveCodigo,prueNombre")] tbPrueba tbPrueba)
        {
            if (ModelState.IsValid)
            {
                db.tbPrueba.Add(tbPrueba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.niveCodigo = new SelectList(db.tbNiveles, "niveCodigo", "niveDescripcion", tbPrueba.niveCodigo);
            return View(tbPrueba);
        }

        // GET: tbPruebas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPrueba tbPrueba = db.tbPrueba.Find(id);
            if (tbPrueba == null)
            {
                return HttpNotFound();
            }
            ViewBag.niveCodigo = new SelectList(db.tbNiveles, "niveCodigo", "niveDescripcion", tbPrueba.niveCodigo);
            return View(tbPrueba);
        }

        // POST: tbPruebas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "prueCodigo,niveCodigo,prueNombre")] tbPrueba tbPrueba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPrueba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.niveCodigo = new SelectList(db.tbNiveles, "niveCodigo", "niveDescripcion", tbPrueba.niveCodigo);
            return View(tbPrueba);
        }

        // GET: tbPruebas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPrueba tbPrueba = db.tbPrueba.Find(id);
            if (tbPrueba == null)
            {
                return HttpNotFound();
            }
            return View(tbPrueba);
        }

        // POST: tbPruebas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPrueba tbPrueba = db.tbPrueba.Find(id);
            db.tbPrueba.Remove(tbPrueba);
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
