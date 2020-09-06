﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PuntoDeVenta.Data;

namespace PuntoDeVenta.Controllers
{
    public class ArticulosVentaController : Controller
    {
        private PuntoDeVentaEntities2 db = new PuntoDeVentaEntities2();

        // GET: ArticulosVenta
        public ActionResult Index()
        {
            return View(db.ARTICULOS.ToList());
        }

        // GET: ArticulosVenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULOS aRTICULOS = db.ARTICULOS.Find(id);
            if (aRTICULOS == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULOS);
        }

        // GET: ArticulosVenta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticulosVenta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CODIGO,DESCRIPCION,EXISTENCIA,PRECIO")] ARTICULOS aRTICULOS)
        {
            if (ModelState.IsValid)
            {
                db.ARTICULOS.Add(aRTICULOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aRTICULOS);
        }

        // GET: ArticulosVenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULOS aRTICULOS = db.ARTICULOS.Find(id);
            if (aRTICULOS == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULOS);
        }

        // POST: ArticulosVenta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CODIGO,DESCRIPCION,EXISTENCIA,PRECIO")] ARTICULOS aRTICULOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aRTICULOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aRTICULOS);
        }

        // GET: ArticulosVenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ARTICULOS aRTICULOS = db.ARTICULOS.Find(id);
            if (aRTICULOS == null)
            {
                return HttpNotFound();
            }
            return View(aRTICULOS);
        }

        // POST: ArticulosVenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ARTICULOS aRTICULOS = db.ARTICULOS.Find(id);
            db.ARTICULOS.Remove(aRTICULOS);
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
