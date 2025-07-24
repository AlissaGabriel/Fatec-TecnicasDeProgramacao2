using System;
using System.IO;
using System.Text.Json;

Livro livro = new Livro("Diario de um Banana", "Jeff Kinney", 2007);
var caminho = @"C:\Users\Alissa\Desktop\Exercicios\Exercicio2\livro.json";

// Serialização
string jsonString = JsonSerializer.Serialize(livro);
File.WriteAllText(caminho, jsonString);

Console.WriteLine("\nObjeto livro serializado\n");

// Desserialização
string jsonStringLido = File.ReadAllText(caminho);
Livro livroDess = JsonSerializer.Deserialize<Livro>(jsonStringLido);

Console.WriteLine($"Titulo: {livroDess.Titulo}, Autor: {livroDess.Autor}, Ano: {livroDess.Ano}");

Console.ReadKey();

public class Livro
{
    public Livro(string titulo, string autor, int ano)
    {
        Titulo = titulo;
        Autor = autor;
        Ano = ano;
    }

    public Livro() { }

    public string? Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }
}
