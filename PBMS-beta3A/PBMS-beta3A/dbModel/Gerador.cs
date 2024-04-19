using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.dbModel
{
    public class Gerador
    {
        public Int32 ID                     { get; set; }
        public string modelo                { get; set; }
        public string marca                 { get; set; }
        public string fabricante            { get; set; }
        public double potencia_KVA          { get; set; }
        public int n_fases                  { get; set; }

        public int ano_fabrico              { get; set; }
        public double capacidade_LTR        { get; set; }
        public double dimensao_kg           { get; set; }
        public double dimensao_H            { get; set; }
        public double dimensao_L            { get; set; }
        public double dimensao_C            { get; set; }
        public bool incorpora_can           { get; set; }
        public bool incorpora_gsm           { get; set; }
        public bool incorpora_modbus        { get; set; }
        public int bateria_v                { get; set; }
        public string tipo_arranque         { get; set; }
        public string programacao_local     { get; set; }

        /*ACTUALIZACOES DO OBJECTO GERADOR DE MODO QUE POSSA CORRESPONDER A TABELA GERADORS EM SQL*/

        public int RuidoEmDb                     { get; set; }
        public string geradortipoCombustivel     { get; set; }
        public double HorasDeFuncionamento       { get; set; }
        public double GeradorPrecoCompra         { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime GeradorDataCompra       { get; set; }

        public Estado Estado                    { get; set; }
        public int Id_Estado                    { get; set; }
    }

    internal partial class Gerador_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Gerador>
    {
        public Gerador_configuration()
        {
            this.HasKey(t => t.ID);
            this.HasRequired(a => a.Estado).WithMany().HasForeignKey(a => a.Id_Estado);
            this.ToTable("Geradors");
        }
    }
}