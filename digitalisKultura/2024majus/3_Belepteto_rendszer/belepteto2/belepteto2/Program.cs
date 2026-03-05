using belepteto2;

//1FELADAT
List<adatok> belepesek = new List<adatok>();
string[] sorok = File.ReadAllLines("bedat.txt");

for (int i = 0; i < sorok.Length; i++)
{
    string[] adatok = sorok[i].Split(" ");
    adatok adat = new adatok(adatok[0], adatok[1], int.Parse(adatok[2]));
    belepesek.Add(adat);
}

//2 feladat
Console.WriteLine("2.Feladat");
Console.WriteLine($"Az első tanuló {belepesek[0].ora:D2}:{belepesek[0].perc:D2} lépett be a főkapun.");
Console.WriteLine($"Az utolsó tanuló {belepesek.Last().ora:D2}:{belepesek.Last().perc:D2} lépett ki a főkapun.");

//3Feladat
string szoveg = "";
StreamWriter kesok = new StreamWriter("kesok.txt");
foreach (adatok adat in belepesek)
{
    if(adat.ora ==7 && adat.perc>50 || adat.ora==8 && adat.perc <= 15)
    {

        if (adat.esemenyKodja == 1)
        {
            kesok.WriteLine($"{adat.ora:D2}:{adat.perc:D2} {adat.diakAzonosito}");
        }
    }
}
kesok.Close();


//4Feladat
Console.WriteLine("4.Feladat");
int szam = 0;
foreach(adatok adat in belepesek)
{
    if(adat.esemenyKodja == 3)
    {
        szam++;
    }
}
Console.WriteLine($"A menzán aznap {szam} tanuló ebédelt.");

//5Feladat
Console.WriteLine("5.Feladat");

var kolcsonzok = belepesek.Where(asd => asd.esemenyKodja == 4).GroupBy(asd => asd.diakAzonosito).Count();
Console.WriteLine(kolcsonzok);

//6Feladat
Console.WriteLine("6.Feladat");


//7Feladat
Console.WriteLine("7.Feladat");

Console.Write("Egy tanuló azonosítója=");
string bekertAzonosito=Console.ReadLine();

var tanulo = belepesek.Where(asd=>asd.diakAzonosito == bekertAzonosito);
int elsoBelepesOra = 0;
int elsoBelepesPerc = 0;
int utolsoBelepesOra = 0;
int utolsoBelepesPerc = 0;
if (tanulo.Count()==0)
{
    Console.WriteLine("Nincs ilyen tanuló!");
}
else
{
    foreach(adatok adat in tanulo)
    {
        if (adat.esemenyKodja == 2)
        {
            utolsoBelepesOra = adat.ora;
            utolsoBelepesPerc = adat.perc;
        }

        
    }
    foreach(adatok adat in tanulo)
    {
        if (adat.esemenyKodja == 1)
        {
            elsoBelepesOra = adat.ora;
            elsoBelepesPerc = adat.perc;
            break;
        }
    }
}
Console.WriteLine($"A tanuló érkezése és távozása között {((utolsoBelepesOra * 60 + utolsoBelepesPerc) - (elsoBelepesOra * 60 + elsoBelepesPerc)) / 60} óra {((utolsoBelepesOra*60+utolsoBelepesPerc)-(elsoBelepesOra*60+elsoBelepesPerc))%60} perc telt el.");
