using Adresse.Kerne;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Find adresser");
Console.WriteLine("-------------");
Console.WriteLine("Indtast adresse eller postnummer (eller del af - brug *)");
string? q = Console.ReadLine();
if (q == null) return;
var v = (await VejnavnPostnummer.Find(q))?.ToList();
if (v == null || v.Count == 0)
    Console.WriteLine("Intet fundet!");
v?.ForEach(Console.WriteLine);