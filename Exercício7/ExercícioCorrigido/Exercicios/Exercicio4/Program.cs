using System.Xml.Serialization;


var catalogo = new CatalogoProdutos();
var relatorio = new Relatorio();

catalogo.ProdutoAdicionado += relatorio.GerarLinha;

catalogo.AdicionarProduto(new Produto("Teclado", "Periféricos", 120));
catalogo.AdicionarProduto(new Produto("Monitor", "Periféricos", 800));
catalogo.AdicionarProduto(new Produto("Cadeira Gamer", "Móveis", 950));
catalogo.AdicionarProduto(new Produto("Mouse", "Periféricos", 70));
//é salvo no projeto pasta bin/debug
catalogo.SalvarXML("produtos.xml");

Console.WriteLine("\nProdutos entre R$50 e R$200:");
catalogo.BuscarPorFaixaPreco(50, 200);
    

Console.WriteLine("\nProdutos agrupados por categoria:");
catalogo.AgruparPorCategoria();


Console.ReadKey();

public delegate void ProdutoHandler(Produto p);

public class Produto
{
    public string Nome { get; set; }
    public string Categoria { get; set; }
    public double Preco { get; set; }
    public DateTime DataCadastro { get; set; }

    public Produto() { } // Necessário para XML

    public Produto(string nome, string categoria, double preco)
    {
        Nome = nome;
        Categoria = categoria;
        Preco = preco;
        DataCadastro = DateTime.Now;
    }
}


public class CatalogoProdutos
{
    public List<Produto> Produtos { get; private set; } = new();
    public event ProdutoHandler? ProdutoAdicionado;

    public void AdicionarProduto(Produto p)
    {
        Produtos.Add(p);
        ProdutoAdicionado?.Invoke(p);
    }

    public void SalvarXML(string caminho)
    {
        using var stream = new FileStream(caminho, FileMode.Create);
        var serializer = new XmlSerializer(typeof(List<Produto>));
        serializer.Serialize(stream, Produtos);
    }

    public void CarregarXML(string caminho)
    {
        if (!File.Exists(caminho)) return;

        using var stream = new FileStream(caminho, FileMode.Open);
        var serializer = new XmlSerializer(typeof(List<Produto>));
        Produtos = (List<Produto>)serializer.Deserialize(stream)!;
    }

    public void BuscarPorFaixaPreco(double min, double max)
    {
        var produtosFaixa = Produtos.Where(p => p.Preco >= min && p.Preco <= max)
                    .OrderBy(p => p.Nome);

        foreach (var produto in produtosFaixa)
        {
            Console.WriteLine($"{produto.Nome}\t{produto.Preco:C2}\t{produto.Categoria}");
        }
    }
        

    public void AgruparPorCategoria()
    {

        var produtosPorCategoria = Produtos.GroupBy(p => p.Categoria)
                                   .OrderBy(c => c.Key);

        foreach (var grupo in produtosPorCategoria)
        {
            Console.WriteLine(grupo.Key + ":" + grupo.Count());

            foreach (var produto in grupo)
            {
                Console.WriteLine(produto.Nome);
            }
        }
    }
}
public class Relatorio
{
    //gravado na pasta do projeto 
    private const string CaminhoRelatorio = "relatorio.txt";

    public void GerarLinha(Produto p)
    {
        string linha = $"[{DateTime.Now}] Produto: {p.Nome}, R${p.Preco}, Categoria: {p.Categoria}";
        using StreamWriter sw = new(CaminhoRelatorio, append: true);
        sw.WriteLine(linha);
    }
}


