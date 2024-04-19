using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.dbModel
{
    public class Manutencao
    {
        public Manutencao()
        {
            this.Funcionario = new HashSet<Funcionario>();
        }

        public Int32 ID                                     { get; set; }
        public Site Site                                    { get; set; }
        public Int32 Id_Site                                { get; set; }
        public double NumeroDeHoras                         { get; set; }
        //create on 26-05-2016
        public Estado Estado                                { get; set; }
        public int Id_Estado                                { get; set; }
        public DateTime ? DataInicio                        { get; set; }
        public DateTime? DataFecho                          { get; set; }
        public Requisicao Requisicao                        { get; set; }
        public Int32 Id_Requisicao                          { get; set; }
        public string Observacoes                           { get; set; }
        public virtual ICollection<Funcionario> Funcionario { get; set; }

        // Código adicionado em 26-05-2016
        public Mes Mes                                     { get; set; }
        public int Id_Mes                                  { get; set; }

        public TipodeTarefa TipodeTarefa                   { get; set; }
        public int Id_TipodeTarefa                         { get; set; }

    }
    internal partial class Manutencao_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Manutencao>
    {
        public Manutencao_configuration()
        {
            this.HasKey(t => t.ID);
            this.HasRequired(d => d.Site).WithMany().HasForeignKey(d =>d.Id_Site);
            this.HasRequired(a => a.Mes).WithMany().HasForeignKey(a => a.Id_Mes);
            this.HasRequired(b => b.Estado).WithMany().HasForeignKey(b => b.Id_Estado);
            this.HasRequired(b => b.Requisicao).WithMany().HasForeignKey(b => b.Id_Requisicao);
            this.HasRequired(c => c.TipodeTarefa).WithMany().HasForeignKey(c => c.Id_TipodeTarefa);
            this.ToTable("Manutencoes");
        }
    }
}