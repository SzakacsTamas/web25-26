using sebesseg;

//1FELADAT
List<adatok> autok = new List<adatok>();
string fejlec = File.ReadLines("ut.txt").First();
string[] sorok = File.ReadAllLines("ut.txt").Skip(1).ToArray();

for (int i = 0; i < sorok.Length; i++)
{
    string[] adat = sorok[i].Split(" ");
    adatok x = new adatok(int.Parse(adat[0]), adat[1]);
    autok.Add(x);
}


//2Feladat
Console.WriteLine("2.Feladat");
var telepulesk= autok.Where(y=>y.esemeny.StartsWith("Varos")).ToList();
Console.WriteLine("A telepulések neve:");
foreach (var item in telepulesk)
{
    Console.WriteLine(item.esemeny);
}

//3Feladat
Console.WriteLine("3.Feladat");
Console.Write("Adja meg a vizsgált szakasz hosszát km-ben!");
double bekertTav = double.Parse(Console.ReadLine());
var tavolsagok = autok.Select(x => x.tavolsag).ToList();
var elso = tavolsagok[0];
Console.WriteLine(elso);
for (int i =1; i < autok.Count(); i++)
{
    int jelen = tavolsagok[i];
    int mult = tavolsagok[i-1];
    Console.WriteLine($"Múlt: {mult} | Jelen: {jelen}");

}