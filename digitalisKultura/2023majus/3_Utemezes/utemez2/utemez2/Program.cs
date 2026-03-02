using utemez2;

List<adatok> utemek = new List<adatok>();
string[] sorok = File.ReadAllLines("taborok.txt");

for (int i = 0; i < sorok.Length; i++)
{
    string[] adatok = sorok[i].Split("\t");
    adatok adat = new adatok(int.Parse(adatok[0]), int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]), adatok[4], adatok[5]);
    utemek.Add (adat);
}

//2.Feladat
Console.WriteLine("2.Feladat");
int szam = 0;
string elsoRogzitett = "";
string utolsoRogzitett = "";
foreach(adatok adat in utemek)
{
    szam++;
    utolsoRogzitett = adat.taborTema;
}
foreach(adatok adat in utemek)
{
    elsoRogzitett = adat.taborTema;
    break;
}
Console.WriteLine($"Az adatsorok száma: {szam}");

Console.WriteLine($"Az először rögzitett tabor temaja: {elsoRogzitett}");
Console.WriteLine($"Az utoljara rögzitett tabor temaja: {utolsoRogzitett}");

//3.Feladat
Console.WriteLine("3.Feladat");

foreach(adatok adat in utemek)
{
    if()
}
