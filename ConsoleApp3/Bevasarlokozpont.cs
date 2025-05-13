using System;
using System.Collections.Generic;
using System.Linq;

public class Bevasarlokozpont
{
	private Dictionary<string, decimal> boltok; 
	private List<Lakos> latogatok;
	private int maxKapacitas;

	public Bevasarlokozpont(int maxKapacitas = 100)
	{
		if (maxKapacitas <= 0) throw new ArgumentException("A maximális kapacitás nem lehet nulla vagy negatív!");
		
		this.maxKapacitas = maxKapacitas;
		boltok = new Dictionary<string, decimal>();
		latogatok = new List<Lakos>();
	}

	public bool UjBolt(string boltNev, decimal atlagKoltes)
	{
		if (string.IsNullOrEmpty(boltNev)) return false;
		if (atlagKoltes < 0) return false;
		if (boltok.ContainsKey(boltNev)) return false;

		boltok.Add(boltNev, atlagKoltes);
		return true;
	}

	public bool Belep(Lakos lakos)
	{
		if (lakos == null) return false;
		if (latogatok.Count >= maxKapacitas) return false;
		if (latogatok.Contains(lakos)) return false;

		latogatok.Add(lakos);
		return true;
	}

	public bool Kilep(Lakos lakos)
	{
		if (lakos == null) return false;
		return latogatok.Remove(lakos);
	}

	public bool Kolt(Lakos lakos, string bolt, decimal osszeg)
	{
		if (lakos == null || string.IsNullOrEmpty(bolt)) return false;
		if (!boltok.ContainsKey(bolt)) return false;
		if (!latogatok.Contains(lakos)) return false;
		
		return lakos.Fizet(osszeg);
	}

	public int LatogatokSzama()
	{
		return latogatok.Count;
	}

	public List<string> GetBoltok()
	{
		return boltok.Keys.ToList();
	}

	public decimal GetAtlagKoltes(string bolt)
	{
		return boltok.ContainsKey(bolt) ? boltok[bolt] : 0;
	}

	public override string ToString()
	{
		return $"Bevásárlóközpont: {boltok.Count} bolt, {latogatok.Count}/{maxKapacitas} látogató";
	}
}