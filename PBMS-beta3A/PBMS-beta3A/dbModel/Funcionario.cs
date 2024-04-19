using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.dbModel
{
    public class Funcionario
    {
        public Funcionario()
        {
            this.Manutencao = new HashSet<Manutencao>();

            this.Contacto = new Contacto();
            this.Documento = new Documento();
            //this.Morada = new Morada();
        }

        public Int32 ID                                     { get; set; }
        public string Nome                                  { get; set; }
        public string Apelido                               { get; set; }
        public virtual ICollection<Manutencao> Manutencao   { get; set; }

        // This classes show below was create on 19-05-2016

        //public Morada Morada                              { get; set; }
        //public int MoradaId                               { get; set; }

        public Contacto Contacto                            { get; set; }
        public int ContactoId                               { get; set; }

        public Funcao Funcao                                { get; set; }
        public int Id_Funcao                                { get; set; }

        public Hablitacao Hablitacao                        { get; set; }
        public int Id_Hablitacao                            { get; set; }

        public Documento Documento                          { get; set; }
        public int DocumentoId                              { get; set; }

    }
    internal partial class Funcionario_configuration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Funcionario>
    {
        public Funcionario_configuration()
        {
            this.HasKey(t => t.ID);

            this.HasRequired(t => t.Hablitacao).WithMany().HasForeignKey(t => t.Id_Hablitacao);
            this.HasRequired(a => a.Funcao).WithMany().HasForeignKey(a => a.Id_Funcao);
            this.HasRequired(b => b.Contacto).WithMany().HasForeignKey(b => b.ContactoId);
            this.HasRequired(c => c.Documento).WithMany().HasForeignKey(c => c.DocumentoId);
            //this.HasRequired(d => d.Morada).WithMany().HasForeignKey(d => d.MoradaId);

            this.ToTable("Funcionarios");
        }
    }
}