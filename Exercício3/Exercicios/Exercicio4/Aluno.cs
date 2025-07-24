using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    internal class Aluno
    {
        public Aluno(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
            Matriculas = new List<Matricula>();
        }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<Matricula> Matriculas { get; set; }

        public void ListarDisciplinas()
        {
            Console.WriteLine($"Disciplinas do aluno {Nome}");
            foreach(var matricula in Matriculas)
            {
                Console.WriteLine($"Nome da Disciplina: {matricula.Disciplina.Nome}\nDuração da Disciplina: {matricula.Disciplina.Duracao}\nProfessor Responsável pela Disciplina: {matricula.Disciplina.Professor}\n");
            }
        }
    }
}
