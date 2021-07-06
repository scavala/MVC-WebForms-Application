using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rwa_mvc.Models.ViewModel;
using DALL.BusinessLayer;
using DAL;

namespace rwa_mvc.Controllers
{

    [Authorize]
    public class PotkategorijaController : Controller
    {


        public ActionResult Index(int? page)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var model = Repozitorij.GetPotkategorije();

            return View(model.ToPagedList(pageNumber, pageSize));
        }



        public ActionResult Delete(int id)
        {
            try
            {
                Repozitorij.KaskadnoObrisiPotkategoriju(id);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "obrisan");

            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "nije obrisan");
            }

        }

        public ActionResult GetNaziv(int id)
        {

            return Content(Repozitorij.GetPotkategorija(id).Naziv);
        }


        public ActionResult Edit(int id)
        {

            var potkategorija = Repozitorij.GetPotkategorija(id);
            var model = new PotkategorijaEditVm
            {
                Potkategorija = potkategorija,
                IDKategorija = potkategorija.KategorijaID,
                Kategorije = Repozitorij.GetKategorije()

            };
            return View(model);
        }


        public ActionResult Create()
        {
            var model = new PotkategorijaEditVm
            {

                Kategorije = Repozitorij.GetKategorije()

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Potkategorija k)
        {

            try
            {
                Repozitorij.InsertPotkategorija(k);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        [HttpPost]
        public ActionResult Edit(Potkategorija p)
        {
            try
            {
                Repozitorij.UpdatePotkategorija(p);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }


    }

}