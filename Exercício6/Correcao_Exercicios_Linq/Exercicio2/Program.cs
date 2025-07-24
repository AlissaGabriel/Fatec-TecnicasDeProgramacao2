List<int> numeros = new List<int> { 5, 12, 8, 20, 3, 15, 7 };

//item a
var maior = numeros.Max();
Console.WriteLine($"O maior número é: {maior}");

//item b
var somaMaior10 = numeros.Where(n => n > 10).Sum();
Console.WriteLine($"\nA soma dos elementos maiores que 10 é: {somaMaior10}");