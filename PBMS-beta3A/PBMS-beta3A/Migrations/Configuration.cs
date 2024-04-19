namespace PBMS_beta3A.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PBMS_beta3A.dbModel;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<PBMS_beta3A.dbModel.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PBMS_beta3A.dbModel.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            using(MyDbContext db= new MyDbContext())
            {
                var ProvinciasAngola = new List<Provincia>() 
                {
                   new Provincia {ID=1,Nome="Bengo"},
                   new Provincia {ID=2,Nome="Benguela"},
                   new Provincia {ID=3,Nome="Bié"},
                   new Provincia {ID=4,Nome="Cabinda"},
                   new Provincia {ID=5,Nome="Kuando Kubango"},
                   new Provincia {ID=6,Nome="Kwanza Norte"},
                   new Provincia {ID=7,Nome="Kwanza Sul"},
                   new Provincia {ID=8,Nome="Cunene"},
                   new Provincia {ID=9,Nome="Huambo"},
                   new Provincia {ID=10,Nome="Huila"},
                   new Provincia {ID=11,Nome="Luanda"},
                   new Provincia {ID=12,Nome="Lunda Norte"},
                   new Provincia {ID=13,Nome="Lunda Sul"},
                   new Provincia {ID=14,Nome="Malanje"},
                   new Provincia {ID=15,Nome="Moxico"},
                   new Provincia {ID=16,Nome="Uíge"},
                   new Provincia {ID=17,Nome="Namibe"},
                   new Provincia {ID=18,Nome="Zaire"}
                };

                ProvinciasAngola.ForEach(a => db.Provincias.AddOrUpdate(b=>b.ID,a));
                db.SaveChanges();

                var MunicipioAngola = new List<Municipio>() 
                { 
                    new Municipio{ID=1,Nome="Ambriz",Id_Provincia=1},
                    new Municipio{ID=2,Nome="Bula Atumba",Id_Provincia=1},
                    new Municipio{ID=3,Nome="Dande",Id_Provincia=1},
                    new Municipio{ID=4,Nome="Dembos",Id_Provincia=1},
                    new Municipio{ID=5,Nome="Nambuangongo",Id_Provincia=1},
                    new Municipio{ID=6,Nome="Pango Aluquém",Id_Provincia=1},

                    new Municipio{ID=7,Nome="Balombo", Id_Provincia=2},
                    new Municipio{ID=8,Nome="Baía Farta", Id_Provincia=2},
                    new Municipio{ID=9,Nome="Benguela", Id_Provincia=2},
                    new Municipio{ID=10,Nome="Bocoio", Id_Provincia=2},
                    new Municipio{ID=11,Nome="Caimbambo", Id_Provincia=2},
                    new Municipio{ID=12,Nome="Catumbela", Id_Provincia=2},
                    new Municipio{ID=13,Nome="Chongoroi", Id_Provincia=2},
                    new Municipio{ID=14,Nome="Cubal", Id_Provincia=2},
                    new Municipio{ID=15,Nome="Ganda", Id_Provincia=2},
                    new Municipio{ID=16,Nome="Lobito", Id_Provincia=2},

                    new Municipio{ID=17,Nome="Andulo", Id_Provincia=3},
                    new Municipio{ID=18,Nome="Camacupa", Id_Provincia=3},
                    new Municipio{ID=19,Nome="Catabola", Id_Provincia=3},
                    new Municipio{ID=20,Nome="Chinguar", Id_Provincia=3},
                    new Municipio{ID=21,Nome="Chitembo", Id_Provincia=3},
                    new Municipio{ID=22,Nome="Cuemba", Id_Provincia=3},
                    new Municipio{ID=23,Nome="Cunhinga", Id_Provincia=3},
                    new Municipio{ID=24,Nome="Kuito", Id_Provincia=3},
                    new Municipio{ID=25,Nome="Nharea", Id_Provincia=3},

                    new Municipio{ID=26,Nome="Belize", Id_Provincia=4},
                    new Municipio{ID=27,Nome="Buco-Zau", Id_Provincia=4},
                    new Municipio{ID=28,Nome="Cabinda", Id_Provincia=4},
                    new Municipio{ID=29,Nome="Cacongo", Id_Provincia=4},

                    new Municipio{ID=30,Nome="Calai", Id_Provincia=5},
                    new Municipio{ID=31,Nome="Cuangar", Id_Provincia=5},
                    new Municipio{ID=32,Nome="Cuchi", Id_Provincia=5},
                    new Municipio{ID=33,Nome="Cuito Cuanavale", Id_Provincia=5},
                    new Municipio{ID=34,Nome="Dirico", Id_Provincia=5},
                    new Municipio{ID=35,Nome="Longa", Id_Provincia=5},
                    new Municipio{ID=36,Nome="Mavinga", Id_Provincia=5},
                    new Municipio{ID=37,Nome="Menongue", Id_Provincia=5},
                    new Municipio{ID=38,Nome="Nancova", Id_Provincia=5},
                    new Municipio{ID=39,Nome="Rivungo", Id_Provincia=5},

                    new Municipio{ID=40,Nome="Ambaca", Id_Provincia=6},
                    new Municipio{ID=41,Nome="Banga", Id_Provincia=6},
                    new Municipio{ID=42,Nome="Bolongongo", Id_Provincia=6},
                    new Municipio{ID=43,Nome="Cambambe", Id_Provincia=6},
                    new Municipio{ID=44,Nome="Cazengo", Id_Provincia=6},
                    new Municipio{ID=45,Nome="Gonguembo", Id_Provincia=6},
                    new Municipio{ID=46,Nome="Golungo Alto", Id_Provincia=6},
                    new Municipio{ID=47,Nome="Lucala", Id_Provincia=6},
                    new Municipio{ID=48,Nome="Quiculungo", Id_Provincia=6},
                    new Municipio{ID=49,Nome="Samba Cajú", Id_Provincia=6},

                    new Municipio{ID=50,Nome="Amboim", Id_Provincia=7},
                    new Municipio{ID=51,Nome="Cassongue", Id_Provincia=7},
                    new Municipio{ID=52,Nome="Conda", Id_Provincia=7},
                    new Municipio{ID=53,Nome="Ebo", Id_Provincia=7},
                    new Municipio{ID=54,Nome="Libolo", Id_Provincia=7},
                    new Municipio{ID=55,Nome="Mussende", Id_Provincia=7},
                    new Municipio{ID=56,Nome="Porto Amboim", Id_Provincia=7},
                    new Municipio{ID=57,Nome="Quibala", Id_Provincia=7},
                    new Municipio{ID=58,Nome="Quilenda", Id_Provincia=7},
                    new Municipio{ID=59,Nome="Seles", Id_Provincia=7},
                    new Municipio{ID=60,Nome="Sumbe", Id_Provincia=7},
                    new Municipio{ID=61,Nome="Waku Kungo", Id_Provincia=7},

                    new Municipio{ID=62,Nome="Cahama", Id_Provincia=8},
                    new Municipio{ID=63,Nome="Cuanhama", Id_Provincia=8},
                    new Municipio{ID=64,Nome="Curoca", Id_Provincia=8},
                    new Municipio{ID=65,Nome="Cuvelai", Id_Provincia=8},
                    new Municipio{ID=66,Nome="Namacunde", Id_Provincia=8},
                    new Municipio{ID=67,Nome="Ombadja", Id_Provincia=8},

                    new Municipio{ID=68,Nome="Bailundo", Id_Provincia=9},
                    new Municipio{ID=69,Nome="Catchiungo", Id_Provincia=9},
                    new Municipio{ID=70,Nome="Caála", Id_Provincia=9},
                    new Municipio{ID=71,Nome="Ekunha", Id_Provincia=9},
                    new Municipio{ID=72,Nome="Huambo", Id_Provincia=9},
                    new Municipio{ID=73,Nome="Londuimbale", Id_Provincia=9},
                    new Municipio{ID=74,Nome="Longonjo", Id_Provincia=9},
                    new Municipio{ID=75,Nome="Mungo", Id_Provincia=9},
                    new Municipio{ID=76,Nome="Tchicala-Tcholoanga", Id_Provincia=9},
                    new Municipio{ID=77,Nome="Tchindjenje", Id_Provincia=9},
                    new Municipio{ID=78,Nome="Ucuma", Id_Provincia=9},

                    new Municipio{ID=79,Nome="Caconda", Id_Provincia=10},
                    new Municipio{ID=80,Nome="Cacula Caluquembe", Id_Provincia=10},
                    new Municipio{ID=81,Nome="Chiange", Id_Provincia=10},
                    new Municipio{ID=82,Nome="Chibia", Id_Provincia=10},
                    new Municipio{ID=83,Nome="Chicomba", Id_Provincia=10},
                    new Municipio{ID=84,Nome="Chipindo", Id_Provincia=10},
                    new Municipio{ID=85,Nome="Cuvango", Id_Provincia=10},
                    new Municipio{ID=86,Nome="Humpata", Id_Provincia=10},
                    new Municipio{ID=87,Nome="Jamba", Id_Provincia=10},
                    new Municipio{ID=88,Nome="Lubango", Id_Provincia=10},
                    new Municipio{ID=89,Nome="Matala", Id_Provincia=10},
                    new Municipio{ID=90,Nome="Quilengues", Id_Provincia=10},
                    new Municipio{ID=91,Nome="Quipungo", Id_Provincia=10},

                    new Municipio{ID=92,Nome="Belas", Id_Provincia=11},
                    new Municipio{ID=93,Nome="Cacuaco", Id_Provincia=11},
                    new Municipio{ID=94,Nome="Cazenga", Id_Provincia=11},
                    new Municipio{ID=95,Nome="Ícolo e Bengo", Id_Provincia=11},
                    new Municipio{ID=96,Nome="Luanda", Id_Provincia=11},
                    new Municipio{ID=97,Nome="Quiçama", Id_Provincia=11},
                    new Municipio{ID=98,Nome="Viana", Id_Provincia=11},

                    new Municipio{ID=99, Nome="Cambulo", Id_Provincia=12},
                    new Municipio{ID=100,Nome="Capenda-Camulemba", Id_Provincia=12},
                    new Municipio{ID=101,Nome="Caungula", Id_Provincia=12},
                    new Municipio{ID=102,Nome="Chitato", Id_Provincia=12},
                    new Municipio{ID=103,Nome="Cuango", Id_Provincia=12},
                    new Municipio{ID=104,Nome="Cuílo", Id_Provincia=12},
                    new Municipio{ID=105,Nome="Lubalo", Id_Provincia=12},
                    new Municipio{ID=106,Nome="Lucapa", Id_Provincia=12},
                    new Municipio{ID=107,Nome="Xá-Muteba", Id_Provincia=12},

                    new Municipio{ID=108,Nome="Cacolo", Id_Provincia=13},
                    new Municipio{ID=109,Nome="Dala", Id_Provincia=13},
                    new Municipio{ID=110,Nome="Muconda", Id_Provincia=13},
                    new Municipio{ID=111,Nome="Saurimo", Id_Provincia=13},
                    new Municipio{ID=112,Nome="Cacuso", Id_Provincia=14},
                    new Municipio{ID=113,Nome="Calandula", Id_Provincia=14},
                    new Municipio{ID=114,Nome="Cambundi-Catembo", Id_Provincia=14},
                    new Municipio{ID=115,Nome="Cangandala", Id_Provincia=14},
                    new Municipio{ID=116,Nome="Caombo", Id_Provincia=14},
                    new Municipio{ID=117,Nome="Cuaba Nzogo", Id_Provincia=14},
                    new Municipio{ID=118,Nome="Cunda-Dia-Baze", Id_Provincia=14},
                    new Municipio{ID=119,Nome="Luquembo", Id_Provincia=14},
                    new Municipio{ID=120,Nome="Malanje", Id_Provincia=14},
                    new Municipio{ID=121,Nome="Marimba", Id_Provincia=14},
                    new Municipio{ID=122,Nome="Massango", Id_Provincia=14},
                    new Municipio{ID=123,Nome="Mucari", Id_Provincia=14},
                    new Municipio{ID=124,Nome="Quela", Id_Provincia=14},
                    new Municipio{ID=125,Nome="Quirima", Id_Provincia=14},

                    new Municipio{ID=126,Nome="Alto Zambeze", Id_Provincia=15},
                    new Municipio{ID=127,Nome="Bundas", Id_Provincia=15},
                    new Municipio{ID=128,Nome="Camanongue", Id_Provincia=15},
                    new Municipio{ID=129,Nome="Léua", Id_Provincia=15},
                    new Municipio{ID=130,Nome="Luau", Id_Provincia=15},
                    new Municipio{ID=131,Nome="Luacano", Id_Provincia=15},
                    new Municipio{ID=132,Nome="Luchazes", Id_Provincia=15},
                    new Municipio{ID=133,Nome="Luena", Id_Provincia=15},
                    new Municipio{ID=134,Nome="Lumeje", Id_Provincia=15},
                    new Municipio{ID=135,Nome="Moxico", Id_Provincia=15},

                    new Municipio{ID=136,Nome="Alto Cauale", Id_Provincia=16},
                    new Municipio{ID=137,Nome="Ambuíla", Id_Provincia=16},
                    new Municipio{ID=138,Nome="Bembe", Id_Provincia=16},
                    new Municipio{ID=139,Nome="Buengas", Id_Provincia=16},
                    new Municipio{ID=140,Nome="Bungo", Id_Provincia=16},
                    new Municipio{ID=141,Nome="Damba", Id_Provincia=16},
                    new Municipio{ID=142,Nome="Macocola", Id_Provincia=16},
                    new Municipio{ID=143,Nome="Milunga", Id_Provincia=16},
                    new Municipio{ID=144,Nome="Mucaba", Id_Provincia=16},
                    new Municipio{ID=145,Nome="Negage", Id_Provincia=16},
                    new Municipio{ID=146,Nome="Puri", Id_Provincia=16},
                    new Municipio{ID=147,Nome="Quimbele", Id_Provincia=16},
                    new Municipio{ID=148,Nome="Quitexe", Id_Provincia=16},
                    new Municipio{ID=149,Nome="Sanza Pombo", Id_Provincia=16},
                    new Municipio{ID=150,Nome="Songo", Id_Provincia=16},
                    new Municipio{ID=151,Nome="Uíge", Id_Provincia=16},
                    new Municipio{ID=152,Nome="Zombo", Id_Provincia=16},

                    new Municipio{ID=153,Nome="Bibala", Id_Provincia=17},
                    new Municipio{ID=154,Nome="Camucuyo", Id_Provincia=17},
                    new Municipio{ID=155,Nome="Namibe", Id_Provincia=17},
                    new Municipio{ID=156,Nome="Tombua", Id_Provincia=17},
                    new Municipio{ID=157,Nome="Virei", Id_Provincia=17},
                    new Municipio{ID=158,Nome="M'Banza Kongo", Id_Provincia=18},
                    new Municipio{ID=159,Nome="Nóqui", Id_Provincia=18},
                    new Municipio{ID=160,Nome="N'Zeto", Id_Provincia=18},
                    new Municipio{ID=161,Nome="Soyo", Id_Provincia=18},
                    new Municipio{ID=162,Nome="Tomboco", Id_Provincia=18},   
                    new Municipio{ID=163,Nome="Cuimba", Id_Provincia=18}
                  
                };

                MunicipioAngola.ForEach(a => db.Municipios.AddOrUpdate(b => b.Nome,a));
                db.SaveChanges();

                var AngolaBairros = new List<Bairro>()
                {
                    new Bairro {ID=1, Nome="Cimangola",Id_Municipio=95},
                    new Bairro {ID=2, Nome="Kikolo",Id_Municipio=95},
                    new Bairro {ID=3, Nome="Bairro Boa Eesperança",Id_Municipio=95},
                    new Bairro {ID=4, Nome="Kifangondo",Id_Municipio=95},
                    new Bairro {ID=5, Nome="Panguila",Id_Municipio=95},
                    new Bairro {ID=6, Nome="Paraíso",Id_Municipio=95},
                    new Bairro {ID=7, Nome="Malueka",Id_Municipio=95},
                    new Bairro {ID=8, Nome="Balumuka",Id_Municipio=95},
                    new Bairro {ID=9, Nome="Mulevos",Id_Municipio=95},
                    new Bairro {ID=10, Nome="Centralidade de Cacuaco",Id_Municipio=95},
                    new Bairro {ID=11, Nome="Vidrul",Id_Municipio=95},
                    new Bairro {ID=12, Nome="Funda",Id_Municipio=95},

                    new Bairro {ID=13, Nome="Vila de Viana",Id_Municipio=100},
                    new Bairro {ID=14, Nome="Bairro da BCA",Id_Municipio=100},
                    new Bairro {ID=15, Nome="Robaldina",Id_Municipio=100},
                    new Bairro {ID=16, Nome="Kilometro 30",Id_Municipio=100},
                    new Bairro {ID=17, Nome="Luanda Sul",Id_Municipio=100},
                    new Bairro {ID=18, Nome="Estalagem",Id_Municipio=100},
                    new Bairro {ID=19, Nome="Huambo",Id_Municipio=100},
                    new Bairro {ID=20, Nome="Grafanil",Id_Municipio=100},
                    new Bairro {ID=21, Nome="Vila da Mata",Id_Municipio=100},
                    new Bairro {ID=22, Nome="Zango I",Id_Municipio=100},
                    new Bairro {ID=23, Nome="Zango II",Id_Municipio=100},
                    new Bairro {ID=24, Nome="Zango III",Id_Municipio=100},
                    new Bairro {ID=25, Nome="Zango IV",Id_Municipio=100},
                    new Bairro {ID=26, Nome="Zango V",Id_Municipio=100},
                    new Bairro {ID=27, Nome="Centralidade do Zango",Id_Municipio=100},
                    new Bairro {ID=28, Nome="Calumbo",Id_Municipio=100},

                    new Bairro {ID=29, Nome="Hoji Ya Henda",Id_Municipio=96},
                    new Bairro {ID=30, Nome="Cuca",Id_Municipio=96},
                    new Bairro {ID=31, Nome="Mabor",Id_Municipio=96},
                    new Bairro {ID=32, Nome="Nocal",Id_Municipio=96},
                    new Bairro {ID=33, Nome="Sonefe",Id_Municipio=96},
                    new Bairro {ID=34, Nome="Tala Hady",Id_Municipio=96},
                    new Bairro {ID=35, Nome="Socola",Id_Municipio=96},
                    new Bairro {ID=36, Nome="Cala Boca",Id_Municipio=96},
                    new Bairro {ID=37, Nome="Ser Madó",Id_Municipio=96},
                    new Bairro {ID=38, Nome="Levilagi",Id_Municipio=96},
                    new Bairro {ID=39, Nome="Calumbo",Id_Municipio=100}
                };

                AngolaBairros.ForEach(a=>db.Bairros.AddOrUpdate(b=>b.ID, a));
                db.SaveChanges();

                var PBM_Main_Data_Estado = new List<Estado>()
                {
                    new Estado{ID=1,Descricao="Stock"},
                    new Estado{ID=2,Descricao="Instalados"},
                    new Estado{ID=3,Descricao="Online"},
                    new Estado{ID=4,Descricao="Manutenção"},
                    new Estado{ID=5,Descricao="Avariado"},
                    new Estado{ID=6,Descricao="Desligados"},
                    new Estado{ID=7,Descricao="A Venda"},
                    new Estado{ID=8,Descricao="Abatidos"},
                    new Estado{ID=9,Descricao="Particulares"},
                    new Estado{ID=10,Descricao="Destruídos"},
                    new Estado{ID=11,Descricao="Devolvidos"},
                    new Estado{ID=12,Descricao="Descontinuados"},
                    new Estado{ID=13,Descricao="Perdidos"},
                    new Estado{ID=14,Descricao="Em Teste 24h"},
                    new Estado{ID=15,Descricao="Em curso"},
                    new Estado{ID=16,Descricao="Concluido"},
                    new Estado{ID=17,Descricao="Normal"},
                    new Estado{ID=18,Descricao="Urgente"},
                    new Estado{ID=19,Descricao="Terminado"},
                    new Estado{ID=20,Descricao="Em vigor"}        

                };
                PBM_Main_Data_Estado.ForEach(a => db.Estados.AddOrUpdate(b=>b.ID,a));
                db.SaveChanges();


                var PBM_Main_Data_Hablitacoes = new List<Hablitacao>()
                {
                    new Hablitacao{ID=1,Grau="Estudos Básicos"},
                    new Hablitacao{ID=2,Grau="Estudos Superiores"},
                    new Hablitacao{ID=3,Grau="Estudos Médio Técnico"},
                    new Hablitacao{ID=4,Grau="Estudos Pré-Universitários"}
                };
                PBM_Main_Data_Hablitacoes.ForEach(a => db.Hablitacaos.AddOrUpdate(b=>b.ID,a));
                db.SaveChanges();


                var PBM_Main_Data_Funcao = new List<Funcao>()
                {
                    new Funcao{ID=1,Descricao="Motorista"},
                    new Funcao{ID=2,Descricao="Electricista"},
                    new Funcao{ID=3,Descricao="Mecânico"},
                    new Funcao{ID=4,Descricao="Electrónico"},
                    new Funcao{ID=5,Descricao="Administrativo"},
                    new Funcao{ID=6,Descricao="Pintor Auto"},
                    new Funcao{ID=7,Descricao="Técnico Básico"},
                    new Funcao{ID=8,Descricao="Informático"},
                    new Funcao{ID=9,Descricao="Gestor de Projectos"},
                    new Funcao{ID=10,Descricao="Coordernador de Equipa"},
                    new Funcao{ID=11,Descricao="Fiel de Armazém"}

                };
                PBM_Main_Data_Funcao.ForEach(a => db.Funcaos.AddOrUpdate(b=>b.ID, a));
                db.SaveChanges();


                var PBM_Main_Data_Mes = new List<Mes>()
                {
                    new Mes{ID=1,NomeDoMes="Janeiro"},
                    new Mes{ID=2,NomeDoMes="Fevereiro"},
                    new Mes{ID=3,NomeDoMes="Março"},
                    new Mes{ID=4,NomeDoMes="Abril"},
                    new Mes{ID=5,NomeDoMes="Maio"},
                    new Mes{ID=6,NomeDoMes="Junho"},
                    new Mes{ID=7,NomeDoMes="Julho"},
                    new Mes{ID=8,NomeDoMes="Agosto"},
                    new Mes{ID=9,NomeDoMes="Setembro"},
                    new Mes{ID=10,NomeDoMes="Outubro"},
                    new Mes{ID=11,NomeDoMes="Novembro"},
                    new Mes{ID=12,NomeDoMes="Dezembro"}
                  
                };
                PBM_Main_Data_Mes.ForEach(a => db.Meses.AddOrUpdate(b => b.ID, a));
                db.SaveChanges();


                var PBM_Main_Data_TipoTarefa = new List<TipodeTarefa>()
                {
                    new TipodeTarefa {ID=1,Descricao="Avaria"},
                    new TipodeTarefa {ID=2,Descricao="Manutenção"},
                    new TipodeTarefa {ID=3,Descricao="Abastecimento Local"},
                    new TipodeTarefa {ID=4,Descricao="Sergviços Técnicos Gerais"},
                    new TipodeTarefa {ID=5,Descricao="Compras de Material"},
                    new TipodeTarefa {ID=6,Descricao="Instalação de Nova Unidade"},
                    new TipodeTarefa {ID=7,Descricao="Problemas Técnico Urgente"}
                };
                PBM_Main_Data_TipoTarefa.ForEach(a => db.TipodeTarefas.AddOrUpdate(b => b.ID, a));
                db.SaveChanges();


                var PBM_Main_Data_Referencia = new List<Referencia>() 
                { 
                  new Referencia{ID=1,Descricao="Electrógeneos"},
                  new Referencia{ID=2,Descricao="Fotovoltaico"},
                  new Referencia{ID=3,Descricao="Hibrido"},
                  new Referencia{ID=4,Descricao="Particular"},
                  new Referencia{ID=5,Descricao="Empresa"},
                  new Referencia{ID=6,Descricao="Particulares"},
                  new Referencia{ID=7,Descricao="Teste de Engenharia"}
                
                };

                PBM_Main_Data_Referencia.ForEach(a => db.Referencias.AddOrUpdate(b => b.ID, a));
                db.SaveChanges();

                var PBM_Main_Data_EmpresaDeTelecomunicacao = new List<EmpresaDeTelecomunicacao>()
                {
                    new EmpresaDeTelecomunicacao{ID=1,Descricao="Unitel"},
                    new EmpresaDeTelecomunicacao{ID=2,Descricao="Movicel"},
                    new EmpresaDeTelecomunicacao{ID=3,Descricao="Vodafone"},
                    new EmpresaDeTelecomunicacao{ID=4,Descricao="Orange"},
                    new EmpresaDeTelecomunicacao{ID=5,Descricao="Movistar"},
                    new EmpresaDeTelecomunicacao{ID=6,Descricao="Libala"},
                };

                PBM_Main_Data_EmpresaDeTelecomunicacao.ForEach(a => db.EmpresaDeTelecomunicacoes.AddOrUpdate(b=>b.ID,a));
                db.SaveChanges();


                //End.. SEED METHOD
            }
        }
    }
}
