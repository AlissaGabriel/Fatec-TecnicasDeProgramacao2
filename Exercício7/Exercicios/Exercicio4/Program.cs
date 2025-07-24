using System.Text.RegularExpressions;
using System.Xml.Serialization;

CatalogoProdutos catalogoProdutos = new CatalogoProdutos();
string caminhoArquivoXml = "C:\\Users\\Alissa\\Desktop\\Exercicios\\Exercicio4\\produtos.xml";

catalogoProdutos.ProdutoAdicionado += RelatorioProduto.GerarRelatorio;

if (File.Exists(caminhoArquivoXml))
{
    catalogoProdutos.CarregarDeXml(caminhoArquivoXml);
    Console.WriteLine("Dados de produtos carregados do arquivo.\n");
}
else
{
    Console.WriteLine("Arquivo de produtos não encontrado. Criando produtos de teste...\n");
    catalogoProdutos.AdicionarProduto(new Produto("Computador", "Eletrônicos", 1999.99m));
    catalogoProdutos.AdicionarProduto(new Produto("Mesa", "Móveis", 150.00m));
    catalogoProdutos.AdicionarProduto(new Produto("Mouse", "Eletrônicos", 49.99m));
    catalogoProdutos.AdicionarProduto(new Produto("Camisa", "Roupas", 75.50m));

    catalogoProdutos.SalvarEmXml(caminhoArquivoXml);
    Console.WriteLine();
}

Console.WriteLine("Produtos com preço entre 50 e 200:");
catalogoProdutos.ProdutosEntre50e200();
Console.WriteLine();

Console.WriteLine("Produtos agrupados por categoria:");
catalogoProdutos.Agrupar();
Console.WriteLine();

public class Produto
{
    public string Nome { get; set; }
    public string Categoria { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataCadastro { get; set; }

    public Produto() { }

    public Produto(string nome, string categoria, decimal preco)
    {
        Nome = nome;
        Categoria = categoria;
        Preco = preco;
        DataCadastro = DateTime.Now;
    }
}

public delegate void ProdutoHandler(object? sender, Produto p);

public class CatalogoProdutos
{
    public List<Produto> Produtos { get; set; } = new List<Produto>();
    public event ProdutoHandler ProdutoAdicionado;

    public void AdicionarProduto(Produto p)
    {
        Produtos.Add(p);
        ProdutoAdicionado?.Invoke(this, p);
    }

    public void SalvarEmXml(string caminhoArquivo)
    {
        var serializer = new XmlSerializer(typeof(List<Produto>));
        using (var writer = new StreamWriter(caminhoArquivo))
        {
            serializer.Serialize(writer, Produtos);
            Console.WriteLine("Produtos salvos com sucesso em arquivo XML!");
        }
    }

    public void CarregarDeXml(string caminhoArquivo)
    {
        if (File.Exists(caminhoArquivo))
        {
            var serializer = new XmlSerializer(typeof(List<Produto>));
            using (var reader = new StreamReader(caminhoArquivo))
            {
                Produtos = (List<Produto>)serializer.Deserialize(reader);
                foreach (var p in Produtos)
                {
                    Console.WriteLine($"Nome: {p.Nome}, Categoria: {p.Categoria}, Preço: {p.Preco}");
                }
            }
        }
        else
        {
            Console.WriteLine("Arquivo de produtos não encontrado.");
        }
    }

    public void ProdutosEntre50e200()
    {
        var produtosPorPreco = Produtos.Where(p => p.Preco >= 50 && p.Preco <= 200).ToList();
        foreach (var p in produtosPorPreco)
        {
            Console.WriteLine($"Produtos: {p.Nome}");
        }
    }

    public void Agrupar()
    {
        var produtosAgrupadosPorCategoria = Produtos
            .GroupBy(p => p.Categoria)
            .ToList();
        foreach (var grupo in produtosAgrupadosPorCategoria)
        {
            Console.WriteLine($"Categoria: {grupo.Key}");
            foreach (var produto in grupo)
            {
                Console.WriteLine($"- {produto.Nome}, Preço: {produto.Preco:C}");
            }
        }
    }


}


public class RelatorioProduto
{
    public static void GerarRelatorio(object? sender,  Produto p)
    {
        string caminhoRelatorio = "C:\\Users\\Alissa\\Desktop\\Exercicios\\Exercicio4\\relatorio.txt";
        string mensagemRelatorio = $"Produto: {p.Nome}, Categoria: {p.Categoria}, " +
                                   $"Preço: {p.Preco:C}, Data de Cadastro: {p.DataCadastro}\n";

        using (var writer = new StreamWriter(caminhoRelatorio, append: true))  
        {
            writer.WriteLine(mensagemRelatorio);
        }

        Console.WriteLine("Relatório gerado com sucesso!");
    }
}
