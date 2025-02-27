string[] nomes = new string[4] { "Ana", "Paulo", "Maria", "Samuel" };

Exibir(nomes);

Array.Reverse(nomes);
Console.WriteLine("\nExibir Invertido: ");
Exibir(nomes);

Array.Sort(nomes);
Console.WriteLine("\nExibir em ordem alfabética: ");
Exibir(nomes);

var indice = Array.BinarySearch(nomes, "Maria");
Console.WriteLine("\nEncontrar um índice no array: ");
Console.WriteLine(indice);

void Exibir(string[] nomes)
{
    foreach (var nome in nomes)
    {
        Console.WriteLine(nome);
    }
}


