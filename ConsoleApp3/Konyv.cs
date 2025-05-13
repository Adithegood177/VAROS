using System;

public class Konyv
{
	private string cim;
	private string szerzo;
	private int oldalSzam;
	private decimal ertek;
	private int peldanySzam;

	public string Cim { get => cim; }
	public string Szerzo { get => szerzo; }
	public int OldalSzam { get => oldalSzam; }
	public decimal Ertek { get => ertek; }
	public int PeldanySzam
	{
		get => peldanySzam;
		set => peldanySzam = value >= 0 ? value : 0;
	}

	public Konyv(string cim, string szerzo, int oldalSzam, decimal ertek, int peldanySzam)
	{
		if (string.IsNullOrEmpty(cim)) throw new ArgumentException("A cím nem lehet üres!");
		if (string.IsNullOrEmpty(szerzo)) throw new ArgumentException("A szerző nem lehet üres!");
		if (oldalSzam <= 0) throw new ArgumentException("Az oldalszám nem lehet nulla vagy negatív!");
		if (ertek < 0) throw new ArgumentException("Az érték nem lehet negatív!");
		if (peldanySzam < 0) throw new ArgumentException("A példányszám nem lehet negatív!");

		this.cim = cim;
		this.szerzo = szerzo;
		this.oldalSzam = oldalSzam;
		this.ertek = ertek;
		this.peldanySzam = peldanySzam;
	}

	public override string ToString()
	{
		return $"{cim} - {szerzo} ({oldalSzam} oldal, {ertek:C}, {peldanySzam} példány)";
	}
}