using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Cliente
    {
        public Cliente()
        {
            this.Morada = new Morada();
            this.Contacto = new Contacto();
        }
        public Int32 ID                  { get; set; }
        public string Nome               { get; set; }
        public string Apelido            { get; set; }
        public Morada Morada             { get; set; }
        public int Id_Morada             { get; set; }
        public Contacto Contacto         { get; set; }
        public int Id_Contacto           { get; set; }
        public DateTime? Data            { get; set; }
        public string URL                { get; set; }

        //created on 28-05-2016
        public Referencia Referencia     { get; set; }   // Indica se é particular ou empresa
        public Int32 Id_Referencia       { get; set; }   
        public Estado Estado             { get; set; }
        public int Id_Estado             { get; set; }  // Activo ou contrato terminado

    }
    internal partial class Cliente_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Cliente>
    {
        public Cliente_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Clientes");
            this.HasRequired(a => a.Morada).WithMany().HasForeignKey(a => a.Id_Morada);
            this.HasRequired(b => b.Contacto).WithMany().HasForeignKey(b=>b.Id_Contacto);
            this.HasRequired(c => c.Estado).WithMany().HasForeignKey(c => c.Id_Estado);
            this.HasRequired(d => d.Referencia).WithMany().HasForeignKey(d => d.Id_Referencia);
        }
    }
}