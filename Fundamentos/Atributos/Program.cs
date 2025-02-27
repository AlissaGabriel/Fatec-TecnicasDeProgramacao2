using Atributos;

Produto produto1 = new ("Caderno", 1.00, 100);

//passagem de parâmetros nomeados que podem estar em qualquer ordem
Produto produto2 = new(preco: 50.00, estoqueMinimo: 50, Nome: "Estojo");

//Console.WriteLine("Escreva seu nome: ");
//string? nome = Console.ReadLine();
//produto1.Nome = nome;

//produto1.Preco = 10.00;
//produto1.Desconto = 0.05;
//produto1.EstoqueMinimo = 100;
//produto1.PrecoFinal = produto1.Preco - (produto1.Preco * produto1.Desconto); //foi deslocado para o método get no precoFinal
Produto.Descricao = "Materiais Escolares";

Console.WriteLine("Produto 1: ");
Produto.Exibir(produto1);

Console.WriteLine("\nProduto 2: ");
Produto.Exibir(produto2);