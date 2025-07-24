using System.Text.Json;
using static CentralDeOcorrencias;

CentralDeOcorrencias centralDeOcorrencias = new CentralDeOcorrencias();
string caminhoArquivoJson = "C:\\Users\\Alissa\\Desktop\\Exercicios\\Exercicio5\\ocorrencia.json";

centralDeOcorrencias.OcorrenciaRegistrada += NotificacaoOcorrencia.GravarLog;
centralDeOcorrencias.OcorrenciaRegistrada += NotificacaoOcorrencia.ExibirAlertaConsole;
centralDeOcorrencias.OcorrenciaRegistrada += NotificacaoOcorrencia.ExibirAlertaConsoleUrgente;

if (File.Exists(caminhoArquivoJson))
{
    centralDeOcorrencias.Desserializar(caminhoArquivoJson);
    Console.WriteLine("Dados de ocorrência carregados do arquivo.");
}
else
{
    Console.WriteLine("Arquivo de ocorrência não encontrado. Criando ocorrências...");
    centralDeOcorrencias.Registrar(new Ocorrencia("Fogo", "Apartamento 101", true));
    centralDeOcorrencias.Registrar(new Ocorrencia("Alagamento", "Garagem", false));
    centralDeOcorrencias.Registrar(new Ocorrencia("Quebra de Porta", "Entrada Principal", true));
    centralDeOcorrencias.Registrar(new Ocorrencia("Quebra de Vidro", "Varanda", false));

    centralDeOcorrencias.Serializar(caminhoArquivoJson);
    Console.WriteLine();
}

Console.WriteLine("\nOcorrências urgentes:");
centralDeOcorrencias.OcorrenciasUrgente();

Console.WriteLine("\nOcorrências agrupadas por tipo:");
centralDeOcorrencias.Agrupar();

public class Ocorrencia
{
    public string Tipo { get; set; }
    public string Local { get; set; }
    public DateTime Data { get; set; }
    public bool Urgente { get; set; }

    public Ocorrencia() { }
    public Ocorrencia(string tipo, string local, bool urgente)
    {
        Tipo = tipo;
        Local = local;
        Urgente = urgente;
        Data = DateTime.Now;
    }
}

public delegate void OcorrenciaHandler(object? sender, Ocorrencia o);

public class CentralDeOcorrencias
{
    public List<Ocorrencia> Ocorrencias { get; set; } = new List<Ocorrencia>();
    public event OcorrenciaHandler OcorrenciaRegistrada;

    public void Registrar(Ocorrencia o)
    {
        Ocorrencias.Add(o);
        OcorrenciaRegistrada?.Invoke(this, o);
    }

    public void Serializar(string caminho)
    {
        string jsonString = JsonSerializer.Serialize(Ocorrencias);
        File.WriteAllText(caminho, jsonString);
        Console.WriteLine("\nOcorrências salvas com sucesso em arquivo Json.");
    }

    public void Desserializar(string caminho)
    {
        string jsonStringLido = File.ReadAllText(caminho);
        List<Ocorrencia>? ocorrenciaDess = JsonSerializer.Deserialize<List<Ocorrencia>>(jsonStringLido);
        if (ocorrenciaDess != null)
        {
            Ocorrencias = ocorrenciaDess;
            foreach (var o in Ocorrencias)
            {
                Console.WriteLine($"{o.Tipo} - {o.Local} - {o.Data}");
            }
        }
    }

    public void OcorrenciasUrgente()
    {
        var ocorrenciasUrgentes = Ocorrencias.Where(o => o.Urgente).ToList();
        foreach (var ocorrencia in ocorrenciasUrgentes)
        {
            Console.WriteLine($"{ocorrencia.Tipo} - {ocorrencia.Local} - {ocorrencia.Data}");
        }
    }

    public void Agrupar()
    {
        var ocorrenciasAgrupadasPorTipo = Ocorrencias.GroupBy(o => o.Tipo).ToList();

        foreach (var grupo in ocorrenciasAgrupadasPorTipo)
        {
            Console.WriteLine($"Tipo: {grupo.Key}");
            foreach (var ocorrencia in grupo)
            {
                Console.WriteLine($"- {ocorrencia.Local} - {ocorrencia.Data}");
            }
        }
    }

}

public class NotificacaoOcorrencia
{
    public static void GravarLog(object? sender, Ocorrencia ocorrencia)
    {
        string caminhoLog = "C:\\Users\\Alissa\\Desktop\\Exercicios\\Exercicio5\\ocorrencia.txt";
        string mensagemLog = $"Tipo: {ocorrencia.Tipo}, Local: {ocorrencia.Local}, Data: {ocorrencia.Data}, Urgente: {ocorrencia.Urgente}\n";

        using (var writer = new StreamWriter(caminhoLog, append: true))
        {
            writer.WriteLine(mensagemLog);
        }

        Console.WriteLine("\nLog de ocorrência registrado com sucesso!");
    }

    public static void ExibirAlertaConsole(object? sender, Ocorrencia ocorrencia)
    {
        Console.WriteLine($"Ocorrência registrada: Tipo: {ocorrencia.Tipo}, Local: {ocorrencia.Local}, Data: {ocorrencia.Data}");
    }

    public static void ExibirAlertaConsoleUrgente(object? sender, Ocorrencia ocorrencia)
    {
        if (ocorrencia.Urgente)
        {
            Console.WriteLine("ALERTA URGENTE!");
        }
    }
}
