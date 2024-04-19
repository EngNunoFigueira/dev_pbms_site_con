using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.Model
{
    public class CriarNovoSite
    {
        public Int32 ID                   { get; set; }
        public Int32 Id_Gerador           { get; set; }
        public Int32 Id_Geraway           { get; set; }
        public Int32 Id_SimCard           { get; set; }
        public int   Id_Cliente           { get; set; }
        public Int32 Id_Provincia         { get; set; }
        public Int32 Id_Municipio         { get; set; }
        public string NomeDoSite          { get; set; }
        public Int32 Id_Bairro            { get; set; }
        public string CoodernadasGPS      { get; set; }
       
        [Column(TypeName = "DateTime2")]
        public DateTime Data              { get; set; }
        public int Id_Estado              { get; set; }
        public int Id_Referencia          { get; set; }

        // Estas variaveis foram declaradas em 25-May-2016
        public int NomeDoMesDaProximaManutencao { get; set; }
        public int Id_MesDaProximaManutencao    { get; set; }

    }
}