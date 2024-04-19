using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PBMS_beta3A.dbModel
{
    public class MyDbContext : DbContext
    {
      
        public DbSet <Municipio> Municipios                               { get; set; }
        public DbSet <Provincia> Provincias                               { get; set; }
        public DbSet <Cliente> Clientes                                   { get; set; }
        public DbSet <Site> Sites                                         { get; set; }
        public DbSet <Manutencao> Manutencoes                             { get; set; }
        public DbSet <Requisicao> Requisicoes                             { get; set; }
        public DbSet <Gerador> Geradors                                   { get; set; }
        public DbSet <Geraway> Geraways                                   { get; set; }
        public DbSet <Contrato> Contratos                                 { get; set; }
        public DbSet <Funcionario> Funcionarios                           { get; set; }
        public DbSet <Bairro> Bairros                                     { get; set; }
        public DbSet <Recarga> Recargas                                   { get; set; }
        public DbSet <InfoSimCard> InfoSimCards                           { get; set; }
        public DbSet <Referencia> Referencias                             { get; set; }
        // Create on 19-05-2016
        public DbSet<Morada> Moradas                                      { get; set; }
        public DbSet<Hablitacao> Hablitacaos                              { get; set; }
        public DbSet<Funcao> Funcaos                                      { get; set; }
        public DbSet<Documento> Documentos                                { get; set; }
        public DbSet<Contacto> Contactos                                  { get; set; }
        // Create on 23-05-2016
        public DbSet<EmpresaDeTelecomunicacao> EmpresaDeTelecomunicacoes  { get; set; }
        public DbSet<Estado> Estados                                      { get; set; }
        // Create on 25-05-2016
        public DbSet<Mes> Meses                                           { get; set; }

        // Create on 26-05-2016
        public DbSet<TipodeTarefa> TipodeTarefas                          { get; set; }

        // Create on 14-08-2016
        public DbSet<DadoDeLogin> DadoDeLogins                            { get; set; }

       // public virtual DbSet<View_FuncionarioManutencao> View_FuncionarioManutencao { get; set; }

        #region Override Methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

             modelBuilder.Configurations.Add(new Site_configuration());
             modelBuilder.Configurations.Add(new Manutencao_configuration());

             modelBuilder.Configurations.Add(new Bairro_configuration());
             modelBuilder.Configurations.Add(new Provincia_configuration());
             modelBuilder.Configurations.Add(new Municipio_configuration());

             modelBuilder.Configurations.Add(new Geraway_configuration());
             modelBuilder.Configurations.Add(new Gerador_configuration());

             modelBuilder.Configurations.Add(new Cliente_configuration());
             modelBuilder.Configurations.Add(new Contrato_configuration());
            
             modelBuilder.Configurations.Add(new InfoSimCard_configuration());
             modelBuilder.Configurations.Add(new Requisicao_configuration());
             modelBuilder.Configurations.Add(new Recarga_configuration());
             modelBuilder.Configurations.Add(new Referencia_configuration());

            // Create on 19-05-2016
             modelBuilder.Configurations.Add(new Morada_configuration());
             modelBuilder.Configurations.Add(new Funcao_configuration());
             modelBuilder.Configurations.Add(new Documento_configuration());
             modelBuilder.Configurations.Add(new Hablitacao_configuration());
             modelBuilder.Configurations.Add(new Contacto_configuration());
             // Create on 23-05-2016
             modelBuilder.Configurations.Add(new EmpresaDeTelecomunicacao_configuration());
             modelBuilder.Configurations.Add(new Estado_configuration());
            // Create on 25-05-2016
             modelBuilder.Configurations.Add(new Mes_configuration());
             modelBuilder.Configurations.Add(new Funcionario_configuration());

            // Create on 25-05-2016
             modelBuilder.Configurations.Add(new TipodeTarefa_configuration());

             // Create on 14-08-2016
             modelBuilder.Configurations.Add(new DadoDeLogin_configuration());

        }
        #endregion
    }
}