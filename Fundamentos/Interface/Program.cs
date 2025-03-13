//Interface
//é um contrato que define um conjunto de métodos que classes devem implementar;
//uma interface pode ser um tipo de dado desde que ela aponte para um objeto que implementa essa interface;
//por que usar: polimorfismo, desacoplamento, reutilização;
//pode-se ter herança entre interfaces;
//uma classe pode implementar mais do que uma interface;
//desacoplamento = padronizar método

IAnimal gato = new Gato();
gato.FazerSom();

public interface IAnimal
{
    public void FazerSom();
}

public class Gato : IAnimal
{
    public void FazerSom()
    {
        Console.WriteLine("Miau");
    }
}

public class Cachorro : IAnimal
{
    public void FazerSom()
    {
        Console.WriteLine("Au au");
    }
}