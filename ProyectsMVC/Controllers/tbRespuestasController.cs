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
    public class tbRespuestasController : Controller
    {
        private ProyectsMVCEntities db = new ProyectsMVCEntities();

        // GET: tbRespuestas
        public ActionResult Index()
        {
            var tbRespuestas = db.tbRespuestas.Include(t => t.tbPreguntas);
            return View(tbRespuestas.ToList());
        }

        // GET: tbRespuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRespuestas tbRespuestas = db.tbRespuestas.Find(id);
            if (tbRespuestas == null)
            {
                return HttpNotFound();
            }
            return View(tbRespuestas);
        }

        // GET: tbRespuestas/Create
        public ActionResult Create()
        {
            ViewBag.pregCodigo = new SelectList(db.tbPreguntas, "pregCodigo", "pregDescripcion");
            return View();
        }

        // POST: tbRespuestas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "respCodigo,respDescripcion,pregCodigo,respCorrectas")] tbRespuestas tbRespuestas)
        {
            if (ModelState.IsValid)
            {
                db.tbRespuestas.Add(tbRespuestas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pregCodigo = new SelectList(db.tbPreguntas, "pregCodigo", "pregDescripcion", tbRespuestas.pregCodigo);
            return View(tbRespuestas);
        }

        // GET: tbRespuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRespuestas tbRespuestas = db.tbRespuestas.Find(id);
            if (tbRespuestas == null)
            {
                return HttpNotFound();
            }
            ViewBag.pregCodigo = new SelectList(db.tbPreguntas, "pregCodigo", "pregDescripcion", tbRespuestas.pregCodigo);
            return View(tbRespuestas);
        }

        // POST: tbRespuestas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "respCodigo,respDescripcion,pregCodigo,respCorrectas")] tbRespuestas tbRespuestas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbRespuestas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pregCodigo = new SelectList(db.tbPreguntas, "pregCodigo", "pregDescripcion", tbRespuestas.pregCodigo);
            return View(tbRespuestas);
        }

        // GET: tbRespuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRespuestas tbRespuestas = db.tbRespuestas.Find(id);
            if (tbRespuestas == null)
            {
                return HttpNotFound();
            }
            return View(tbRespuestas);
        }

        // POST: tbRespuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbRespuestas tbRespuestas = db.tbRespuestas.Find(id);
            db.tbRespuestas.Remove(tbRespuestas);
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
