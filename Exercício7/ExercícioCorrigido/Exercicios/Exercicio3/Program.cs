using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

var gerenciador = new GerenciadorUsuarios();
var notificacoes = new Notificacoes();

// Registrar ouvintes
gerenciador.UsuarioCadastrado += notificacoes.MostrarNoConsole;
gerenciador.UsuarioCadastrado += notificacoes.RegistrarLog;

// Carregar usuários do JSON (se houver)
gerenciador.Carregar();

// Cadastro de novos usuários
gerenciador.CadastrarUsuario(new Usuario("Ana", "ana@gmail.com", 22));
gerenciador.CadastrarUsuario(new Usuario("Bruno", "bruno@outlook.com", 17));
gerenciador.CadastrarUsuario(new Usuario("Carla", "carla@gmail.com", 30));
gerenciador.CadastrarUsuario(new Usuario("Daniel", "daniel@yahoo.com", 19));

// Salvar após cadastro
gerenciador.Salvar();

// LINQ - Maiores de idade
Console.WriteLine("\nUsuários maiores de idade:");
foreach (var u in gerenciador.FiltrarMaiores())
    Console.WriteLine($"- {u.Nome}, {u.Idade} anos");

// LINQ - Agrupamento por domínio
Console.WriteLine("\nAgrupados por domínio:");
foreach (var grupo in gerenciador.AgruparPorDominio())
{
    Console.WriteLine($"\nDomínio: {grupo.Key}");
    foreach (var u in grupo)
        Console.WriteLine($"- {u.Nome}");
}

// LINQ - 3 mais recentes
Console.WriteLine("\n3 usuários mais recentes:");
foreach (var u in gerenciador.Top3Recentes())
    Console.WriteLine($"- {u.Nome}, {u.DataCadastro}");

Console.ReadKey();

public delegate void NotificacaoHandler(Usuario usuario);
public class Usuario
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Idade { get; set; }
    public DateTime DataCadastro { get; set; }

    public Usuario(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
        DataCadastro = DateTime.Now;
    }

    // Necessário para desserialização
    public Usuario() { }
}


public class GerenciadorUsuarios
{
    private List<Usuario> usuarios = new();
    //acertar o caminho para rodar na sua máquina.
    private const string CaminhoArquivo = @"C:\fatec\Tecnica_Programacao_II\usuarios.json";
    
    public event NotificacaoHandler? UsuarioCadastrado;

    public void CadastrarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
        UsuarioCadastrado?.Invoke(usuario);
    }

    public void Salvar()
    {
       
        File.WriteAllText(CaminhoArquivo, JsonSerializer.Serialize(usuarios));
        Console.WriteLine("Usuários salvos no JSON.");
    }

    public void Carregar()
    {
        if (!File.Exists(CaminhoArquivo))
        {
            Console.WriteLine("Arquivo JSON não encontrado.");
            return;
        }

        var json = File.ReadAllText(CaminhoArquivo);
        var lista = JsonSerializer.Deserialize<List<Usuario>>(json);
        if (lista != null)
            usuarios = lista;
    }

    // LINQ – Maiores de idade
    public IEnumerable<Usuario> FiltrarMaiores()
        => usuarios.Where(u => u.Idade >= 18);

    // LINQ – Agrupar por domínio de e-mail
    public IEnumerable<IGrouping<string, Usuario>> AgruparPorDominio()
        => usuarios.GroupBy(u => u.Email.Split('@').Last());

    // LINQ – 3 mais recentes
    public IEnumerable<Usuario> Top3Recentes()
        => usuarios.OrderByDescending(u => u.DataCadastro).Take(3);

    // Acesso à lista 
    public List<Usuario> ObterTodos() => usuarios;
}
public class Notificacoes
{
    public void MostrarNoConsole(Usuario usuario)
    {
        Console.WriteLine($"Novo usuário: {usuario.Nome}, cadastrado em {usuario.DataCadastro}");
    }

    public void RegistrarLog(Usuario usuario)
    {
        string mensagem = $"[{DateTime.Now}] Novo usuário: {usuario.Nome}, cadastrado em {usuario.DataCadastro}";
        //o arquivo log.txt quando especificado dessa forma, é gravado na pasta do projeto,  bin/debug
        File.AppendAllText("log.txt", mensagem + Environment.NewLine);
    }
}

