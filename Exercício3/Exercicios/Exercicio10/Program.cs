Console.WriteLine("\nConsulta de Usuário Assíncrona");
ConsultarUsuarioAsync();

Console.ReadKey();

static async void ConsultarUsuarioAsync()
{
    Console.WriteLine("Iniciando consulta ao banco...");

    var tarefaUsuario = ObterUsuarioAsync();
    var usuario = await tarefaUsuario;

    var exibir = ExibirUsuarioAsync(usuario);
    var exibirUsuario = await exibir;

    EncerrandoAsync(usuario, exibirUsuario);
}

static async Task<Usuario> ObterUsuarioAsync()
{
    Console.WriteLine("Conectando ao banco...");
    await Task.Delay(2000);

    Console.WriteLine("Consultando dados...");
    await Task.Delay(3000);

    return new Usuario(1, "João");
}

static async Task<Exibir> ExibirUsuarioAsync(Usuario usuario)
{
    Console.WriteLine("Exibindo resultado...");
    await Task.Delay(2000);
    Console.WriteLine($"Usuário encontrado:\nID: {usuario.Id}\nNome: {usuario.Nome}");

    return new Exibir();
}

static async void EncerrandoAsync(Usuario usuario, Exibir exibir)
{
    Console.WriteLine("Dados do usuário obtidos");
    await Task.Delay(2000);
}

public class Usuario
{
    public Usuario(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
}

internal class Exibir
{
    public Exibir() { }
}
