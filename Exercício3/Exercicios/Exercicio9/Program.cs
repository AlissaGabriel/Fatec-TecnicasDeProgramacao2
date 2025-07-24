Conta conta = new();
conta.Agencia = "456-7";
conta.NumeroConta = "12345-6";
conta.Mostrar();
conta.Depositar(10000);
conta.Sacar(500);

public class Conta
{
    public string? Agencia { get; set; }
    public string? NumeroConta { get; set; }
    public double Saldo { get; set; }
    public void Sacar(double valor)
    {
        if (Saldo < valor)
        {
            throw new SaldoInsuficienteException(valor, Saldo);
        }
        else
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de {valor} realizado! Saldo atual é de: {Saldo}");
        }
    }
    public void Depositar(double valor)
    {
        Saldo += valor;
        Console.WriteLine($"Depósito de {valor} realizado! Saldo atual é de: {Saldo}");
    }

    public void Mostrar()
    {
        Console.WriteLine($"Agência: {Agencia}\nConta: {NumeroConta}\nSaldo: {Saldo}");
    }
}

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException() { }
    public SaldoInsuficienteException(string Message) : base(Message) { }
    public SaldoInsuficienteException(double valor, double saldo) : base($"Exception: O valor do saque {valor} é maior que o saldo {saldo}") { }
}