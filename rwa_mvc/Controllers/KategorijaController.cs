using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

using System.Web.Mvc;
using DAL;
using DALL.BusinessLayer;
using PagedList;

namespace rwa_mvc.Controllers
{
    [Authorize]
    public class KategorijaController : Controller
    {


     

        public ActionResult Index(int? page)
        {
            var model = Repozitorij.GetKategorije();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Delete(int id)
        {
            try
            {
                Repozitorij.KaskadnoObrisiKategoriju(id);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "obrisan");

            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "nije obrisan");
            }

        }

        public ActionResult GetNaziv(int id)
        {

            return Content(Repozitorij.GetKategorija(id).Naziv);
        }
        public ActionResult Edit(int id)
        {

            var model = Repozitorij.GetKategorija(id);
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kategorija k)
        {

            try
            {
                Repozitorij.InsertKategorija(k);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        [HttpPost]
        public ActionResult Edit(Kategorija k)
        {

            try
            {
                Repozitorij.UpdateKategorija(k);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }


    }

}