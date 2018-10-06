using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using damla.Models;

namespace damla.Controllers
{
    public class CozumController : Controller
    {

        private damla.Models.damladbaEntities4 _db2 = new damla.Models.damladbaEntities4();
        public ActionResult AnaSayfa()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(_db2.t_cozum.ToList());

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
        public ActionResult Create([Bind(Exclude = "id")] t_cozum t_cozumToCreate)
        {
            try
            {
                _db2.AddTot_cozum(t_cozumToCreate);
                _db2.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var Cozumedit = (from e in _db2.t_cozum where e.cozum_id == id select e).First();
            return View(Cozumedit);
        }
      [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Edit(t_cozum Cozumedit)
        {
            var czmorginalhata = (from e in _db2.t_cozum where e.cozum_id==Cozumedit.cozum_id select e).First();
            if (!ModelState.IsValid)
            {
                return View(czmorginalhata);
                }
            _db2.ApplyPropertyChanges(czmorginalhata.EntityKey.EntitySetName, Cozumedit);
            _db2.SaveChanges();
            return RedirectToAction("Edit");



        //    try
        //    {
        //        // TODO: Add update logic here
        //        var 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        }


        //delete

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var liste = _db2.t_cozum.ToList();
            var kayit = liste.Where(a => a.cozum_id == id).SingleOrDefault();
            return View(kayit);
        }

        [ActionNameAttribute("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try {
            
                t_cozum cozum = _db2.t_cozum.FirstOrDefault(x => x.cozum_id == id);
                _db2.t_cozum.DeleteObject(cozum);
                _db2.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}