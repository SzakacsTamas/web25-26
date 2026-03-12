using reklam2;
//1Feladat
List<adatok> rendelesek = new List<adatok>();
string[] sorok = File.ReadAllLines("rendel.txt");

for (int i = 0; i < sorok.Length; i++)
{
    string[] adatok = sorok[i].Split(" ");
    adatok adat = new adatok(int.Parse(adatok[0]), adatok[1], int.Parse(adatok[2]));
    rendelesek.Add(adat);
}

//2Feladat
Console.WriteLine("2.Feladat");
int szam = 0;
foreach(adatok adat in rendelesek)
{
    szam++;
}
Console.WriteLine($"A rendelések száma: {szam}");
//LINKQ
var rendelesSzam = rendelesek.Count();
Console.WriteLine($"A rendelések száma: {rendelesSzam}");

//3Feladat
Console.WriteLine("3.Feladat");
Console.Write("Kérem, adjon meg egy napot: ");
int bekertNap = int.Parse(Console.ReadLine());
int szam2 = 0;
foreach(adatok adat in rendelesek)
{
    if(bekertNap == adat.nap)
    {
        szam2++;
    }
}
Console.WriteLine($"A rendelések száma az adott napon: {szam2}");
//LINKQ
var rendelesSzamAdottNapon = rendelesek.Where(x => x.nap == bekertNap).Count();
Console.WriteLine($"A rendelések száma az adott napon: {rendelesSzamAdottNapon}");

//4Feladat
Console.WriteLine("4.Feladat");
//LINKQ
var nemVoltRendeles = rendelesek.GroupBy(x => x.nap).Where(g => !g.Any(x => x.varos == "NR")).Count();
Console.WriteLine($"{nemVoltRendeles} nap nem volt a reklámban nem érintett városból rendelés");

//5Feladat
Console.WriteLine("5.Feladat");
var legnagyobb= rendelesek.Max(x =>x.rendelesSzama);
var leganyobbNap = rendelesek.Where(x => x.rendelesSzama == legnagyobb).Select(x => x.nap).First();

Console.WriteLine($"A legnagyobb darabszám: {legnagyobb}, a rendelés napja {leganyobbNap}");
var adott = rendelesek.GroupBy(x => x.nap).Select(g => new
{
    Nap = g.Key,
    OsszesRendeles = g.Sum(x => x.rendelesSzama) // Rendeles mező összeadása
})
    .ToList();

foreach (var a in adott)
{
    Console.WriteLine(a.OsszesRendeles);
}
//6Feladat
void osszes()
{

}