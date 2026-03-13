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






//6Feladat

int osszes(string varosNeve, int napSzam)
{
    /*
    var adott = rendelesek.GroupBy(x => x.nap).Select(g => new
    {
        Nap = g.Key,
        OsszesRendeles = g.GroupBy(x => x.varos).Select(a => new
        {
            varosNeve = a.Key,
            rendelesSzamVarosNapAlapjan = a.Sum(x => x.rendelesSzama)
        })
.ToList()
    })
.ToList();
    */

    var szures = rendelesek.Where(y => y.varos==varosNeve && y.nap == napSzam).Sum(y =>y.rendelesSzama);
    return szures;
}
//7Feladat
Console.WriteLine("7.Feladat");
Console.WriteLine($"A rendelt termékek darabszáma a 21.napon PL: {osszes("PL", 21)} TV: {osszes("TV", 21)} NR: {osszes("NR", 21)}");

//8Feladat
Console.WriteLine("8.Feladat");
int osszesAdott(string varosNeve, int napEleje, int napVege)
{


    var szures = rendelesek.Where(y => y.varos == varosNeve && y.nap >= napEleje && y.nap <= napVege).Count();

    return szures;
}
StreamWriter fajl = new StreamWriter("kampany.txt");
var varosok=rendelesek.GroupBy(x => x.varos).ToList();
fajl.WriteLine("Napok\t1..10\t11..20\t21..30");
Console.WriteLine("Napok\t1..10\t11..20\t21..30");

foreach (var varos in varosok)
{
    
    Console.Write(varos.Key);
    fajl.Write(varos.Key);
    for (int i = 0; i < 3; i++)
    {
        fajl.Write($"\t{osszesAdott(varos.Key, 1 + i * 10, 10 + i * 10)}");
        Console.Write($"\t{osszesAdott(varos.Key, 1 + i * 10, 10 + i * 10)}");
    }
    Console.WriteLine();
    fajl.WriteLine();
}

fajl.Close();




