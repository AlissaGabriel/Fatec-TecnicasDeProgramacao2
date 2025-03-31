using System.Collections;

var produtos = new ArrayList();
int? opcao = 0;

do
{
    Console.WriteLine("\nEscolha uma das opções: ");
    Console.WriteLine("1 - Adicionar um produto na lista");
    Console.WriteLine("2 - Remover um produto");
    Console.WriteLine("3 - Exibir a lista de produtos");
    Console.WriteLine("4 - Sair: ");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            {
                Console.WriteLine("\nInforme o produto a ser adicionado: ");
                string? produto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(produto))
                {
                    produtos.Add(produto);
                    Console.WriteLine("Produto adicionado com sucesso");
                }
                else
                {
                    Console.WriteLine("\nProduto não pode ser vazio");
                }
                break;
            }
        case 2:
            {
                Console.WriteLine("\nInforme o produto a ser removido: ");
                string? produto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(produto))
                {
                    if (produtos.Contains(produto))
                    {
                        produtos.Remove(produto);
                        Console.WriteLine("Produto removido com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Produto não está presente na lista");
                    }
                }
                else
                {
                    Console.WriteLine("Produto não pode ser vazio");
                }
                break;
            }
        case 3:
            {
                Console.WriteLine("\nListando os produtos armazenados: ");
                if (produtos.Count > 0)
                {
                    foreach (var produto in produtos)
                    {
                        Console.WriteLine(produto);
                    }
                }
                else
                {
                    Console.WriteLine("Não há produtos na lista");
                }
                break;
            }
    }
} while (opcao != 4);