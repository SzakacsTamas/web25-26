using Fuvar;
//1Fealdat
List<adatok> fuvarok = new List<adatok>();
string[] sorok = File.ReadAllLines("Fuvar.csv");

for (int i = 1; i < sorok.Length; i++)
{
    string[] s = sorok[i].Split(";");
    adatok adat = new adatok(int.Parse(s[0]), s[1], int.Parse(s[2]), double.Parse(s[3]), double.Parse(s[4]), double.Parse(s[5]), s[6]);
    fuvarok.Add(adat);
}


//3Feladat
Console.WriteLine($"3. feladat: {fuvarok.Count} fuvar");

//4Feladat
var feladat4 = fuvarok.Where(x => x.taxiAz == 6185);
int fuvarDb = feladat4.Count();
double osszBevetel = feladat4.Sum(x => x.vitelDij); 


Console.WriteLine($"4. feladat: {fuvarDb} fuvar alatt: {osszBevetel}$");

//5Feladat
var feladat5 = fuvarok.GroupBy(x => x.fizetesMod).Select(g=> new 
{
    fizetesMod=g.Key,
    darabSzam=g.Count()
});

foreach (var f in feladat5)
{
    Console.WriteLine($"\t{f.fizetesMod}: {f.darabSzam} fuvar");
}

//6Feladat
var feladat6 = fuvarok.Sum(x => x.megtettTav*1.6);

Console.WriteLine($"6. feladat: {feladat6:F2}km");

//7Feladat
var feladat7 = fuvarok.Max(x => x.utazasIdeje);
var feladat72 = fuvarok.Where(x => x.utazasIdeje == feladat7);

foreach (var f in feladat72)
{
    Console.WriteLine($"7. feladat: Leghosszabb fuvar: \n\tFuvar hossza: {f.utazasIdeje} másodperc" +
        $"\n\tTaxi azonosító: {f.taxiAz}" +
        $"\n\tMegtett távolság: {f.megtettTav} km" +
        $"\n\tViteldíj: {f.vitelDij}$");

}

//8feladat
Console.WriteLine("8. feladat: hibak.txt");
StreamWriter szovegesFajl = new StreamWriter("hibak.txt");
var feladat8 = fuvarok.Where(x=>x.megtettTav ==0 && x.vitelDij >0 && x.utazasIdeje > 0).OrderBy(x => x.indulasIdopontja) 
    .ToList();
szovegesFajl.WriteLine($"taxi_id;indulas;sdkasfs");
foreach (var f in feladat8)
{
    // ugyanaz a szerkezet, mint a CSV-ben

    szovegesFajl.WriteLine($"{f.taxiAz};{f.indulasIdopontja};{f.utazasIdeje};{f.megtettTav};{f.vitelDij};{f.fizetesMod}");
}


szovegesFajl.Close();

