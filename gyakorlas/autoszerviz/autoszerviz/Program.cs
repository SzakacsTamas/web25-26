using autoszerviz;
using System.Threading.Tasks.Sources;

List<adatok> autok = new List<adatok>();
string[] sorok = File.ReadAllLines("szerviz.txt");

for (int i = 0; i < sorok.Length; i++)
{
    string[] adatok = sorok[i].Split("\t");
    adatok adat =new adatok(adatok[0], adatok[1], DateOnly.Parse(adatok[2]), adatok[3], DateOnly.Parse(adatok[4]));
    autok.Add(adat);
}

//2Feladat
var szam = autok.Count();
Console.WriteLine("2 Feladat");
Console.WriteLine($"Ennyi alkalommal vittek járművet szervízbe: {szam}");

//3Feladat
var autokSzama=autok.DistinctBy(s => s.rendSzam);
Console.WriteLine("3 Feladat");
Console.WriteLine($"Autok száma: {autokSzama.Count()}");

//4Feladat
Console.WriteLine("4 Feladat");
Console.Write("Kérek egy rendszamot: ");
string bekertRendSzam=Console.ReadLine();

var feladat3 = autok.Where(s => s.rendSzam == bekertRendSzam).ToArray();

if (feladat3.Count()== 0)
{
    Console.WriteLine("Nem volt ilyen");
}
else
{
    foreach (var auto in feladat3)
    {
        Console.WriteLine(auto.szervizbeHozas);
    }

}

//5Felatad
Console.WriteLine("5.Fealadat");
var legtobb = autok
    .GroupBy(a => a.rendSzam)
    .OrderByDescending(g => g.Count())
    .FirstOrDefault();

if (legtobb != null)
{
    Console.WriteLine($"A legtöbbször előforduló rendszám: {legtobb.Key}");
    Console.WriteLine($"Előfordulások száma: {legtobb.Count()}");
}

//6Felatad
Console.WriteLine("6.Fealadat");

var eladottRendszamok = autok
    .GroupBy(a => a.rendSzam)
    .Where(g => g.Select(x => x.tulajNeve).Distinct().Count() > 1)
    .Select(g => g.Key);

foreach(var adat in eladottRendszamok)
{
    Console.WriteLine(adat);
}
