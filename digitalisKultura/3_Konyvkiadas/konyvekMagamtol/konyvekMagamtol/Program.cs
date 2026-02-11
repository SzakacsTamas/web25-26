using konyvekMagamtol;
using System.Linq;

List<adatok> konyvek=new List<adatok>();
string[] sorok = File.ReadAllLines("kiadas.txt");

for(int i=0; i< sorok.Length; i++)
{
    string[] adatok = sorok[i].Split(";");
    adatok adat = new adatok(int.Parse(adatok[0]), int.Parse(adatok[1]), adatok[2],adatok[3], int.Parse(adatok[4]));
    konyvek.Add(adat);

}
/*
foreach(adatok adat in konyvek)
{
    Console.WriteLine(adat.ev);
}
*/

//2.Feladat
Console.WriteLine("2. feladat:");
Console.Write("Szerző: ");
string bekertNev= Console.ReadLine();
int szamlalo = 0;

foreach (adatok adat in konyvek)
{

    if (adat.leiras.Contains(bekertNev))
    {
        szamlalo++;
    }


}
if (szamlalo == 0)
{
    Console.WriteLine("Nincs ilyen szerző");
}
else
{
    Console.WriteLine($"{szamlalo} könyvkiadás");
}

//3.Feladat
Console.WriteLine("3. feladat");
Console.Write("Legnagyobb példányszám: ");
int legnagyobbErtek = 0;
int elofordulas = 0;
foreach(adatok adat in konyvek)
{
    if (adat.kiadottPeldanySzam > legnagyobbErtek)
    {
        legnagyobbErtek = adat.kiadottPeldanySzam;
        elofordulas = 1;
    }
    else if (adat.kiadottPeldanySzam == legnagyobbErtek)
    {
        elofordulas++; 
    }

}
Console.WriteLine($"{legnagyobbErtek} előfordult {elofordulas} alkalommal");

//4.Feladat
Console.WriteLine("4. feladat");
foreach(adatok adat in konyvek)
{
    if (adat.eredet == "kf" && adat.kiadottPeldanySzam > 40000)
    {
       
       
            Console.WriteLine($"{adat.ev}/{adat.negyedEv}. {adat.leiras}");
            break;
    
    }
}

//5.Feladat
Console.WriteLine("5.feladat");
Console.WriteLine("Év\tMagyar kiadás\tMagyar példányszám\tKülföldi kiadás\tKülföldi példányszám");
List<int> evek=new List<int>();
List<int> magyarDarabLista = new List<int>();
List<int> magyarPeldanySzamLista = new List<int>();
List<int> kulfoldiDarabLista = new List<int>();
List<int> kulfoldiPeldanyszamLista = new List<int>();






foreach (adatok adat in konyvek)
{
    if (!evek.Contains(adat.ev))
    {
        evek.Add(adat.ev);
    }

}

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
                magyarPeldanySzam += k.kiadottPeldanySzam;
            }
            else if (k.eredet == "kf")
            {
                kulfoldiDarab++;
                kulfoldiPeldanyszam += k.kiadottPeldanySzam;
            }
        }
    }
    magyarDarabLista.Add(magyarDarab);
    magyarPeldanySzamLista.Add(magyarPeldanySzam);
    kulfoldiDarabLista.Add(kulfoldiDarab);
    kulfoldiPeldanyszamLista.Add (kulfoldiPeldanyszam);

}

for(int i =0; i < evek.Count(); i++)
{
    Console.WriteLine($"{evek[i]}\t{magyarDarabLista[i]}\t\t{magyarPeldanySzamLista[i]}\t\t\t{kulfoldiDarabLista[i]}\t\t{kulfoldiPeldanyszamLista[i]}");
}
string tablazat = "<table><tr><th>Év</th><th>Magyar kiadás</th><th>Magyar példányszám</th><th>Külföldi kiadás</th><th>Külföldi példányszám</th></tr>";

for (int i = 0; i < evek.Count(); i++)
{
    tablazat+=$"<tr><td>{evek[i]}</td><td>{magyarDarabLista[i]}</td><td>{magyarPeldanySzamLista[i]}</td><td>{kulfoldiDarabLista[i]}</td><td>{kulfoldiPeldanyszamLista[i]}</td> </tr>";
}
tablazat += $"</table>";
File.WriteAllText("tabla.html",tablazat);

//6Feladat
Console.WriteLine("6.feladat");
Console.WriteLine("Legalább kétszer, nagyobb példányszámban újra kiadott könyvek: ");

var konyvekcskek = konyvek.GroupBy(adat => adat.leiras);


/*
List<string> lista = new List<string>();

foreach(adatok adat in konyvek)
{
    lista.Add(adat.leiras);
}
*/

foreach (var csoport in konyvekcskek)
{
    var kiadasLista = csoport
        .ToList();

    int elsoPeldany = kiadasLista[0].kiadottPeldanySzam;
    int nagyobbDb = 0;



    for (int i = 1; i < kiadasLista.Count; i++)
    {
        if (kiadasLista[i].kiadottPeldanySzam > elsoPeldany)
            nagyobbDb++;
    }

    if (nagyobbDb >= 2)
        Console.WriteLine(csoport.Key);
}