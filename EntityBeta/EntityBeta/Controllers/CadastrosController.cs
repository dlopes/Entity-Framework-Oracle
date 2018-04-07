using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityBeta.DAL;
using EntityBeta.Models;

namespace EntityBeta.Controllers
{
    public class CadastrosController : Controller
    {
        private EntityBetaContext db = new EntityBetaContext();

        // GET: Cadastros
        public ActionResult Index()
        {
            return View(db.Cadastros.ToList());
        }

        // GET: Cadastros/Details/5
        public ActionResult Details(/*int? id*/ String CPF_CGC)
        {
            if (/*id == null*/ CPF_CGC == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
  

            var cad = db.Cadastros.Where(c => c.CPF_CGC == CPF_CGC ).First();

            if (cad == null)
            {
                return HttpNotFound();
            }

            return View(cad);
        }

        // GET: Cadastros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadastros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PESSOA,CPF_CGC,NOME_PESSOA,DATA_INCLUSAO,BLOB_IMAGEM")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Cadastros.Add(cadastro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastro);
        }

        // GET: Cadastros/Edit/5
        public ActionResult Edit(/*int? id*/ String CPF_CGC)
        {
            if (CPF_CGC == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var cad = db.Cadastros.Where(c => c.CPF_CGC == CPF_CGC).First();

            
            if (cad == null)
            {
                return HttpNotFound();
            }
           
            return View(cad);
        }

        // POST: Cadastros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_PESSOA,CPF_CGC,NOME_PESSOA,DATA_INCLUSAO,BLOB_IMAGEM")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastro);
        }

        // GET: Cadastros/Delete/5
        public ActionResult Delete(/*int? id*/ String CPF_CGC)
        {
            if (/*id == null*/ CPF_CGC == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var cad = db.Cadastros.Where(c => c.CPF_CGC == CPF_CGC ).First();

            if (cad == null)
            {
                return HttpNotFound();
            }

            return View(cad);

        }

        // POST: Cadastros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(/*int id*/ String CPF_CGC)
        {
         
            var cad = db.Cadastros.Where(c => c.CPF_CGC == CPF_CGC).First();
            db.Cadastros.Remove(cad);
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
