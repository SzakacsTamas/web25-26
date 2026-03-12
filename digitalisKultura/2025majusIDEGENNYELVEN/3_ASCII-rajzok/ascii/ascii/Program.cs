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
string asd = "szöveg \n sadsad";
/*
for (int i = 0; i < szam; i++)
{
    foreach (string sor in konyv)
    {
        Console.WriteLine($"{sor} |");
        
    }
}
*/
Console.Write(asd);