using System;

Estoque estoque = new Estoque();

estoque.OnCriarEstoque += Monitor.Criacao;
estoque.OnEstoqueBaixo += Monitor.Alerta;

estoque.criarEstoque("Caneta", 10, 5);

estoque.RemoverEstoque(2);
estoque.RemoverEstoque(2);
estoque.RemoverEstoque(1);

Console.ReadKey();

public class EstoqueEventArgs : EventArgs
{
    public string? Nome {  get; set; }
    public int? Quantidade { get; set; }
    public int? LimiteMinimo { get; set; }
}

public class Estoque
{
    public string? nomeProduto { get; set; }
    public int? quantidadeInicialProduto { get; set; }
    public int? limiteMinimoEstoque { get; set; }

    public event EventHandler<EstoqueEventArgs>? OnCriarEstoque;
    public event EventHandler<EstoqueEventArgs>? OnEstoqueBaixo;

   public void criarEstoque(string nome, int quantidadeInicial, int limiteMinimo)
    {
        nomeProduto = nome;
        quantidadeInicialProduto = quantidadeInicial;
        limiteMinimoEstoque = limiteMinimo;
        Console.WriteLine("Iniciando o criar estoque");
        if (OnCriarEstoque != null)
        {
            OnCriarEstoque(this, new EstoqueEventArgs { Nome = nome, Quantidade = quantidadeInicial, LimiteMinimo = limiteMinimo });
        }
    }

    public void RemoverEstoque(int quantidade)
    {
        quantidadeInicialProduto -= quantidade;
        Console.WriteLine($"Foram removidas {quantidade} quantidades do produto {nomeProduto}");
        if (quantidadeInicialProduto <= limiteMinimoEstoque)
        {
            Console.WriteLine($"Produto: {nomeProduto} | Nova quantidade: {quantidadeInicialProduto}");
            OnEstoqueBaixo(this, new EstoqueEventArgs { Nome = nomeProduto, Quantidade = quantidadeInicialProduto, LimiteMinimo = limiteMinimoEstoque });
        }
    }
}

public class Monitor
{
    public static void Alerta(object? sender, EstoqueEventArgs e)
    {
        Console.WriteLine($"Alerta de estoque baixo: {e.Quantidade}");
    }

    public static void Criacao(object? sender, EstoqueEventArgs e)
    {
        Console.WriteLine($"Estoque criado para: {e.Nome} com quantidade de: {e.Quantidade} e limite de estoque de: {e.LimiteMinimo}");
    }
}




