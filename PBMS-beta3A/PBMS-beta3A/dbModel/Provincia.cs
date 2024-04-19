using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Provincia
    {
        public Int32 ID                      { get; set; }
        public string Nome                   { get; set; }
    }
    internal partial class Provincia_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Provincia>
    {
        public Provincia_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Provincias");
        }
    }
}