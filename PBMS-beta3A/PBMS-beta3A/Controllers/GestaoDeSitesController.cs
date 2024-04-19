using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBMS_beta3A.Model;
using PBMS_beta3A.dbModel;

namespace PBMS_beta3A.Controllers
{
    public class GestaoDeSitesController : Controller   
    {
        #region MOSTRA A LISTA DE TODOS OS SITES INSTALADOS

        [HttpGet]
        public ActionResult GestaoDaListaDeSITES()
        {
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    var GetSitesFromDb = from sites in db.Sites
                                         where sites.ID >= 1
                                         orderby sites.ID
                                         select new
                                         {
                                             sites.Nome,
                                             sites.Bairro,
                                             sites.Bairro.Municipio,
                                             sites.Bairro.Municipio.provincia,
                                             sites.Cliente,
                                             sites.DataInstalacao,
                                             sites.Geraway,
                                             sites.Gerador,
                                             sites.SimCard,
                                             sites.Estado.Descricao,
                                             sites.Referencia
                                         };

                    GetSitesFromDb.ToList();

                    string nuno = GetSitesFromDb.First().provincia.Nome;

                    List<ListaDeSITES> GetSites = new List<ListaDeSITES>();

                    for (int i = 0; i < GetSitesFromDb.ToArray().Length; i++)
                    {
                        GetSites.Add(new ListaDeSITES
                        {
                            SITENome = GetSitesFromDb.ToArray()[i].Nome,
                            SITEProvincia = GetSitesFromDb.ToArray()[i].provincia.Nome,
                            SITEMunicipio = GetSitesFromDb.ToArray()[i].Municipio.Nome,
                            SITEDataInstalacao = GetSitesFromDb.ToArray()[i].DataInstalacao,
                            SITENomeCliente = GetSitesFromDb.ToArray()[i].Cliente.Nome,
                            SITEContactoMobile = GetSitesFromDb.ToArray()[i].SimCard.Numero,
                            SITEGRWYPartNumber = GetSitesFromDb.ToArray()[i].Geraway.part_number,
                            SITEEstadoDescricao = GetSitesFromDb.ToArray()[i].Descricao,
                            SITERTiposeferencia = GetSitesFromDb.ToArray()[i].Referencia.Descricao,
                            SITEBairro = GetSitesFromDb.ToArray()[i].Bairro.Nome,
                            SITEGRDORKVA = GetSitesFromDb.ToArray()[i].Gerador.potencia_KVA

                        });
                    }

                    return View(GetSites);
                }
            }
            catch (Exception)
            {
                List<ListaDeSITES> GetSites = new List<ListaDeSITES>();

                return View(GetSites);
            }

        }
        #endregion

        #region  REFRESCA A PAGINA - SITES -> Partialview

        [HttpGet]
        public PartialViewResult SitesRequisitados(int site)
        {
             
            using (MyDbContext db = new MyDbContext())  
            {
                var GetSitesFromDb = from sites in db.Sites
                                     where sites.Id_Estado == site
                                     orderby sites.ID
                                     select new
                                     {
                                         sites.Nome,
                                         sites.Bairro,
                                         sites.Bairro.Municipio,
                                         sites.Bairro.Municipio.provincia,
                                         sites.Cliente,
                                         sites.DataInstalacao,
                                         sites.Geraway,
                                         sites.Gerador,
                                         sites.SimCard,
                                         sites.Estado.Descricao,
                                         sites.Referencia
                                     };

                GetSitesFromDb.ToList();

           
                List<ListaDeSITES> GetSites = new List<ListaDeSITES>();

                for (int i = 0; i < GetSitesFromDb.ToArray().Length; i++)
                {
                    GetSites.Add(new ListaDeSITES
                    {
                        SITENome = GetSitesFromDb.ToArray()[i].Nome,
                        SITEProvincia = GetSitesFromDb.ToArray()[i].provincia.Nome,
                        SITEMunicipio = GetSitesFromDb.ToArray()[i].Municipio.Nome,
                        SITEDataInstalacao = GetSitesFromDb.ToArray()[i].DataInstalacao,
                        SITENomeCliente = GetSitesFromDb.ToArray()[i].Cliente.Nome,
                        SITEContactoMobile = GetSitesFromDb.ToArray()[i].SimCard.Numero,
                        SITEGRWYPartNumber = GetSitesFromDb.ToArray()[i].Geraway.part_number,
                        SITEEstadoDescricao = GetSitesFromDb.ToArray()[i].Descricao,
                        SITERTiposeferencia = GetSitesFromDb.ToArray()[i].Referencia.Descricao,
                        SITEBairro = GetSitesFromDb.ToArray()[i].Bairro.Nome,
                        SITEGRDORKVA = GetSitesFromDb.ToArray()[i].Gerador.potencia_KVA

                    });
                }

                return PartialView(GetSites);

            }
            
        }
        #endregion

        #region MENU DE CONFIGIRAÇO DE SITES

        [HttpGet]
        public ActionResult CriarNovoSite()
        {
            // ESTE CONTROLLER MOSTRA A VISTA ONDE SE CONFIGURAM OS NOVOS SITES

           CriarNovoSite model = new CriarNovoSite();

           using (MyDbContext db = new MyDbContext())
            {
                // Carrega a Lista de Provincias... 1

                ViewBag.Provincias = db.Provincias.Select(t => t.Nome).Distinct().ToList();

                var GetProvincias = from items in db.Provincias
                               where items.ID!=0
                               orderby items.Nome
                               select items;

                ViewBag.Provincias = GetProvincias.ToList();

                //Carrega a Lista de Municipios... 2

                var GetMunicipios = from items in db.Municipios
                               where items.ID>0
                               orderby items.Nome
                               select items;

                ViewBag.Municipios = GetMunicipios.ToList();

                // Carrega a lista de Geradores... 3

                var GetGeradores = from items in db.Geradors
                                   where items.Id_Estado == 1
                                   orderby items.potencia_KVA
                                   select new { items.ID, items.potencia_KVA };

                ViewBag.Geradores = GetGeradores.ToList();

                // Carrega a Lista de Geraways... 4

                var GetGeraways = from items in db.Geraways
                                  where items.Id_Estado == 1 // carrega os equipamentos que estao em stock 
                                  orderby items.modelo
                                  select new {items.ID,items.modelo };

                ViewBag.Geraways = GetGeraways.ToList();

               // Buscar a Lista de Clientes... 5

                var GetClientes = from items in db.Clientes
                                  where items.ID > 0
                                  orderby items.Nome
                                  select new { items.ID, items.Nome };

                ViewBag.Clientes = GetClientes.ToList();

               // Buscar a Lista de Bairros... 6

                var GetBairros = from items in db.Bairros
                                where items.ID > 0
                                orderby items.Nome
                                select new { items.ID, items.Nome };

                ViewBag.Bairros = GetBairros.ToList();

                // Buscar a Lista de Numeros de Telefone Em Stock... 7

                var GetSimCardNumber = from items in db.InfoSimCards
                                       where items.Id_Estado == 1
                                       select new { items.ID, items.Numero };

                ViewBag.SimCardNumber = GetSimCardNumber.ToList();        

               //# BUSCA A LISTA DE REFERENCIAS

                var GET_REFERENCIAS = from items in db.Referencias
                                      select new { items.ID, items.Descricao};

                ViewBag.Referencias = GET_REFERENCIAS.ToList();       



            }

            return View(model);
        }
        [HttpPost]
        public ActionResult CriarNovoSite(CriarNovoSite model)
        {
      
            //# GUARDA AS CONFIGURAÇÕES DO NOVO SITE NA BDA

            using(MyDbContext db =new MyDbContext())
            {
                Site NovoSite = new Site();

                NovoSite.Nome     = model.NomeDoSite;
                NovoSite.Id_Referencia = model.Id_Referencia;
                NovoSite.Id_Estado = model.Id_Estado;
                NovoSite.Id_Cliente = model.Id_Cliente;
                NovoSite.Id_SimCard = model.Id_SimCard;
                NovoSite.Id_Bairro = model.Id_Bairro;
                NovoSite.Id_Gerador= model.Id_Gerador;
                NovoSite.Id_Gerawy = model.Id_Geraway;
                NovoSite.DataInstalacao = model.Data;
                NovoSite.Id_Mes = model.Id_MesDaProximaManutencao;

                db.Sites.Add(NovoSite);
                db.SaveChanges();
            }

            if (ModelState.IsValid)
            {
                using (MyDbContext db = new MyDbContext())
                {
                    //# SEMPRE QUE OS EQUIPAMENTOS SAIREM DE STOCK PARA UMA MONTAGEM
                    //#TEMOS QUE ACTUALIZAR O SEUS ESTADOS NA BDA POR EXEMPLO, 
                    //# UM GERADOR DEPOIS DE PASSAR PARA UM SITE FICA 
                    //#STOCK

                    //#SIMCARD
                    var ACTUALIZAR_STOCK_SIMCARD = db.InfoSimCards.FirstOrDefault(a => a.ID == model.Id_SimCard);
                    ACTUALIZAR_STOCK_SIMCARD.Id_Estado = model.Id_Estado;
                    db.SaveChanges();
                    //# GERADOR
                    var ACTUALIZAR_STOCK_GERADOR = db.Geradors.FirstOrDefault(b => b.ID == model.Id_Gerador);
                    ACTUALIZAR_STOCK_GERADOR.Id_Estado = model.Id_Estado;
                    db.SaveChanges();
                    //# GERAWAY
                    var ACTUALIZAR_STOCK_GERAWAY = db.Geraways.FirstOrDefault(c => c.ID == model.Id_Geraway);
                    ACTUALIZAR_STOCK_GERADOR.Id_Estado = model.Id_Estado;
                    db.SaveChanges();
                }

            }
            
            return (RedirectToAction("GestaoDaListaDeSITES")); 
        }

        #endregion

        #region ACTUALIZAR OS PARAMETROS DO SITE

        [HttpGet]
        public ActionResult EditarSiteParametros(Int32 id)
        {
            // Recebe o código do Site que se deseja fazer alterações básicas e vamos a BDA carregar o Obj para apresentar ao Utilizador.
            //  O utlizador análisa todas as informações do Obj e vê qual a que será actualizada.

            // Portanto, nesta action faremos a selecção do objecto da lista que será alterado os seus parâmetros.

            using(MyDbContext db= new MyDbContext()) 
            {

                var ACTUALIZAR_SITE = from itens in db.Sites
                                      where itens.ID == id
                                      select new 
                                      {
                                          itens.Nome,
                                          itens.Referencia.Descricao,
                                          itens.SimCard.Numero,
                                          itens.Gerador.potencia_KVA,
                                          itens.Geraway.part_number,
                                          itens.DataInstalacao,
                                          itens.Estado,
                                          itens.Cliente.Apelido,
                                          itens.Bairro.Municipio,
                                          itens.Bairro.Municipio.provincia,
                                          itens.Mes.NomeDoMes
                                      };

                ListaDeSITES  SiteParaActualizar = new ListaDeSITES();

                ACTUALIZAR_SITE.ToArray();

                SiteParaActualizar.SITENome = ACTUALIZAR_SITE.ToArray()[0].Nome;
                SiteParaActualizar.SITENomeCliente = ACTUALIZAR_SITE.ToArray()[0].Apelido;
                SiteParaActualizar.SITEGRWYPartNumber = ACTUALIZAR_SITE.ToArray()[0].part_number;
                SiteParaActualizar.SITEGRDORKVA = ACTUALIZAR_SITE.ToArray()[0].potencia_KVA;
                SiteParaActualizar.SITEEstadoOnOff = ACTUALIZAR_SITE.ToArray()[0].Estado.Descricao;
                SiteParaActualizar.SITEContactoMobile = ACTUALIZAR_SITE.ToArray()[0].Numero;
                SiteParaActualizar.SITEMunicipio = ACTUALIZAR_SITE.ToArray()[0].Municipio.Nome;
                SiteParaActualizar.SITEProvincia = ACTUALIZAR_SITE.ToArray()[0].provincia.Nome;
                SiteParaActualizar.SITEDataInstalacao = ACTUALIZAR_SITE.ToArray()[0].DataInstalacao;
                SiteParaActualizar.SITERTiposeferencia = ACTUALIZAR_SITE.ToArray()[0].Descricao;
                SiteParaActualizar.NomeDoMesDaProximaManutencao = ACTUALIZAR_SITE.ToArray()[0].NomeDoMes;


               // //PROVINCIAS
               // var GetProvincias = from items in db.Provincias
               //                     where items.ID != 0
               //                     orderby items.Nome
               //                     select items;

               // ViewBag.Provincias = GetProvincias.ToList();

               // //MUNICÍPIOS
               // var GetMunicipios = from items in db.Municipios
               //                     where items.ID > 0
               //                     orderby items.Nome
               //                     select items;

               // ViewBag.Municipios = GetMunicipios.ToList();

               // // NÚMERO DE SIM CARDS DISPONÍVEIS
               // var GetSimCardNumber = from items in db.InfoSimCards
               //                        where items.Id_Estado == 1
               //                        select new { items.ID, items.Numero };

               //ViewBag.SimCardNumber = GetSimCardNumber.ToList();  
 
                return View(SiteParaActualizar);
            }
            
        }
        [HttpPost]
        public ActionResult EditarSiteParametros(ListaDeSITES model)
        {
            // Recebe o novo Obj com as actualizações feitas e guarda na BDA.

            // Portanto, nesta action será programado o código que vai interagir com a base de dados para guardar o Obj alterado.

            return View();
        }
        #endregion

        #region    Visualização de Todos os SITES no Mapa

        [HttpGet]
        public ActionResult MapaDeGeradores()
        {

            using (MyDbContext db = new MyDbContext())
            {
                var PointsMap = db.Sites.Select(t => new GeoLocationSiteonMap
                {
                    Direction = t.Direction,
                    Latitude = t.Latitude,
                    Location = t.Location,
                    Longitude = t.Longitude

                }).ToArray();  
          
             
                //List<GeoLocationSiteonMap> points = new List<GeoLocationSiteonMap>();
                //points.Add(new GeoLocationSiteonMap { Location = "Cabinda", Latitude =  -8.90270979, Longitude = 13.18565368 });

            var str = "[";
            var commaRequired = false;
            foreach (var item in PointsMap.Select(o => "['" + o.Direction + "'," + o.Longitude + ", " + o.Latitude + "]"))
            {
                if (commaRequired)
                    str += ",";
                str += item;

                commaRequired = true;
            }
            str += "]";

            ViewBag.Points = str;

            }

            return View();

        }

        #endregion

        #region  VER A LISTA DAS PROXIMAS MANUTENCOES DE SITES

        [HttpGet]
        public ActionResult ProximasManutencoes()
        {

            #region NOVO CÓDIGO ---- // #LISTA TODOS OS SITES QUE TEM MANUTENÇõ DENTRO DO RESECTIVO MÊS DA CONSULTA


            DateTime GetMesActual = DateTime.Now;
            List<ManutencaoSite> PMSite = new List<ManutencaoSite>();

            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    var GetSitesParaManutencao = from sites in db.Sites
                                                 where sites.Id_Mes == GetMesActual.Month
                                                 orderby sites.ID
                                                 select new
                                                 {
                                                     sites.ID,
                                                     sites.Mes,
                                                     sites.Nome,
                                                     sites.Bairro,
                                                     sites.Bairro.Municipio,
                                                     sites.Bairro.Municipio.provincia,
                                                     sites.Cliente,
                                                     sites.DataInstalacao,
                                                     sites.Geraway,
                                                     sites.Gerador,
                                                     sites.SimCard,
                                                     sites.Estado,
                                                     sites.Referencia
                                                 };

                    GetSitesParaManutencao.ToList();

                    for (int i = 0; i < GetSitesParaManutencao.ToArray().Length; i++)
                    {
                        PMSite.Add(new ManutencaoSite
                        {
                            ID = GetSitesParaManutencao.ToArray()[i].ID,
                            MSiteNome = GetSitesParaManutencao.ToArray()[i].Nome,
                            MesProximaManutencao = GetSitesParaManutencao.ToArray()[i].Mes.NomeDoMes,
                            MDescricaoEstadoSite = GetSitesParaManutencao.ToArray()[i].Estado.Descricao,
                            MBairro = GetSitesParaManutencao.ToArray()[i].Bairro.Nome,
                            MMunicipio = GetSitesParaManutencao.ToArray()[i].Municipio.Nome,
                            MProvincia = GetSitesParaManutencao.ToArray()[i].provincia.Nome,
                            MPotenciaKVA = GetSitesParaManutencao.ToArray()[i].Gerador.potencia_KVA,
                            MGerawayRef = GetSitesParaManutencao.ToArray()[i].Geraway.serial_number,
                            MGerawayNumber = GetSitesParaManutencao.ToArray()[i].SimCard.Numero,
                            Horrasuncionamento = GetSitesParaManutencao.ToArray()[i].Gerador.HorasDeFuncionamento,
                            MDescricaoTipoSite = GetSitesParaManutencao.ToArray()[i].Referencia.Descricao

                        });
                    }
                }

             return View(PMSite);
            }
            catch (Exception) {return RedirectToAction("GestaoDaListaDeSITES"); }


            #endregion
        }

        [HttpGet]
        public PartialViewResult ConsultarProximasManutencoes(int MesDaProximaManutencao)
        {
            #region MOSTRAS AS PRÓXIMAS MANUTENÇÕES PARA CADA MES

            List<ManutencaoSite> PMSite = new List<ManutencaoSite>();

            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    var GetSitesParaManutencao = from sites in db.Sites
                                                 where sites.Id_Mes == MesDaProximaManutencao
                                                 orderby sites.ID
                                                 select new
                                                 {
                                                     sites.ID,
                                                     sites.Mes,
                                                     sites.Nome,
                                                     sites.Bairro,
                                                     sites.Bairro.Municipio,
                                                     sites.Bairro.Municipio.provincia,
                                                     sites.Cliente,
                                                     sites.DataInstalacao,
                                                     sites.Geraway,
                                                     sites.Gerador,
                                                     sites.SimCard,
                                                     sites.Estado,
                                                     sites.Referencia
                                                 };

                    GetSitesParaManutencao.ToList();

                    for (int i = 0; i < GetSitesParaManutencao.ToArray().Length; i++)
                    {
                        PMSite.Add(new ManutencaoSite
                        {
                            ID = GetSitesParaManutencao.ToArray()[i].ID,
                            MSiteNome = GetSitesParaManutencao.ToArray()[i].Nome,
                            MesProximaManutencao = GetSitesParaManutencao.ToArray()[i].Mes.NomeDoMes,
                            MDescricaoEstadoSite = GetSitesParaManutencao.ToArray()[i].Estado.Descricao,
                            MBairro = GetSitesParaManutencao.ToArray()[i].Bairro.Nome,
                            MMunicipio = GetSitesParaManutencao.ToArray()[i].Municipio.Nome,
                            MProvincia = GetSitesParaManutencao.ToArray()[i].provincia.Nome,
                            MPotenciaKVA = GetSitesParaManutencao.ToArray()[i].Gerador.potencia_KVA,
                            MGerawayRef = GetSitesParaManutencao.ToArray()[i].Geraway.serial_number,
                            MGerawayNumber = GetSitesParaManutencao.ToArray()[i].SimCard.Numero,
                            Horrasuncionamento = GetSitesParaManutencao.ToArray()[i].Gerador.HorasDeFuncionamento,
                            MDescricaoTipoSite = GetSitesParaManutencao.ToArray()[i].Referencia.Descricao

                        });
                    }
                }

                return PartialView(PMSite);
            }
            catch (Exception) { return PartialView(RedirectToAction("GestaoDaListaDeSITES")); }


            #endregion
        }

        #endregion

        #region  CRIAR PLANO DE MANUTENCAO PARA UM SITE

        [HttpGet]
        public ActionResult Manutencao(int id)
        {
                // #region SELECCIONA OS SITES QUE TÊM MANUTENCAO MARCADA
                // #Vai à base de dados da manutençao e seleciona todos os geradores que a ultima manutençao foi feita a 
                // #Tres meses

            using (MyDbContext db = new MyDbContext())
            {

                var GET_SITE_PARA_MANUTENCAO = from items in db.Sites
                                               where items.ID == id
                                               select new
                                               {
                                                   items.ID,
                                                   items.Nome,
                                                   items.Gerador,
                                                   items.Geraway,
                                                   items.Bairro.Municipio,
                                                   items.Bairro.Municipio.provincia,
                                                   items.Bairro,
                                                   items.Estado,
                                                   items.SimCard,
                                                   items.Referencia
                                               };

                GET_SITE_PARA_MANUTENCAO.ToArray();
            //   var GET_SITE_PARA_MANUTENCAO = db.Sites.FirstOrDefault(a => a.ID == id);


                ManutencaoSite MSite = new ManutencaoSite
                    {
                        ID = GET_SITE_PARA_MANUTENCAO.ToArray()[0].ID,
                        MSiteNome = GET_SITE_PARA_MANUTENCAO.ToArray()[0].Nome,
                        //MTipoSite              =GET_SITE_PARA_MANUTENCAO.Referencia.Descricao,               
                        //MEstadoSite            =GET_SITE_PARA_MANUTENCAO.Estado.Descricao,             
                        MBairro = GET_SITE_PARA_MANUTENCAO.ToArray()[0].Bairro.Nome,
                        MMunicipio = GET_SITE_PARA_MANUTENCAO.ToArray()[0].Bairro.Municipio.Nome,
                        MProvincia = GET_SITE_PARA_MANUTENCAO.ToArray()[0].Municipio.provincia.Nome,
                        MPotenciaKVA = GET_SITE_PARA_MANUTENCAO.ToArray()[0].Gerador.potencia_KVA,
                        MGerawayRef = GET_SITE_PARA_MANUTENCAO.ToArray()[0].Geraway.serial_number,
                        MGerawayNumber = GET_SITE_PARA_MANUTENCAO.ToArray()[0].SimCard.Numero,
                        Horrasuncionamento = GET_SITE_PARA_MANUTENCAO.ToArray()[0].Gerador.HorasDeFuncionamento,
                       // MFuncionarioResp = GET_SITE_PARA_MANUTENCAO,
                       // MFuncionarioA = GET_SITE_PARA_MANUTENCAO,
                       // MFuncionarioB = GET_SITE_PARA_MANUTENCAO,
                       // MFuncionarioC = GET_SITE_PARA_MANUTENCAO,
                       // DataConcliusao = GET_SITE_PARA_MANUTENCAO,
                       // DataProximaManutencao = GET_SITE_PARA_MANUTENCAO,
                       // MHorasEstimadas = GET_SITE_PARA_MANUTENCAO,
                       // MCodigoRequisicao = GET_SITE_PARA_MANUTENCAO,
                       // MComentarioUltimaManutencao = GET_SITE_PARA_MANUTENCAO,
                       // MesProximaManutencao = GET_SITE_PARA_MANUTENCAO,
                       // Id_MesProximaManutencao = GET_SITE_PARA_MANUTENCAO,
                        MDescricaoEstadoSite = GET_SITE_PARA_MANUTENCAO.ToArray()[0].Estado.Descricao,
                        MDescricaoTipoSite = GET_SITE_PARA_MANUTENCAO.ToArray()[0].Referencia.Descricao, 
      
                    };

                //#Informação para enviar para a vista
                var CategoriaDaManutencao = from items in db.TipodeTarefas
                                            select new
                                            {
                                                items.ID,
                                                items.Descricao
                                            };


                ViewBag.Categoriademanutencao = CategoriaDaManutencao.ToList();
                
                //#region SELECCIONA OS FUNCIONARIOS QUE ESTAO LIVRES PARA FAZEREM A MANUTENCAO
                //#Informação para enviar para a vista
                var FuncionarioChefeEquipa = from item in db.Funcionarios
                                             where item.Id_Funcao == 10
                                             select new
                                             {
                                                 item.ID,
                                                 item.Nome,
                                                 item.Apelido
                                             };

                FuncionarioChefeEquipa.ToList();
                List<NomesDeFuncionarios> ChefeDeEquipa = new List<NomesDeFuncionarios>();

                for (int i = 0; i < FuncionarioChefeEquipa.ToArray().Length; i++)
                {
                    ChefeDeEquipa.Add(new NomesDeFuncionarios
                                     {
                                         ID = FuncionarioChefeEquipa.ToArray()[i].ID,
                                         NomeCompleto = string.Concat(FuncionarioChefeEquipa.ToArray()[i].Nome, " ", FuncionarioChefeEquipa.ToArray()[i].Apelido)
                                     });
                }

                ViewBag.ChefeEquipa = ChefeDeEquipa.ToList();

                //# Nomes dos Mecânicos que estao livres
                var FuncionarioMecanico = from item in db.Funcionarios
                                          where item.Id_Funcao == 3
                                          select new
                                          {
                                              item.ID,
                                              item.Nome,
                                              item.Apelido
                                          };
                FuncionarioMecanico.ToList();

                List<NomesDeFuncionarios> Mecacnico = new List<NomesDeFuncionarios>();

                for (int i = 0; i < FuncionarioMecanico.ToArray().Length; i++)
                {
                    Mecacnico.Add(new NomesDeFuncionarios
                    {
                        ID = FuncionarioMecanico.ToArray()[i].ID,
                        NomeCompleto = string.Concat(FuncionarioMecanico.ToArray()[i].Nome, " ", FuncionarioMecanico.ToArray()[i].Apelido)
                    });
                }

                ViewBag.FMecanico = Mecacnico.ToList();

                //# Nomes Electricista que estao disponioveis
                var FuncionarioElectricista = from item in db.Funcionarios
                                              where item.Id_Funcao == 2
                                              select new
                                              {
                                                  item.ID,
                                                  item.Nome,
                                                  item.Apelido
                                              };
                FuncionarioElectricista.ToList();
                List<NomesDeFuncionarios> Electricista = new List<NomesDeFuncionarios>();

                for (int i = 0; i < FuncionarioElectricista.ToArray().Length; i++)
                {
                    Electricista.Add(new NomesDeFuncionarios
                    {
                        ID = FuncionarioElectricista.ToArray()[i].ID,
                        NomeCompleto = string.Concat(FuncionarioElectricista.ToArray()[i].Nome, " ", FuncionarioElectricista.ToArray()[i].Apelido)
                    });
                }

                ViewBag.FElectricista = Electricista.ToList();

                //# Nomes dos Motorista que estao disponiveis
                var FuncionarioMotorista = from item in db.Funcionarios
                                           where item.Id_Funcao == 1
                                           select new
                                           {
                                               item.ID,
                                               item.Nome,
                                               item.Apelido
                                           };
                FuncionarioMotorista.ToList();
                List<NomesDeFuncionarios> Motorista = new List<NomesDeFuncionarios>();

                for (int i = 0; i < FuncionarioMotorista.ToArray().Length; i++)
                {
                    Motorista.Add(new NomesDeFuncionarios
                    {
                        ID = FuncionarioMotorista.ToArray()[i].ID,
                        NomeCompleto = string.Concat(FuncionarioMotorista.ToArray()[i].Nome, " ", FuncionarioMotorista.ToArray()[i].Apelido)
                    });
                }

                ViewBag.FMotorista = Motorista.ToList();


                return View(MSite);
            }
        }

        [HttpPost]
        public ActionResult Manutencao(ManutencaoSite model)
        {
            //# REGISTA NA BASE DE DADOS TODOS OS DETALHES DA PROXIMA MANUTENCAO
            //# Notamos que ao tentar devolver o controlador com um return view obtemos um erro portanto, usamos o redirect 

            using(MyDbContext db=new MyDbContext())
            {

                //if(model.MCodigoRequisicao!=null)
                //{
                //    //var GET_ID_DAREQUISICAO= from items in db.Requisicoes
                //}

                Manutencao NOVA_MANUTENCAO = new Manutencao
                {
                    Id_Site = model.ID,
                    NumeroDeHoras = model.MHorasEstimadas,
                    Id_Estado = 15,
                    DataInicio = DateTime.Now,
                    Id_Requisicao = 1,
                    Observacoes = "Manutenção normal",
                    Id_Mes = model.Id_MesProximaManutencao,
                    Id_TipodeTarefa = model.MTipoDeTarefa,
                };

                var CHEFE_DE_EQUIPA = db.Funcionarios.FirstOrDefault(a => a.ID == model.RESPONSAVEL_ID);
                var MOTORISTA = db.Funcionarios.FirstOrDefault(a => a.ID == model.Motorista_ID);
                var ELECTRICISTA = db.Funcionarios.FirstOrDefault(a => a.ID == model.Electricista_ID);
                var MECANICO = db.Funcionarios.FirstOrDefault(a => a.ID == model.Mecanico_ID);

                NOVA_MANUTENCAO.Funcionario.Add(CHEFE_DE_EQUIPA);
                NOVA_MANUTENCAO.Funcionario.Add(MOTORISTA);
                NOVA_MANUTENCAO.Funcionario.Add(ELECTRICISTA);
                NOVA_MANUTENCAO.Funcionario.Add(MECANICO);
                
            
                db.Manutencoes.Add(NOVA_MANUTENCAO);
                db.SaveChanges();

              //#ACTUALIZA A PRÓXIMA MANUTENÇÃO DO SITE

                var SITE_PROXIMA_MANUTENCAO = db.Sites.FirstOrDefault(a=>a.ID==model.ID);
                SITE_PROXIMA_MANUTENCAO.Id_Mes = model.Id_MesProximaManutencao;
                db.SaveChanges();

            }

            return RedirectToAction("GestaoDaListaDeSITES");
        }
        #endregion

        #region ESTA ACTION PERMITE FAZER CONSULTAR AS LISTA DE REQUISIÇÕES DE MATERIAIS

        [HttpGet]
        public ActionResult ListaDeRequisicoes()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Actualiza_ListaDeRequisicoes(int operacao)
        {
            return PartialView();
        }
        #endregion

        #region  ESTA ACTION PERMITE FAZER A GESTÃO DAS REQUISIÇÕES DE MATERIAIS
        [HttpGet]
        public ActionResult RequisitarMaterial()
        {
            //#Devolve uma vista que permite fazer uma requisição
            using (MyDbContext db = new MyDbContext())
            {

                var GET_ESTADO = from items in db.Estados
                                            select new
                                            {
                                                items.ID,
                                                items.Descricao
                                            };

                 ViewBag.ESTADO_REQUISICAO=GET_ESTADO.ToList();

                 return View();
            }
            
        }

        [HttpGet]
        public PartialViewResult ValidarDadosDoResponsavel(string mambo, string nome)
        {
            using (MyDbContext db= new MyDbContext())
            {
                //#Permite validar os dados do responsável
                RequisitarMaterial RESP = new RequisitarMaterial();

                var VALIDARINFODORESPONSAVEL = from itens in db.Funcionarios
                                               where itens.Nome == nome
                                               where itens.Apelido == mambo
                                               select new
                                               {
                                                   itens.ID,
                                                   itens.Nome,
                                                   itens.Apelido,
                                                   itens.Contacto
                        
                                               };

                RESP.ID            = VALIDARINFODORESPONSAVEL.ToArray()[0].ID;
                RESP.RespNome      = VALIDARINFODORESPONSAVEL.ToArray()[0].Nome;
                RESP.RespApelido   = VALIDARINFODORESPONSAVEL.ToArray()[0].Apelido;
                RESP.ResEmail      = VALIDARINFODORESPONSAVEL.ToArray()[0].Contacto.Email;
                RESP.ResTelemovel  = VALIDARINFODORESPONSAVEL.ToArray()[0].Contacto.Telemovel;

                return PartialView(RESP);
            }
            
        }

        [HttpPost]
        public ActionResult ValidarDadosDoResponsavel(RequisitarMaterial model)
        {
            //#Guarda as informações na base de dados
            //#vamos introduzir código para verificar
            //#se dados do funcionario estão correctos.
            //#Isso porque haverá vezes que o utilizador 
            //# não precisará de validar os dados do 
            //# do usuario.
            using (MyDbContext db=new MyDbContext())
            {
                Requisicao NOVA_REQUISICAO = new Requisicao();

                  //NOVA_REQUISICAO.ID
                  NOVA_REQUISICAO.Id_Estado=model.Id_Estado;
                  NOVA_REQUISICAO.Id_Funcionario=model.ID;
                  NOVA_REQUISICAO.Data = DateTime.Now;
                  NOVA_REQUISICAO.Material = model.Material;

                  db.Requisicoes.Add(NOVA_REQUISICAO);
                  db.SaveChanges();

                  return View();
            }
        }

        #endregion

        #region  Visualização dos Contratos em PDF- Crystal Report

        public ActionResult ImprimirContratosDeManutenção()
        {

            return View();
        }
        #endregion 
    }
}




















