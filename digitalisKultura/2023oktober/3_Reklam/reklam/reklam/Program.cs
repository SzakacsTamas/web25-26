using reklam;
//1Feladat
List<adatok> reklamok= new List<adatok>();
string[] sorok = File.ReadAllLines("rendel.txt");

for (int i = 0; i < sorok.Length; i++)
{
    string[] adatok = sorok[i].Split(" ");
    adatok adat = new adatok(int.Parse(adatok[0]), adatok[1], int.Parse(adatok[2]));
    reklamok.Add(adat);
}

//2Feladat
Console.WriteLine("2. Feladat");
int RendelesekSzama = 0;
foreach(adatok adat in reklamok)
{
    RendelesekSzama++;
}

Console.WriteLine($"A rendelések száma: {RendelesekSzama}");

//3Feladat
Console.WriteLine("3. Feladat");
Console.Write("Kérem, adjon meg egy napot: ");
int nap = int.Parse(Console.ReadLine());
int rendelesekSzamaAdottNapon = 0;
foreach(adatok adat in reklamok)
{
    if(adat.nap==nap)
    {
        rendelesekSzamaAdottNapon++;
    }
}

Console.WriteLine($"A rendelések száma az adott napon: {rendelesekSzamaAdottNapon}");


//4Feladat
Console.WriteLine("4. Feladat");
int nemVoltRendeles = 0;


for (int i = 1; i <= 30; i++)
{
    bool reklamMentesNap = false;
    foreach (adatok adat in reklamok)
    {
        if(adat.nap==i && adat.hirdetesTipus=="NR")
        {
            reklamMentesNap=true;
            break;
        }
    }
    if (!reklamMentesNap)
    {
        nemVoltRendeles++;
    }
}
Console.WriteLine($"{nemVoltRendeles} nap a reklámban nem érintett városból rendelés");

//5Feladat
Console.WriteLine("5. Feladat");


int legnagyobbSzam = 0;
int rendelesNapja = 0;
foreach(adatok adat in reklamok)
{
    if(legnagyobbSzam <= adat.rendelesDarab+1)
    {
        legnagyobbSzam++;
        rendelesNapja = adat.nap;
    }
}

Console.WriteLine($"A legnagyobb darabszám: {legnagyobbSzam}, a rendelés napja: {rendelesNapja}");