using System;
using System.Collections.Generic;
using System.Linq;

public class Konyvtar
{
	private List<Konyv> konyvek;
	private int maxKapacitas;
	private List<Lakos> bentlevok;

	public IReadOnlyList<Konyv> Konyvek => konyvek;
	public IReadOnlyList<Lakos> Bentlevok => bentlevok;
	public int MaxKapacitas => maxKapacitas;

	public Konyvtar(int maxKapacitas)
	{
		if (maxKapacitas <= 0) throw new ArgumentException("A maximális kapacitás nem lehet nulla vagy negatív!");

		this.maxKapacitas = maxKapacitas;
		konyvek = new List<Konyv>();
		bentlevok = new List<Lakos>();
	}

	public bool Belepes(Lakos lakos)
	{
		if (lakos == null) return false;
		if (bentlevok.Contains(lakos)) return false;
		if (bentlevok.Count >= maxKapacitas) return false;

		bentlevok.Add(lakos);
		return true;
	}

	public bool Kilepes(Lakos lakos)
	{
		if (lakos == null) return false;
		return bentlevok.Remove(lakos);
	}

	public Konyv Kolcsonoz(string cim)
	{
		var konyv = konyvek.FirstOrDefault(k => k.Cim == cim && k.PeldanySzam > 0);
		if (konyv != null)
		{
			konyv.PeldanySzam--;
			return konyv;
		}
		return null;
	}

	public bool Visszahoz(Konyv konyv)
	{
		if (konyv == null) return false;
		if (!konyvek.Contains(konyv)) return false;

		konyv.PeldanySzam++;
		return true;
	}

	public bool Hozzaad(Konyv konyv)
	{
		if (konyv == null) return false;
		if (konyvek.Any(k => k.Cim == konyv.Cim)) return false;

		konyvek.Add(konyv);
		return true;
	}

	public List<Konyv> KonyvKereses(string szerzo = null, string cim = null)
	{
		return konyvek.Where(k => 
			(szerzo == null || k.Szerzo.Contains(szerzo)) &&
			(cim == null || k.Cim.Contains(cim))
		).ToList();
	}

	public override string ToString()
	{
		return $"Könyvtár: {konyvek.Count} könyv, {bentlevok.Count}/{maxKapacitas} látogató";
	}
}