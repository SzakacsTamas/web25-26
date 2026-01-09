


//1 Feladat
Console.WriteLine("1. feladat");
string[] konyv =File.ReadAllLines("konyv.txt");
foreach (var sor in konyv)
{
    Console.WriteLine(sor);
}
//2 Feladat
Console.WriteLine("2. feladat");
Console.Write("Kérem adja meg az ismétlések számát: ");
int szam= int.Parse(Console.ReadLine());
string sokKonyv="";


int maxHossz = konyv.Max(s => s.Length);

 
foreach (var sor in konyv)
{
    string feltoltottSor = sor.PadRight(maxHossz);

    for (int i = 0; i < szam; i++)
    {
        Console.Write(feltoltottSor);
        Console.Write("|");
      
    }
    Console.WriteLine();
}

//3 Feladat

string[] tomoritett = File.ReadAllLines("szg_t.txt");
List<string> kibontott = new List<string>();

foreach (string sor in tomoritett)
{
    string ujSor = "";
    int i = 0;

    while (i < sor.Length)
    {
        // szám beolvasása
        if (char.IsDigit(sor[i]))
        {
            int szam2 = 0;

            while (i < sor.Length && char.IsDigit(sor[i]))
            {
                szam2 = szam2 * 10 + (sor[i] - '0');
                i++;
            }

            // a szám utáni karakter
            if (i < sor.Length)
            {
                char jel = sor[i];

                for (int j = 0; j < szam2; j++)
                {
                    ujSor += jel;
                }
                i++;
            }
        }
        else
        {
            // ha nincs szám, akkor 1× írjuk ki
            ujSor += sor[i];
            i++;
        }
    }

    kibontott.Add(ujSor);
}


//4 Feladat
Console.WriteLine("\n4. feladat");

foreach (string sor in kibontott)
{
    Console.WriteLine(sor);
}

//5 Feladat
Console.WriteLine("\n5. feladat");

Console.Write("Kérem adja meg a tömörített ábra fájlnevét: ");
string tomoritettNev = Console.ReadLine();

Console.Write("Kérem adja meg a tömörítetlen ábra fájlnevét: ");
string tomoritetlenNev = Console.ReadLine();

string[] tomoritettSorok = File.ReadAllLines(tomoritettNev);
string[] tomoritetlenSorok = File.ReadAllLines(tomoritetlenNev);

int tomoritettKarakter = 0;
int tomoritetlenKarakter = 0;

foreach (string sor in tomoritettSorok)
{
    tomoritettKarakter += sor.Length;
}

foreach (string sor in tomoritetlenSorok)
{
    tomoritetlenKarakter += sor.Length;
}

double arany = (double)tomoritettKarakter / tomoritetlenKarakter;

Console.WriteLine($"A karakterek száma a tömörített állományban: {tomoritettKarakter}");
Console.WriteLine($"A karakterek száma a tömörítetlen állományban: {tomoritetlenKarakter}");
Console.WriteLine($"A tömörítési arány: {arany:0.00}");

//6 Feladat

Console.WriteLine("\n6. feladat");

// magasság
int magassag = tomoritetlenSorok.Length;

// szélesség
int szelesseg = 0;
foreach (string sor in tomoritetlenSorok)
{
    if (sor.Length > szelesseg)
    {
        szelesseg = sor.Length;
    }
}

// blokkok száma (nem szóköz)
int blokkok = 0;
foreach (string sor in tomoritetlenSorok)
{
    foreach (char c in sor)
    {
        if (c != ' ')
        {
            blokkok++;
        }
    }
}

Console.WriteLine($"Az ábra magassága sorokban: {magassag}");
Console.WriteLine($"Az ábra szélessége karakterekben: {szelesseg}");
Console.WriteLine($"A blokkok száma: {blokkok}");
