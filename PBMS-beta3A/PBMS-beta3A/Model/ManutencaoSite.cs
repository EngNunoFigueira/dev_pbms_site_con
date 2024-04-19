using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PBMS_beta3A.Model
{
    public class ManutencaoSite
    {
        public Int32 ID                                 { get; set; }
        public string MSiteNome                         { get; set; }
        public int MTipoSite                            { get; set; }
        public int MEstadoSite                          { get; set; }

        [ReadOnly(true)]
        public string MBairro                           { get; set; }
        public string MMunicipio                        { get; set; }
        public string MProvincia                        { get; set; }

        public double MPotenciaKVA                      { get; set; }
        public string MGerawayRef                       { get; set; }
        public string MGerawayNumber                    { get; set; }
        public double Horrasuncionamento { get; set; }
     
        public string MFuncionarioResp                  { get; set; }
        public string MFuncionarioA                     { get; set; }
        public string MFuncionarioB                     { get; set; }
        public string MFuncionarioC                     { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DataConcliusao                  { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime DataProximaManutencao           { get; set; }

        public double MHorasEstimadas                   { get; set; }
        public string MCodigoRequisicao                 { get; set; }

        public string MComentarioUltimaManutencao       { get; set; }

        // Criada em 25-maio-2016
        public string MesProximaManutencao            { get; set; }
        public int Id_MesProximaManutencao         { get; set; }
        public string MDescricaoEstadoSite            { get; set; }
        public string MDescricaoTipoSite              { get; set; }
        // Criada em 26-maio-2016
        public int MTipoDeTarefa                      { get; set; }

        //Added on 27-05-2016
        public int RESPONSAVEL_ID                    { get; set; }
        public int Electricista_ID                   { get; set; }
        public int Mecanico_ID                       { get; set; }
        public int Motorista_ID                      { get; set; }
    }
}