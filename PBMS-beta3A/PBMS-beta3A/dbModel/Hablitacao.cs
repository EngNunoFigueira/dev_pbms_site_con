using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Hablitacao
    {
        public int ID                       { get; set; }
        public string Grau                  { get; set; }
    }
    internal partial class Hablitacao_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Hablitacao>
    {
        public Hablitacao_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Hablitacaos");
        }
    }
}