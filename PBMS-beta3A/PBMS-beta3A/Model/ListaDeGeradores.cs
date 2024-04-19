using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.Model
{
    public class ListaDeGeradores
    {
        public Int32 ID { get; set; }
        public string GeradorFabricante                    { get; set; }
        public string GeradorMarca                         { get; set; }
        public string GeradorModelo                        { get; set; }
        public double GeradorKVA                           { get; set; }
        public string GeradorTipo                          { get; set; }
        public DateTime GeradorAnoFabrico                  { get; set; }
        public string GeradorNumeroDoMotor                 { get; set; }
        public double GeradorCapacidadeLitros              { get; set; }
        public string GeradorNumeroDoAlternador            { get; set; }
        public string GeradorEstadoOnOff                   { get; set; }
        public string GeradorSITE                          { get; set; }
        public string GeradorRuido                         { get; set; }

    }
}