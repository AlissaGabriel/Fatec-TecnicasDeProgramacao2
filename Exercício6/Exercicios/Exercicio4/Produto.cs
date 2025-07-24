using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
     class Produto
    {

        public Produto(string nome, double preco) 
        {
            Nome = nome;
            Preco = preco;
        }
        public string? Nome { get; set; }

        public double Preco { get; set; }

    }


}
