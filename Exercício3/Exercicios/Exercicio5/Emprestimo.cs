using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio5
{
    internal class Emprestimo
    {
        public Emprestimo(Leitor leitor, Livro livro, DateTime dataEmprestimo) 
        {
            Leitor = leitor;
            Livro = livro;
            DataEmprestimo = dataEmprestimo;
        }

        public Leitor Leitor { get; set; }
        public Livro Livro { get; set; }
        public DateTime DataEmprestimo { get; set; }

        public void livroEmprestado()
        {
            Console.WriteLine($"Nome do Leitor: {Leitor.Nome}\nIdade do Leitor: {Leitor.Idade}\nE-mail: {Leitor.Email}\nId do Livro: {Livro.Id}\nLivro Emprestado: {Livro.Titulo}\nAutor: {Livro.Autor}\nData do Empréstimo: {DataEmprestimo}");
        }
    }
}
