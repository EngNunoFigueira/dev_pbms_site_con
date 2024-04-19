using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Contacto
    {
        public int ID                      { get; set; }
        public string Telefone             { get; set; }
        public string Telemovel            { get; set; }
        public string Email                { get; set; }
    }
    internal partial class Contacto_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Contacto>
    {
        public Contacto_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Contactos");
        }
    }
}