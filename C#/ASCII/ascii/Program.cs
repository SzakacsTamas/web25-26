


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