using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.Model
{
    public class GestorDeTarefas
    {
        public string NomeDoFuncionario         { get; set; }
        public string ApelifoDoFuncionario      { get; set; }
        public string Especialidade             { get; set; }
        public string CargoDoFuncionario        { get; set; }

        public string TarefaEmCurso             { get; set; }
        public string EstadoActual              { get; set; }
        public double NumeroDeHoras             { get; set; }
        public DateTime ? DateInicio            { get; set; }
        public DateTime? DateFecho              { get; set; }
    }
}