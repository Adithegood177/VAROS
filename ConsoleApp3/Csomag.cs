using System;

public class Csomag
{
	private string kuldo;
	private string cimzett;
	private double suly;
	private decimal ar;
	private CsomagAllapot allapot;

	public string Kuldo { get => kuldo; }
	public string Cimzett { get => cimzett; }
	public double Suly { get => suly; }
	public decimal Ar { get => ar; }
	public CsomagAllapot Allapot { get => allapot; }

	public Csomag(string kuldo, string cimzett, double suly, decimal ar)
	{
		if (string.IsNullOrEmpty(kuldo)) throw new ArgumentException("A küldő neve nem lehet üres!");
		if (string.IsNullOrEmpty(cimzett)) throw new ArgumentException("A címzett neve nem lehet üres!");
		if (suly <= 0) throw new ArgumentException("A súly nem lehet nulla vagy negatív!");
		if (ar < 0) throw new ArgumentException("Az ár nem lehet negatív!");

		this.kuldo = kuldo;
		this.cimzett = cimzett;
		this.suly = suly;
		this.ar = ar;
		this.allapot = CsomagAllapot.Letrehozva;
	}

	public bool Feladas()
	{
		if (allapot != CsomagAllapot.Letrehozva) return false;
		allapot = CsomagAllapot.Feladva;
		return true;
	}

	public bool Szallitas()
	{
		if (allapot != CsomagAllapot.Feladva) return false;
		allapot = CsomagAllapot.Szallitas;
		return true;
	}

	public bool Kiszallitas()
	{
		if (allapot != CsomagAllapot.Szallitas) return false;
		allapot = CsomagAllapot.Kezbesitve;
		return true;
	}

	public override string ToString()
	{
		return $"Csomag: {kuldo} -> {cimzett}, {suly}kg, {ar:C}, Állapot: {allapot}";
	}
}

public enum CsomagAllapot
{
	Letrehozva,
	Feladva,
	Szallitas,
	Kezbesitve
}