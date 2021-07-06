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
    public class ProizvodiController : Controller
    {

        public ActionResult Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var model = Repozitorij.GetProizvodi();

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Edit(int id)
        {

            var proizvod = Repozitorij.GetProizvod(id);
            var model = new ProizvodEditVm
            {
                Proizvod = proizvod,
                IDPotkategorija = proizvod.PotkategorijaID,
                Potkategorije = Repozitorij.GetPotkategorije()

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Proizvod p)
        {
            try
            {
                Repozitorij.UpdateProizvod(p);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult Create()
        {
            var model = new ProizvodEditVm
            {
                Potkategorije = Repozitorij.GetPotkategorije()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Proizvod p)
        {

            try
            {
                Repozitorij.InsertProizvod(p);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }


        public ActionResult Delete(int id)
        {
            try
            {
                Repozitorij.KaskadnoObrisiProizvod(id);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "obrisan");

            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "nije obrisan");
            }

        }
    }
}