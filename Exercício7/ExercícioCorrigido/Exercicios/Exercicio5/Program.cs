using System.Text.Json;

var central = new CentralDeOcorrencias();
var reacoes = new Reacoes();

central.OcorrenciaRegistrada += reacoes.ExibirNoConsole;
central.OcorrenciaRegistrada += reacoes.GravarEmArquivo;

central.Registrar(new Ocorrencia("Incêndio", "Bloco A", true));
central.Registrar(new Ocorrencia("Vazamento", "Bloco C", false));
central.Registrar(new Ocorrencia("Briga", "Garagem", true));
central.Registrar(new Ocorrencia("Queda de energia", "Bloco B", false));

central.Salvar();

Console.WriteLine("\nOcorrências urgentes:");
central.FiltrarUrgentes();
    

Console.WriteLine("\nAgrupadas por tipo:");
central.AgruparPorTipo();

public delegate void OcorrenciaHandler(Ocorrencia o);

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

public class CentralDeOcorrencias
{
    public List<Ocorrencia> Ocorrencias { get; private set; } = new();
    public event OcorrenciaHandler? OcorrenciaRegistrada;
    private const string Caminho = "ocorrencias.json";

    public void Registrar(Ocorrencia o)
    {
        Ocorrencias.Add(o);
        OcorrenciaRegistrada?.Invoke(o);
    }

    public void Salvar()
    {
        var json = JsonSerializer.Serialize(Ocorrencias, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(Caminho, json);
    }

    public void Carregar()
    {
        if (!File.Exists(Caminho)) return;
        var json = File.ReadAllText(Caminho);
        var lista = JsonSerializer.Deserialize<List<Ocorrencia>>(json);
        if (lista != null) Ocorrencias = lista;
    }

    public void FiltrarUrgentes()
    {

        var ocorrenciasUrgentes = Ocorrencias.Where(o => o.Urgente);
        foreach (var ocorrencia in ocorrenciasUrgentes)
        {

            Console.WriteLine(ocorrencia.Local);

        }
    }

    public void AgruparPorTipo()
    {
        var ocorrenciaPorTipo = Ocorrencias.GroupBy(p => p.Tipo)
                                   .OrderBy(c => c.Key);

        foreach (var grupo in ocorrenciaPorTipo)
        {
            Console.WriteLine(grupo.Key + ":" + grupo.Count());

            foreach (var ocorrencia in grupo)
            {
                Console.WriteLine(ocorrencia.Local);
            }
        }
        
    }
    
}
public class Reacoes
{
    public void ExibirNoConsole(Ocorrencia o)
    {
        Console.WriteLine($"\nOcorrência registrada: {o.Tipo} em {o.Local} às {o.Data}");
        if (o.Urgente)
            Console.WriteLine("ALERTA URGENTE");
    }

    public void GravarEmArquivo(Ocorrencia o)
    {
        string texto = $"[{o.Data}] {o.Tipo} em {o.Local}. Urgente: {o.Urgente}";
        File.AppendAllText("ocorrencias.txt", texto + Environment.NewLine);
    }
}
