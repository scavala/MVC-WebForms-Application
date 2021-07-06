using DALL.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rwa_mvc.Models.ViewModel
{
    public class PotkategorijaEditVm
    {
        public Potkategorija Potkategorija { get; set; }
        public int IDKategorija { get; set; }
        public IEnumerable<Kategorija> Kategorije { get; set; }

    }
}