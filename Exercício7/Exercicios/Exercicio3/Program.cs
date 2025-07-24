using System.Text.Json;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

GerenciadorUsuarios gerenciador = new GerenciadorUsuarios();

gerenciador.UsuarioCadastrado += Notificacoes.ExibirMensagemConsole;
gerenciador.UsuarioCadastrado += GravarLog.Gravar;

string caminhoDados = "C:\\Users\\Alissa\\Desktop\\Exercicios\\Exercicio3\\usuarios.json";

if (File.Exists(caminhoDados))
{
    gerenciador.Desserializar(caminhoDados);
    Console.WriteLine("Dados carregados do arquivo.\n");
}
else
{
    Console.WriteLine("Arquivo não encontrado. Criando usuários de teste...\n");
    gerenciador.CadastrarUsuario(new Usuario("João", "joao@gmail.com", 19));
    gerenciador.CadastrarUsuario(new Usuario("Maria", "maria@gmail.com", 50));
    gerenciador.CadastrarUsuario(new Usuario("Joana", "joana@email.com", 17));
}

Console.WriteLine("Usuários maiores de idade");
gerenciador.Maiores();
Console.WriteLine();

Console.WriteLine("Usuários agrupados por domínio de email");
gerenciador.Agrupar();
Console.WriteLine();

Console.WriteLine("Três usuários mais recentes cadastrados");
gerenciador.Recentes();
Console.WriteLine();

gerenciador.Serializar(caminhoDados);

public class Usuario
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Idade { get; set; }
    public DateTime DataCadastro { get; set; }

    public Usuario() { }

    public Usuario(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
        DataCadastro = DateTime.Now;
    }
}

public delegate void NotificacaoHandler(object? sender, Usuario usuario);

public class GerenciadorUsuarios
{
    public List<Usuario> Usuarios { get; set; } = new();

    public event NotificacaoHandler UsuarioCadastrado;

    public void CadastrarUsuario(Usuario usuario)
    {
        Usuarios.Add(usuario);
        UsuarioCadastrado?.Invoke(this, usuario);
    }

    public void Serializar(string caminho)
    {
        string jsonString = JsonSerializer.Serialize(Usuarios);
        File.WriteAllText(caminho, jsonString);
        Console.WriteLine("Dados serializados e salvos no arquivo.\n");
    }

    public void Desserializar(string caminho)
    {
        string jsonStringLido = File.ReadAllText(caminho);
        List<Usuario>? usuarioDess = JsonSerializer.Deserialize<List<Usuario>>(jsonStringLido);
        if (usuarioDess != null)
        {
            Usuarios = usuarioDess;
        }
    }

    public void Maiores()
    {
        var maiorQue18 = Usuarios.Where(u => u.Idade >= 18);
        foreach (var u in maiorQue18)
        {
            Console.WriteLine($"{u.Nome}, {u.Idade} anos");
        }
    }

    public void Agrupar()
    {
        var usuarioPorEmail = Usuarios.GroupBy(u => u.Email.Split('@').Last());
        foreach (var grupo in usuarioPorEmail)
        {
            Console.WriteLine($"Domínio: {grupo.Key}");
            foreach (var u in grupo)
            {
                Console.WriteLine($"  - {u.Nome} ({u.Email})");
            }
        }
    }

    public void Recentes()
    {
        var tresMaisRecentes = Usuarios.OrderByDescending(u => u.DataCadastro).Take(3);
        foreach (var u in tresMaisRecentes)
        {
            Console.WriteLine($"Nome: {u.Nome}");
        }
    }
}

public class Notificacoes
{
    public static void ExibirMensagemConsole(object? sender, Usuario usuario)
    {
        Console.WriteLine($"[Notificação] Novo usuário cadastrado: {usuario.Nome}, em {usuario.DataCadastro}");
    }
}

public class GravarLog
{
    public static void Gravar(object? sender, Usuario usuario)
    {
        string caminhoLog = "C:\\Users\\Alissa\\Desktop\\Exercicios\\Exercicio3\\log.txt";
        string mensagemLog = $"Novo usuário: {usuario.Nome}, cadastrado em {usuario.DataCadastro}\n";
        File.AppendAllText(caminhoLog, mensagemLog);
        Console.WriteLine("[Log] Registro gravado com sucesso!");
    }
}
