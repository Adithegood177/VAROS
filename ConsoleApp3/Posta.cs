using System;
using System.Collections.Generic;
using System.Linq;

public class Posta
{
	private List<Csomag> csomagok;
	private Queue<Lakos> sorbanAllok;
	private int maxSorHossz;

	public Posta(int maxSorHossz = 10)
	{
		this.maxSorHossz = maxSorHossz;
		csomagok = new List<Csomag>();
		sorbanAllok = new Queue<Lakos>();
	}

	public bool SorbanAllas(Lakos lakos)
	{
		if (lakos == null) return false;
		if (sorbanAllok.Count >= maxSorHossz) return false;

		sorbanAllok.Enqueue(lakos);
		return true;
	}

	public void SorbanAllasKezeles()
	{
		if (sorbanAllok.Count > 0)
		{
			Lakos kovetkezo = sorbanAllok.Dequeue();
		}
	}

	public bool Kuldes(Csomag csomag)
	{
		if (csomag == null || !csomag.Feladas()) return false;

		csomagok.Add(csomag);
		csomag.Szallitas();
		return true;
	}

	public bool Atvetel(Csomag csomag, Lakos cimzett)
	{
		if (csomag == null || cimzett == null) return false;
		if (!csomagok.Contains(csomag)) return false;
		if (csomag.Cimzett != cimzett.Nev) return false;

		csomagok.Remove(csomag);
		csomag.Kiszallitas();
		return true;
	}

	public int SorbanAllokSzama()
	{
		return sorbanAllok.Count;
	}

	public int CsomagokSzama()
	{
		return csomagok.Count;
	}

	public List<Csomag> GetCsomagokCimzettnek(string cimzett)
	{
		return csomagok.Where(cs => cs.Cimzett == cimzett).ToList();
	}
}