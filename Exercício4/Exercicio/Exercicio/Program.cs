//Delegates Pré-Definidos para Eventos
//- EventHandler = Método que vai manipular evento que não possui dados;
//public delegate void EventHandler(object? sender, EventArgs e);
//onde:
//Object? sender = contém uma referência ao objeto que gerou evento;
//EventArgs = um objeto que não contém nenhum dado de um evento;
//-EventHandler < TEventArgs > = método que vai manipular evento que possui dados;
//public delegate void EventHandler<TEventArgs>(object? sender; TEventArgs);
//onde:
//< TEventArgs > = tipo de dados;
//TEventArgs = Dados do evento;


Console.WriteLine("Usando evento");
Pedido pedido = new Pedido();
//registrar as classes assinantes
pedido.OnCriarPedido += EnviarEmail.email;
pedido.OnCriarPedido += EnviarSMS.sms;

pedido.OnStatusAlterado += EnviarEmail.email;
pedido.OnStatusAlterado += EnviarSMS.sms;

pedido.criarPedido("jorge@gmail.com", "14 9999-9999", "começando");

pedido.alterarStatus("Em andamento");

Console.WriteLine("Fim do Pedido");

Console.ReadKey();

class PedidoEventArgs : EventArgs
{
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? Status { get; set; }
}

class Pedido
{
    public event EventHandler<PedidoEventArgs>? OnCriarPedido;
    public event EventHandler<PedidoEventArgs>? OnStatusAlterado;

    //armazenar os dados após criação
    public string? email;
    public string? telefone;

    public void criarPedido(string email, string telefone, string status)
    {
        Console.WriteLine("Iniciando o criar pedido");

        //salva os dados
        this.email = email;
        this.telefone = telefone;

        if (OnCriarPedido != null)
        {
            OnCriarPedido(this, new PedidoEventArgs { Email = email, Telefone = telefone, Status = status });
        }
    }

    public void alterarStatus(string novoStatus)
    {
        Console.WriteLine($"Alterando status do pedido para: {novoStatus}");

        if (OnStatusAlterado != null)
        {
            OnStatusAlterado(this, new PedidoEventArgs { Email = email, Telefone = telefone, Status = novoStatus });
        }
    }
}

class EnviarEmail
{
    public static void email(Object? sender, PedidoEventArgs e)
    {
        Console.WriteLine($"E-mail enviado para: {e.Email} com status {e.Status}!");
    }
}

class EnviarSMS
{
    public static void sms(Object? sender, PedidoEventArgs e)
    {
        Console.WriteLine($"SMS enviado para: {e.Telefone} com status {e.Status}!");
    }
}

