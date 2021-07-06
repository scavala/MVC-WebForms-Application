using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class KreditnaKartica
{

    public int IDKreditnaKartica { get; set; }
    public string Tip { get; set; }
    public string Broj { get; set; }
    public short IstekMjesec { get; set; }
    public short IstekGodina { get; set; }

	public KreditnaKartica()
	{
	}
}