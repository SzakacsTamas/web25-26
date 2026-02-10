using autok;
using System.Security.Cryptography;

List<adatok> autok = new List<adatok>();
string[] sorok = File.ReadAllLines("jeladas.txt");

for (int i=0; i < sorok.Length; i++ )
{
    string[] adatok = sorok[i].Split("\t");
    adatok adat=new adatok(adatok[0], int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
    autok.Add(adat);
}


//2.Feladat
Console.WriteLine("2. Feladat:");
string utolsoDatum = "";
string utolsoRendszam = "";
foreach (adatok adat in autok)
{
    utolsoDatum = $"{adat.ora}:{adat.perc}";
    utolsoRendszam = adat.rendSzam;

}
Console.WriteLine($"Az utolsó jeladás időpontja: {utolsoDatum}, a jármű rendszáma: {utolsoRendszam}");

//3.Feladat
string elsoRendszam = autok[0].rendSzam;
Console.WriteLine("3. Feladat:");
Console.WriteLine($"Az első jármű: {elsoRendszam}");
Console.Write("Jeladásainak időpontja: ");
foreach(adatok adat in autok)
{
    if(elsoRendszam == adat.rendSzam)
    {
        Console.Write($" {adat.ora}:{adat.perc} ");
    }
}

//4.Feladat
Console.WriteLine("4. Feladat:");
Console.Write("Kérem adja meg az órát: ");
int bekertOra = int.Parse(Console.ReadLine());
Console.Write("Kérem adja meg a percet: ");
int bekertPerc = int.Parse(Console.ReadLine());
int szam = 0;
foreach(adatok adat in autok)
{
    if(adat.ora == bekertOra && adat.perc == bekertPerc)
    {
        szam++;
    }
}
Console.WriteLine($"A jeladások száma: {szam}");

//5.Feladat
Console.WriteLine("5. Feladat:");
int maxSebesseg = 0;
foreach (adatok adat in autok)
{
    if(adat.sebesseg > maxSebesseg)
    {
        maxSebesseg = adat.sebesseg;
    }


}
Console.WriteLine($"A legnagyobb sebesség km/h: {maxSebesseg}");
Console.Write($"A járművek: ");
foreach (adatok adat in autok)
{
    if (adat.sebesseg == maxSebesseg)
    {
       Console.Write($"{adat.rendSzam} ");
    }
}
Console.WriteLine();
//6.Feladat
Console.WriteLine("6. Feladat:");

Console.Write("Kérem adja meg a rendszámot: ");
string bekertRendszam = Console.ReadLine();
double km = 0.0;
List<adatok> jelzesek = new List<adatok>();


int darab = 0;
foreach (adatok adat in autok)
{
    if(adat.rendSzam == bekertRendszam)
    {
        jelzesek.Add(adat);
        darab++;
    }

}
if (darab == 0)
{
    Console.WriteLine("Nincs ilyen rendszámú jármű!");
}
Console.WriteLine($"{jelzesek[0].ora}:{jelzesek[0].perc} {km:F1} km");
for (int i = 1; i< jelzesek.Count; i++)
{
    adatok elozo = jelzesek[i - 1];
    adatok aktualis = jelzesek[i];

    // eltelt idő percben
    int elozoPerc = elozo.ora * 60 + elozo.perc;
    int aktualisPerc = aktualis.ora * 60 + aktualis.perc;
    int elteltPerc = aktualisPerc - elozoPerc;

    // távolság növelése
    double elteltOra = elteltPerc / 60.0;
    km += elteltOra * elozo.sebesseg;



    Console.WriteLine($"{jelzesek[i].ora}:{jelzesek[i].perc} {km:F1} km");
}

//7.Feladat

StreamWriter szovegesFajl = new StreamWriter("ido.txt");

Dictionary<string, int[]> rendszamokTomb = new Dictionary<string, int[]>();

foreach (string rendszam in autok.Select(a => a.rendSzam).Distinct())
{

    // az adott rendszám jeladásai
    var jeladasok = autok
        .Where(a => a.rendSzam == rendszam)
        .OrderBy(a => a.ora)
        .ThenBy(a => a.perc)
        .ToList();

    var elso = jeladasok.First();
    var utolso = jeladasok.Last();

    // tárolás: {elsoOra, elsoPerc, utolsoOra, utolsoPerc}
    rendszamokTomb[rendszam] = new int[] { elso.ora, elso.perc, utolso.ora, utolso.perc };
}

foreach (var kvp in rendszamokTomb)
{
    string rendszam = kvp.Key;
    int[] ido = kvp.Value;

    szovegesFajl.WriteLine(
        $"{rendszam} {ido[0]} {ido[1]} {ido[2]} {ido[3]}"
    );
}
szovegesFajl.Close();



