using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Komercijalist
{
    public int IDKomercijalist { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    
    public string PunoIme
    {
        get { return Ime + " " + Prezime; }
    }


	public Komercijalist()
	{
	}
}