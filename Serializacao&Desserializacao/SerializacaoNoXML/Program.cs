using System.Xml.Serialization;

var familia = new Familia
{
    Sobrenome = "Silva",
    Pessoas = new List<Pessoa>
    {
        new Pessoa
        {
            Nome = "João",
            Idade = 35,
            Endereco = new Endereco
            {
                Rua = "Xv de Novembro",
                Cidade = "Jaú"
            }
        },
        new Pessoa
        {
            Nome = "Maria",
            Idade = 33,
            Endereco = new Endereco
            {
                Rua = "7 de Setembro",
                Cidade = "São Paulo"
            }
        }
    }
};

//serialização em memória
var serializar = new XmlSerializer(typeof(Familia));
using var writer = new StringWriter();
serializar.Serialize(writer, familia);
string xml = writer.ToString();
Console.WriteLine("XML Gerado\n");
Console.WriteLine(xml);

//Desserializar
using var reader = new StringReader(xml);
Familia familiaDess = (Familia)serializar.Deserialize(reader);
Console.WriteLine($"\nSobrenome: {familiaDess.Sobrenome}\n");
foreach(var pessoa in familiaDess.Pessoas)
{
    Console.WriteLine($"\nPessoa: {pessoa.Nome}, {pessoa.Endereco.Cidade}\n");
}

Console.ReadKey();
[XmlRoot("Família")]

public class Familia
{
    public Familia() { }
    [XmlElement("Sobrenome")]
    public string Sobrenome { get; set; }
    [XmlArray("Membros")]
    [XmlArrayItem("Pessoa")]
    public List<Pessoa> Pessoas { get; set; } = new();
}

public class Pessoa
{
    public Pessoa() { }
    [XmlElement("Nome")]
    public string Nome { get; set; }
    [XmlIgnore]
    public int Idade { get; set; }
    [XmlElement("Endereco")]
    public Endereco Endereco { get; set; }
}

public class Endereco
{ 
    public Endereco() { }
    [XmlElement("Rua")]
    public string Rua { get; set; }
    [XmlElement("Cidade")]
    public string Cidade { get; set; }
}
