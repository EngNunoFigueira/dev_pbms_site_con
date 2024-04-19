using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.Model
{
    public class ListaDaManutencao
    {
        public Int32 ID                               { get; set; }
        public string Site                            { get; set; }
        public string Status                          { get; set; }
        public string Observacao                      { get; set; }
        public string Funcionario                     { get; set; }
        public string Provincia                       { get; set; }
        public string Municipio                       { get; set; }
        public string Cliente                         { get; set; }

        public DateTime DataUltimaManutencao          { get; set; }
        public DateTime DataProximaManutencao         { get; set; }
    }
}