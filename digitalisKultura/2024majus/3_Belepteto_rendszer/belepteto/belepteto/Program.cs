using belepteto;
//1Feladat
List<adatok> diakok = new List<adatok>();
string[] sorok = File.ReadAllLines("bedat.txt");

for(int i=0; i<sorok.Length; i++)
{
    string[] adatok = sorok[i].Split(" ");
    adatok adat = new adatok(adatok[0],adatok[1], int.Parse(adatok[2]));
    diakok.Add(adat);
}
//2Feladat
Console.WriteLine("2. feladat");

int[] elsoTanuloBelepes=new int[2];
int[] utolsoTanuloBelepes = new int[2];
foreach (adatok adat in diakok)
{
    elsoTanuloBelepes[0] = adat.ora;
    elsoTanuloBelepes[1] = adat.perc;
    break;
}
foreach (adatok adat in diakok)
{
    utolsoTanuloBelepes[0] = adat.ora;
    utolsoTanuloBelepes[1] = adat.perc;
   
}


Console.WriteLine($"Az első tanuló {elsoTanuloBelepes[0]:D2}:{elsoTanuloBelepes[1]:D2}-kor lépett be a főkapun");
Console.WriteLine($"Az első tanuló {utolsoTanuloBelepes[0]:D2}:{utolsoTanuloBelepes[1]:D2}-kor lépett be a főkapun");

//3Feladat

StreamWriter sw = new StreamWriter("kesok.txt");

foreach (adatok adat in diakok)
{
    int aktualisPerc = adat.ora * 60 + adat.perc;
    int alsoHatar = 7 * 60 + 50;
    int felsoHatar = 8 * 60 + 15;

    if (adat.esemeny == 1 &&
        aktualisPerc > alsoHatar &&
        aktualisPerc <= felsoHatar)
    {
        sw.WriteLine($"{adat.ora:D2}:{adat.perc:D2} {adat.tanuloKod}");
    }
}

sw.Close();

//4Feladat
Console.WriteLine("4. Feladat");
int ebedelesekSzama = 0;
foreach(adatok adat in diakok)
{
    if (adat.esemeny == 3)
    {
        ebedelesekSzama++;
    }
}
Console.WriteLine($"A menzán aznap {ebedelesekSzama} tanuló ebédelt");

//5Feladat
Console.WriteLine("5. Feladat");
int kolcsonzesekSzama = 0;
List<string> kolcsonzok = new List<string>();
foreach (adatok adat in diakok)
{
    if (adat.esemeny == 4)
    {
        if (!kolcsonzok.Contains(adat.tanuloKod))
        {
            kolcsonzok.Add(adat.tanuloKod);
        }
    }
}
Console.WriteLine($"Aznap {kolcsonzok.Count()} tanuló kölcsönzött a könyvtárban.");
if(kolcsonzok.Count() > ebedelesekSzama)
{
    Console.WriteLine("Többen voltak, mint a menzán.");

}
else
{
    Console.WriteLine("Nem voltak többen, mint a menzán.");
}

//6Feladat
Console.WriteLine("6 Feladat");




foreach(adatok adat in diakok)
{
    int aktualisPerc = adat.ora * 60 + adat.perc;

    int alsoHatar = 10 * 60 + 51; // 10:50 = 650 perc
    int felsoHatar = 11 * 60 + 0; // 11:00 = 660 perc

    if (adat.esemeny == 1 && aktualisPerc >= alsoHatar && aktualisPerc <= felsoHatar)
    {
        Console.WriteLine($"{adat.tanuloKod} {adat.ora} {adat.perc}");


    }
}