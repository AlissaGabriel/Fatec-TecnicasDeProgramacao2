Cliente cliente1 = new Cliente("Maria", "1111111111");
Cliente cliente2 = new Cliente("João", "222222222");

Produto produto1 = new("Caderno", 10.20);
Produto produto2 = new("Lápis de Cor", 3.50);
Produto produto3 = new("Borracha", 5.00);

var pedidos = new List<Pedido>
{
    new Pedido{Cliente = cliente1, Produto = produto1, Quantidade = 20, DataPedido = DateTime.Now},
    new Pedido{Cliente = cliente1, Produto = produto2, Quantidade = 10, DataPedido = DateTime.Now},
    new Pedido{Cliente = cliente2, Produto = produto3, Quantidade = 2, DataPedido = DateTime.Now}
};

//item a
Console.WriteLine("Pedidos por Cliente: ");
var pedidosPorCliente = pedidos.GroupBy(p => p.Cliente.Nome);
foreach(var p in pedidosPorCliente)
{
    foreach(var item in p)
    {
        Console.WriteLine($"Produto: {item.Produto.Nome}\t Preço: {item.Produto.Preco}");
    }
}

//item b
Console.WriteLine("\nClientes com pedidos acima de 500: ");
var pedidosAcima500 = pedidos.GroupBy(p => p.Cliente)
                             .Where(g => g.Sum(p => p.ValorTotal) > 500)
                             .Select(g => g.Key.Nome);

foreach(var p in pedidosAcima500)
{
    Console.WriteLine(p);
}

//item c
Console.WriteLine("\nValor total pedido por Cliente: ");
var valorTotal = pedidos.GroupBy(p => p.Cliente)
                        .Select(g => new
                        {
                            Cliente = g.Key.Nome,
                            Total = g.Sum(p => p.ValorTotal)
                        });

foreach (var p in valorTotal)
{
    Console.WriteLine($"Cliente: {p.Cliente}\t Valor Total: {p.Total}");
}


public class Produto
{
    public Produto(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
    }
    public string? Nome { get; set; }
    public double? Preco { get; set; }
}

public class Cliente
{
    public Cliente(string nome, string cpf)
    {
    }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
}

public class Pedido
{
    public int Quantidade { get; set; }
    public DateTime? DataPedido { get; set; }
    public Produto? Produto { get; set; }
    public Cliente? Cliente { get; set; }

    public double ValorTotal => (double)(Quantidade * Produto.Preco);
}

