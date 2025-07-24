using System.Xml.Serialization;

Aluno aluno1 = new Aluno(1, "Vera Lucia", "vera@email.com");
var caminho = @"C:\Users\Alissa\Desktop\Exercicios\Exercicio2\livro.json";

XmlSerializer serializer = new XmlSerializer(typeof(Aluno));
using (StreamWriter writer = new StreamWriter(caminho))
{
    serializer.Serialize(writer, aluno1);
}

Console.WriteLine("\nObjeto aluno serializado\n");

//Desserialização
using (StreamReader reader = new StreamReader(caminho))
{
    var alunoDess = (Aluno)serializer.Deserialize(reader);
    Console.WriteLine($"Aluno: {alunoDess.Nome}, E-mail: {alunoDess.Email}");
}

    Console.ReadKey();

public class Aluno
{
    public Aluno() { }
    public Aluno(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}