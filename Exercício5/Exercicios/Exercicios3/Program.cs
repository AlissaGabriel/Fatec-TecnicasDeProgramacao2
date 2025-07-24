using System;

Botao botao = new Botao();
ContadorCliques contador = new ContadorCliques();
botao.OnClique += contador.Clique;

botao.SimularClique();
botao.SimularClique();
botao.SimularClique();

Console.ReadKey();

public class Botao
{
    public event EventHandler OnClique;
    public void SimularClique()
    {
        OnClique(this, EventArgs.Empty);
    }
}

public class ContadorCliques
{
    public int numeroDeCliques = 0;
    public void Clique(object? sender, EventArgs e)
    {
        numeroDeCliques++;
        Console.WriteLine($"Quantidade de cliques: {numeroDeCliques}");
    }
}
