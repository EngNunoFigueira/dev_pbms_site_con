using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PBMS_beta3A.Model;

namespace PBMS_beta3A.dbModel
{
    public class RequisicaoMaterialParaManutencao
    {
        public string NomeDoSite                     { get; set; }
        public string TipoDeMaterial                 { get; set; }
        public DateTime DataDaManutencao             { get; set; }
        public string DescricaoDaManutencao          { get; set; }
        public int CodigoResponsavelPelaManutencao   { get; set; }
    }
}