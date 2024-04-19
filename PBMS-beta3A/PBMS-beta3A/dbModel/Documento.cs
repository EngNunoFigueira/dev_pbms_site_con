using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Documento
    {
        public int ID                 { get; set; }
        public string Tipo            { get; set; }
        public string Numero          { get; set; }
        public DateTime? Validade     { get; set; }
    }
    internal partial class Documento_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Documento>
    {
        public Documento_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Documentos");
        }
    }
}