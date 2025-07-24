using Exercicio4;
using System.Text.RegularExpressions;

Produto produto1 = new Produto("Computador", 2500.00);
Produto produto2 = new Produto("Mouse", 150.00);

Cliente cliente1 = new Cliente("João", "123.456.789-00");
Cliente cliente2 = new Cliente("Maria", "987.654.321-00");
Cliente cliente3 = new Cliente("Márcio", "132.456.798-00");

List<Produto> produtosPedido1 = new List<Produto> { produto1, produto2}; 
Pedidos pedido1 = new Pedidos(10, new DateTime(2015, 5, 10, 9, 30, 0), produtosPedido1, cliente1);


List<Produto> produtosPedido2 = new List<Produto> { produto1 };
Pedidos pedido2 = new Pedidos(20, new DateTime(2015, 5, 10, 9, 30, 0), produtosPedido2, cliente2);

List<Produto> produtosPedido3 = new List<Produto> { produto2 };
Pedidos pedido3 = new Pedidos(1, new DateTime(2015, 5, 10, 9, 30, 0), produtosPedido3, cliente3);

List<Pedidos> pedidos = new List<Pedidos> { pedido1, pedido2, pedido3};


//a. Mostre todos os pedidos agrupados por cliente.
var pedidosPorCliente = from p in pedidos
                        group p by p.Cliente into pedidoGrupo
                        select pedidoGrupo;

foreach (var grupo in pedidosPorCliente)
{
    Console.WriteLine($"\nCliente: {grupo.Key.Nome}");  //`grupo.Key` é o cliente
    foreach (var pedido in grupo) //acessando os pedidos dentro do grupo
    {
        Console.WriteLine($"Data do Pedido: {pedido.DataPedido?.ToString("dd/MM/yyyy HH:mm")}");
        Console.WriteLine("Itens do Pedido: ");
        foreach (var produto in pedido.Produto) //iterando sobre os produtos dentro do pedido
        {
            Console.WriteLine($"Nome: {produto.Nome}, Preço: R$ {produto.Preco:F2}");
        }
    }  
}

//b. Trazer os nomes dos clientes que têm pedidos acima de R$ 500
var acimaDe500 = from p in pedidos
                 group p by p.Cliente into pedidoGrupo
                 let TotalPedidos = pedidoGrupo.Sum
                     (p => p.Produto.Sum(produto => produto.Preco * p.Quantidade))
                where TotalPedidos > 500
                 select pedidoGrupo;

Console.WriteLine("\nClientes com Pedidos acima de R$ 500: ");
foreach (var nomeCliente in acimaDe500)
{
    Console.WriteLine($"Cliente: {nomeCliente.Key.Nome}");
}

//c. Calcular o valor total de pedidos por cliente
var totalPedido = from p in pedidos
                 group p by p.Cliente into pedidoGrupo
                 select new
                 {
                     Cliente = pedidoGrupo.Key,
                     TotalPedidos = pedidoGrupo.Sum
                     (p => p.Produto.Sum(produto => produto.Preco * p.Quantidade))
                 };

Console.WriteLine("\nValor total de pedidos por cliente: ");
foreach (var total in totalPedido)
{
    Console.WriteLine($"Cliente: {total.Cliente.Nome}, Total: {total.TotalPedidos:F2}");
}