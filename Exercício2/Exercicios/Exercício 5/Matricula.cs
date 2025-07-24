using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercício_5
{
    internal class Matricula
    {
        public Matricula(Aluno aluno, Curso curso, DateTime dataMatricula) {
            Aluno = aluno;
            Curso = curso;
            DataMatricula = dataMatricula;
        }

        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
        public DateTime DataMatricula { get; set; }

        public void ExibirMatricula ()
        {
            Console.WriteLine($"Idade do Aluno: {Aluno.Idade}\nNome do Curso: {Curso.Nome}\nDuração do Curso: {Curso.Duracao}\nProfessor Responsável pelo Curso: {Curso.Professor.Nome}\nEspecialização do Professor: {Curso.Professor.Especializacao}\nData da Matricula: {DataMatricula}");
        }
    }
}
