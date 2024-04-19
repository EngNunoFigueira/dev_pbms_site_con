using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBMS_beta3A.Model;
using PBMS_beta3A.dbModel;


namespace PBMS_beta3A.Controllers
{
    public class GestaoListaGerawayController : Controller
    {
   
        [HttpGet]
        public ActionResult IndexGestaoListaGeraway()
        {
            #region Gestão do Geraway : LISTA TODOS OS EQUIPAMENTOS QUE ESTÃO EM STOCK

            using (MyDbContext db = new MyDbContext())
            {

                List<_Geraway> EquipamentoGeraway = new List<_Geraway>();

                var GET_Geraway = from items in db.Geraways
                                  where items.Id_Estado == 1
                                  select new
                                  {
                                      items.ID,
                                      items.modelo,
                                      items.firmware_version,
                                      items.serial_number,
                                      items.part_number,
                                      items.n_sensore_I,
                                      items.n_sensores_F,
                                      items.n_sensores_N,
                                      items.n_sensores_P,
                                      items.n_sensores_T,
                                      items.n_sensores_V,
                                      items.tipo_M_T_B,
                                      items.PCB_version,
                                      items.Estado.Descricao
                                  };

                GET_Geraway.ToList();

                for (int i = 0; i < GET_Geraway.ToArray().Length; i++)
                {
                    EquipamentoGeraway.Add(new _Geraway
                    {
                        ID = GET_Geraway.ToArray()[i].ID,
                        modelo = GET_Geraway.ToArray()[i].modelo,
                        firmware_version = GET_Geraway.ToArray()[i].firmware_version,
                        serial_number = GET_Geraway.ToArray()[i].serial_number,
                        part_number = GET_Geraway.ToArray()[i].part_number,
                        n_sensore_I = GET_Geraway.ToArray()[i].n_sensore_I,
                        n_sensores_V = GET_Geraway.ToArray()[i].n_sensores_V,
                        n_sensores_P = GET_Geraway.ToArray()[i].n_sensores_P,
                        n_sensores_T = GET_Geraway.ToArray()[i].n_sensores_T,
                        n_sensores_F = GET_Geraway.ToArray()[i].n_sensores_F,
                        n_sensores_N = GET_Geraway.ToArray()[i].n_sensores_N,
                        tipo_M_T_B = GET_Geraway.ToArray()[i].tipo_M_T_B,
                        PCB_version = GET_Geraway.ToArray()[i].PCB_version,
                        DescricaoDoEstado = GET_Geraway.ToArray()[i].Descricao

                    });
                }

                  return View(EquipamentoGeraway);
            }

            #endregion
        }

        [HttpGet]
        public PartialViewResult ConsultaGerawayInfo(int operacao)
        {

            #region ESTA ACTION PERMITE FAZER CONSULTAS AVANÇADAS A BASE DE DADOS
            using (MyDbContext db = new MyDbContext())
            {

                List<_Geraway> EquipamentoGeraway = new List <_Geraway>();

                 var GET_Geraway  = from items in db.Geraways
                                    where items.Id_Estado == operacao
                                  select new
                                  {
                                          items.ID,
                                          items.modelo,
                                          items.firmware_version,
                                          items.serial_number,
                                          items.part_number,
                                          items.n_sensore_I,
                                          items.n_sensores_F,
                                          items.n_sensores_N,
                                          items.n_sensores_P,
                                          items.n_sensores_T,
                                          items.n_sensores_V,
                                          items.tipo_M_T_B,
                                          items.PCB_version,          
                                          items.Estado.Descricao
                                  };  

                 GET_Geraway.ToList();

                for(int i=0;i< GET_Geraway.ToArray().Length;i++)
                {
                    EquipamentoGeraway.Add(new _Geraway
                    { 
                        ID                       = GET_Geraway.ToArray()[i].ID,
                        modelo                   = GET_Geraway.ToArray()[i].modelo,
                        firmware_version         = GET_Geraway.ToArray()[i].firmware_version,
                        serial_number            = GET_Geraway.ToArray()[i].serial_number,
                        part_number              = GET_Geraway.ToArray()[i].part_number,
                        n_sensore_I              = GET_Geraway.ToArray()[i].n_sensore_I,
                        n_sensores_V             = GET_Geraway.ToArray()[i].n_sensores_V,
                        n_sensores_P             = GET_Geraway.ToArray()[i].n_sensores_P,
                        n_sensores_T             = GET_Geraway.ToArray()[i].n_sensores_T,
                        n_sensores_F             = GET_Geraway.ToArray()[i].n_sensores_F,
                        n_sensores_N             = GET_Geraway.ToArray()[i].n_sensores_N,
                        tipo_M_T_B               = GET_Geraway.ToArray()[i].tipo_M_T_B,
                        PCB_version              = GET_Geraway.ToArray()[i].PCB_version,
                        DescricaoDoEstado        = GET_Geraway.ToArray()[i].Descricao
                    
                    });
                }

                return PartialView(EquipamentoGeraway);
            }
            #endregion
        }

        [HttpGet]
        public ActionResult InserirNovoGeraway()
        {
            #region  ESTA ACTION DEVOLVE A VISTA QUE PERMITE FAZER A INSCRIÇÃO DE UM NOVO GERAWAY
              return View();
             #endregion   
        }

        [HttpPost]
        public ActionResult InserirNovoGeraway(_Geraway model)
        {
            #region ESTA ACTION RECEBE OS DADOS DO NOVO GERAWAY E GUARDA NA BASE DE DADOS

            Geraway NovoGeraway = new Geraway();

            NovoGeraway.ID = model.ID;
            NovoGeraway.n_sensore_I = model.n_sensore_I;
            NovoGeraway.n_sensores_V = model.n_sensores_V;
            NovoGeraway.n_sensores_T = model.n_sensores_T;
            NovoGeraway.n_sensores_P = model.n_sensores_P;
            NovoGeraway.n_sensores_F = model.n_sensores_F;
            NovoGeraway.n_sensores_N = model.n_sensores_N;

            NovoGeraway.Id_Estado = model.Estado;
            NovoGeraway.modelo = model.modelo;
            NovoGeraway.tipo_M_T_B = model.tipo_M_T_B;
            NovoGeraway.PCB_version = model.PCB_version;
            NovoGeraway.serial_number = model.serial_number;
            NovoGeraway.part_number = model.part_number;
            NovoGeraway.firmware_version = model.firmware_version;

            using (MyDbContext db = new MyDbContext())
            {
                db.Geraways.Add(NovoGeraway);
                db.SaveChanges();
            }


            return RedirectToAction("IndexGestaoListaGeraway");

            #endregion
        }  

        [HttpGet]
        public ActionResult EditarGeraway(Int32 id)
        {
            #region ESTA ACTION PERMITE FAZER ACTUALIZAÇÕES AOS GERAWAYS REGISTADOS
            // Recebe o serial number do Geraway que será actualizado e vai a BDA carregar as informações do equipamento.
            // Mostra os dados do equipamento ao utilizador de modo a perceber quais os dados que devemos alterados......
            

            using (MyDbContext db=new MyDbContext())
            {
                var GET_GERAWAY_PARA_CATUALIZAR = from items in db.Geraways
                                                  where items.ID == id
                                                  select new 
                                                  {
                                                      items.ID,
                                                      items.modelo,
                                                      items.Estado,
                                                      items.tipo_M_T_B,
                                                      items.n_sensore_I,
                                                      items.n_sensores_F,
                                                      items.n_sensores_V,
                                                      items.n_sensores_T,
                                                      items.n_sensores_N,
                                                      items.n_sensores_P,
                                                      items.PCB_version,
                                                      items.serial_number,
                                                      items.part_number,
                                                      items.firmware_version
                                                  };

                GET_GERAWAY_PARA_CATUALIZAR.ToArray();

                _Geraway GPActualizar = new _Geraway
                { 
                    ID                     = GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].ID,
                    modelo                 =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].modelo,
                    firmware_version       = GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].firmware_version,
                    serial_number          = GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].serial_number,
                    part_number            =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].part_number,
	                n_sensore_I            =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].n_sensore_I,
                    n_sensores_V           =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].n_sensores_V,
                    n_sensores_P           =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].n_sensores_P,
                    n_sensores_T           =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].n_sensores_T,
                    n_sensores_F           =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].n_sensores_F,
                    n_sensores_N           =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].n_sensores_N,
                    tipo_M_T_B             =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].tipo_M_T_B,
                    PCB_version            =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].PCB_version,
                    Estado                 =GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].Estado.ID,
                    DescricaoDoEstado     = GET_GERAWAY_PARA_CATUALIZAR.ToArray()[0].Estado.Descricao
                };

                return View(GPActualizar);
            }

              

            #endregion
        }

        [HttpPost]
        public ActionResult EditarGeraway(_Geraway model)
        {
              #region ESTA ACTION PERMITE EDITAR OS PARÂMETROS DO GERAWAY
            // Recebe o novo Geraway com as alterações feitas e salva na base de dados do sistema...............
            // Volta a lista inicial onde apresenta-se todos os Geraway de modo a exibir o resultado da operação.

            using (MyDbContext db = new MyDbContext())
            {
                var GRW_Actualizado = db.Geraways.FirstOrDefault(a => a.ID == model.ID);

                    GRW_Actualizado.Id_Estado           = model.Estado;
                    GRW_Actualizado.firmware_version    = model.firmware_version;
                    GRW_Actualizado.PCB_version         = model.PCB_version;

                    GRW_Actualizado.n_sensore_I         = model.n_sensore_I;
                    GRW_Actualizado.n_sensores_V        = model.n_sensores_V;
                    GRW_Actualizado.n_sensores_T        = model.n_sensores_T;
                    GRW_Actualizado.n_sensores_P        = model.n_sensores_P;
                    GRW_Actualizado.n_sensores_N        = model.n_sensores_N;
                    GRW_Actualizado.n_sensores_F        = model.n_sensores_F;

                    db.SaveChanges();
            }

            return (RedirectToAction("IndexGestaoListaGeraway"));

             #endregion
        }
    }
}
