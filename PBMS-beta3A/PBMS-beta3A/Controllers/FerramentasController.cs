using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBMS_beta3A.Model;
using PBMS_beta3A.dbModel;


namespace PBMS_beta3A.Controllers
{
    public class FerramentasController : Controller
    {
   
        # region NESTA ACTION VAMOS MOSTRAR A LISTA DE SIMCARDS QUE ESTÃO EM USO OU OS QUE ESTAÕ EM STOCK

        public ActionResult NumerosDeTelefone()
        {
            List<ListaDeSimCard> SimCard = new List<ListaDeSimCard>();

            using (MyDbContext db = new MyDbContext())
            {

               //# Uma vez que o importante é mostrar o historico do cartão vamos começar por 
               //# por consultar a tabela de registo de recargas.
               
                var GET_REGRARGA = from items in db.Recargas
                                   where items.ID >0
                                   select new
                                   {
                                       items.ID,
                                       items.InfoSimCard,
                                       items.UTT,
                                       items.DataCompra,
                                       items.InfoSimCard.Estado.Descricao
                                   };

                GET_REGRARGA.ToList();

                //# Vamos verificar se existe algum registo nesta tabela e se assim for vamos tratar e mostrar esta informação
                //# caso não haver dados na tabela Recargas teremos que trabalhar com as informações da tabela InfoSimCards.
                if (GET_REGRARGA.ToArray().Length <= 0)
                {
                    var GET_SIMCARD = from cards in db.InfoSimCards
                                      where cards.Id_Estado == 1
                                      select new
                                      {
                                          cards.ID,
                                          cards.Numero,
                                          cards.Operadora,
                                          cards.PinCode,
                                          cards.Puk_1,
                                          cards.Puk_2,
                                          cards.Estado.Descricao
                                      };

                    //# Vamos processar a informação de modo a meter estes dados numa lista que será passada à vista
                    for (int i = 0; i < GET_SIMCARD.ToArray().Length; i++)
                    {

                        //# Tratamento da informação do estado do cartão de Sim 
                        SimCard.Add(new ListaDeSimCard
                        {
                            ID= GET_SIMCARD.ToArray()[i].ID,
                            EstadoDescricao = GET_SIMCARD.ToArray()[i].Descricao,  // ESTADO DO CARTÃO -ACTIVO OU EM STOCK
                            Numero = GET_SIMCARD.ToArray()[i].Numero,
                            Operadora = GET_SIMCARD.ToArray()[i].Operadora.Descricao,  // NOME Da OPERADORA
                            Puk_1 = GET_SIMCARD.ToArray()[i].Puk_1,
                            Puk_2 = GET_SIMCARD.ToArray()[i].Puk_2,
                            PinCode = GET_SIMCARD.ToArray()[i].PinCode,
                            DataUltimaRecarga =DateTime.Now,
                            ValorEmUTTs =125 
                        }
                            );
                    }


                }
                else
                {

                    //# Vamos processar a informação de modo a meter estes dados numa lista que será passada à vista
                    for (int i = 0; i < GET_REGRARGA.ToArray().Length; i++)
                    {

                        //#region Tratamento da informação do estado do cartão de Sim 
                        SimCard.Add(new ListaDeSimCard
                        {
                            ID = GET_REGRARGA.ToArray()[i].InfoSimCard.ID,
                            EstadoDescricao = GET_REGRARGA.ToArray()[i].Descricao,
                            Numero = GET_REGRARGA.ToArray()[i].InfoSimCard.Numero,
                            Operadora = GET_REGRARGA.ToArray()[i].InfoSimCard.Operadora.Descricao,
                            Puk_1 = GET_REGRARGA.ToArray()[i].InfoSimCard.Puk_1,
                            Puk_2 = GET_REGRARGA.ToArray()[i].InfoSimCard.Puk_2,
                            PinCode = GET_REGRARGA.ToArray()[i].InfoSimCard.PinCode,
                            DataUltimaRecarga = GET_REGRARGA.ToArray()[i].DataCompra,
                            ValorEmUTTs = GET_REGRARGA.ToArray()[i].UTT
                        }
                            );
                    }
                }

            }

            return View(SimCard);

          
    }
      # endregion

        #region NESTA ACTION VAMOS DEVOLVER O FORMULARIO DE INSERÇÃO DE NOVOS NÚMERO DE TELEFONE : METHOD GET AND POST

        [HttpGet]
        public ActionResult RegistarNumeroTelefone()
        {
            // NESTE CONTROLADOR VAMOS DEVOLVER O FORMULARIO DE INSERÇÃO DE NOVOS NÚMERO DE TELEFONE


            using (MyDbContext db= new MyDbContext())
            {

                var GETESTADOS = from items in db.Estados
                                 where items.ID>=0
                                 select new {items.ID,items.Descricao};

                ViewBag.OpcoesDeEstado = GETESTADOS.ToList();
            
            }

            return View();
        }

        [HttpPost]
        public ActionResult RegistarNumeroTelefone(RegistarSimCard model)
        {
            // Recebe as informações do novo número de telefone e guarda na BDA

            using (MyDbContext db = new MyDbContext())
            {
                InfoSimCard SimCard = new InfoSimCard();

                SimCard.DataDaCompra = model.DataDaCompra;
                SimCard.Numero = model.Numero;
                SimCard.Id_Operadora = model.Operadora;
                SimCard.PinCode = model.PinCode;
                SimCard.Puk_1 = model.Puk_1;
                SimCard.Puk_2 = model.Puk_2;
                SimCard.Id_Estado = model.Status_Referencia;

                db.InfoSimCards.Add(SimCard);
                db.SaveChanges();
            }

            return  RedirectToAction("NumerosDeTelefone");
        }

        #endregion

        #region ESTA ACTION É UMA PARTIALVIEW QUE PERMITE FAZER CONSULTAS AVANÇADAS SOBRE O SISTEMA DE GESTÃO DE SIM CARDS
        public PartialViewResult SimCardConsultas(int operacao)
        {
            //# NESTA ACTION VAMOS METER TODO O CÓDIGO QUE PERMITE FAZER UMA CONSULTA AVANÇADA AS 
            //# INFORMAÇÕES DOS SIMCARDS

            using (MyDbContext db =new MyDbContext())
            {

                List<ListaDeSimCard> SimCard = new List<ListaDeSimCard>();

                var GET_SIMCARD = from cards in db.InfoSimCards
                                  where cards.Id_Estado == operacao
                                      select new
                                      {
                                          cards.ID,
                                          cards.Numero,
                                          cards.Operadora,
                                          cards.PinCode,
                                          cards.Puk_1,
                                          cards.Puk_2,
                                          cards.Estado.Descricao
                                      };

                    for (int i = 0; i < GET_SIMCARD.ToArray().Length; i++)
                    {

                        SimCard.Add(new ListaDeSimCard
                        {
                            ID=GET_SIMCARD.ToArray()[i].ID,
                            EstadoDescricao = GET_SIMCARD.ToArray()[i].Descricao,  // ESTADO DO CARTÃO -ACTIVO OU EM STOCK
                            Numero = GET_SIMCARD.ToArray()[i].Numero,
                            Operadora = GET_SIMCARD.ToArray()[i].Operadora.Descricao,  // NOME DA OPERADORA
                            Puk_1 = GET_SIMCARD.ToArray()[i].Puk_1,
                            Puk_2 = GET_SIMCARD.ToArray()[i].Puk_2,
                            PinCode = GET_SIMCARD.ToArray()[i].PinCode,
                            DataUltimaRecarga = DateTime.Now,
                            ValorEmUTTs = 125
                        }
                             );
                    }

                    return PartialView(SimCard);
                }
        }
        #endregion

        #region NESTE ITEMS TEMOS DUAS ACTION QUE FAZEM A GESTÃO DA ACTUALIZAÇÃO DOS DADOS DO CARTÃO SIM

        [HttpGet]
        public ActionResult ActualizarSimCard(int id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var GET_SIMCARD = from cards in db.InfoSimCards
                                  where cards.ID == id
                                  select new
                                  {
                                      cards.Numero,
                                      cards.Operadora,
                                      cards.PinCode,
                                      cards.Puk_1,
                                      cards.Puk_2,
                                      cards.Estado.Descricao
                                  };

                ListaDeSimCard ActualizarSimCard = new ListaDeSimCard
                    {
                        EstadoDescricao     = GET_SIMCARD.ToArray()[0].Descricao, 
                        Numero              = GET_SIMCARD.ToArray()[0].Numero,
                        Operadora           = GET_SIMCARD.ToArray()[0].Operadora.Descricao, 
                        Puk_1               = GET_SIMCARD.ToArray()[0].Puk_1,
                        Puk_2               = GET_SIMCARD.ToArray()[0].Puk_2,
                        PinCode             = GET_SIMCARD.ToArray()[0].PinCode,
                        DataUltimaRecarga   = DateTime.Now,
                        ValorEmUTTs         = 125
                    };

                   return View(ActualizarSimCard);
            }
        }
      
        [HttpPost]
        public ActionResult ActualizarSimCard(ListaDeSimCard model)
        {
            using (MyDbContext db =new MyDbContext())
            {
                var ActualizarSimCard = db.InfoSimCards.FirstOrDefault(a=>a.ID==model.ID);

                ActualizarSimCard.Id_Estado = model.Estado;
                ActualizarSimCard.PinCode = model.PinCode;

                ActualizarSimCard.Puk_1 = model.Puk_1;
                ActualizarSimCard.Puk_2 = model.Puk_2;

                db.SaveChanges();
            }

            return RedirectToAction("NumerosDeTelefone");
        }

        #endregion

        #region Gestão de Recargas Via Remota

        [HttpGet]
        public ActionResult RecargaRemotas(int id)
        {
            // Mostra a vista que permite ao ulizador introduzir os dados da recarga

            RecargaSimCardcs model = new RecargaSimCardcs();

            // Vai a base de dados e selecciona o ID do SIM CARD através do Número de telefone

            return View();
        }

        [HttpPost]
        public ActionResult RecargaRemotas(RecargaSimCardcs model)
        {
            // Recebe a informação e guarda na BDA
            
            return RedirectToAction("NumerosDeTelefone");
        }

        #endregion 

        #region Registar Técnicos no Sistema

        [HttpGet]
        public ActionResult RegistarFuncionarios()
        {
            // Mostra a vista que permite registar um novo funcionario no sistema
            return View();
        }

        [HttpPost]
        public ActionResult RegistarFuncionarios(RegistarFuncionario model)
        {
            // Recebe a informação do novo funcionario e regista na base de dados do sistema

            using (MyDbContext db = new MyDbContext())
            {
                //Funcionario FuncionarioTecnico = new Funcionario();

                //FuncionarioTecnico.Email = model.Email;
                //FuncionarioTecnico.Nome = model.Nome;
                //FuncionarioTecnico.Apelido = model.Apelido;
                //FuncionarioTecnico.NumeroDeBI = model.NumeroDeBI;
                //FuncionarioTecnico.Telefone_fixo = model.Telefone_fixo;
                //FuncionarioTecnico.Telemove_1 = model.Telemove_1;
                //FuncionarioTecnico.Telemovel_2 = model.Telemovel_2;
                //FuncionarioTecnico.Categoria.ID = model.Categoria_Id_Referencia;
                //FuncionarioTecnico.Especialidade.ID = model.Especialidade_Id_Referencia;

                //db.Funcionarios.Add(FuncionarioTecnico);
                //db.SaveChanges();
            }
            return RedirectToAction("NumerosDeTelefone");
        }

        #endregion

    }
}

