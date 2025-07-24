using ExemplosLinq;

var produtos = Produto.GetProdutos();

//buscar lista de Eletrônicos
Console.WriteLine("Produtos Eletrônicos");
var eletronicos = produtos.Where(p => p.Categoria == "Eletrônicos");
foreach(var eletronico in eletronicos)
{
    Console.WriteLine($"{eletronico.Nome}\t{eletronico.Preco:C2}");
}

//os produtos mais caros e com estoque mínimo de 10 ordenado pelo nome
Console.WriteLine("\nProdutos Caros");

var produtosCaros = produtos.Where(p => p.Preco >= 2000 && p.Estoque < 10).OrderBy(p => p.Nome);

foreach(var produto in produtosCaros)
{
    Console.WriteLine($"{produto.Nome}\t{produto.Preco:C2}\t{produto.Estoque}");
}

//lista de todos os produtos ordenado pelo nome e pela categoria
Console.WriteLine("\nProdutos ordenados pelo nome e categoria");

var produtosOrdenados = produtos.OrderBy(p => p.Nome).ThenBy(p => p.Categoria);
var nomeAnterior = "";

foreach( var produto in produtosOrdenados)
{
    if(produto.Nome != nomeAnterior)
    {
        Console.WriteLine($"{produto.Nome}\t{produto.Categoria}");
        nomeAnterior = produto.Nome;
    }
}

//valor total do estoque
double valorEstoque = produtos.Where(p => p.Estoque > 0).Sum(p => p.Preco * p.Estoque);
Console.WriteLine($"\nValor em Estoque: R$ {valorEstoque:C2}");

//média produtos eletrônicos
string? categoria = "Eletrônicos";
double media = produtos.Where(p => p.Categoria == categoria).Average(p => p.Preco);
Console.WriteLine($"\nMédia: R$ {media:C2}");

//filtrar preço menor que 500 e dar aumento de 10% e ordenar por nome (tipo anônimo)
Console.WriteLine("\nProdutos com Aumento 10%");
var Aumento = produtos.Where(p => p.Preco < 500).OrderBy(p => p.Nome).Select(p => new
{
    NomeProduto = p.Nome.ToUpper(),
    PrecoAumento = p.Preco * 1.1
});

foreach(var produto in Aumento)
{
    Console.WriteLine($"Produto: {produto.NomeProduto}\tPreço: {produto.PrecoAumento:C2}");
}

//exemplo first
Console.WriteLine("\nExemplo usando o First");
try
{
    Console.WriteLine("\nProcurando o primeiro sem argumento: ");
    var primeiro1 = produtos.First();
    Console.WriteLine(primeiro1.Nome);

    Console.WriteLine("\nProcurando o primeiro com argumento: ");
    var primeiro2 = produtos.First(p => p.Nome == "Cadeira");
    Console.WriteLine($"Id: {primeiro2.Id}\t Nome: {primeiro2.Nome}");

    Console.WriteLine("\nProcurando o primeiro com argumento sem existir: ");
    var primeiro3 = produtos.First(p => p.Nome == "Sofá");
    Console.WriteLine($"Id: {primeiro3.Id}\t Nome: {primeiro3.Nome}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


Console.WriteLine("\nExemplo usando o Last");
//exemplo last
try
{
    Console.WriteLine("\nProcurando o último sem argumento: ");
    var ultimo1 = produtos.Last();
    Console.WriteLine(ultimo1.Nome);

    Console.WriteLine("\nProcurando o último com argumento: ");
    var ultimo2 = produtos.Last(p => p.Nome == "Cadeira");
    Console.WriteLine($"Id: {ultimo2.Id}\t Nome: {ultimo2.Nome}");

    Console.WriteLine("\nProcurando o último com argumento sem existir: ");
    var ultimo3 = produtos.Last(p => p.Nome == "Sofá");
    Console.WriteLine($"Id: {ultimo3.Id}\t Nome: {ultimo3.Nome}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("\nExemplo usando o FirstOrDefault");
//exemplo first or default
Console.WriteLine("\nProcurando o primeiro sem argumento: ");
var primeiro4 = produtos.FirstOrDefault();

if (primeiro4 != null)
{
    
    Console.WriteLine(primeiro4.Nome);
}
else
{
    Console.WriteLine("Produto não Encontrado");
}

Console.WriteLine("\nProcurando o primeiro com argumento: ");
var primeiro5 = produtos.FirstOrDefault(p => p.Nome == "Cadeira");

if (primeiro5 != null)
{
    Console.WriteLine($"Id: {primeiro5.Id}\t Nome: {primeiro5.Nome}");
}
else
{
   Console.WriteLine("Produto não Encontrado");
}

Console.WriteLine("\nProcurando o primeiro com argumento sem existir: ");
var primeiro6 = produtos.FirstOrDefault(p => p.Nome == "Sofá");
if (primeiro6 != null)
{
    Console.WriteLine($"Id: {primeiro6.Id}\t Nome: {primeiro6.Nome}");
}
else
{
    Console.WriteLine("Produto não Encontrado");
}

Console.WriteLine("\nExemplo usando o LastOrDefault");
//exemplo last or default
Console.WriteLine("\nProcurando o último sem argumento: ");
var ultimo4 = produtos.LastOrDefault();

if (ultimo4 != null)
{
    
    Console.WriteLine(ultimo4.Nome);
}
else
{
    Console.WriteLine("Produto não Encontrado");
}

Console.WriteLine("\nProcurando o último com argumento: ");
var ultimo5 = produtos.LastOrDefault(p => p.Nome == "Cadeira");

if (ultimo5 != null)
{
    Console.WriteLine($"Id: {ultimo5.Id}\t Nome: {ultimo5.Nome}");
}
else
{
   Console.WriteLine("Produto não Encontrado");
}

Console.WriteLine("\nProcurando o último com argumento sem existir: ");
var ultimo6 = produtos.LastOrDefault(p => p.Nome == "Sofá");
if (ultimo6 != null)
{
    Console.WriteLine($"Id: {ultimo6.Id}\t Nome: {ultimo6.Nome}");
}
else
{
    Console.WriteLine("Produto não Encontrado");
}

Console.WriteLine("\nExemplo usando Single");
//exemplo single
try
{
    Console.WriteLine("\nProcurando um único elemento: ");
    var unico2 = produtos.Single(p => p.Nome == "Monitor Gamer");
    Console.WriteLine($"Id: {unico2.Id}\t Nome: {unico2.Nome}");

    Console.WriteLine("\nProcurando um único elemento tendo 2: ");
    var unico1 = produtos.Single(p => p.Nome == "Cadeira");
    Console.WriteLine($"Id: {unico1.Id}\t Nome: {unico1.Nome}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("\nExemplo usando SingleOrDefault");
//exemplo single or default
try
{
    Console.WriteLine("\nProcurando um único elemento tendo 2: ");
    var unico3 = produtos.SingleOrDefault(p => p.Nome == "Cadeira");
    if (unico3 != null)
    {
        Console.WriteLine($"Id: {unico3.Id}\t Nome: {unico3.Nome}");
    }
    else
    {
        Console.WriteLine("Produto não Encontrado");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("\nProcurando um único elemento: ");
    var unico4 = produtos.SingleOrDefault(p => p.Nome == "Monitor Gamer");
    if (unico4 != null)
    {
        Console.WriteLine($"Id: {unico4.Id}\t Nome: {unico4.Nome}");
    }
    else
    {
        Console.WriteLine("Produto não Encontrado");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    Console.WriteLine("\nProcurando um único elemento sem ter: ");
    var unico5 = produtos.SingleOrDefault(p => p.Nome == "Sofá");
    if (unico5 != null)
    {
        Console.WriteLine($"Id: {unico5.Id}\t Nome: {unico5.Nome}");
    }
    else
    {
        Console.WriteLine("Produto não Encontrado");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//Exemplo GroupBy
Console.WriteLine("\nExemplo usando GroupBy: ");
var produtosPorCategoria = produtos.GroupBy(p => p.Categoria).OrderBy(c => c.Key);

foreach(var grupo in produtosPorCategoria)
{
    Console.WriteLine($"\nCategoria: {grupo.Key}\t Quantidade: {grupo.Count()}");

    foreach(var produto in grupo)
    {
        Console.WriteLine($"Produtos: {produto.Nome}");
    }
}

Console.WriteLine("\nOrdenando os produtos dentro da Categoria: ");
var produtosPorCategoria2 = produtos.GroupBy(p => p.Categoria).
                                     OrderBy(c => c.Key).Select(g => new
                                     {
                                         Categoria = g.Key,
                                         ProdutosOrdenados = g.OrderBy(p => p.Nome)
                                                             .Select(p => new
                                                             {
                                                                Nome = p.Nome,
                                                                Preco = p.Preco,
                                                                Estoque = p.Estoque
                                                             })
                                     });

foreach (var grupo in produtosPorCategoria2)
{
    Console.WriteLine($"\nCategoria: {grupo.Categoria}");

    foreach (var produto in grupo.ProdutosOrdenados)
    {
        Console.WriteLine($"Produtos: {produto.Nome}\t Preço: {produto.Preco}\t Estoque: {produto.Estoque}");
    }
}





