using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Municipio
    {
        public Int32 ID              { get; set; }
        public string Nome           { get; set; }
        public Provincia provincia   { get; set; }
        public int Id_Provincia      { get; set; }
    }
    internal partial class Municipio_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Municipio>
    {
        public Municipio_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Municipios");
            this.HasRequired(t => t.provincia).WithMany().HasForeignKey(t => t.Id_Provincia);
        }
    }
}