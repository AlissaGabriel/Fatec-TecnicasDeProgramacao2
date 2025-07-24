using System.Globalization;
using System.Text.Json.Serialization;
var pessoa = new Pessoa("Maria", 15, "(14)987765554");

//serialização

string pessoaJson = System.Text.Json.JsonSerializer.Serialize(pessoa);
Console.WriteLine(pessoaJson);

//Desserialização

string pessoaJson1 = "{\"Nome\":\"João\", \"Idade\":25}";

Pessoa pessoaObjeto = System.Text.Json.JsonSerializer.Deserialize<Pessoa>(pessoaJson1);
Console.WriteLine($"\n{pessoaObjeto.Nome}");


Console.ReadKey();

public class Pessoa
{
    public Pessoa(string nome, int idade, string celular)
    {
        Nome = nome;
        Idade = idade;
        Celular = celular;
    }
    //o construtor padrão é obrigatório quando se tem construtor
    //com parâmetros para a serialização
    public Pessoa()
    {

    }
    public string? Nome { get; set; }
    [JsonIgnore]
    public int Idade { get; set; }

    public string? Celular { get; set; }
}
