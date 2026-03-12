using autok2;

//1Feladat
List<adatok> autok = new List<adatok>();
string[] sorok = File.ReadAllLines("jeladas.txt");

for (int i = 0; i < sorok.Length; i++)
{
    string[] adat = sorok[i].Split("\t");
    adatok x = new adatok(adat[0], int.Parse(adat[1]), int.Parse(adat[2]), int.Parse(adat[3]));
    autok.Add(x);
}



//2Feladat
Console.WriteLine("2.Feladat:");
Console.WriteLine($"Az utolsó jeladás időpontja {autok.Last().ora}:{autok.Last().perc}, a játmű rendszáma {autok.Last().rendszam}");


//3Feladat
Console.WriteLine("3.Feladat:");
var elsoAutoJelzesei = autok.Where(x => x.rendszam == autok.First().rendszam).Select(x => $"{x.ora}:{x.perc}");
Console.WriteLine($"Az első jármű: {autok.First().rendszam}");
Console.WriteLine($"Jeladásainak időpontjai: {string.Join(" ", elsoAutoJelzesei)}");

//4Feladat
Console.WriteLine("4.Feladat:");
Console.Write("Kérem, adja meg az órát: ");
int bekertOra = int.Parse(Console.ReadLine());
Console.Write("Kérem, adja meg a percet: ");
int bekertPerc = int.Parse(Console.ReadLine());
var jeladasTortent = autok.Where(x => x.ora == bekertOra && x.perc == bekertPerc).Count();
Console.WriteLine($"A jeladások száma: {jeladasTortent}");

//5Feladat
Console.WriteLine("5.Feladat:");
var legnagyobbsebese = autok.Max(x => x.sebesseg);
Console.WriteLine($"A legnagyobb sebesség km/h {legnagyobbsebese}");
/*
var elemek= autok.Where(x=> x.sebesseg == legnagyobbsebese).ToList();
foreach(var asd in elemek)
{
    Console.Write($"A járművek: {asd.rendszam}");
}

*/

var rendszamok = autok.Where(k => k.sebesseg == legnagyobbsebese).Select(k => k.rendszam);
Console.WriteLine($"A járművek: {string.Join(" ", rendszamok)}");

//6Feladat
Console.WriteLine("6.Feladat:");
Console.Write("Kérem, adja meg a rendszámot: ");
string bekertRendszam=Console.ReadLine();

var hatosFeladat = autok.Where(x => x.rendszam == bekertRendszam).ToList();
if (hatosFeladat.Count == 0)
{
    Console.WriteLine("Nincs benne!");
}
else
{
    double elteltPerc = 0;
    Console.WriteLine($"{hatosFeladat[0].ora}:{hatosFeladat[0].perc} 0.0 km");
    for (int i = 1; hatosFeladat.Count > i; i++)
    {
        int jelenlegiIdo = (hatosFeladat[i].ora) * 60 + hatosFeladat[i].perc;
        int elotteIdo = (hatosFeladat[i - 1].ora) * 60 + hatosFeladat[i - 1].perc;

        elteltPerc += Math.Round(((jelenlegiIdo - elotteIdo) / 60.0) * hatosFeladat[i].sebesseg, 1);

        Console.WriteLine($"{hatosFeladat[i].ora}:{hatosFeladat[i].perc} {elteltPerc} km");
    }
}


//7Feladat


using StreamWriter szoveg = new StreamWriter("ido.txt");
foreach (var a in autok.GroupBy(x => x.rendszam))
{
    szoveg.WriteLine($"{a.Key} {a.First().ora} {a.First().perc} {a.Last().ora} {a.Last().perc}");
}

