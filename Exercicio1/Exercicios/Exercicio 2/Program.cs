List<string> nomes = new();
int? opcao = 0;

do
{
    Console.WriteLine("\nEscolha uma das opções: ");
    Console.WriteLine("1 - Adicionar um nome na lista");
    Console.WriteLine("2 - Remover um nome específico");
    Console.WriteLine("3 - Listar os nomes armazenados");
    Console.WriteLine("4 - Sair: ");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            {
                Console.WriteLine("\nInforme o nome a ser adicionado: ");
                string? nome = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(nome))
                {
                    nomes.Add(nome);
                    Console.WriteLine("Nome adicionado com sucesso");
                }
                else
                {
                    Console.WriteLine("\nNome não pode ser vazio");
                }
                break;
            }
        case 2:
            {
                Console.WriteLine("\nInforme o nome a ser removido: ");
                string? nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    if (nomes.Contains(nome))
                    {
                        nomes.Remove(nome);
                        Console.WriteLine("Nome removido com sucesso");
                    }
                    else 
                    { 
                        Console.WriteLine("Nome não está presente na lista"); 
                    }
                }
                else
                {
                    Console.WriteLine("Nome não pode ser vazio");
                }
                break;
            }
        case 3:
            {
                Console.WriteLine("\nListando os nomes armazenados: ");
                if (nomes.Count > 0) 
                {
                    foreach (var nome in nomes)
                    {
                        Console.WriteLine(nome);
                    }
                }
                else
                {
                    Console.WriteLine("Não há nomes na lista");
                }
                break;
            }
    } 
} while (opcao != 4);



