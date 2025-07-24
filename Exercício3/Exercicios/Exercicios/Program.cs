using System;

Funcionario funcionario1 = new("Contador", "Jorge", "1000");

Gerente gerente1 = new("Financeiro", "Raissa", "2000");

funcionario1.mostrarFuncionario();
gerente1.mostrarGerente();

public class Pessoa
{
    public Pessoa(string? nome, string? salario)
    {
        Nome = nome;
        Salario = salario;
    }
    protected string? Nome { get; set; }
    protected string? Salario { get; set; }

    public void mostrarPessoa()
    {
        Console.WriteLine($"Nome: {Nome}\nSalário: {Salario}");
    }
}

public class Funcionario : Pessoa
{
    public Funcionario(string? funcao, string? nome, string? salario) : base(nome, salario)
    {
        Funcao = funcao;
    }
    public string? Funcao { get; set; }

    public void mostrarFuncionario()
    {
        base.mostrarPessoa();
        Console.WriteLine($"Função: {Funcao}\n");
    }

}

public class Gerente : Pessoa
{
    public Gerente(string? departamento, string? nome, string? salario) : base(nome, salario)
    {
        Departamento = departamento;
    }

    public string? Departamento { get; set; }

    public void mostrarGerente()
    {
        base.mostrarPessoa();
        Console.WriteLine($"Departamento: {Departamento}\n");
    }
}