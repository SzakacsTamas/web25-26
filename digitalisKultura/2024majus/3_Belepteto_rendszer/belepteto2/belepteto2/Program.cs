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
List<string> rendesenKimentek = new List<string>();
foreach (adatok adat in belepesek)
{
    int aktualisPerc = adat.ora * 60 + adat.perc;

    int RendesKilepesAlso = 10 * 60 + 45;
    int RendesKilepesFelso = 10 * 60 + 50;

    if (adat.esemenyKodja == 2 && aktualisPerc >= RendesKilepesAlso && aktualisPerc <= RendesKilepesFelso)
    {
        rendesenKimentek.Add(adat.diakAzonosito);
    }
}

foreach (adatok adat in belepesek)
{
    int aktualisPerc = adat.ora * 60 + adat.perc;

    int alsoHatar = 10 * 60 + 51;
    int felsoHatar = 11 * 60;

    if (adat.esemenyKodja == 1 &&
        aktualisPerc >= alsoHatar &&
        aktualisPerc <= felsoHatar &&
        !rendesenKimentek.Contains(adat.diakAzonosito))
    {
        bool voltKorabbiBelepes = false;

        foreach (adatok masik in belepesek)
        {
            int masikPerc = masik.ora * 60 + masik.perc;

            if (masik.diakAzonosito == adat.diakAzonosito &&
                masik.esemenyKodja == 1 &&
                masikPerc < aktualisPerc)
            {
                voltKorabbiBelepes = true;
                break;
            }
        }

        if (voltKorabbiBelepes)
        {
            Console.Write($"{adat.diakAzonosito} ");
        }
    }
}
//LINKQ 
var eredmeny = belepesek
    .Where(a =>
        a.esemenyKodja == 1 &&
        (a.ora * 60 + a.perc) >= (10 * 60 + 51) &&
        (a.ora * 60 + a.perc) <= (11 * 60) &&

        // nem ment ki 10:45-10:50 között
        !belepesek.Any(b =>
            b.diakAzonosito == a.diakAzonosito &&
            b.esemenyKodja == 2 &&
            (b.ora * 60 + b.perc) >= (10 * 60 + 45) &&
            (b.ora * 60 + b.perc) <= (10 * 60 + 50)
        ) &&

        // volt korábbi belépése
        belepesek.Any(b =>
            b.diakAzonosito == a.diakAzonosito &&
            b.esemenyKodja == 1 &&
            (b.ora * 60 + b.perc) < (a.ora * 60 + a.perc)
        )
    )
    .Select(a => a.diakAzonosito)
    .Distinct();

Console.WriteLine(string.Join(" ", eredmeny));


//7Feladat
Console.WriteLine();
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
    Console.WriteLine($"A tanuló érkezése és távozása között {((utolsoBelepesOra * 60 + utolsoBelepesPerc) - (elsoBelepesOra * 60 + elsoBelepesPerc)) / 60} óra {((utolsoBelepesOra * 60 + utolsoBelepesPerc) - (elsoBelepesOra * 60 + elsoBelepesPerc)) % 60} perc telt el.");
}

