using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosLinq
{
    class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }
        public string? Categoria { get; set; }
        public static List<Produto> GetProdutos()
        {
            List<Produto> produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome="Camiseta", Preco = 50.00,
                              Estoque = 50, Categoria = "Roupa" },
                new Produto { Id = 2, Nome="Calça Jeans", Preco = 150.00,
                              Estoque = 5, Categoria = "Roupa" },
                new Produto { Id = 3, Nome="Relógio", Preco = 200.00,
                              Estoque = 10, Categoria = "Acessório" },
                new Produto { Id = 4, Nome="Celular", Preco = 5500.99,
                              Estoque = 20, Categoria = "Eletrônicos" },
                new Produto { Id = 5, Nome="Notebook", Preco = 7756.99,
                              Estoque = 50, Categoria = "Eletrônicos" },
                new Produto { Id = 6, Nome="Mesa Redonda", Preco = 1500.00,
                              Estoque = 2, Categoria = "Móveis" },
                new Produto { Id = 7, Nome="Cadeira", Preco = 200.00,
                              Estoque = 10, Categoria = "Móveis" },
                new Produto { Id = 8, Nome="Cadeira", Preco = 250.00,
                              Estoque = 100, Categoria = "Móveis" },
                new Produto { Id = 9, Nome="Monitor Gamer", Preco = 2500.00, 
                              Estoque = 5, Categoria = "Eletrônicos" }
            };
            return produtos;
        }
    }
}
