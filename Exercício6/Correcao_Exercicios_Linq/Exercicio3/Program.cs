List<Pessoa> pessoas = new List<Pessoa>
{
    new Pessoa { Nome = "João", Idade = 17 },
    new Pessoa { Nome = "Maria", Idade = 22 },
    new Pessoa { Nome = "Carlos", Idade = 30 }
};

//item a
var maiorIdade = pessoas.Where(p => p.Idade > 17);

Console.WriteLine("Pessoas maiores de idade: ");
foreach(var maior in maiorIdade)
{
    Console.WriteLine(maior.Nome);
}

//item b
Console.WriteLine("\nPessoas ordenadas pelo nome: ");
var pessoasOrdenado = pessoas.Select(p => p.Nome).OrderBy(n => n);
foreach(var pessoa in pessoasOrdenado)
{
    Console.WriteLine($"Nome: {pessoa}");
}

class Pessoa
{
    public string? Nome { get; set; }
    public int Idade { get; set; }
}