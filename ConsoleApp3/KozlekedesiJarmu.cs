using System;
using System.Collections.Generic;

public class KozlekedesiJarmu
{
	private string nev;
	private string utvonal;
	private int ferohely;
	private decimal jegyAr;
	private List<Lakos> utasok;

	public string Nev { get => nev; }
	public string Utvonal { get => utvonal; }
	public int Ferohely { get => ferohely; }
	public decimal JegyAr { get => jegyAr; }
	public IReadOnlyList<Lakos> Utasok => utasok;

	public KozlekedesiJarmu(string nev, string utvonal, int ferohely, decimal jegyAr)
	{
		if (string.IsNullOrEmpty(nev)) throw new ArgumentException("A jármű neve nem lehet üres!");
		if (string.IsNullOrEmpty(utvonal)) throw new ArgumentException("Az útvonal nem lehet üres!");
		if (ferohely <= 0) throw new ArgumentException("A férőhely nem lehet nulla vagy negatív!");
		if (jegyAr < 0) throw new ArgumentException("A jegyár nem lehet negatív!");

		this.nev = nev;
		this.utvonal = utvonal;
		this.ferohely = ferohely;
		this.jegyAr = jegyAr;
		this.utasok = new List<Lakos>();
	}

	public bool Felszallas(Lakos lakos)
	{
		if (lakos == null) return false;
		if (utasok.Contains(lakos)) return false;
		if (utasok.Count >= ferohely) return false;

		utasok.Add(lakos);
		return true;
	}

	public void Lepes()
	{
		Console.WriteLine($"{nev} halad a(z) {utvonal} útvonalon. Utasok száma: {utasok.Count}/{ferohely}");
	}

	public override string ToString()
	{
		return $"{nev} ({utvonal}, {utasok.Count}/{ferohely} utas, jegyár: {jegyAr:C})";
	}
}