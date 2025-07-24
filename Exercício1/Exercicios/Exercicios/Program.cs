using Exercicios;

Veiculo veiculo1 = new("AAA 1111");
Veiculo veiculo2 = new("BBB 2222");

Console.WriteLine("Exibindo informações do veículo 1: ");
Veiculo.ExibirInformacoes(veiculo1);

Console.WriteLine("\nExibindo informações do veículo 2: ");
Veiculo.ExibirInformacoes(veiculo2);

Carro carro1 = new("CCC 3333", 4);
Console.WriteLine("\nExibindo informações do carro 1: ");
//carro1.Exibir(); sem ser estático
Carro.Exibir(carro1); //estático

Moto moto1 = new("DDD 4444", "Sim");
Console.WriteLine("\nExibindo informações da moto 1: ");
//carro1.Exibir(); sem ser estático
Moto.ExibirMoto(moto1); //estático