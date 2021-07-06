using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.BusinessLayer
{
    public class Proizvod
    {
        public int IDProizvod { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan")]
        [StringLength(50, ErrorMessage = "Maksimalna duljina je 50 znakova")]
        public string Naziv { get; set; }

        [Display(Name = "Broj Proizvoda")]
        [Required(ErrorMessage = "Broj proizvoda je obavezan")]
        [StringLength(50, ErrorMessage = "Maksimalna duljina je 50 znakova")]
        public string BrojProizvoda { get; set; }

        [Required(ErrorMessage = "Boja je obavezna")]
        [StringLength(50, ErrorMessage = "Maksimalna duljina je 50 znakova")]
        public string Boja { get; set; }

        [Display(Name = "Cijena Bez PDV(HRK)")]
        [Required(ErrorMessage = "Cijena je obavezna")]
        [RegularExpression(@"\d+(\,\d{1,2})?", ErrorMessage = "Unesite cijenu koristeći znak zarez da odvojite decimalni dio od cijelog. Max 2 decimale.")]
        public string CijenaBezPDV { get; set; }

        [Display(Name = "Minimalna Kolicina")]
        [Required(ErrorMessage = "Minimalna kolicina je obavezna")]
        [Range(0, int.MaxValue, ErrorMessage = "Unesite cijeli broj")]
        public int MinimalnaKolicina { get; set; }

        [Display(Name = "Potkategorija")]
        public int PotkategorijaID { get; set; }

        public Proizvod()
        {
        }
    }
}