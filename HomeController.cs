using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using damla.Models;

namespace damla.Controllers
{
    public class HomeController : Controller
    {

        private damla.Models.damladbaEntities3 _db = new damla.Models.damladbaEntities3();
        public ActionResult AnaSayfa() 
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(_db.t_hata.ToList());
        
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        //create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Home/Create 

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Exclude = "id")] t_hata t_HataToCreate)
        {
            try
            {
                _db.AddTot_hata(t_HataToCreate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
         

        //delete

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var liste = _db.t_hata.ToList();
            var kayit = liste.Where(a => a.hata_id == id).SingleOrDefault();
            return View(kayit);
        }

        [ActionNameAttribute("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
           try
            {
               t_hata hata =  _db.t_hata.FirstOrDefault(x => x.hata_id == id);
               _db.t_hata.DeleteObject(hata);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}