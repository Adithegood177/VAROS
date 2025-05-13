using System;

public class Lakos
{
	private string nev;
	private int eletkor;
	private string lakcim;
	private decimal penzOsszeg;

	public string Nev { get => nev; }
	public int Eletkor { get => eletkor; }
	public string Lakcim { get => lakcim; }
	public decimal PenzOsszeg { get => penzOsszeg; }

	public Lakos(string nev, int eletkor, string lakcim, decimal penzOsszeg)
	{
		if (string.IsNullOrEmpty(nev)) throw new ArgumentException("A név nem lehet üres!");
		if (eletkor < 0) throw new ArgumentException("Az életkor nem lehet negatív!");
		if (string.IsNullOrEmpty(lakcim)) throw new ArgumentException("A lakcím nem lehet üres!");
		if (penzOsszeg < 0) throw new ArgumentException("A pénzösszeg nem lehet negatív!");

		this.nev = nev;
		this.eletkor = eletkor;
		this.lakcim = lakcim;
		this.penzOsszeg = penzOsszeg;
	}

	public bool Fizet(decimal osszeg)
	{
		if (osszeg <= 0) return false;
		if (penzOsszeg >= osszeg)
		{
			penzOsszeg -= osszeg;
			return true;
		}
		return false;
	}

	public void BelepSzolgaltatasba(object szolgaltatas)
	{
		switch (szolgaltatas)
		{
			case Konyvtar konyvtar:
				konyvtar.Belepes(this);
				break;
			case Kavezo kavezo:
				kavezo.Rendel(this);
				break;
			case Posta posta:
				posta.SorbanAllas();
				break;
			case Bevasarlokozpont kozpont:
				kozpont.Belep(this);
				break;
		}
	}

	public bool HasznalKozlekedest(KozlekedesiJarmu jarmu)
	{
		if (jarmu != null && Fizet(jarmu.JegyAr))
		{
			return jarmu.Felszallas(this);
		}
		return false;
	}
}