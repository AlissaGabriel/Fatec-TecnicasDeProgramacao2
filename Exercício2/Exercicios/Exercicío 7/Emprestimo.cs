using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exercicío_7.Biblioteca;

namespace Exercicío_7
{
   
        internal class Emprestimo
        {
            public Emprestimo(Livro livro, Usuario usuario, DateTime dataDoEmprestimo, DateTime dataPrevistaDevolucao)
            {
                LivroEmprestado = livro ?? throw new ArgumentNullException(nameof(livro), "Livro não pode ser nulo.");
                Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario), "Usuário não pode ser nulo.");
                DataDoEmprestimo = dataDoEmprestimo;
                DataPrevistaDevolucao = dataPrevistaDevolucao;
            }

            public Livro LivroEmprestado { get; set; }
            public Usuario Usuario { get; set; }
            public DateTime DataDoEmprestimo { get; set; }
            public DateTime DataPrevistaDevolucao { get; set; }
        }

}
