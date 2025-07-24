using System;
using System.Collections.Generic;

SistemaEnergia sistema = new SistemaEnergia();

sistema.ConsumoElevado += ExibirAlerta.Alerta;
sistema.ConsumoElevado += DesligarDispositivos.Desligar;

DispositivoEletrico ar = new DispositivoEletrico("Ar-condicionado", 350) { Ativo = true };
DispositivoEletrico tv = new DispositivoEletrico("TV", 120) { Ativo = true };
DispositivoEletrico chuveiro = new DispositivoEletrico("Chuveiro", 600) { Ativo = true };

sistema.AdicionarDispositivo(ar);
sistema.AdicionarDispositivo(tv);
sistema.AdicionarDispositivo(chuveiro);

ar.Usar(sistema);
tv.Usar(sistema);
chuveiro.Usar(sistema);


public class AlertaConsumoArgs : EventArgs
{
    public string NomeDispositivo { get; }
    public double ConsumoAtual { get; }

    public AlertaConsumoArgs(string nomeDispositivo, double consumoAtual)
    {
        NomeDispositivo = nomeDispositivo;
        ConsumoAtual = consumoAtual;
    }
}

public class DispositivoEletrico
{
    public string Nome { get; set; }
    public double ConsumoPorUso { get; set; }
    public bool Ativo { get; set; }

    public DispositivoEletrico(string nome, double consumoPorUso)
    {
        Nome = nome;
        ConsumoPorUso = consumoPorUso;
        Ativo = false;
    }

    public void Usar(SistemaEnergia sistema)
    {
        if (Ativo)
        {
            Console.WriteLine($"{Nome} foi usado(a) (+{ConsumoPorUso}W)");
            sistema.ConsumoTotal += ConsumoPorUso;

            if (sistema.ConsumoTotal > SistemaEnergia.LimiteConsumo)
            {
                var causador = sistema.ObterDispositivoMaiorConsumo();
                sistema.OnConsumoElevado(new AlertaConsumoArgs(causador.Nome, sistema.ConsumoTotal));
            }
        }
    }
}

public class SistemaEnergia
{
    public const double LimiteConsumo = 1000;
    public double ConsumoTotal { get; set; } = 0;
    public List<DispositivoEletrico> Dispositivos { get; set; } = new();

    public event EventHandler<AlertaConsumoArgs>? ConsumoElevado;

    public void AdicionarDispositivo(DispositivoEletrico dispositivo)
    {
        Dispositivos.Add(dispositivo);
    }

    public DispositivoEletrico ObterDispositivoMaiorConsumo()
    {
        DispositivoEletrico? maior = null;
        foreach (var d in Dispositivos)
        {
            if (d.Ativo && (maior == null || d.ConsumoPorUso > maior.ConsumoPorUso))
            {
                maior = d;
            }
        }
        return maior!;
    }

    public void OnConsumoElevado(AlertaConsumoArgs args)
    {
        ConsumoElevado?.Invoke(this, args);
    }
}

public static class ExibirAlerta
{
    public static void Alerta(object? sender, AlertaConsumoArgs args)
    {
        Console.WriteLine($"\nALERTA DE CONSUMO ");
        Console.WriteLine($"Dispositivo com maior consumo: {args.NomeDispositivo}");
        Console.WriteLine($"Consumo total da casa: {args.ConsumoAtual}W\n");
    }
}

public static class DesligarDispositivos
{
    public static void Desligar(object? sender, AlertaConsumoArgs args)
    {
        if (sender is not SistemaEnergia sistema) return;

        Console.WriteLine("Desligando dispositivos com consumo > 200W");
        foreach (var d in sistema.Dispositivos)
        {
            if (d.Ativo && d.ConsumoPorUso > 200)
            {
                d.Ativo = false;
                Console.WriteLine($"{d.Nome} desligado automaticamente ({d.ConsumoPorUso}W)");
            }
        }
    }
}
