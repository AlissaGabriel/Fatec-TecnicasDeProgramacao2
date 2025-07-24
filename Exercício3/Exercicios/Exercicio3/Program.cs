//Relacionamento Composição

Pedido pedido1 = new(1, DateTime.Now, "Calça", 10, 50.00m);
Console.WriteLine("Detalhes do pedido:\n ");
pedido1.mostrar();

public class Pedido
{
    public Pedido(int? id, DateTime dataPedido, string produto, int quantidade, decimal preco)
    {
        Id = id;
        DataPedido = dataPedido;
        ItensPedido = new ItemPedido(produto, quantidade, preco);
    }

    public int? Id { get; set; }
    public DateTime DataPedido { get; set; }
    public ItemPedido ItensPedido { get; set; }

    public void mostrar()
    {
        Console.WriteLine($"Id: {Id}\nData do Pedido: {DataPedido}\nProduto: {ItensPedido.Produto}\nQuantidade: {ItensPedido.Quantidade}\nPreço: {ItensPedido.Preco}");
    }

    public class ItemPedido
    {
        public ItemPedido(string produto, int quantidade, decimal preco)
        {
            Produto = produto;
            Quantidade = quantidade;
            Preco = preco;
        }

        public string Produto { get; set; }
        public int? Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}//fim da classe carro


