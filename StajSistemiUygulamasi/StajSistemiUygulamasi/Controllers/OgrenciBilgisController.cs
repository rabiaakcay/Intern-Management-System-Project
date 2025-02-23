﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StajSistemiUygulamasi.Models;

namespace StajSistemiUygulamasi.Controllers
{
    public class OgrenciBilgisController : Controller
    {
        private stajsistemiEntities db = new stajsistemiEntities();

        // GET: OgrenciBilgis
        public ActionResult Index()
        {
            return View(db.OgrenciBilgi.ToList());
        }

        // GET: OgrenciBilgis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciBilgi ogrenciBilgi = db.OgrenciBilgi.Find(id);
            if (ogrenciBilgi == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciBilgi);
        }

        // GET: OgrenciBilgis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OgrenciBilgis/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OgrenciNo,Adi,Soyadi,Ogretim")] OgrenciBilgi ogrenciBilgi)
        {
            if (ModelState.IsValid)
            {
                db.OgrenciBilgi.Add(ogrenciBilgi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ogrenciBilgi);
        }

        // GET: OgrenciBilgis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciBilgi ogrenciBilgi = db.OgrenciBilgi.Find(id);
            if (ogrenciBilgi == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciBilgi);
        }

        // POST: OgrenciBilgis/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OgrenciNo,Adi,Soyadi,Ogretim")] OgrenciBilgi ogrenciBilgi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenciBilgi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenciBilgi);
        }

        // GET: OgrenciBilgis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OgrenciBilgi ogrenciBilgi = db.OgrenciBilgi.Find(id);
            if (ogrenciBilgi == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciBilgi);
        }

        // POST: OgrenciBilgis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OgrenciBilgi ogrenciBilgi = db.OgrenciBilgi.Find(id);
            db.OgrenciBilgi.Remove(ogrenciBilgi);
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
