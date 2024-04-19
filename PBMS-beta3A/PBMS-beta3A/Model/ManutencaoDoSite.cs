using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class ManutencaoDoSite
    {
        public string NomeDoSite                    { get; set; }
        public string Provincia                     { get; set; }
        public string Municipio                     { get; set; }
    
        public string MarcaDoGerador                { get; set; }
        public double PotenciaElectricaKVA          { get; set; }
        public string NumeroDeSerieDoMotor          { get; set; }
        public string NumeroDeSerieDoGerador        { get; set; }
        public string NumeroDeSerieDoAlternador     { get; set; }
        public DateTime DataDaManutencao            { get; set; }
        public double HorasDeFuncionamentoGerador   { get; set; }


        public string NomeDaEmpresaCliente          { get; set; }
        public int ContactoTelefoneCliente          { get; set; }
        public string NomeResponsavelCliente        { get; set; }
        public string ContactoEmailDoCliente        { get; set; }

        #region Material Substituido na Manutenção

        public bool TrocaDoOleoDoMotor               { get; set; }
        public bool TrocaDeFiltroDeAr                { get; set; }
        public bool TrocaDeFiltroDeOleo              { get; set; }
        public bool TrocaDeFiltroDeGasoleo           { get; set; }

        #endregion

        public int GerawayStatusOk                  { get; set; }
        public DateTime GerawayUltimoSaldo          { get; set; }
      
    }
}