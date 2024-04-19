using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Referencia
    {
        public Int32 ID          { get; set; }
        public string Descricao  { get; set; }
    }

    internal partial class Referencia_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Referencia>
    {
        public Referencia_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Referencias");
        }
    }
}