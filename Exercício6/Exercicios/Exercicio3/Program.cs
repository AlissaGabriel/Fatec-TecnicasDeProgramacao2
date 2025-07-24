var pessoas = Pessoa.GetPessoas();

var maiorQue18 = from p in pessoas
                 where p.Idade > 18
                 select p;

Console.WriteLine($"Pessoas maiores que 18: ");
foreach( var pessoa in maiorQue18)
{
    Console.WriteLine($"Nome: {pessoa.Nome}\t Idade: {pessoa.Idade}");
}

var ordenadosAlfabeticamente = from p in pessoas
                               orderby p.Nome
                               select p;

Console.WriteLine($"Pessoas ordenadas alfabeticamente: ");
foreach (var pessoa in ordenadosAlfabeticamente)
{
    Console.WriteLine($"Nome: {pessoa.Nome}\t Idade: {pessoa.Idade}");
}

class Pessoa
{
    public string? Nome { get; set; }

    public int Idade { get; set; }

    public static List<Pessoa> GetPessoas()
    {
        List<Pessoa> pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "João", Idade = 17 },

             new Pessoa { Nome = "Maria", Idade = 22 },

            new Pessoa { Nome = "Carlos", Idade = 30 }
        };
        return pessoas;
    }
}


