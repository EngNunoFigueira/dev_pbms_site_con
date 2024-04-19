using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.Model
{
    public class GeradorElectrico
    {
        public Int32    ID                           { get; set; }
        public int      RuidoEmDb                    { get; set; }
        public double   CapacidadeEmLitros           { get; set; }
        public double   HorasDeFuncionamento         { get; set; }
        public bool     TipoControladorRemoto        { get; set; }


        public string   GeradorModelo                { get; set; }
        public string   GeradorFabricante            { get; set; }
        public double   GeradorPotenciaKVA           { get; set; }

        public int      GeradorAnoDeFabrico          { get; set; }
        public int      GeradorNumeroDeFases         { get; set; }
        public double   GeradorPrecoCompra           { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime GeradorDataCompra            { get; set; }

        public string   GeradorDistribuidor          { get; set; }
        public bool     GeradorProtocoloCAN          { get; set; }
        public bool     GeradorProtocoloModbus       { get; set; }

        public string   GeradorTipoCombustivel       { get; set; }
        public string   Marca                        { get; set; }
        public bool     GeradorIncorporaGSM          { get; set; }
        public string   GeradorprogramadorLocal      { get; set; }
        public string   GeradorTipoDeArranque        { get; set; }


        public int      GeradorBateria               { get; set; }
        //Estes Dados Foram Actualização Em 17/12/2015
        public double Dimensao_kg                    { get; set; }
        public double Dimensao_H                     { get; set; }
        public double Dimensao_L                     { get; set; }
        public double Dimensao_C                     { get; set; }

        public int Estado                            { get; set; }

    }
}