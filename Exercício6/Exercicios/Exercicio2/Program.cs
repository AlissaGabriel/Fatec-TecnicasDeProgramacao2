List<int> numeros = new List<int> { 5, 12, 8, 20, 3, 15, 7 };

var maiorNumero = numeros.Max();
Console.WriteLine($"Maior número: {maiorNumero}");

var somaMaiorQue10 = (from n in numeros
            where n > 10
            select n).Sum();

Console.WriteLine($"Soma dos números maiores que 10: {somaMaiorQue10}");
