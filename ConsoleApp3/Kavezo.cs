using System;
using System.Collections.Generic;
using System.Linq;

public class Kavezo
{
	private List<EtelItal> menu;
	private List<Lakos> vendegLista;
	private Dictionary<Lakos, List<EtelItal>> rendelesek;

	public Kavezo()
	{
		menu = new List<EtelItal>();
		vendegLista = new List<Lakos>();
		rendelesek = new Dictionary<Lakos, List<EtelItal>>();
	}

	public void MenuHozzaadas(EtelItal etelItal)
	{
		if (etelItal != null && !menu.Contains(etelItal))
		{
			menu.Add(etelItal);
		}
	}

	public void Rendel(Lakos lakos)
	{
		if (lakos == null || menu.Count == 0) return;

		if (!vendegLista.Contains(lakos))
		{
			vendegLista.Add(lakos);
		}

		Random rnd = new Random();
		EtelItal rendeltTetel = menu[rnd.Next(menu.Count)];

		if (lakos.Fizet(rendeltTetel.Ar))
		{
			if (!rendelesek.ContainsKey(lakos))
			{
				rendelesek[lakos] = new List<EtelItal>();
			}
			rendelesek[lakos].Add(rendeltTetel);
		}
	}

	public void Fogyaszt(Lakos lakos)
	{
		if (lakos != null && rendelesek.ContainsKey(lakos))
		{
			rendelesek.Remove(lakos);
			vendegLista.Remove(lakos);
		}
	}

	public List<EtelItal> GetMenu()
	{
		return new List<EtelItal>(menu);
	}

	public int VendegekSzama()
	{
		return vendegLista.Count;
	}
}