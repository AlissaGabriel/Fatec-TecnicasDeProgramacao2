using Exercicío_7;
using System;
using static Exercicío_7.Biblioteca;

try
{
    Livro livro1 = new("C# para Iniciantes", "Autor A", 1);
    Livro livro2 = new("Programação Avançada em C#", "Autor B", 2);
    Livro livro3 = new("Estruturas de Dados", "Autor C", 3);

    Usuario usuario1 = new("João", 101);
    Usuario usuario2 = new("Maria", 102);

    if (livro1.Status)
    {
        if (usuario1.LivrosEmprestados.Any(emprestimo => emprestimo.DataPrevistaDevolucao < DateTime.Now))
        {
            throw new InvalidOperationException("Usuário tem livro com data de devolução ultrapassada.");
        }

        Emprestimo emprestimo1 = new Emprestimo(livro1, usuario1, DateTime.Now, DateTime.Now.AddDays(1));

        livro1.Status = false;
        usuario1.LivrosEmprestados.Add(emprestimo1);

        Console.WriteLine($"Livro '{livro1.Titulo}' emprestado para {usuario1.Nome} até {emprestimo1.DataPrevistaDevolucao.ToShortDateString()}.");
    }
    else
    {
        throw new InvalidOperationException("Livro já está emprestado.");
    }

    if (livro3.Status)
    {
        if (usuario1.LivrosEmprestados.Any(emprestimo => emprestimo.DataPrevistaDevolucao < DateTime.Now))
        {
            throw new InvalidOperationException("Usuário tem livro com data de devolução ultrapassada.");
        }

        Emprestimo emprestimo2 = new(livro3, usuario1, DateTime.Now, DateTime.Now.AddDays(10));

        livro3.Status = false;
        usuario1.LivrosEmprestados.Add(emprestimo2);

        Console.WriteLine($"Livro '{livro3.Titulo}' emprestado para {usuario1.Nome} até {emprestimo2.DataPrevistaDevolucao.ToShortDateString()}.");
    }
    else
    {
        throw new InvalidOperationException("Livro já está emprestado.");
    }

    var emprestimoJoao = usuario1.LivrosEmprestados.FirstOrDefault(emprestimo => emprestimo.LivroEmprestado.Id == livro1.Id);
    if (emprestimoJoao != null)
    {
        usuario1.LivrosEmprestados.Remove(emprestimoJoao);
        emprestimoJoao.LivroEmprestado.Status = true;

        Console.WriteLine($"Livro '{livro1.Titulo}' devolvido por {usuario1.Nome}.");
    }
    else
    {
        throw new InvalidOperationException("Este livro não foi emprestado para este usuário.");
    }

    if (livro2.Status)
    {
        if (usuario2.LivrosEmprestados.Any(emprestimo => emprestimo.DataPrevistaDevolucao < DateTime.Now))
        {
            throw new InvalidOperationException("Usuário tem livro com data de devolução ultrapassada.");
        }

        Emprestimo emprestimo2 = new(livro2, usuario2, DateTime.Now, DateTime.Now.AddDays(10));
        livro2.Status = false;
        usuario2.LivrosEmprestados.Add(emprestimo2);

        Console.WriteLine($"Livro '{livro2.Titulo}' emprestado para {usuario2.Nome} até {emprestimo2.DataPrevistaDevolucao.ToShortDateString()}.");
    }
    else
    {
        throw new InvalidOperationException("Livro já está emprestado.");
    }

    if (livro3.Status)
    {
        if (usuario2.LivrosEmprestados.Any(emprestimo => emprestimo.DataPrevistaDevolucao < DateTime.Now))
        {
            throw new InvalidOperationException("Usuário tem livro com data de devolução ultrapassada.");
        }

        Emprestimo emprestimo3 = new(livro3, usuario2, DateTime.Now, DateTime.Now.AddDays(10));
        livro3.Status = false;
        usuario2.LivrosEmprestados.Add(emprestimo3);

        Console.WriteLine($"Livro '{livro3.Titulo}' emprestado para {usuario2.Nome} até {emprestimo3.DataPrevistaDevolucao.ToShortDateString()}.");
    }
    else
    {
        throw new InvalidOperationException($"o Livro {livro3.Titulo} já está emprestado.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");

}
