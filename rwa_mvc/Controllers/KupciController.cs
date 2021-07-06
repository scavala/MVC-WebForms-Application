using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using rwa_mvc.App_Start;
using rwa_mvc.Models.DataTransferObject;

namespace rwa_mvc.Controllers
{
    public class KupciController : ApiController
    {
        [HttpGet]   
        public IHttpActionResult GetKupci()
        {

            var kupci = Repozitorij.GetKupci();
            var kupciDTO = AutoMapperConfig.Mapper.Map<IEnumerable<KupacDTO>>(kupci);
            return Ok(kupciDTO);

        }

        [HttpGet]
        public IHttpActionResult GetKupac(int id)
        {
            var kupac = Repozitorij.GetOdabraniKupac(id);
            if (kupac == null) return NotFound();
            var kupacDTO= AutoMapperConfig.Mapper.Map<KupacDTO>(kupac);

            return Ok(kupacDTO);
        }


    }
}
