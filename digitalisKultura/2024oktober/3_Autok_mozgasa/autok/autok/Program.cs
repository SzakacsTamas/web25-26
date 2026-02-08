using autok;

List<adatok> autok = new List<adatok>();
string[] sorok = File.ReadAllLines("jeladas.txt");

for (int i=0; i < sorok.Length; i++ )
{
    string[] adatok = sorok[i].Split("\t");
    adatok adat=new adatok(adatok[0], int.Parse(adatok[1]), int.Parse(adatok[2]), int.Parse(adatok[3]));
    autok.Add(adat);
}

foreach (adatok adat in autok)
{
    Console.WriteLine($"{adat.rendSzam} {adat.ora} {adat.perc} {adat.sebesseg}");
}