using Exercício_6;
using static Exercício_6.Hospital;

Paciente paciente1 = new("João", 18, "Quebrou o braço");
Paciente paciente2 = new("Pedro", 50, "Dor de Cabeça");

Medico medico1 = new("Flávio", 60, "Ortopedista", 123456);
Medico medico2 = new("Joana", 30, "Neurologista", 789012);

Consulta consulta1 = new(medico1, paciente1, new DateTime(2024, 2, 9, 14, 30, 0), "Fratura");
Consulta consulta2 = new(medico2, paciente2, new DateTime(2024, 3, 10, 15, 30, 0), "Enxaqueca");

Console.WriteLine("Exibindo a consulta 1: ");
consulta1.ExibirConsulta();
Console.WriteLine("\nExibindo a consulta 2: ");
consulta2.ExibirConsulta();