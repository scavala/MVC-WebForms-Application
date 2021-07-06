using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using DALL.BusinessLayer;

namespace DAL
{

    public static class Repozitorij
    {

        public static DataSet ds { get; set; }
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static KreditnaKartica GetKreditnaKartica(int idKK)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetKreditnaKartica", idKK);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                KreditnaKartica k = new KreditnaKartica();
                k.Tip = row["Tip"].ToString();
                return k;
            }
            else
                return new KreditnaKartica { Tip = "-" };
        }
        public static string GetNazivProizvoda(int id)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetNazivProizvoda", id);
            if (ds.Tables[0].Rows.Count > 0)
            {

                return ds.Tables[0].Rows[0]["Naziv"].ToString();
            }
            else
                return "-";
        }

        public static Komercijalist GetKomercijalist(int idKomercijalist)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetKomercijalist", idKomercijalist);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                Komercijalist k = new Komercijalist();
                k.Ime = row["Ime"].ToString();
                k.Prezime = row["Prezime"].ToString();
                return k;
            }
            else
                return new Komercijalist { Ime = "-", Prezime = "-" };
        }

        public static int UpdateKupac(Kupac k)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateKupac", k.IDKupac, k.Ime, k.Prezime, k.Email, k.Telefon, k.GradID);
        }


        public static List<Drzava> GetDrzave()
        {
            List<Drzava> kolekcijaDrzava = new List<Drzava>();
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiDrzave");

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                kolekcijaDrzava.Add(
                new Drzava
                {
                    IDDrzava = (int)row["IDDrzava"],
                    Naziv = row["Naziv"].ToString()

                });

            }
            return kolekcijaDrzava;
        }

        public static List<Grad> GetGradoviIzDrzave(int drzavaID)
        {
            List<Grad> kolekcijaGradova = new List<Grad>();
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiGradove", drzavaID);

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                kolekcijaGradova.Add(
                new Grad
                {
                    IDGrad = (int)row["IDGrad"],
                    Naziv = row["Naziv"].ToString(),
                    DrzavaID = (int)row["DrzavaID"]
                });

            }
            return kolekcijaGradova;
        }

        public static Kupac GetOdabraniKupac(int kupacID)
        {
            Kupac kupac = new Kupac();
            ds = SqlHelper.ExecuteDataset(cs, "DetaljiKupca", kupacID);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                kupac.IDKupac = (int)row["IDKupac"];
                kupac.Ime = row["ime"].ToString();
                kupac.Prezime = row["prezime"].ToString();
                kupac.Email = row["email"].ToString();
                kupac.Telefon = row["telefon"].ToString();
                kupac.GradID = int.TryParse(row["GradID"].ToString(), out int tmp) ? tmp : 0;
            }
            return kupac;
        }
      

        public static Grad GetGrad(int gradID)
        {
            Grad grad = new Grad();
            ds = SqlHelper.ExecuteDataset(cs, "GetGrad", gradID);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int tmp;
                grad.IDGrad = (int)row["IDGrad"];
                grad.Naziv = row["Naziv"].ToString();


                grad.DrzavaID = int.TryParse(row["DrzavaID"].ToString(), out tmp) ? tmp : 0;
            }
            return grad;
        }



        public static List<Proizvod> GetProizvodi()
        {
            List<Proizvod> kolekcijaProizvoda = new List<Proizvod>();
            ds = SqlHelper.ExecuteDataset(cs, "GetProizvodi");

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                int length = row["CijenaBezPDV"].ToString().Length;
                kolekcijaProizvoda.Add(


                new Proizvod
                {
                    IDProizvod = (int)row["IDProizvod"],
                    Naziv = row["Naziv"].ToString(),
                    BrojProizvoda = row["BrojProizvoda"].ToString(),
                    Boja = row["Boja"].ToString(),
                    MinimalnaKolicina = int.TryParse(row["MinimalnaKolicinaNaSkladistu"].ToString(), out int kolicina) ? kolicina : 0,
                    CijenaBezPDV = row["CijenaBezPDV"].ToString().Remove(length - 2),
                    PotkategorijaID = int.TryParse(row["PotkategorijaID"].ToString(), out int p) ? p : 0,
                });

            }
            return kolekcijaProizvoda;
        }

        public static void KaskadnoObrisiKategoriju(int id)
        {
            SqlHelper.ExecuteDataset(cs, "KaskadnoObrisiKategoriju", id);

        }
        public static void KaskadnoObrisiProizvod(int id)
        {
            SqlHelper.ExecuteDataset(cs, "KaskadnoObrisiProizvod", id);

        }

        public static void KaskadnoObrisiPotkategoriju(int id)
        {
            SqlHelper.ExecuteDataset(cs, "KaskadnoObrisiPotkategoriju", id);

        }


        public static Kategorija GetKategorija(int idKK)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetKategorija", idKK);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                Kategorija k = new Kategorija();
                k.Naziv = row["Naziv"].ToString();
                k.IDKategorija = idKK;
                return k;
            }
            else
                return new Kategorija { Naziv = "-" };
        }


        public static int UpdateKategorija(Kategorija k)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateKategorija", k.IDKategorija, k.Naziv);
        }
        public static int InsertKategorija(Kategorija k)
        {
            return SqlHelper.ExecuteNonQuery(cs, "InsertKategorija", k.Naziv);
        }
        public static int InsertPotkategorija(Potkategorija p)
        {
            return SqlHelper.ExecuteNonQuery(cs, "InsertPotkategorija", p.Naziv, p.KategorijaID);
        }
        public static int UpdatePotkategorija(Potkategorija p)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdatePotkategorija", p.IDPotkategorija, p.Naziv, p.KategorijaID);
        }
        public static int InsertProizvod(Proizvod p)
        {
            return SqlHelper.ExecuteNonQuery(cs, "InsertProizvod", p.Naziv, p.BrojProizvoda, p.Boja, p.MinimalnaKolicina, p.CijenaBezPDV, p.PotkategorijaID);
        }
        public static int UpdateProizvod(Proizvod p)
        {
            return SqlHelper.ExecuteNonQuery(cs, "UpdateProizvod", p.IDProizvod, p.Naziv, p.BrojProizvoda, p.Boja, p.MinimalnaKolicina, p.CijenaBezPDV, p.PotkategorijaID);
        }


        public static Proizvod GetProizvod(int id)
        {
            ds = SqlHelper.ExecuteDataset(cs, "GetProizvod", id);
            if (ds.Tables[0].Rows.Count > 0)
            {

                DataRow row = ds.Tables[0].Rows[0];
                Proizvod p = new Proizvod();
                int length = row["CijenaBezPDV"].ToString().Length;

                p.IDProizvod = (int)row["IDProizvod"];
                p.Naziv = row["Naziv"].ToString();
                p.BrojProizvoda = row["BrojProizvoda"].ToString();
                p.Boja = row["Boja"].ToString();
                p.MinimalnaKolicina = int.TryParse(row["MinimalnaKolicinaNaSkladistu"].ToString(), out int kolicina) ? kolicina : 0;
                p.CijenaBezPDV = row["CijenaBezPDV"].ToString().Remove(length - 2);
                p.PotkategorijaID = int.TryParse(row["PotkategorijaID"].ToString(), out int pid) ? pid : 0;

                return p;
            }
            else
                throw new Exception("Nema tog proizvoda!");
        }



        public static List<Kupac> GetKupci()
        {
            List<Kupac> koelkcijaKupaca = new List<Kupac>();
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiKupce");

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                koelkcijaKupaca.Add(

                new Kupac
                {
                    IDKupac = (int)row["IDKupac"],
                    Ime = row["ime"].ToString(),
                    Prezime = row["prezime"].ToString(),
                    Email = row["email"].ToString(),
                    Telefon = row["telefon"].ToString(),
                    GradID = int.TryParse(row["GradID"].ToString(), out int tmp) ? tmp : 0
                });

            }
            return koelkcijaKupaca;
        }

        public static List<Kategorija> GetKategorije()
        {
            List<Kategorija> kolekcijaKategorija = new List<Kategorija>();
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiKategorije");

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                kolekcijaKategorija.Add(
                new Kategorija
                {
                    IDKategorija = (int)row["IDKategorija"],
                    Naziv = row["Naziv"].ToString()

                });

            }
            return kolekcijaKategorija;
        }
        public static List<Potkategorija> GetPotkategorije()
        {
            List<Potkategorija> kolekcijaPotkategorija = new List<Potkategorija>();
            ds = SqlHelper.ExecuteDataset(cs, "DohvatiPotkategorije");

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                kolekcijaPotkategorija.Add(
                new Potkategorija
                {
                    IDPotkategorija = (int)row["IDPotkategorija"],
                    Naziv = row["Naziv"].ToString(),
                    KategorijaID = (int)row["KategorijaID"]

                });

            }
            return kolekcijaPotkategorija;
        }



        public static Potkategorija GetPotkategorija(int id)
        {
            Potkategorija potkategorija = new Potkategorija();
            ds = SqlHelper.ExecuteDataset(cs, "GetPotkategorija", id);

            foreach (DataRow row in ds.Tables[0].Rows)
            {

                potkategorija.IDPotkategorija = id;
                potkategorija.KategorijaID = (int)row["KategorijaID"];
                potkategorija.Naziv = row["Naziv"].ToString();

            }
            return potkategorija;
        }

    }
}
