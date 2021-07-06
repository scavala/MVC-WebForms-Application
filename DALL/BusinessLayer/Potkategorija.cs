using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DALL.BusinessLayer
{
    public class Potkategorija
    {

        public int IDPotkategorija { get; set; }

        [Display(Name = "Kategorija")]
        [Required(ErrorMessage = "Kategorija je obavezana")]
        public int KategorijaID { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan")]
        public string Naziv { get; set; }
    }
}