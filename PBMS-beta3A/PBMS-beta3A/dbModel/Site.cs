using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBMS_beta3A.dbModel
{
    public class Site
    {
        public Int32 ID                              { get; set; }
        public string Nome                           { get; set; }

        public Gerador Gerador                       { get; set; }
        public Int32 Id_Gerador { get; set; }

        public Geraway Geraway                       { get; set; }
        public Int32 Id_Gerawy                       { get; set; }

        public InfoSimCard SimCard                   { get; set; }
        public Int32 Id_SimCard                      { get; set; }

        public Bairro Bairro                         { get; set; }
        public Int32 Id_Bairro                       { get; set; }

        public Mes Mes                               { get; set; }
        public int Id_Mes                            { get; set; }

        public string Location                       { get; set; }
        public string Latitude                       { get; set; }
        public string Longitude                      { get; set; }
        public string Direction                      { get; set; }
       
        [Column(TypeName = "DateTime2")]
        public DateTime DataInstalacao               { get; set; }

        public Referencia Referencia                 { get; set; }
        public int Id_Referencia                     { get; set; }

        public Cliente Cliente                       { get; set; }
        public int Id_Cliente                        { get; set; }

        public Estado Estado                         { get; set; }
        public int Id_Estado                         { get; set; }
    }

    internal partial class Site_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Site>
    {
        public Site_configuration()
        {
            this.HasKey(t => t.ID);
            this.ToTable("Sites");

            this.HasRequired(t => t.Gerador).WithMany().HasForeignKey(t => t.Id_Gerador);
            this.HasRequired(t => t.Geraway).WithMany().HasForeignKey(t => t.Id_Gerawy);
            this.HasRequired(t => t.Bairro).WithMany().HasForeignKey(t =>  t.Id_Bairro);
            this.HasRequired(t => t.SimCard).WithMany().HasForeignKey(t => t.Id_SimCard);
            this.HasRequired(t => t.Cliente).WithMany().HasForeignKey(t => t.Id_Cliente);
            this.HasRequired(a => a.Estado).WithMany().HasForeignKey(a => a.Id_Estado);
            // Criado em 25 de Maio de 2016
            this.HasRequired(b => b.Mes).WithMany().HasForeignKey(b => b.Id_Mes);
            this.HasRequired(c => c.Referencia).WithMany().HasForeignKey(c => c.Id_Referencia);
        }
    }
}