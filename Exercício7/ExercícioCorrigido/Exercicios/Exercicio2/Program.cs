using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

Biblioteca biblioteca = new Biblioteca();

// Criando alguns livros 
var livros = new List<Livro>
{
    new Livro("Dom Casmurro", "Machado de Assis", 1899),
    new Livro("A Revolução dos Bichos", "George Orwell", 1945),
    new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", 1954)
};

// Salvando livros em JSON
biblioteca.SalvarLivros(livros);

// Carregando do JSON e exibindo
var livrosJson = biblioteca.CarregarLivros();
biblioteca.ExibirLivros(livrosJson);

Console.ReadKey();
public class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }

    public Livro(string titulo, string autor, int ano)
    {
        Titulo = titulo;
        Autor = autor;
        Ano = ano;
    }

    // Construtor vazio necessário para desserialização
    public Livro() { }
}


public class Biblioteca
{
    //acertar o caminho para rodar na sua máquina
    private string caminho = @"C:\fatec\Tecnica_Programacao_II\livros.json";

    public void SalvarLivros(List<Livro> livros)
    {
        
        string json = JsonSerializer.Serialize(livros);
        File.WriteAllText(caminho, json);
        Console.WriteLine("Livros salvos com sucesso!");
    }

    public List<Livro> CarregarLivros()
    {
        if (!File.Exists(caminho))
        {
            Console.WriteLine("Nenhum arquivo encontrado.");
            return new List<Livro>();
        }

        string json = File.ReadAllText(caminho);
        var livros = JsonSerializer.Deserialize<List<Livro>>(json);
        return livros;
    }

    public void ExibirLivros(List<Livro> livros)
    {
        Console.WriteLine("\nLista de Livros:");
        foreach (var livro in livros)
        {
            Console.WriteLine($"- {livro.Titulo} ({livro.Ano}), por {livro.Autor}");
        }
    }
}

