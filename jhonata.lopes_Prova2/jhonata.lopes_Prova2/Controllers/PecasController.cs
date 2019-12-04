using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using jhonata.lopes_Prova2.DAL;
using jhonata.lopes_Prova2.Models;

namespace jhonata.lopes_Prova2.Controllers
{
    public class PecasController : Controller
    {
        private PecasContext db = new PecasContext();

        // GET: Pecas
        public ActionResult Index()
        {
            return View(db.pecas.ToList());
        }

        // GET: Pecas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pecas pecas = db.pecas.Find(id);
            if (pecas == null)
            {
                return HttpNotFound();
            }
            return View(pecas);
        }

        // GET: Pecas/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome_Peca,QTD_Pecas")] Pecas pecas)
        {
            if (ModelState.IsValid)
            {
                db.pecas.Add(pecas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pecas);
        }

        // GET: Pecas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pecas pecas = db.pecas.Find(id);
            if (pecas == null)
            {
                return HttpNotFound();
            }
            return View(pecas);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome_Peca,QTD_Pecas")] Pecas pecas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pecas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pecas);
        }

        // GET: Pecas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pecas pecas = db.pecas.Find(id);
            if (pecas == null)
            {
                return HttpNotFound();
            }
            return View(pecas);
        }

        // POST: Pecas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pecas pecas = db.pecas.Find(id);
            db.pecas.Remove(pecas);
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
