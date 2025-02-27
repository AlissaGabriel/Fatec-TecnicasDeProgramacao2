//aumentar dinamicamente
//valores do mesmo tipo
//Declaração
//List <tipo> nome_list = new List <tipo> ();
//List <string> nomes = new List <string> ();
//var nomes = new List <string> ();
//List <double> numeros = new ();
//var lista = new List <string> () { "Maria" };
//Operações
//igual ao ArrayList
//Métodos
//Contains, Sort e Clear
//Find(predicado) - 1º elemento
//FindLast(predicado)
//FindIndex(predicado)
//FindLastIndex(predicado)
//FindAll(predicado)
//*Predicado é uma função de argumento único que retorna um valor booleano

List<string> nomes = new() { "Maria", "Marta", "Carlos" };

var nome = nomes.Find(Procurar);
Console.WriteLine("Procura pelo início: ");
Console.WriteLine(nome);

var nome1 = nomes.FindLast(Procurar);
Console.WriteLine("\nProcura pelo final: ");
Console.WriteLine(nome1);

var lista = nomes.FindAll(Procurar);
Console.WriteLine("\nProcura todos: ");
foreach (var item in lista)
{
    Console.WriteLine(item);
}


static bool Procurar(string item)
{
    return item.Contains('M');
}

