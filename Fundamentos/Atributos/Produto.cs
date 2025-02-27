using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributos
{
    internal class Produto
    {
        //criando um construtor
        public Produto(string nome)
        {
            Nome = nome;

        }
        //cria um padrão
        public Produto(string Nome, double preco, int estoqueMinimo) : this(Nome)
        {
            //this.Nome = Nome;
            Preco = preco;
            //Desconto = desconto; atributo somente de leitura
            EstoqueMinimo = estoqueMinimo; //só de gravação
        }
        private string? nome;
        public string? Nome {
            get { return nome.ToUpper(); } 
            set { nome = value ?? ""; } 
        }
        private double preco;
        public double Preco {
            get { return preco; }
            set { 
                 if (value < 5)
                 {
                   preco = 5.00;
                 }
                 else
                 {
                   preco = value;
                 }
            } 
        }
        private double desconto = 0.05;
        public double Desconto { 
            get { return desconto; }
        }
        private int minimo;
        public int EstoqueMinimo { 
            set {  minimo = value; }
        }
        public double PrecoFinal { 
            get { return Preco - (Preco * Desconto); }
        }
        //static = não precisa instaciar um objeto, acessa pelo nome da classe
        //um elemento estático é compartilhado com todos os elementos da classe
        public static string? Descricao { get; set; }

        public static void Exibir(Produto produto)
        {
            Console.WriteLine($"Nome: {produto.Nome}\nPreço: {produto.Preco.ToString("c")}\nDesconto: {produto.Desconto.ToString("c")}\nEstoque Minímo: {produto.minimo}\nPreço Final: {produto.PrecoFinal.ToString("c")}\nDescrição: {Produto.Descricao}");
        }
    }
}
