using Exercicio5;

Leitor leitor1 = new("joao@gmail.com", "João", 18);
Livro livro1 = new(1, "Diário de um Banana", "Jeff Kinney");
Emprestimo emprestimo1 = new(leitor1, livro1, DateTime.Now);

Console.WriteLine("Detalhes do livro:\n ");
emprestimo1.livroEmprestado();

public class Pessoa
{
    public Pessoa(string? nome, int? idade)
    {
        Nome = nome;
        Idade = idade;
    }
    public string? Nome { get; set; }
    public int? Idade { get; set; }
}

public class Leitor : Pessoa
{
    public Leitor(string? email, string? nome, int? idade) : base(nome, idade)
    {
        Email = email;
    }
    public string? Email { get; set; }
}

public class Livro
{
    public Livro(int id, string titulo, string autor)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
    }

    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
}