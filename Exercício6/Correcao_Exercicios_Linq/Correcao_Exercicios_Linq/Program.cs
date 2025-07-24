List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };
var somaImpares = numeros.Where(n => n % 2 != 0).Sum();
Console.WriteLine(somaImpares);