

Gato gato = new Gato("Timtim");
Console.WriteLine($"Nome do gato é: {gato.getNome()}");
gato.SomGato();

public class Animal
{
    //construtor
    public Animal(string nome)
    {
        Nome = nome;
    }

    //protegido não consegue acessar fora da classe filha
    protected string? Nome { get; set; }
}

public class Gato : Animal
{
    public Gato(string nome):base(nome){}

    public void SomGato()
    {
        Console.WriteLine("Miauuuu");
    }   

    public string getNome()
    {
        return Nome;
    }
}

public class Cachorro : Animal
{
    public Cachorro(string nome) : base(nome) { }

    public void SomCachorro()
    {
        Console.WriteLine("au au au au");
    }
}