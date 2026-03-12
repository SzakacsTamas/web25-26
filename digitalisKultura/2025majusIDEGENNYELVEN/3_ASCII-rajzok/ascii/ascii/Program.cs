using ascii;

//1Feladat
Console.WriteLine("1. feladat");
string[] konyv = File.ReadAllLines("konyv.txt");

foreach (string sor in konyv)
{
    Console.WriteLine(sor);
}

//2Feladat
Console.WriteLine("2. feladat");
Console.Write("Kérem adja meg az ismétlések számát: ");
int szam = int.Parse(Console.ReadLine());
int maxHossz = 0;

foreach (string sor in konyv)
{
    if (sor.Length > maxHossz)
        maxHossz = sor.Length;
}
foreach (string sor in konyv)
{
    for (int i = 0; i < szam; i++)
    {
        Console.Write(sor.PadRight(maxHossz) + " | ");
    }
    Console.WriteLine();
}

