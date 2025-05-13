using System;

public class EtelItal
{
	private string nev;
	private decimal ar;
	private bool isEtel;
	private int koffeinTartalom;
	private int kaloria;

	public string Nev { get => nev; }
	public decimal Ar { get => ar; }
	public bool IsEtel { get => isEtel; }
	public int KoffeinTartalom { get => koffeinTartalom; }
	public int Kaloria { get => kaloria; }

	public EtelItal(string nev, decimal ar, bool isEtel, int koffeinTartalom, int kaloria)
	{
		if (string.IsNullOrEmpty(nev)) throw new ArgumentException("A név nem lehet üres!");
		if (ar <= 0) throw new ArgumentException("Az ár nem lehet nulla vagy negatív!");
		if (kaloria < 0) throw new ArgumentException("A kalória nem lehet negatív!");
		if (koffeinTartalom < 0) throw new ArgumentException("A koffein tartalom nem lehet negatív!");

		this.nev = nev;
		this.ar = ar;
		this.isEtel = isEtel;
		this.koffeinTartalom = koffeinTartalom;
		this.kaloria = kaloria;
	}

	public override string ToString()
	{
		return $"{nev} - {ar:C} ({(isEtel ? "Étel" : "Ital")}, {kaloria} kcal" + 
			   (koffeinTartalom > 0 ? $", {koffeinTartalom}mg koffein" : "") + ")";
	}
}