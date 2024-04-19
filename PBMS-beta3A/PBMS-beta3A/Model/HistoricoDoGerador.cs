using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.Model
{
    public class HistoricoDoGerador
    {
        public DateTime DataDaInstalacao           { get; set; }
        public DateTime DataDaManutencao           { get; set; }
        public string   MotivoDaManutencao         { get; set; }
        public string   TipoDeAvarias              { get; set; }
        public double   HorasDeFuncionamento       { get; set; }
        public string   NomeDoTecnicoResponsavel   { get; set; }
        public string   ApelidoDoTecnicoResponsavel { get; set; }

        public int Obs_Material_01                 { get; set; }
        public int Obs_Material_02                 { get; set; }
        public int Obs_Material_03                 { get; set; }
        public int Obs_Material_04                 { get; set; }
        public int Obs_Material_05                 { get; set; }
        public int Obs_Material_06                 { get; set; }
        public int Obs_Material_07                 { get; set; }
        public int Obs_Material_08                 { get; set; }
        public int Obs_Material_09                 { get; set; }
        public int Obs_Material_10                 { get; set; }
    }
}