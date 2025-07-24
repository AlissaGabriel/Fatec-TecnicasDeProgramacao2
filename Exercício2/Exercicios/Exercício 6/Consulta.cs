using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercício_6;
using static Exercício_6.Hospital;

namespace Exercício_6
{
    internal class Consulta
    {
        public Consulta(Medico medico, Paciente paciente, DateTime dataConsulta, string diagnostico) {
            Medico = medico;
            Paciente = paciente;
            DataConsulta = dataConsulta;
            Diagnostico = diagnostico;
        }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Diagnostico { get; set; }

        public void ExibirConsulta()
        {
            Console.WriteLine($"Nome do Paciente: {Paciente.Nome}\nIdade do Paciente: {Paciente.Idade}\nHistórico de Doenças: {Paciente.Historico}\nMédico responsável pelo atendimento: {Medico.Nome}\nIdade do médico: {Medico.Idade}\nEspecialização do Médico: {Medico.Especialidade}\nCRM: {Medico.Crm}\nData da Consulta: {DataConsulta}\nDiagnóstico: {Diagnostico}");
        }
    }
}
