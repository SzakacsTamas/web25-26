using kraterek;
using System.Globalization;

List<adatok> kraterek = new List<adatok>();
string[] sorok = File.ReadAllLines("felszin_tvesszo.txt");

for (int i = 0; i < sorok.Length; i++)
{
    string[] adatok = sorok[i].Split("\t");
    adatok adat = new adatok(double.Parse(adatok[0]), double.Parse(adatok[1]), double.Parse(adatok[2]), adatok[3]);
    kraterek.Add(adat);
}


//2.Feladat
Console.WriteLine("2.Feladat");
int szamlalo = 0;
foreach(adatok adat in kraterek)
{
    szamlalo++;
}
Console.WriteLine($"A kráterek száma: {szamlalo}");

//3.Feladat
Console.WriteLine("3.Feladat");
Console.Write("Kérem egy kráter nevét: ");
string nev1=Console.ReadLine();
double kraterX = 0;
double kraterY = 0;
double kraterSugara = 0;
foreach (adatok adat in kraterek)
{
    if (adat.kraterNev == nev1
        
        
        
        )
    {

        kraterSugara = adat.kraterSugar;
        kraterX = adat.xKoordinata;
        kraterY = adat.yKoordinata;
    }
}

Console.WriteLine($"A(z) {nev1} középpontja X={kraterX} Y={kraterY} sugara R={kraterSugara}.");

//4.Feladat
Console.WriteLine("4.Feladat");
double legnagyobbKrater = 0;
string legnagyobbKraterNeve = "";
foreach(adatok adat in kraterek)
{
    if (legnagyobbKrater < adat.kraterSugar)
    {
        legnagyobbKrater=adat.kraterSugar;
        legnagyobbKraterNeve = adat.kraterNev;
    }
}

Console.WriteLine($"A legnagyobb kráter neve és sugara: {legnagyobbKraterNeve} {legnagyobbKrater}");

//5.Feladat
static double Tavolsag(double x1, double y1, double x2, double y2)
{
    double dx = x2 - x1;
    double dy = y2 - y1;

    return Math.Sqrt(dx * dx + dy * dy);
}

//6.Feladat
Console.WriteLine("6.Feladat");
Console.Write("Add meg egy kráter nevét: ");
string nev = Console.ReadLine();

adatok kivalasztott = null;

// 1️⃣ Megkeressük a kiválasztott krátert
foreach (adatok k in kraterek)
{
    if (k.kraterNev == nev)
    {
        kivalasztott = k;
        break;
    }
}

if (kivalasztott != null)
{
    List<string> nincsKozoResz = new List<string>();

    // 2️⃣ Végigmegyünk az összes kráteren
    foreach (adatok masik in kraterek)
    {
        if (masik != kivalasztott) // ne önmagával hasonlítsuk
        {
            double tav = Tavolsag(
                kivalasztott.xKoordinata,
                kivalasztott.yKoordinata,
                masik.xKoordinata,
                masik.yKoordinata
            );

            // 3️⃣ Feltétel ellenőrzés
            if (tav > (kivalasztott.kraterSugar + masik.kraterSugar))
            {
                nincsKozoResz.Add(masik.kraterNev);
            }
        }
    }

    // 4️⃣ Kiírás vessző + szóköz elválasztással
    if (nincsKozoResz.Count > 0)
    {
        for (int i = 0; i < nincsKozoResz.Count; i++)
        {
            Console.Write(nincsKozoResz[i]);

            if (i < nincsKozoResz.Count - 1)
            {
                Console.Write(", ");
            }
        }
    }
}

//8.Feldaat

string tartalom = "";

foreach (adatok k in kraterek)
{
    double terulet = Math.Round(k.kraterSugar * k.kraterSugar * 3.14, 2);

    tartalom += terulet.ToString("F2", CultureInfo.InvariantCulture)
                + "\t"
                + k.kraterNev
                + "\n";
}

File.WriteAllText("terulet.txt", tartalom);