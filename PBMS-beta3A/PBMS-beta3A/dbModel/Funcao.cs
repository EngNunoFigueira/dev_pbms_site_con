using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Funcao
    {
        public int ID                      { get; set; }
        public string Descricao            { get; set; }
    }
    internal partial class Funcao_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Funcao>
    {
        public Funcao_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Funcoes");
        }
    }
}