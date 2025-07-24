Console.WriteLine("Cadastro de Produtos");
try
{
    Console.WriteLine("Digite o produto: ");
    string? produto = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(produto))
    {
        throw new Exception("O nome do produto não pode ser vazio.");
    }

    Console.Write("Digite o preço do produto: ");
    decimal preco = Convert.ToDecimal(Console.ReadLine());
    if (preco < 0)
    {
        throw new Exception("O preço do produto não pode ser negativo.");
    }

    Console.Write("Digite a quantidade em estoque: ");
    int quantidade = Convert.ToInt32(Console.ReadLine());
    if (quantidade < 0)
    {
        throw new Exception("A quantidade não pode ser negativa.");
    }

    Console.WriteLine("\nDetalhes do produto: ");
    Console.WriteLine($"Nome: {produto}\nQuantidade: {quantidade}\nPreço: {preco:C}");
}
catch (FormatException)
{
    Console.WriteLine("Erro: Entrada em formato inválido. Use apenas números para preço e quantidade.");
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
}


