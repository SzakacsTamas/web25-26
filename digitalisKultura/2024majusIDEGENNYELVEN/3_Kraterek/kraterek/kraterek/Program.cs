using kraterek;
using System.Globalization;
using System.Text.RegularExpressions;

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
var kraterekSzama=kraterek.Count();
Console.WriteLine($"Kréterek szésfkihsdig: {kraterekSzama}");

//3.Feladat
Console.WriteLine("3.Feladat");
Console.Write("Kérem egy kráter nevét: ");
string bekertNev= Console.ReadLine();
var feladat3 = kraterek.Where(x => x.kraterNev == bekertNev).ToList();

foreach(var faszok in feladat3)
{
    Console.WriteLine($"A(z) {faszok.kraterNev} középpontja X={faszok.xKoordinata} Y={faszok.yKoordinata} sugara R={faszok.kraterSugar}.");
}

//4.Feladat
Console.WriteLine("4.Feladat");
var feladat4 = kraterek.Max(x => x.kraterSugar);
var feladat42 = kraterek.Where(x => x.kraterSugar == feladat4).ToList();
foreach(var asd in feladat42)
{
    Console.WriteLine($"A legnagyobb kárter neve és sugara: {asd.kraterNev} {asd.kraterSugar}");
}


//5.Feladat

static double tavolsag(double x1, double y1, double x2, double y2)
{
    return Math.Sqrt((x2-x1)*(x2-x1)+(y2-y1)*(y2-y1));
}

//6feladat
Console.WriteLine("6.Feladat");
Console.Write("Kérem egy kráter nevét: ");
string bekertNev2 = "Jacques Cassini";

var feladat6 =kraterek.Where(x=>x.kraterNev ==bekertNev2).ToList();
double bekertX = 0.0;
double bekertY = 0.0;
double bekertSugar = 0.0;
foreach (var asd in feladat6)
{
bekertSugar = asd.kraterSugar;
    bekertX = asd.xKoordinata;
    bekertY = asd.yKoordinata;
}

double osszesX = 0.0;
double osszesY = 0.0;
double osszesSugar = 0.0;
string osszesNeve = "";
Console.Write("Nincs közös része: ");
for (int i = 0; i < kraterek.Count; i++)
{
    osszesSugar = kraterek[i].kraterSugar;
    osszesX = kraterek[i].xKoordinata;
    osszesY = kraterek[i].yKoordinata;
   
    if (tavolsag(bekertX, bekertY, osszesX, osszesY) > (bekertSugar+osszesSugar))
    {
        Console.Write($"{kraterek[i].kraterNev}, ");
    };
}
//7feladat
Console.WriteLine();
Console.WriteLine("7. Feladat");

for (int i = 0; i < kraterek.Count; i++)
{
    for (int j = i + 1; j < kraterek.Count; j++)
    {
        var kr1 = kraterek[i];
        var kr2 = kraterek[j];
        if (kr1.kraterSugar > kr2.kraterSugar)
        {
            if (tavolsag(kr1.xKoordinata, kr1.yKoordinata, kr2.xKoordinata, kr2.yKoordinata) < (kr1.kraterSugar - kr2.kraterSugar))
            {
                Console.WriteLine($"A(z) {kr1.kraterNev} tartalmazza a(z) {kr2.kraterNev} krátert");
            }
        }
        else if (kr2.kraterSugar > kr1.kraterSugar)
        {
            if (tavolsag(kr1.xKoordinata, kr1.yKoordinata, kr2.xKoordinata, kr2.yKoordinata) < (kr2.kraterSugar - kr1.kraterSugar))
            {
                Console.WriteLine($"A(z) {kr2.kraterNev} tartalmazza a(z) {kr1.kraterNev} krátert");
            }
        }
    }
}
//8Feladat
StreamWriter fajl = new StreamWriter("terulet.txt");
foreach(adatok adat in kraterek)
{
    double ertek = (adat.kraterSugar * adat.kraterSugar) * 3.14;
    fajl.WriteLine($"{Math.Round(ertek,2, MidpointRounding.AwayFromZero)}\t{adat.kraterNev}");
}



fajl.Close();