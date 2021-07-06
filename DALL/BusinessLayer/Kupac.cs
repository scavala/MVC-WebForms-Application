using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

/// <summary>
/// Summary description for Kupac
/// </summary>
/// [Serializable]
[Serializable]

public class Kupac
{
    public int IDKupac { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; }
    public int GradID { get; set; }


	public Kupac()
	{
	
	}

    public object this[string propertyName]
    {
        get
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            return property.GetValue(this, null);
        }
        set
        {
            PropertyInfo property = GetType().GetProperty(propertyName);
            property.SetValue(this, value, null);
        }
    }
}