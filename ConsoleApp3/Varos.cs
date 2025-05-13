using System;
using System.Collections.Generic;

public class Varos
{
	private List<Lakos> lakosok;
	private List<Konyvtar> konyvtarak;
	private List<KozlekedesiJarmu> jarmuvek;
	private List<Posta> postak;
	private List<Kavezo> kavezok;
	private List<Bevasarlokozpont> bevasarlokozpontok;

	public IReadOnlyList<Lakos> Lakosok => lakosok;

	public Varos()
	{
		lakosok = new List<Lakos>();
		konyvtarak = new List<Konyvtar>();
		jarmuvek = new List<KozlekedesiJarmu>();
		postak = new List<Posta>();
		kavezok = new List<Kavezo>();
		bevasarlokozpontok = new List<Bevasarlokozpont>();
	}

	public void HozzaadLakos(Lakos lakos)
	{
		if (lakos != null)
		{
			lakosok.Add(lakos);
		}
	}

	public void SzolgaltatasInditasa(object szolgaltatas)
	{
		if (szolgaltatas == null) return;

		switch (szolgaltatas)
		{
			case Konyvtar k:
				konyvtarak.Add(k);
				break;
			case KozlekedesiJarmu j:
				jarmuvek.Add(j);
				break;
			case Posta p:
				postak.Add(p);
				break;
			case Kavezo ka:
				kavezok.Add(ka);
				break;
			case Bevasarlokozpont b:
				bevasarlokozpontok.Add(b);
				break;
		}
	}

	public void NapFutasa()
	{
		foreach (var jarmu in jarmuvek)
		{
			jarmu.Lepes();
		}

		foreach (var lakos in lakosok)
		{
			Random rnd = new Random();
			int tevekenyseg = rnd.Next(5);

			switch (tevekenyseg)
			{
				case 0 when konyvtarak.Count > 0:
					lakos.BelepSzolgaltatasba(konyvtarak[0]);
					break;
				case 1 when postak.Count > 0:
					lakos.BelepSzolgaltatasba(postak[0]);
					break;
				case 2 when kavezok.Count > 0:
					lakos.BelepSzolgaltatasba(kavezok[0]);
					break;
				case 3 when bevasarlokozpontok.Count > 0:
					lakos.BelepSzolgaltatasba(bevasarlokozpontok[0]);
					break;
				case 4 when jarmuvek.Count > 0:
					lakos.HasznalKozlekedest(jarmuvek[0]);
					break;
			}
		}
	}

	public string VarosStatusza()
	{
		return $"Lakók száma: {lakosok.Count}\n" +
			   $"Könyvtárak száma: {konyvtarak.Count}\n" +
			   $"Járművek száma: {jarmuvek.Count}\n" +
			   $"Posták száma: {postak.Count}\n" +
			   $"Kávézók száma: {kavezok.Count}\n" +
			   $"Bevásárlóközpontok száma: {bevasarlokozpontok.Count}";
	}
}