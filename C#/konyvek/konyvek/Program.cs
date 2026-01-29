using konyvek;
using System;
using System.Text;

List<adatok> konyvek = new List<adatok>();
string[] sorok = File.ReadAllLines("kiadas.txt");

for (int i = 0; i < sorok.Length; i++)
{
    string[] adatok = sorok[i].Split(';');
    adatok adat = new adatok(Int32.Parse(adatok[0]), Int32.Parse(adatok[1]), adatok[2], adatok[3], Int32.Parse(adatok[4]));
    konyvek.Add(adat);

}
//Console.WriteLine(konyvek[1].ev);

//2.Feladat
Console.WriteLine($"2.Feladat:");
Console.Write("Szerző:");
string bekertNev = Console.ReadLine().Trim();

int darab2 = 0;
foreach (var k in konyvek)
{
    string szerzo = k.KoltoEsCim.Split(':')[0].Trim();
    if (szerzo == bekertNev)
    {
        darab2++;
    }
}

if (darab2 > 0)
{

    
    Console.WriteLine($"{darab2} kölcsönzés");

}

else 
{ 
    Console.WriteLine("Nem adták ki");
}

//3.Feladat
int max = int.MinValue;
int darab3 = 0;
foreach (var k in konyvek)
{
    if (k.peldanySzam > max)
        max = k.peldanySzam;
}


foreach (var k in konyvek)
{
    if (k.peldanySzam == max)
        darab3++;
}

Console.WriteLine($"3.Feladat: Legnagyobb példányszám: {max}, előfordulás: {darab3} alkalommal");

//4.Feladat
foreach (var k in konyvek)
{
    if (k.eredet == "kf" && k.peldanySzam >= 40000)
    {
        Console.WriteLine("4.Feladat:");
        Console.WriteLine($"{k.ev}/{k.negyedEv}. {k.KoltoEsCim}");
        break;
    }
}

//5.Feladat
List<int> evek = new List<int>();

foreach (var k in konyvek)
{
    if (!evek.Contains(k.ev))
    {
        evek.Add(k.ev);
    }
}

Console.WriteLine("5.Feladat:");
Console.WriteLine("Év\tMagyar kiadás\tMagyar példányszám\tKülföldi kiadás\tKülföldi példányszám");
string tablazatKod = "<html><body><table><tr><th>Év</th><th>Magyar kiadás</th><th>Magyar példányszám</th><th>Külföldi kiadás</th><th>Külföldi példányszám</th></tr>\n</body></html>";

foreach (int ev in evek)
{
    int magyarDarab = 0;
    int magyarPeldanySzam = 0;
    int kulfoldiDarab = 0;
    int kulfoldiPeldanyszam = 0;

    foreach (var k in konyvek)
    {
        if (k.ev == ev)
        {
            if (k.eredet == "ma")
            {
                magyarDarab++;
                magyarPeldanySzam += k.peldanySzam;
            }
            else if (k.eredet == "kf")
            {
                kulfoldiDarab++;
                kulfoldiPeldanyszam += k.peldanySzam;
            }
        }
    }

    Console.WriteLine($"{ev}\t{magyarDarab}\t\t{magyarPeldanySzam}\t\t\t{kulfoldiDarab}\t\t{kulfoldiPeldanyszam}");
    tablazatKod += $"<tr><td>{ev}</td><td>{magyarDarab}</td><td>{magyarPeldanySzam}</td><td>{kulfoldiDarab}</td><td>{kulfoldiPeldanyszam}</td></tr>\n";
}


File.WriteAllText("kiadasok.html", tablazatKod);

//6.Feladat
Console.WriteLine("6. Feladat:");
Console.WriteLine("Legalább kétszer, nagyobb példányszámban újra kiadott könyvek:");

List<string> keresettDolgok = new List<string>();

foreach (var k in konyvek)
{
    string keresettKoltoEsCim = k.KoltoEsCim;
    if (!keresettDolgok.Contains(keresettKoltoEsCim))
    {
        int kiadasSzam = 0;
        int? elsoPeldanySzam = null;
        int nagyobbak = 0;

        foreach (var k2 in konyvek)
        {
            if (k2.KoltoEsCim == keresettKoltoEsCim)
            {
                kiadasSzam++;
                if (elsoPeldanySzam == null)
                {
                    elsoPeldanySzam = k2.peldanySzam;
                }
                else if (k2.peldanySzam > elsoPeldanySzam)
                {
                    nagyobbak++;
                }
            }
        }

        if (kiadasSzam >= 3 && nagyobbak >= 2)
        {
            Console.WriteLine(keresettKoltoEsCim);
        }

        keresettDolgok.Add(keresettKoltoEsCim);
    }
}
