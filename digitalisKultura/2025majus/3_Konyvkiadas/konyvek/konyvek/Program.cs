using konyvek;
//1FEladat
List<adatok> konyvek= new List<adatok>();
string[] sorok = File.ReadAllLines("kiadas.txt");

for(int i = 0; i < sorok.Length; i++)
{
    string[] adat = sorok[i].Split(";");
    adatok adatok = new adatok(int.Parse(adat[0]), int.Parse(adat[1]), adat[2], adat[3], int.Parse(adat[4]));
    konyvek.Add(adatok);

}

//2Feladat
Console.WriteLine("2.Feladat");
Console.Write("Szerző: ");
string szerzo=Console.ReadLine();
szerzo="Benedek Elek";
var feladat2 = konyvek.Where(x => x.leiras.Contains(szerzo)).Count();

if(feladat2 == 0)
{
    Console.WriteLine("Nem adatka ki!");
}
else
{
    Console.WriteLine($"{feladat2} könyvkiadás");
}

//3Feladat
Console.WriteLine("3.Feladat");

var feladat3 = konyvek.Max(x => x.kiadottSzam);
var feladat3Hanyszor = konyvek.Where(x => x.kiadottSzam == feladat3).Count();
Console.WriteLine($"Legnagyobb példányszám {feladat3}, előfordult {feladat3Hanyszor} alkalommal");
//4Feladat
Console.WriteLine("4.Feladat");
var feladat4 = konyvek.Where(x=>x.eredet == "kf" && x.kiadottSzam >= 40000).ToList().First();

Console.WriteLine($"{feladat4.ev}/{feladat4.negyedEv}. {feladat4.leiras}");

//5Feladat
Console.WriteLine("5.Feladat");
Console.WriteLine($"Év\tMagyar kiadás\tMagyar példányszám\tKülföldi kiadás\t Külföldi példányszám");
StreamWriter sw = new StreamWriter("tabla.html");
sw.WriteLine("<table>\r\n<tr><th>Év</th><th>Magyar kiadás</th><th>Magyar példányszám</th><th>Külföldi\r\nkiadás</th><th>Külföldi példányszám</th></tr>");
var evek = konyvek
    .GroupBy(x => x.ev)
    .Select(g => new
    {
        evLinkq = g.Key,
        maDarab = g.Count(x => x.eredet == "ma"),
        maOsszeg = g.Where(x => x.eredet == "ma").Sum(x => x.kiadottSzam),
        kfDarab = g.Count(x => x.eredet == "kf"),
        kfOsszeg = g.Where(x => x.eredet == "kf").Sum(x => x.kiadottSzam)
    })
    .ToList();

foreach (var asd in evek)
{
    Console.WriteLine($"{asd.evLinkq}\t{asd.maDarab}\t\t{asd.maOsszeg}\t\t\t{asd.kfDarab}\t\t{asd.kfOsszeg}");
    sw.WriteLine($"<tr><td>{asd.evLinkq}</td><td>{asd.maDarab}</td><td>{asd.maOsszeg}</td><td>{asd.kfDarab}</td><td>{asd.kfOsszeg}</td></tr>");

}
sw.WriteLine("</table>");
sw.Close();

//6Feladat
Console.WriteLine("6.Feladat");
Console.WriteLine("Legalább kétszer, nagyobb példányszámban újra kiadott könyvek:");
