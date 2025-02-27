//Expressão LamBida
//é uma função anônima e usa o operador =>
//var frutas = new List <string> () {"Maçã", "Banana", "Uva"};
//exemplo:
//var resultado1 = frutas.Find(i=>i.Contains('B'));
//var resultado2 = frutas.FindLast(i=>i.Contains('B'));
//var resultado3 = frutas.FindIndex(i=>i.Contains('B'));

var frutas = new List<string>() { "Maçã", "Banana", "Uva", "Bergamota" };

Console.WriteLine("Procurando pelo início: ");
var resultado1 = frutas.Find(i => i.Contains('B'));
Console.WriteLine(resultado1);
Console.WriteLine("Procurando pelo final: ");
var resultado2 = frutas.FindLast(i => i.Contains('B'));
Console.WriteLine(resultado2);
Console.WriteLine("Procurando pelo índice: ");
var resultado3 = frutas.FindIndex(i => i.Contains('B'));
Console.WriteLine(resultado3);
Console.WriteLine("Procurando pelo valor: ");
var resultado4 = frutas.Find(i => i.Contains("Maçã"));
Console.WriteLine(resultado4);