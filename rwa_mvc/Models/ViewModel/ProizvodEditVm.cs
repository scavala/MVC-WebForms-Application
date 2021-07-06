using DALL.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rwa_mvc.Models.ViewModel
{
    public class ProizvodEditVm
    {
        public Proizvod Proizvod { get; set; }
        public int IDPotkategorija { get; set; }
        public IEnumerable<Potkategorija> Potkategorije { get; set; }
    }
}