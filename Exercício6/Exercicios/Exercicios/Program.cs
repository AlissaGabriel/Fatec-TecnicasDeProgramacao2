List<int> numeros = new List<int> { 5, 12, 8, 20, 3, 15, 7 };
int somaImpares = numeros.SomarImpares();

var impares = from n in numeros
            where n % 2 != 0
            select n;

Console.WriteLine("Números Ímpares:");
foreach (var impar in impares)
{
    Console.WriteLine(impar);
}

Console.WriteLine($"Soma dos ímpares: {somaImpares}");

public static class ListSomarImpares
{
    public static int SomarImpares(this List<int> lista)
    {
        return (from n in lista
                    where n % 2 != 0
                    select n).Sum();
    }
}


