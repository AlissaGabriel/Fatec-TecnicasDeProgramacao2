using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicío_7
{
    internal class Biblioteca
    {
        public class Livro
        {
            public Livro(string titulo, string autor, int id)
            {
                if (id <= 0) throw new ArgumentException("Id do livro deve ser maior que zero");
                Titulo = titulo;
                Autor = autor;
                Id = id;
                Status = true;
            }

            public string Titulo { get; set; }
            public string Autor { get; set; }
            public int Id { get; set; }
            public bool Status { get; set; }
        }

        public class Usuario
        {
            public Usuario(string nome, int id)
            {
                if (id <= 0) throw new ArgumentException("Id do usuário deve ser maior que zero");
                Nome = nome;
                Id = id;
                LivrosEmprestados = new List<Emprestimo>();
            }

            public string Nome { get; set; }
            public int Id { get; set; }
            public List<Emprestimo> LivrosEmprestados { get; set; }



        }
    }
}

