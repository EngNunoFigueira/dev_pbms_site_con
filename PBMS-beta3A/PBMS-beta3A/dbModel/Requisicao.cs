using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.dbModel
{
    public class Requisicao
    {
        public Int32 ID                  { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Data             { get; set; }
        //create on 27-05-2016
        public Estado Estado             { get; set; }
        public int Id_Estado             { get; set; }
        public string Material           { get; set; }
        public Funcionario Funcionario   { get; set; }
        public int Id_Funcionario        { get; set; }
    }

    internal partial class Requisicao_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Requisicao>
    {
        public Requisicao_configuration()
        {
            this.HasKey(t => t.ID);
            this.HasRequired(a => a.Estado).WithMany().HasForeignKey(a => a.Id_Estado);
            this.HasRequired(b => b.Funcionario).WithMany().HasForeignKey(b=>b.Id_Funcionario);
            this.ToTable("Requisicoes");
        }
    }
}