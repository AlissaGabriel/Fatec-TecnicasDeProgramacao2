Curso curso1 = new Curso("DSM", "36 Meses", "Vania");
Aluno aluno1 = new Aluno("Jorge", 21, curso1);

aluno1.mostrar();

public class Aluno
{
    public Aluno(string? nome, int idade, Curso curso)
    {
        Nome = nome;
        Idade = idade;
        Curso = curso;
    }
    public string? Nome { get; set; }
    public int Idade { get; set; }
    public Curso Curso  { get; set; }

    public void mostrar()
    {
        Console.WriteLine($"Nome Aluno: {Nome}\nIdade: {Idade}\nNome do Curso: {Curso.Nome}\nDuração: {Curso.Duracao}\nProfessor: {Curso.Professor}");
    }
}

public class Curso 
{
    public Curso(string? nome, string? duracao, string? professor)
    {
        Nome = nome;
        Duracao = duracao;
        Professor = professor;
    }

    public string? Nome { get; set; }
    public string? Duracao { get; set; }
    public string? Professor { get; set; }
}
