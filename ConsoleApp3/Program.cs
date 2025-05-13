using System;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Városi Szolgáltató Rendszer Szimuláció\n");
		
		var varos = new Varos();

		
		Console.WriteLine("Lakosok létrehozása...");
		for (int i = 1; i <= 10; i++)
		{
			varos.HozzaadLakos(new Lakos($"Lakos{i}", 20 + i, $"Utca {i}", 10000 + i * 1000));
		}

		
		Console.WriteLine("\nKönyvtár létrehozása és könyvek hozzáadása...");
		var konyvtar = new Konyvtar(50);
		varos.SzolgaltatasInditasa(konyvtar);

		konyvtar.Hozzaad(new Konyv("1984", "George Orwell", 328, 2500, 3));
		konyvtar.Hozzaad(new Konyv("A Gyűrűk Ura", "J.R.R. Tolkien", 1178, 4500, 2));
		konyvtar.Hozzaad(new Konyv("Harry Potter", "J.K. Rowling", 309, 3200, 5));
		konyvtar.Hozzaad(new Konyv("Alapítvány", "Isaac Asimov", 255, 2800, 1));
		konyvtar.Hozzaad(new Konyv("Dűne", "Frank Herbert", 412, 3800, 2));

		Console.WriteLine("\nKönyvtár használata...");
		var lakos1 = varos.Lakosok[0];
		var lakos2 = varos.Lakosok[1];
		var lakos3 = varos.Lakosok[2];

		konyvtar.Belepes(lakos1);
		konyvtar.Belepes(lakos2);
		konyvtar.Belepes(lakos3);

		var konyv1 = konyvtar.Kolcsonoz("1984");
		var konyv2 = konyvtar.Kolcsonoz("Harry Potter");
		var konyv3 = konyvtar.Kolcsonoz("Dűne");

		Console.WriteLine($"Kölcsönzött könyvek: {konyv1}, {konyv2}, {konyv3}");

		Console.WriteLine("\nKözlekedés szimuláció...");
		var busz = new KozlekedesiJarmu("1-es busz", "Központ - Kertváros", 30, 350);
		varos.SzolgaltatasInditasa(busz);

		for (int i = 0; i < 5; i++)
		{
			if (busz.Felszallas(varos.Lakosok[i]))
			{
				Console.WriteLine($"{varos.Lakosok[i].Nev} felszállt a buszra");
			}
		}

		Console.WriteLine("\nKávézó szimuláció...");
		var kavezo = new Kavezo();
		varos.SzolgaltatasInditasa(kavezo);

		var kave = new EtelItal("Espresso", 1500, false, 100, 5);
		var sutemeny = new EtelItal("Tiramisu", 1200, true, 30, 350);

		kavezo.MenuHozzaadas(kave);
		kavezo.MenuHozzaadas(sutemeny);

		kavezo.Rendel(lakos1);
		kavezo.Fogyaszt(lakos1);

 		Console.WriteLine("\nPosta szimuláció...");
		var posta = new Posta();
		varos.SzolgaltatasInditasa(posta);

		var csomag = new Csomag(lakos1.Nev, lakos2.Nev, 2.5, 1500);
		if (posta.Kuldes(csomag))
		{
			Console.WriteLine($"Csomag feladva: {csomag}");
		}
		if (posta.Atvetel(csomag, lakos2))
		{
			Console.WriteLine($"Csomag kézbesítve: {csomag}");
		}

		Console.WriteLine("\nEgy nap szimulációja...");
		varos.NapFutasa();

		Console.WriteLine("\nVáros statisztika:");
		Console.WriteLine(varos.VarosStatusza());
	}
}