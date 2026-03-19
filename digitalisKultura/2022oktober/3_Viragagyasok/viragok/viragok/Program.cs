using viragok;
//1Feladat
string elsoSor=File.ReadLines("felajanlas.txt").First();
string[] sorok = File.ReadAllLines("felajanlas.txt").Skip(1).ToArray();
List<adatok> viragok = new List<adatok>();

for(int i =0; i< sorok.Length; i++)
{
    string[] adat = sorok[i].Split(" ");
    adatok adatok = new adatok(int.Parse(adat[0]), int.Parse(adat[1]), adat[0]);
    viragok.Add(adatok);

}

//2Feladat
Console.WriteLine("2.Feladat");
var ajanlasokSzama=viragok.Count();
Console.WriteLine($"A felajánlások száma: {ajanlasokSzama}");

//3Feladat
Console.WriteLine("3.Feladat");
