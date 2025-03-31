ISalario horista = new FuncionarioHorista("Carlos", 12, 30);
Console.WriteLine($"Nome: {((FuncionarioHorista)horista).Nome}");
Console.WriteLine($"Vaor por Hora{((FuncionarioHorista)horista).ValorPorHora}");
Console.WriteLine($"Horas Trabalhadas: {((FuncionarioHorista)horista).HorasTrabalhadas}");
Console.WriteLine($"Salário: {horista.CalcularSalario():F2}");
//horista.ExibirSalario();

ISalario mensalista = new FuncionarioMensalista("João", 1200);
Console.WriteLine($"\nNome: {((FuncionarioMensalista)mensalista).Nome}");
Console.WriteLine($"Salário Mensal: {((FuncionarioMensalista)mensalista).SalarioMensal:F2}");
//mensalista.ExibirSalario();

public interface ISalario
{
    double CalcularSalario();
    //void ExibirSalario();
}

public class FuncionarioHorista : ISalario
{
    public string Nome { get; set; }
    public double ValorPorHora { get; set; }
    public double HorasTrabalhadas { get; set; }

    public FuncionarioHorista(string nome, double valorPorHora, double horasTrabalhadas)
    {
        Nome = nome;
        ValorPorHora = valorPorHora;
        HorasTrabalhadas = horasTrabalhadas;
       
    }

    public double CalcularSalario()
    {
        return ValorPorHora * HorasTrabalhadas;
    }

    //public void ExibirSalario()
    //{
        //Console.WriteLine($"Nome: {Nome}");
        //Console.WriteLine($"Valor por Hora: {ValorPorHora}");
        //Console.WriteLine($"Horas Trabalhadas: {HorasTrabalhadas}");
        //Console.WriteLine($"Salário: {CalcularSalario():F2}");
    //}
}



public class FuncionarioMensalista : ISalario
{
    public string Nome { get; set; }
    public double SalarioMensal { get; set; }

    public FuncionarioMensalista(string nome, double salarioMensal)
    {
        Nome = nome;
        SalarioMensal = salarioMensal;
    }

    public double CalcularSalario()
    {
        return SalarioMensal;
    }

    //public void ExibirSalario()
    //{
        //Console.WriteLine($"\nNome: {Nome}");
        //Console.WriteLine($"Salário Mensal: {SalarioMensal:F2}");
    //}
}