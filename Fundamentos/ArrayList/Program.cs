//aumenta dinamicamente
//guarda valores de diversos tipos
//ArrayList() -> classe
//Declarações
//ArrayList lista = new ArrayList(5);
//var lista = new ArrayList(5);
//ArrayList lista = new(5);
//var lista = new ArrayList(){"Paulo", 4.5, 5, true, "", null};
//Tipo Object -> "pai" de todos os tipos
//Operações
//nome_arraylist.Add("Maria");
//nome_arraylist.Insert(2, 10);
//nome_arraylist.AddRange(array);
//nome_arraylist.InsertRange(3, array);
//nome_arraylist.Remove(objeto_value);
//nome_arraylist.RemoveAt(int index);
//nome_arraylist.RemoveRange(int index, int count); //int count, a partir do index quantos são para remover
//Métodos
//nome_arraylist.Contains(object_value); //procurar pelo valor
//nome_arraylist.Sort(); //classifica (mesmo tipo)
//nome_arraylist.Clear(); //limpa o arraylist

using System.Collections;

var lista = new ArrayList() { "Maria", 25, 52.7, true };
Console.WriteLine("\nExibindo o array list: ");
Exibir(lista);

lista.Add("Paulo");
Console.WriteLine("\nExibindo o array list adicionando um valor: ");
Exibir(lista);


lista.Insert(1, 10);
Console.WriteLine("\nExibindo o array list adicionando um valor no índice 1: ");
Exibir(lista);

int[] numeros = { 1, 2, 3 };
lista.AddRange(numeros); //adiciona no final do array
Console.WriteLine("\nExibindo o array list adicionando números no final: ");
Exibir(lista);

lista.Remove("Paulo");
Console.WriteLine("\nExibindo o array list removendo paulo da lista: ");
Exibir(lista);

lista.RemoveAt(1);
Console.WriteLine("\nExibindo o array list removendo o índice 1 da lista: ");
Exibir(lista);

lista.RemoveRange(1, 2);
Console.WriteLine("\nExibindo o array list removendo o índice 1 da lista e os próximos 2: ");
Exibir(lista);

if (lista.Contains(25))
{
    Console.WriteLine("\nEncontrou");
}
else
{
    Console.WriteLine("\nNão encontrou");
}

ArrayList nomes = new ArrayList() { "Paulo", "André", "Kátia" };
nomes.Sort();
Console.WriteLine("\nOrdenando pelo mesmo tipo: ");
Exibir(nomes);

void Exibir(ArrayList lista)
{
    foreach(var item in lista)
    {
        Console.WriteLine(item);
    }
}

