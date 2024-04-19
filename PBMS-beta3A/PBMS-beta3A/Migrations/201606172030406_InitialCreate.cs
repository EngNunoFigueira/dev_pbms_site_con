namespace PBMS_beta3A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bairros",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Id_Municipio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Municipios", t => t.Id_Municipio)
                .Index(t => t.Id_Municipio);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Id_Provincia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Provincias", t => t.Id_Provincia)
                .Index(t => t.Id_Provincia);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Apelido = c.String(),
                        Id_Morada = c.Int(nullable: false),
                        Id_Contacto = c.Int(nullable: false),
                        Data = c.DateTime(),
                        URL = c.String(),
                        Id_Referencia = c.Int(nullable: false),
                        Id_Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contactos", t => t.Id_Contacto)
                .ForeignKey("dbo.Estados", t => t.Id_Estado)
                .ForeignKey("dbo.Moradas", t => t.Id_Morada)
                .ForeignKey("dbo.Referencias", t => t.Id_Referencia)
                .Index(t => t.Id_Morada)
                .Index(t => t.Id_Contacto)
                .Index(t => t.Id_Referencia)
                .Index(t => t.Id_Estado);
            
            CreateTable(
                "dbo.Contactos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Telefone = c.String(),
                        Telemovel = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Moradas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Id_Bairro = c.Int(nullable: false),
                        Morada_Rua_AVD = c.String(),
                        Morada_Numero_Porta = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bairros", t => t.Id_Bairro)
                .Index(t => t.Id_Bairro);
            
            CreateTable(
                "dbo.Referencias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contratos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Id_Cliente = c.Int(nullable: false),
                        clausa_6 = c.Int(nullable: false),
                        clausa_7 = c.Int(nullable: false),
                        clausa_8 = c.Int(nullable: false),
                        clausa_9 = c.Int(nullable: false),
                        clausa_10 = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        clausa_1_ID = c.Int(),
                        clausa_2_ID = c.Int(),
                        clausa_3_ID = c.Int(),
                        clausa_4_ID = c.Int(),
                        clausa_5_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Referencias", t => t.clausa_1_ID)
                .ForeignKey("dbo.Referencias", t => t.clausa_2_ID)
                .ForeignKey("dbo.Referencias", t => t.clausa_3_ID)
                .ForeignKey("dbo.Referencias", t => t.clausa_4_ID)
                .ForeignKey("dbo.Referencias", t => t.clausa_5_ID)
                .ForeignKey("dbo.Clientes", t => t.Id_Cliente)
                .Index(t => t.Id_Cliente)
                .Index(t => t.clausa_1_ID)
                .Index(t => t.clausa_2_ID)
                .Index(t => t.clausa_3_ID)
                .Index(t => t.clausa_4_ID)
                .Index(t => t.clausa_5_ID);
            
            CreateTable(
                "dbo.Documentos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Numero = c.String(),
                        Validade = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmpresaDeTelecomunicacoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Funcoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Apelido = c.String(),
                        ContactoId = c.Int(nullable: false),
                        Id_Funcao = c.Int(nullable: false),
                        Id_Hablitacao = c.Int(nullable: false),
                        DocumentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contactos", t => t.ContactoId)
                .ForeignKey("dbo.Documentos", t => t.DocumentoId)
                .ForeignKey("dbo.Funcoes", t => t.Id_Funcao)
                .ForeignKey("dbo.Hablitacaos", t => t.Id_Hablitacao)
                .Index(t => t.ContactoId)
                .Index(t => t.Id_Funcao)
                .Index(t => t.Id_Hablitacao)
                .Index(t => t.DocumentoId);
            
            CreateTable(
                "dbo.Hablitacaos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Grau = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Manutencoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Id_Site = c.Int(nullable: false),
                        NumeroDeHoras = c.Double(nullable: false),
                        Id_Estado = c.Int(nullable: false),
                        DataInicio = c.DateTime(),
                        DataFecho = c.DateTime(),
                        Id_Requisicao = c.Int(nullable: false),
                        Observacoes = c.String(),
                        Id_Mes = c.Int(nullable: false),
                        Id_TipodeTarefa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estados", t => t.Id_Estado)
                .ForeignKey("dbo.Meses", t => t.Id_Mes)
                .ForeignKey("dbo.Requisicoes", t => t.Id_Requisicao)
                .ForeignKey("dbo.Sites", t => t.Id_Site)
                .ForeignKey("dbo.TipodeTarefas", t => t.Id_TipodeTarefa)
                .Index(t => t.Id_Site)
                .Index(t => t.Id_Estado)
                .Index(t => t.Id_Requisicao)
                .Index(t => t.Id_Mes)
                .Index(t => t.Id_TipodeTarefa);
            
            CreateTable(
                "dbo.Meses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomeDoMes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Requisicoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Id_Estado = c.Int(nullable: false),
                        Material = c.String(),
                        Id_Funcionario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estados", t => t.Id_Estado)
                .ForeignKey("dbo.Funcionarios", t => t.Id_Funcionario)
                .Index(t => t.Id_Estado)
                .Index(t => t.Id_Funcionario);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Id_Gerador = c.Int(nullable: false),
                        Id_Gerawy = c.Int(nullable: false),
                        Id_SimCard = c.Int(nullable: false),
                        Id_Bairro = c.Int(nullable: false),
                        Id_Mes = c.Int(nullable: false),
                        Location = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Direction = c.String(),
                        DataInstalacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Id_Referencia = c.Int(nullable: false),
                        Id_Cliente = c.Int(nullable: false),
                        Id_Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Bairros", t => t.Id_Bairro)
                .ForeignKey("dbo.Clientes", t => t.Id_Cliente)
                .ForeignKey("dbo.Estados", t => t.Id_Estado)
                .ForeignKey("dbo.Geradors", t => t.Id_Gerador)
                .ForeignKey("dbo.Geraways", t => t.Id_Gerawy)
                .ForeignKey("dbo.Meses", t => t.Id_Mes)
                .ForeignKey("dbo.Referencias", t => t.Id_Referencia)
                .ForeignKey("dbo.InfoSimCards", t => t.Id_SimCard)
                .Index(t => t.Id_Gerador)
                .Index(t => t.Id_Gerawy)
                .Index(t => t.Id_SimCard)
                .Index(t => t.Id_Bairro)
                .Index(t => t.Id_Mes)
                .Index(t => t.Id_Referencia)
                .Index(t => t.Id_Cliente)
                .Index(t => t.Id_Estado);
            
            CreateTable(
                "dbo.Geradors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        modelo = c.String(),
                        marca = c.String(),
                        fabricante = c.String(),
                        potencia_KVA = c.Double(nullable: false),
                        n_fases = c.Int(nullable: false),
                        ano_fabrico = c.Int(nullable: false),
                        capacidade_LTR = c.Double(nullable: false),
                        dimensao_kg = c.Double(nullable: false),
                        dimensao_H = c.Double(nullable: false),
                        dimensao_L = c.Double(nullable: false),
                        dimensao_C = c.Double(nullable: false),
                        incorpora_can = c.Boolean(nullable: false),
                        incorpora_gsm = c.Boolean(nullable: false),
                        incorpora_modbus = c.Boolean(nullable: false),
                        bateria_v = c.Int(nullable: false),
                        tipo_arranque = c.String(),
                        programacao_local = c.String(),
                        RuidoEmDb = c.Int(nullable: false),
                        geradortipoCombustivel = c.String(),
                        HorasDeFuncionamento = c.Double(nullable: false),
                        GeradorPrecoCompra = c.Double(nullable: false),
                        GeradorDataCompra = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Id_Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estados", t => t.Id_Estado)
                .Index(t => t.Id_Estado);
            
            CreateTable(
                "dbo.Geraways",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        modelo = c.String(),
                        firmware_version = c.String(),
                        serial_number = c.String(),
                        part_number = c.String(),
                        n_sensore_I = c.Int(nullable: false),
                        n_sensores_V = c.Int(nullable: false),
                        n_sensores_P = c.Int(nullable: false),
                        n_sensores_T = c.Int(nullable: false),
                        n_sensores_N = c.Int(nullable: false),
                        n_sensores_F = c.Int(nullable: false),
                        tipo_M_T_B = c.String(),
                        PCB_version = c.String(),
                        Id_Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estados", t => t.Id_Estado)
                .Index(t => t.Id_Estado);
            
            CreateTable(
                "dbo.InfoSimCards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        PinCode = c.Int(nullable: false),
                        Puk_1 = c.Int(nullable: false),
                        Puk_2 = c.Int(nullable: false),
                        Id_Operadora = c.Int(nullable: false),
                        Id_Estado = c.Int(nullable: false),
                        DataDaCompra = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estados", t => t.Id_Estado)
                .ForeignKey("dbo.EmpresaDeTelecomunicacoes", t => t.Id_Operadora)
                .Index(t => t.Id_Operadora)
                .Index(t => t.Id_Estado);
            
            CreateTable(
                "dbo.TipodeTarefas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Recargas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UTT = c.Int(nullable: false),
                        CodigoRecarga = c.String(),
                        DataCompra = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Id_InfoSimCard = c.Int(nullable: false),
                        Feedback = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InfoSimCards", t => t.Id_InfoSimCard)
                .Index(t => t.Id_InfoSimCard);
            
            CreateTable(
                "dbo.ManutencaoFuncionario",
                c => new
                    {
                        Manutencao_ID = c.Int(nullable: false),
                        Funcionario_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Manutencao_ID, t.Funcionario_ID })
                .ForeignKey("dbo.Manutencoes", t => t.Manutencao_ID, cascadeDelete: true)
                .ForeignKey("dbo.Funcionarios", t => t.Funcionario_ID, cascadeDelete: true)
                .Index(t => t.Manutencao_ID)
                .Index(t => t.Funcionario_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recargas", "Id_InfoSimCard", "dbo.InfoSimCards");
            DropForeignKey("dbo.Manutencoes", "Id_TipodeTarefa", "dbo.TipodeTarefas");
            DropForeignKey("dbo.Manutencoes", "Id_Site", "dbo.Sites");
            DropForeignKey("dbo.Sites", "Id_SimCard", "dbo.InfoSimCards");
            DropForeignKey("dbo.InfoSimCards", "Id_Operadora", "dbo.EmpresaDeTelecomunicacoes");
            DropForeignKey("dbo.InfoSimCards", "Id_Estado", "dbo.Estados");
            DropForeignKey("dbo.Sites", "Id_Referencia", "dbo.Referencias");
            DropForeignKey("dbo.Sites", "Id_Mes", "dbo.Meses");
            DropForeignKey("dbo.Sites", "Id_Gerawy", "dbo.Geraways");
            DropForeignKey("dbo.Geraways", "Id_Estado", "dbo.Estados");
            DropForeignKey("dbo.Sites", "Id_Gerador", "dbo.Geradors");
            DropForeignKey("dbo.Geradors", "Id_Estado", "dbo.Estados");
            DropForeignKey("dbo.Sites", "Id_Estado", "dbo.Estados");
            DropForeignKey("dbo.Sites", "Id_Cliente", "dbo.Clientes");
            DropForeignKey("dbo.Sites", "Id_Bairro", "dbo.Bairros");
            DropForeignKey("dbo.Manutencoes", "Id_Requisicao", "dbo.Requisicoes");
            DropForeignKey("dbo.Requisicoes", "Id_Funcionario", "dbo.Funcionarios");
            DropForeignKey("dbo.Requisicoes", "Id_Estado", "dbo.Estados");
            DropForeignKey("dbo.Manutencoes", "Id_Mes", "dbo.Meses");
            DropForeignKey("dbo.ManutencaoFuncionario", "Funcionario_ID", "dbo.Funcionarios");
            DropForeignKey("dbo.ManutencaoFuncionario", "Manutencao_ID", "dbo.Manutencoes");
            DropForeignKey("dbo.Manutencoes", "Id_Estado", "dbo.Estados");
            DropForeignKey("dbo.Funcionarios", "Id_Hablitacao", "dbo.Hablitacaos");
            DropForeignKey("dbo.Funcionarios", "Id_Funcao", "dbo.Funcoes");
            DropForeignKey("dbo.Funcionarios", "DocumentoId", "dbo.Documentos");
            DropForeignKey("dbo.Funcionarios", "ContactoId", "dbo.Contactos");
            DropForeignKey("dbo.Contratos", "Id_Cliente", "dbo.Clientes");
            DropForeignKey("dbo.Contratos", "clausa_5_ID", "dbo.Referencias");
            DropForeignKey("dbo.Contratos", "clausa_4_ID", "dbo.Referencias");
            DropForeignKey("dbo.Contratos", "clausa_3_ID", "dbo.Referencias");
            DropForeignKey("dbo.Contratos", "clausa_2_ID", "dbo.Referencias");
            DropForeignKey("dbo.Contratos", "clausa_1_ID", "dbo.Referencias");
            DropForeignKey("dbo.Clientes", "Id_Referencia", "dbo.Referencias");
            DropForeignKey("dbo.Clientes", "Id_Morada", "dbo.Moradas");
            DropForeignKey("dbo.Moradas", "Id_Bairro", "dbo.Bairros");
            DropForeignKey("dbo.Clientes", "Id_Estado", "dbo.Estados");
            DropForeignKey("dbo.Clientes", "Id_Contacto", "dbo.Contactos");
            DropForeignKey("dbo.Bairros", "Id_Municipio", "dbo.Municipios");
            DropForeignKey("dbo.Municipios", "Id_Provincia", "dbo.Provincias");
            DropIndex("dbo.ManutencaoFuncionario", new[] { "Funcionario_ID" });
            DropIndex("dbo.ManutencaoFuncionario", new[] { "Manutencao_ID" });
            DropIndex("dbo.Recargas", new[] { "Id_InfoSimCard" });
            DropIndex("dbo.InfoSimCards", new[] { "Id_Estado" });
            DropIndex("dbo.InfoSimCards", new[] { "Id_Operadora" });
            DropIndex("dbo.Geraways", new[] { "Id_Estado" });
            DropIndex("dbo.Geradors", new[] { "Id_Estado" });
            DropIndex("dbo.Sites", new[] { "Id_Estado" });
            DropIndex("dbo.Sites", new[] { "Id_Cliente" });
            DropIndex("dbo.Sites", new[] { "Id_Referencia" });
            DropIndex("dbo.Sites", new[] { "Id_Mes" });
            DropIndex("dbo.Sites", new[] { "Id_Bairro" });
            DropIndex("dbo.Sites", new[] { "Id_SimCard" });
            DropIndex("dbo.Sites", new[] { "Id_Gerawy" });
            DropIndex("dbo.Sites", new[] { "Id_Gerador" });
            DropIndex("dbo.Requisicoes", new[] { "Id_Funcionario" });
            DropIndex("dbo.Requisicoes", new[] { "Id_Estado" });
            DropIndex("dbo.Manutencoes", new[] { "Id_TipodeTarefa" });
            DropIndex("dbo.Manutencoes", new[] { "Id_Mes" });
            DropIndex("dbo.Manutencoes", new[] { "Id_Requisicao" });
            DropIndex("dbo.Manutencoes", new[] { "Id_Estado" });
            DropIndex("dbo.Manutencoes", new[] { "Id_Site" });
            DropIndex("dbo.Funcionarios", new[] { "DocumentoId" });
            DropIndex("dbo.Funcionarios", new[] { "Id_Hablitacao" });
            DropIndex("dbo.Funcionarios", new[] { "Id_Funcao" });
            DropIndex("dbo.Funcionarios", new[] { "ContactoId" });
            DropIndex("dbo.Contratos", new[] { "clausa_5_ID" });
            DropIndex("dbo.Contratos", new[] { "clausa_4_ID" });
            DropIndex("dbo.Contratos", new[] { "clausa_3_ID" });
            DropIndex("dbo.Contratos", new[] { "clausa_2_ID" });
            DropIndex("dbo.Contratos", new[] { "clausa_1_ID" });
            DropIndex("dbo.Contratos", new[] { "Id_Cliente" });
            DropIndex("dbo.Moradas", new[] { "Id_Bairro" });
            DropIndex("dbo.Clientes", new[] { "Id_Estado" });
            DropIndex("dbo.Clientes", new[] { "Id_Referencia" });
            DropIndex("dbo.Clientes", new[] { "Id_Contacto" });
            DropIndex("dbo.Clientes", new[] { "Id_Morada" });
            DropIndex("dbo.Municipios", new[] { "Id_Provincia" });
            DropIndex("dbo.Bairros", new[] { "Id_Municipio" });
            DropTable("dbo.ManutencaoFuncionario");
            DropTable("dbo.Recargas");
            DropTable("dbo.TipodeTarefas");
            DropTable("dbo.InfoSimCards");
            DropTable("dbo.Geraways");
            DropTable("dbo.Geradors");
            DropTable("dbo.Sites");
            DropTable("dbo.Requisicoes");
            DropTable("dbo.Meses");
            DropTable("dbo.Manutencoes");
            DropTable("dbo.Hablitacaos");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Funcoes");
            DropTable("dbo.EmpresaDeTelecomunicacoes");
            DropTable("dbo.Documentos");
            DropTable("dbo.Contratos");
            DropTable("dbo.Referencias");
            DropTable("dbo.Moradas");
            DropTable("dbo.Estados");
            DropTable("dbo.Contactos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Provincias");
            DropTable("dbo.Municipios");
            DropTable("dbo.Bairros");
        }
    }
}
