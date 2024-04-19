using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Morada
    {
        public Int32 ID                   { get; set; }
        public string Descricao           { get; set; }
        public Bairro Bairro              { get; set; }
        public int Id_Bairro               { get; set; }
        public string Morada_Rua_AVD      { get; set; }
        public string Morada_Numero_Porta { get; set; }
    }

    internal partial class Morada_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Morada>
    {
        public Morada_configuration()
        {
            this.HasKey(a => a.ID);
            this.HasRequired(a => a.Bairro).WithMany().HasForeignKey(t => t.Id_Bairro);
            this.ToTable("Moradas");
        }
    }
}