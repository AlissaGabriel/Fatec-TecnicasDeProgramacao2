using System;
using System.Collections.Generic;
using System.Linq;

var sistema = new SistemaEnergia();
var monitor = new MonitorEnergia(sistema);

var ar = new DispositivoEletrico("Ar-condicionado", 500);
var geladeira = new DispositivoEletrico("Geladeira", 200);
var chuveiro = new DispositivoEletrico("Chuveiro", 600);
var computador = new DispositivoEletrico("Computador", 250);
var ferro = new DispositivoEletrico("Ferro de passar", 300);

sistema.AdicionarDispositivo(ar);
sistema.AdicionarDispositivo(geladeira);
sistema.AdicionarDispositivo(chuveiro);
sistema.AdicionarDispositivo(computador);
sistema.AdicionarDispositivo(ferro);


geladeira.Usar(sistema);  
computador.Usar(sistema); 
ar.Usar(sistema);         
ferro.Usar(sistema);      
chuveiro.Usar(sistema);   

Console.ReadKey();

public delegate void AlertaConsumoHandler(string nomeDispositivo, double consumoAtual);

public class DispositivoEletrico
{
    public string Nome { get; set; }
    public double ConsumoPorUso { get; set; } 
    public bool Ativo { get; set; } = true;

    public DispositivoEletrico(string nome, double consumo)
    {
        Nome = nome;
        ConsumoPorUso = consumo;
    }

    public void Usar(SistemaEnergia sistema)
    {
        if (Ativo)
        {
            sistema.RegistrarConsumo(this);
        }
    }
}

public class SistemaEnergia
{
    private List<DispositivoEletrico> dispositivos = new List<DispositivoEletrico>();
    private double consumoTotal = 0;
    private double limite = 1000; 

    // Evento baseado no delegate personalizado
    public event AlertaConsumoHandler? ConsumoElevado;

    // Adiciona um novo dispositivo à lista
    public void AdicionarDispositivo(DispositivoEletrico dispositivo)
    {
        dispositivos.Add(dispositivo);
    }

    // Chamada pelo dispositivo quando for usado
    public void RegistrarConsumo(DispositivoEletrico dispositivo)
    {
        consumoTotal += dispositivo.ConsumoPorUso;

        if (consumoTotal > limite)
        {
            // Identifica o dispositivo ativo de maior consumo
            var maisGastador = dispositivos
                .Where(d => d.Ativo)
                .OrderByDescending(d => d.ConsumoPorUso)
                .FirstOrDefault();

            ConsumoElevado?.Invoke(maisGastador?.Nome ?? "Desconhecido", consumoTotal);
        }
    }

    // Desliga apenas o dispositivo ativo que consome mais
    public void DesligarDispositivoMaisGastador()
    {
        var maisGastador = dispositivos
            .Where(d => d.Ativo)
            .OrderByDescending(d => d.ConsumoPorUso)
            .FirstOrDefault();

        if (maisGastador != null)
        {
            maisGastador.Ativo = false;
            Console.WriteLine($"[Sistema] Dispositivo desligado automaticamente: {maisGastador.Nome}");
        }
    }

    public void DesligarDispositivosAltos(double minimo)
    {
        foreach (var d in dispositivos.Where(d => d.Ativo && d.ConsumoPorUso >= minimo))
        {
            d.Ativo = false;
            Console.WriteLine($"[Sistema] Desligando dispositivo de alto consumo: {d.Nome}");
        }
    }
}
public class MonitorEnergia
{
    private SistemaEnergia _sistema;

    public MonitorEnergia(SistemaEnergia sistema)
    {
        _sistema = sistema;
        _sistema.ConsumoElevado += ExibirAlerta;
        _sistema.ConsumoElevado += DesligarDispositivos;
    }

    public void ExibirAlerta(string nomeDispositivo, double consumoAtual)
    {
        Console.WriteLine($"[Alerta] Consumo elevado detectado! Total: {consumoAtual}W. Dispositivo responsável: {nomeDispositivo}");
    }

    public void DesligarDispositivos(string nomeDispositivo, double consumoAtual)
    {
        Console.WriteLine("[Ação] Iniciando desligamento automático...");
        _sistema.DesligarDispositivoMaisGastador();

    }
}


