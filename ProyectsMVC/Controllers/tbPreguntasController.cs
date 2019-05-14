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
    public class tbPreguntasController : Controller
    {
        private ProyectsMVCEntities db = new ProyectsMVCEntities();

        // GET: tbPreguntas
        public ActionResult Index()
        {
            var tbPreguntas = db.tbPreguntas.Include(t => t.tbPrueba);
            return View(tbPreguntas.ToList());
        }

        // GET: tbPreguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPreguntas tbPreguntas = db.tbPreguntas.Find(id);
            if (tbPreguntas == null)
            {
                return HttpNotFound();
            }
            return View(tbPreguntas);
        }

        // GET: tbPreguntas/Create
        public ActionResult Create()
        {
            ViewBag.prueCodigo = new SelectList(db.tbPrueba, "prueCodigo", "prueNombre");
            return View();
        }

        // POST: tbPreguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pregCodigo,pregDescripcion,prueCodigo")] tbPreguntas tbPreguntas)
        {
            if (ModelState.IsValid)
            {
                db.tbPreguntas.Add(tbPreguntas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.prueCodigo = new SelectList(db.tbPrueba, "prueCodigo", "prueNombre", tbPreguntas.prueCodigo);
            return View(tbPreguntas);
        }

        // GET: tbPreguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPreguntas tbPreguntas = db.tbPreguntas.Find(id);
            if (tbPreguntas == null)
            {
                return HttpNotFound();
            }
            ViewBag.prueCodigo = new SelectList(db.tbPrueba, "prueCodigo", "prueNombre", tbPreguntas.prueCodigo);
            return View(tbPreguntas);
        }

        // POST: tbPreguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pregCodigo,pregDescripcion,prueCodigo")] tbPreguntas tbPreguntas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPreguntas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.prueCodigo = new SelectList(db.tbPrueba, "prueCodigo", "prueNombre", tbPreguntas.prueCodigo);
            return View(tbPreguntas);
        }

        // GET: tbPreguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPreguntas tbPreguntas = db.tbPreguntas.Find(id);
            if (tbPreguntas == null)
            {
                return HttpNotFound();
            }
            return View(tbPreguntas);
        }

        // POST: tbPreguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPreguntas tbPreguntas = db.tbPreguntas.Find(id);
            db.tbPreguntas.Remove(tbPreguntas);
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
