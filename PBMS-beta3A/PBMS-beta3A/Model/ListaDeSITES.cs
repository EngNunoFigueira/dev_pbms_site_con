using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.Model
{
    public class ListaDeSITES
    {  
        public string SITENome                     { get; set; }
        public string SITEProvincia                { get; set; }
        public string SITEMunicipio                { get; set; }
        public DateTime SITEDataInstalacao         { get; set; }
        public string SITENomeCliente              { get; set; }
        public string SITEContactoMobile           { get; set; }
        public string SITEGRWYPartNumber           { get; set; }
        public double SITEGRDORKVA                 { get; set; }

        public string SITEEstadoOnOff { get; set; }
        // Estas variaveis foram declaradas em 30-May-2016
        public string SITEEstadoDescricao          { get; set; }

        public int SITETiposDeSite                 { get; set; }
        // Estas variaveis foram declaradas em 30-May-2016
        public string SITERTiposeferencia          { get; set; }

        public string SITEBairro                   { get; set; }

        // Estas variaveis foram declaradas em 25-May-2016
        public string NomeDoMesDaProximaManutencao { get; set; }
        public int Id_MesDaProximaManutencao       { get; set; }
    }
}