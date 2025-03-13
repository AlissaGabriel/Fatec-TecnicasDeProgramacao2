//IEnumerable <T>
//ICollection <T>
//representam coleção genéricas de elementos;
//ICollection herda de IEnumerable
//ICollection permite adicionar e remover elementos, além de contar itens.
//Exemplo
//public void ExibirNomes(IEnumerable<string>nomes){}
//ICollection<string>nomes = new List <string>;

ExemploIEnumerable obj = new ExemploIEnumerable();
List<string> nomes1 = new List<string> { "Maria", "Paulo"};

String[] nomes2 = { "Clara", "Pedro" };

Console.WriteLine("Listando os nomes: ");
obj.ExibirNome(nomes1);
obj.ExibirNome(nomes2);

//Exemplo ICollection
ICollection<string> pessoas = new List<string> { "Clóvis" };

Console.WriteLine("\nAdicionando João: ");
pessoas.Add("João");
foreach (var nome in pessoas)
{
    Console.WriteLine(nome);
}

Console.WriteLine("\nRemovendo Clóvis: ");
pessoas.Remove("Clóvis");
foreach (var nome in pessoas)
{
    Console.WriteLine(nome);
}

public class ExemploIEnumerable
{
    public void ExibirNome(IEnumerable<string> nomes)
    {
        foreach(var nome in nomes)
        {
            Console.WriteLine(nome);
        }
    }
}
