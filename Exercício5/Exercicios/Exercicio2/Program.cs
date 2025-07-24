using System;

Console.WriteLine("Usando evento");
ArCondicionado ar = new ArCondicionado();

ar.limiteSuperior = 29.0;
ar.limiteInferior = 21.0;

ar.OnAlarmeTemperatura += Monitor.Alerta;

ar.ajustarTemperatura(20.0); 
ar.ajustarTemperatura(30.0); 
ar.ajustarTemperatura(25);   

Console.ReadKey();

public class ArCondicionadoEventArgs : EventArgs
{
    public double? Temperatura { get; set; }
    public double? LimiteSuperior { get; set; }
    public double? LimiteInferior { get; set; }
}

public class ArCondicionado
{
    public double? temperatura { get; set; }
    public double? limiteSuperior { get; set; }
    public double? limiteInferior { get; set; }

    public event EventHandler<ArCondicionadoEventArgs>? OnAlarmeTemperatura;

    public void ajustarTemperatura(double novaTemperatura)
    {
        temperatura = novaTemperatura;
        Console.WriteLine($"Nova temperatura: {temperatura}°C");

        if (temperatura > limiteSuperior)
        {
            OnAlarmeTemperatura(this, new ArCondicionadoEventArgs
            {
                Temperatura = temperatura,
                LimiteInferior = limiteInferior,
                LimiteSuperior = limiteSuperior
            });
            Console.WriteLine("Temperatura ultrapassou o limite superior");
        }
        else if (temperatura < limiteInferior)
        {
            OnAlarmeTemperatura(this, new ArCondicionadoEventArgs
            {
                Temperatura = temperatura,
                LimiteInferior = limiteInferior,
                LimiteSuperior = limiteSuperior
            });
            Console.WriteLine("Temperatura está abaixo do limite inferior");
        }
        else
        {
            Console.WriteLine("Temperatura está dentro dos limites");                                                                                                                                                                                                                                                                                                                                                                  );
        }
    }
}

public class Monitor
{
    public static void Alerta(object? sender, ArCondicionadoEventArgs e)
    {
        Console.WriteLine($"Alerta de temperatura: {e.Temperatura}°C");
    }
}
