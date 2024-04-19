using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBMS_beta3A.Model;
using System.Threading;
using PBMS_beta3A.dbModel;


namespace PBMS_beta3A.Controllers
{
    public class GestaoDeGeradoresController : Controller
    {
        #region Mostra a Lista de Geradores

        [HttpGet]
        public ActionResult MostraListaDeGeradores()
        {
            // #MOSTRA A LISTA DE GERADORES EM STOCK
            using (MyDbContext db = new MyDbContext())
            {
                var GetGerador = from items in db.Geradors
                                 where items.ID >= 1 
                                 where items.Id_Estado== 1 // Código dos geradores em Stock
                                 select new
                                 {
                                     items.ID,
                                     items.modelo,
                                     items.marca,
                                     items.fabricante,
                                     items.potencia_KVA,
                                     items.n_fases,
                                     items.ano_fabrico,
                                     items.capacidade_LTR,
                                     items.dimensao_kg,
                                     items.dimensao_H,
                                     items.dimensao_L,
                                     items.dimensao_C,
                                     items.incorpora_can,
                                     items.incorpora_gsm,
                                     items.incorpora_modbus,
                                     items.bateria_v,
                                     items.tipo_arranque,
                                     items.programacao_local,
                                     items.RuidoEmDb,
                                     items.geradortipoCombustivel,
                                     items.HorasDeFuncionamento,
                                     items.GeradorPrecoCompra,
                                     items.Estado
                                 };

                GetGerador.ToList();


                List<GeradorElectrico> Gmodel = new List<GeradorElectrico>();

                for (int i = 0; i < GetGerador.ToArray().Length;i++)
                {
                    //#Dentro deste for vamos guaradar os valores listados para devolver a vista

                    Gmodel.Add(new GeradorElectrico 
                    {
                        ID=GetGerador.ToArray()[i].ID,                           
                        RuidoEmDb=GetGerador.ToArray()[i].RuidoEmDb,               
                        CapacidadeEmLitros=GetGerador.ToArray()[i].capacidade_LTR,          
                        HorasDeFuncionamento=GetGerador.ToArray()[i].HorasDeFuncionamento,         
                       // TipoControladorRemoto=GetGerador.ToArray()[i].,       
                        GeradorModelo=GetGerador.ToArray()[i].modelo,                
                        GeradorFabricante=GetGerador.ToArray()[i].fabricante,           
                        GeradorPotenciaKVA=GetGerador.ToArray()[i].potencia_KVA,          
                        GeradorAnoDeFabrico=GetGerador.ToArray()[i].ano_fabrico,         
                        GeradorNumeroDeFases=GetGerador.ToArray()[i].n_fases,         
                        GeradorPrecoCompra=GetGerador.ToArray()[i].ID,           
                       // GeradorDataCompra=GetGerador.ToArray()[i].,          
                       // GeradorDistribuidor=GetGerador.ToArray()[i].,
                        GeradorProtocoloCAN = GetGerador.ToArray()[i].incorpora_can,
                        GeradorProtocoloModbus = GetGerador.ToArray()[i].incorpora_modbus,
                        GeradorTipoCombustivel = GetGerador.ToArray()[i].geradortipoCombustivel,
                        Marca = GetGerador.ToArray()[i].marca,
                        GeradorIncorporaGSM = GetGerador.ToArray()[i].incorpora_gsm,
                        GeradorprogramadorLocal = GetGerador.ToArray()[i].programacao_local,
                        GeradorTipoDeArranque = GetGerador.ToArray()[i].tipo_arranque,
                        GeradorBateria = GetGerador.ToArray()[i].bateria_v,
                        Dimensao_kg = GetGerador.ToArray()[i].dimensao_kg,
                        Dimensao_H = GetGerador.ToArray()[i].dimensao_H,
                        Dimensao_L = GetGerador.ToArray()[i].dimensao_L,
                        Dimensao_C = GetGerador.ToArray()[i].dimensao_C,
                        //Status = GetGerador.ToArray()[i].Estado     
                    }
                        );

                }

                return View(Gmodel);
            }
        }

        // #Mostra A LSITA DE GERADORES ATRAVÉS DOS SEGUINTES FILTRO: ABATIDOS, EM REPAÇAO, INSTALADOS...
        [HttpGet]
        public PartialViewResult EstadoDoGerador(int operacao)
        {

            List<GeradorElectrico> GetGeradorInfo = new List<GeradorElectrico>();


            using (MyDbContext db = new MyDbContext())
            {
                var GeradorAbatidos = from items in db.Geradors
                                      where items.Id_Estado == operacao 
                                      select new
                                      {
                                          items.ID,
                                          items.modelo,
                                          items.marca,
                                          items.fabricante,
                                          items.potencia_KVA,
                                          items.n_fases,
                                          items.ano_fabrico,
                                          items.capacidade_LTR,
                                          items.dimensao_kg,
                                          items.dimensao_H,
                                          items.dimensao_L,
                                          items.dimensao_C,
                                          items.incorpora_can,
                                          items.incorpora_gsm,
                                          items.incorpora_modbus,
                                          items.bateria_v,
                                          items.tipo_arranque,
                                          items.programacao_local,
                                          items.RuidoEmDb,
                                          items.geradortipoCombustivel,
                                          items.HorasDeFuncionamento,
                                          items.GeradorPrecoCompra,
                                          items.Estado
                                      };

                for (int i = 0; i < GeradorAbatidos.ToArray().Length; i++)
                {
                    //#Dentro deste for vamos guaradar os valores lidos para devolver a vista

                    GetGeradorInfo.Add(new GeradorElectrico
                    {
                        ID = GeradorAbatidos.ToArray()[i].ID,
                        RuidoEmDb = GeradorAbatidos.ToArray()[i].RuidoEmDb,
                        CapacidadeEmLitros = GeradorAbatidos.ToArray()[i].capacidade_LTR,
                        HorasDeFuncionamento = GeradorAbatidos.ToArray()[i].HorasDeFuncionamento,
                        // TipoControladorRemoto=GetGerador.ToArray()[i].,       
                        GeradorModelo = GeradorAbatidos.ToArray()[i].modelo,
                        GeradorFabricante = GeradorAbatidos.ToArray()[i].fabricante,
                        GeradorPotenciaKVA = GeradorAbatidos.ToArray()[i].potencia_KVA,
                        GeradorAnoDeFabrico = GeradorAbatidos.ToArray()[i].ano_fabrico,
                        GeradorNumeroDeFases = GeradorAbatidos.ToArray()[i].n_fases,
                        GeradorPrecoCompra = GeradorAbatidos.ToArray()[i].ID,
                        // GeradorDataCompra=GetGerador.ToArray()[i].,          
                        // GeradorDistribuidor=GetGerador.ToArray()[i].,
                        GeradorProtocoloCAN = GeradorAbatidos.ToArray()[i].incorpora_can,
                        GeradorProtocoloModbus = GeradorAbatidos.ToArray()[i].incorpora_modbus,
                        GeradorTipoCombustivel = GeradorAbatidos.ToArray()[i].geradortipoCombustivel,
                        Marca = GeradorAbatidos.ToArray()[i].marca,
                        GeradorIncorporaGSM = GeradorAbatidos.ToArray()[i].incorpora_gsm,
                        GeradorprogramadorLocal = GeradorAbatidos.ToArray()[i].programacao_local,
                        GeradorTipoDeArranque = GeradorAbatidos.ToArray()[i].tipo_arranque,
                        GeradorBateria = GeradorAbatidos.ToArray()[i].bateria_v,
                        Dimensao_kg = GeradorAbatidos.ToArray()[i].dimensao_kg,
                        Dimensao_H = GeradorAbatidos.ToArray()[i].dimensao_H,
                        Dimensao_L = GeradorAbatidos.ToArray()[i].dimensao_L,
                        Dimensao_C = GeradorAbatidos.ToArray()[i].dimensao_C
                        // Status = GeradorAbatidos.ToArray()[i].Estado
                    }
                        );

                }

                return PartialView(GetGeradorInfo);
            }

            //switch (operacao)
            //{
            //    #region MOSTRA A LISTA DE GERADORES ABATIDOS
            //    case 1:
            //        break;
            //    #endregion 

            //    #region MOSTRA A LISTA DE GERADORES AVARIADOS
            //    case "Avariados":

            //        using (MyDbContext db = new MyDbContext())
            //        {
            //            var GeradorAbatidos = from items in db.Geradors
            //                                  where items.Id_Estado == 5 //  // Indica que o gerador está Avariado
            //                                  select new
            //                                  {
            //                                      items.ID,
            //                                      items.modelo,
            //                                      items.marca,
            //                                      items.fabricante,
            //                                      items.potencia_KVA,
            //                                      items.n_fases,
            //                                      items.ano_fabrico,
            //                                      items.capacidade_LTR,
            //                                      items.dimensao_kg,
            //                                      items.dimensao_H,
            //                                      items.dimensao_L,
            //                                      items.dimensao_C,
            //                                      items.incorpora_can,
            //                                      items.incorpora_gsm,
            //                                      items.incorpora_modbus,
            //                                      items.bateria_v,
            //                                      items.tipo_arranque,
            //                                      items.programacao_local,
            //                                      items.RuidoEmDb,
            //                                      items.geradortipoCombustivel,
            //                                      items.HorasDeFuncionamento,
            //                                      items.GeradorPrecoCompra,
            //                                      items.Estado
            //                                  };

            //            for (int i = 0; i < GeradorAbatidos.ToArray().Length; i++)
            //            {
            //                //#Dentro deste for vamos guaradar os valores lidos para devolver a vista

            //                GetGeradorInfo.Add(new GeradorElectrico
            //                {
            //                    ID = GeradorAbatidos.ToArray()[i].ID,
            //                    RuidoEmDb = GeradorAbatidos.ToArray()[i].RuidoEmDb,
            //                    CapacidadeEmLitros = GeradorAbatidos.ToArray()[i].capacidade_LTR,
            //                    HorasDeFuncionamento = GeradorAbatidos.ToArray()[i].HorasDeFuncionamento,
            //                    // TipoControladorRemoto=GetGerador.ToArray()[i].,       
            //                    GeradorModelo = GeradorAbatidos.ToArray()[i].modelo,
            //                    GeradorFabricante = GeradorAbatidos.ToArray()[i].fabricante,
            //                    GeradorPotenciaKVA = GeradorAbatidos.ToArray()[i].potencia_KVA,
            //                    GeradorAnoDeFabrico = GeradorAbatidos.ToArray()[i].ano_fabrico,
            //                    GeradorNumeroDeFases = GeradorAbatidos.ToArray()[i].n_fases,
            //                    GeradorPrecoCompra = GeradorAbatidos.ToArray()[i].ID,
            //                    // GeradorDataCompra=GetGerador.ToArray()[i].,          
            //                    // GeradorDistribuidor=GetGerador.ToArray()[i].,
            //                    GeradorProtocoloCAN = GeradorAbatidos.ToArray()[i].incorpora_can,
            //                    GeradorProtocoloModbus = GeradorAbatidos.ToArray()[i].incorpora_modbus,
            //                    GeradorTipoCombustivel = GeradorAbatidos.ToArray()[i].geradortipoCombustivel,
            //                    Marca = GeradorAbatidos.ToArray()[i].marca,
            //                    GeradorIncorporaGSM = GeradorAbatidos.ToArray()[i].incorpora_gsm,
            //                    GeradorprogramadorLocal = GeradorAbatidos.ToArray()[i].programacao_local,
            //                    GeradorTipoDeArranque = GeradorAbatidos.ToArray()[i].tipo_arranque,
            //                    GeradorBateria = GeradorAbatidos.ToArray()[i].bateria_v,
            //                    Dimensao_kg = GeradorAbatidos.ToArray()[i].dimensao_kg,
            //                    Dimensao_H = GeradorAbatidos.ToArray()[i].dimensao_H,
            //                    Dimensao_L = GeradorAbatidos.ToArray()[i].dimensao_L,
            //                    Dimensao_C = GeradorAbatidos.ToArray()[i].dimensao_C
            //                   // Status = GeradorAbatidos.ToArray()[i].Estado
            //                }
            //                    );

            //            }

            //        }

            //        break;
            //    #endregion

            //    #region MOSTRA A LISTA DE GERADORES INSTALADOS
            //    case "Instalados":
            //        using (MyDbContext db = new MyDbContext())
            //        {
            //            var GeradorAbatidos = from items in db.Geradors
            //                                  where items.Id_Estado == 2  // Indica que o gerador está instalado
            //                                  select new
            //                                  {
            //                                      items.ID,
            //                                      items.modelo,
            //                                      items.marca,
            //                                      items.fabricante,
            //                                      items.potencia_KVA,
            //                                      items.n_fases,
            //                                      items.ano_fabrico,
            //                                      items.capacidade_LTR,
            //                                      items.dimensao_kg,
            //                                      items.dimensao_H,
            //                                      items.dimensao_L,
            //                                      items.dimensao_C,
            //                                      items.incorpora_can,
            //                                      items.incorpora_gsm,
            //                                      items.incorpora_modbus,
            //                                      items.bateria_v,
            //                                      items.tipo_arranque,
            //                                      items.programacao_local,
            //                                      items.RuidoEmDb,
            //                                      items.geradortipoCombustivel,
            //                                      items.HorasDeFuncionamento,
            //                                      items.GeradorPrecoCompra,
            //                                      items.Estado
            //                                  };

            //            for (int i = 0; i < GeradorAbatidos.ToArray().Length; i++)
            //            {
            //                //#Dentro deste for vamos guaradar os valores lidos para devolver a vista

            //                GetGeradorInfo.Add(new GeradorElectrico
            //                {
            //                    ID = GeradorAbatidos.ToArray()[i].ID,
            //                    RuidoEmDb = GeradorAbatidos.ToArray()[i].RuidoEmDb,
            //                    CapacidadeEmLitros = GeradorAbatidos.ToArray()[i].capacidade_LTR,
            //                    HorasDeFuncionamento = GeradorAbatidos.ToArray()[i].HorasDeFuncionamento,
            //                    // TipoControladorRemoto=GetGerador.ToArray()[i].,       
            //                    GeradorModelo = GeradorAbatidos.ToArray()[i].modelo,
            //                    GeradorFabricante = GeradorAbatidos.ToArray()[i].fabricante,
            //                    GeradorPotenciaKVA = GeradorAbatidos.ToArray()[i].potencia_KVA,
            //                    GeradorAnoDeFabrico = GeradorAbatidos.ToArray()[i].ano_fabrico,
            //                    GeradorNumeroDeFases = GeradorAbatidos.ToArray()[i].n_fases,
            //                    GeradorPrecoCompra = GeradorAbatidos.ToArray()[i].ID,
            //                    // GeradorDataCompra=GetGerador.ToArray()[i].,          
            //                    // GeradorDistribuidor=GetGerador.ToArray()[i].,
            //                    GeradorProtocoloCAN = GeradorAbatidos.ToArray()[i].incorpora_can,
            //                    GeradorProtocoloModbus = GeradorAbatidos.ToArray()[i].incorpora_modbus,
            //                    GeradorTipoCombustivel = GeradorAbatidos.ToArray()[i].geradortipoCombustivel,
            //                    Marca = GeradorAbatidos.ToArray()[i].marca,
            //                    GeradorIncorporaGSM = GeradorAbatidos.ToArray()[i].incorpora_gsm,
            //                    GeradorprogramadorLocal = GeradorAbatidos.ToArray()[i].programacao_local,
            //                    GeradorTipoDeArranque = GeradorAbatidos.ToArray()[i].tipo_arranque,
            //                    GeradorBateria = GeradorAbatidos.ToArray()[i].bateria_v,
            //                    Dimensao_kg = GeradorAbatidos.ToArray()[i].dimensao_kg,
            //                    Dimensao_H = GeradorAbatidos.ToArray()[i].dimensao_H,
            //                    Dimensao_L = GeradorAbatidos.ToArray()[i].dimensao_L,
            //                    Dimensao_C = GeradorAbatidos.ToArray()[i].dimensao_C
            //                   // Status = GeradorAbatidos.ToArray()[i].Estado
            //                }
            //                    );

            //            }

            //        }
            //        //return PartialView(Teste);
            //        break;
            //    #endregion

            //    #region MOSTRA A LISTA DE GERADORES EM MANUTENCAO
            //    case "Avenda":
            //        using (MyDbContext db = new MyDbContext())
            //        {
            //            var GeradorAbatidos = from items in db.Geradors
            //                                  where items.Id_Estado == 5// A venda
            //                                  select new
            //                                  {
            //                                      items.ID,
            //                                      items.modelo,
            //                                      items.marca,
            //                                      items.fabricante,
            //                                      items.potencia_KVA,
            //                                      items.n_fases,
            //                                      items.ano_fabrico,
            //                                      items.capacidade_LTR,
            //                                      items.dimensao_kg,
            //                                      items.dimensao_H,
            //                                      items.dimensao_L,
            //                                      items.dimensao_C,
            //                                      items.incorpora_can,
            //                                      items.incorpora_gsm,
            //                                      items.incorpora_modbus,
            //                                      items.bateria_v,
            //                                      items.tipo_arranque,
            //                                      items.programacao_local,
            //                                      items.RuidoEmDb,
            //                                      items.geradortipoCombustivel,
            //                                      items.HorasDeFuncionamento,
            //                                      items.GeradorPrecoCompra
            //                                      //items.Estado
            //                                  };

            //            for (int i = 0; i < GeradorAbatidos.ToArray().Length; i++)
            //            {
            //                //#Dentro deste for vamos guaradar os valores lidos para devolver a vista

            //                GetGeradorInfo.Add(new GeradorElectrico
            //                {
            //                    ID = GeradorAbatidos.ToArray()[i].ID,
            //                    RuidoEmDb = GeradorAbatidos.ToArray()[i].RuidoEmDb,
            //                    CapacidadeEmLitros = GeradorAbatidos.ToArray()[i].capacidade_LTR,
            //                    HorasDeFuncionamento = GeradorAbatidos.ToArray()[i].HorasDeFuncionamento,
            //                    // TipoControladorRemoto=GetGerador.ToArray()[i].,       
            //                    GeradorModelo = GeradorAbatidos.ToArray()[i].modelo,
            //                    GeradorFabricante = GeradorAbatidos.ToArray()[i].fabricante,
            //                    GeradorPotenciaKVA = GeradorAbatidos.ToArray()[i].potencia_KVA,
            //                    GeradorAnoDeFabrico = GeradorAbatidos.ToArray()[i].ano_fabrico,
            //                    GeradorNumeroDeFases = GeradorAbatidos.ToArray()[i].n_fases,
            //                    GeradorPrecoCompra = GeradorAbatidos.ToArray()[i].ID,
            //                    // GeradorDataCompra=GetGerador.ToArray()[i].,          
            //                    // GeradorDistribuidor=GetGerador.ToArray()[i].,
            //                    GeradorProtocoloCAN = GeradorAbatidos.ToArray()[i].incorpora_can,
            //                    GeradorProtocoloModbus = GeradorAbatidos.ToArray()[i].incorpora_modbus,
            //                    GeradorTipoCombustivel = GeradorAbatidos.ToArray()[i].geradortipoCombustivel,
            //                    Marca = GeradorAbatidos.ToArray()[i].marca,
            //                    GeradorIncorporaGSM = GeradorAbatidos.ToArray()[i].incorpora_gsm,
            //                    GeradorprogramadorLocal = GeradorAbatidos.ToArray()[i].programacao_local,
            //                    GeradorTipoDeArranque = GeradorAbatidos.ToArray()[i].tipo_arranque,
            //                    GeradorBateria = GeradorAbatidos.ToArray()[i].bateria_v,
            //                    Dimensao_kg = GeradorAbatidos.ToArray()[i].dimensao_kg,
            //                    Dimensao_H = GeradorAbatidos.ToArray()[i].dimensao_H,
            //                    Dimensao_L = GeradorAbatidos.ToArray()[i].dimensao_L,
            //                    Dimensao_C = GeradorAbatidos.ToArray()[i].dimensao_C
            //                   // Status = GeradorAbatidos.ToArray()[i].Estado
            //                }
            //                    );

            //            }
            //        }
            //        break;
            //    #endregion

            //    #region MOSTRA A LISTA DE GERADORES PERDIDOS 
            //    case "Roubados":
            //        using (MyDbContext db = new MyDbContext())
            //        {
            //            var GeradorAbatidos = from items in db.Geradors
            //                                  where items.Id_Estado == 13  // Indica que o gerador foi roubado
            //                                  select new
            //                                  {
            //                                      items.ID,
            //                                      items.modelo,
            //                                      items.marca,
            //                                      items.fabricante,
            //                                      items.potencia_KVA,
            //                                      items.n_fases,
            //                                      items.ano_fabrico,
            //                                      items.capacidade_LTR,
            //                                      items.dimensao_kg,
            //                                      items.dimensao_H,
            //                                      items.dimensao_L,
            //                                      items.dimensao_C,
            //                                      items.incorpora_can,
            //                                      items.incorpora_gsm,
            //                                      items.incorpora_modbus,
            //                                      items.bateria_v,
            //                                      items.tipo_arranque,
            //                                      items.programacao_local,
            //                                      items.RuidoEmDb,
            //                                      items.geradortipoCombustivel,
            //                                      items.HorasDeFuncionamento,
            //                                      items.GeradorPrecoCompra
            //                                     // items.Status
            //                                  };

            //            for (int i = 0; i < GeradorAbatidos.ToArray().Length; i++)
            //            {
            //                //#Dentro deste for vamos guaradar os valores lidos para devolver a vista

            //                GetGeradorInfo.Add(new GeradorElectrico
            //                {
            //                    ID = GeradorAbatidos.ToArray()[i].ID,
            //                    RuidoEmDb = GeradorAbatidos.ToArray()[i].RuidoEmDb,
            //                    CapacidadeEmLitros = GeradorAbatidos.ToArray()[i].capacidade_LTR,
            //                    HorasDeFuncionamento = GeradorAbatidos.ToArray()[i].HorasDeFuncionamento,
            //                    // TipoControladorRemoto=GetGerador.ToArray()[i].,       
            //                    GeradorModelo = GeradorAbatidos.ToArray()[i].modelo,
            //                    GeradorFabricante = GeradorAbatidos.ToArray()[i].fabricante,
            //                    GeradorPotenciaKVA = GeradorAbatidos.ToArray()[i].potencia_KVA,
            //                    GeradorAnoDeFabrico = GeradorAbatidos.ToArray()[i].ano_fabrico,
            //                    GeradorNumeroDeFases = GeradorAbatidos.ToArray()[i].n_fases,
            //                    GeradorPrecoCompra = GeradorAbatidos.ToArray()[i].ID,
            //                    // GeradorDataCompra=GetGerador.ToArray()[i].,          
            //                    // GeradorDistribuidor=GetGerador.ToArray()[i].,
            //                    GeradorProtocoloCAN = GeradorAbatidos.ToArray()[i].incorpora_can,
            //                    GeradorProtocoloModbus = GeradorAbatidos.ToArray()[i].incorpora_modbus,
            //                    GeradorTipoCombustivel = GeradorAbatidos.ToArray()[i].geradortipoCombustivel,
            //                    Marca = GeradorAbatidos.ToArray()[i].marca,
            //                    GeradorIncorporaGSM = GeradorAbatidos.ToArray()[i].incorpora_gsm,
            //                    GeradorprogramadorLocal = GeradorAbatidos.ToArray()[i].programacao_local,
            //                    GeradorTipoDeArranque = GeradorAbatidos.ToArray()[i].tipo_arranque,
            //                    GeradorBateria = GeradorAbatidos.ToArray()[i].bateria_v,
            //                    Dimensao_kg = GeradorAbatidos.ToArray()[i].dimensao_kg,
            //                    Dimensao_H = GeradorAbatidos.ToArray()[i].dimensao_H,
            //                    Dimensao_L = GeradorAbatidos.ToArray()[i].dimensao_L,
            //                    Dimensao_C = GeradorAbatidos.ToArray()[i].dimensao_C
            //                   // Status = GeradorAbatidos.ToArray()[i].Status
            //                }
            //                    );

            //            }

            //        }
            //        break;
            //    #endregion

            //    #region MOSTRA A LISTA DE GERADORES A VENDA
            //    case "Avenida" :
            //        using (MyDbContext db = new MyDbContext())
            //        {
            //            var GeradorAbatidos = from items in db.Geradors
            //                                  where items.Id_Estado == 7  //Indica que o gerador está a Venda
            //                                  select new
            //                                  {
            //                                      items.ID,
            //                                      items.modelo,
            //                                      items.marca,
            //                                      items.fabricante,
            //                                      items.potencia_KVA,
            //                                      items.n_fases,
            //                                      items.ano_fabrico,
            //                                      items.capacidade_LTR,
            //                                      items.dimensao_kg,
            //                                      items.dimensao_H,
            //                                      items.dimensao_L,
            //                                      items.dimensao_C,
            //                                      items.incorpora_can,
            //                                      items.incorpora_gsm,
            //                                      items.incorpora_modbus,
            //                                      items.bateria_v,
            //                                      items.tipo_arranque,
            //                                      items.programacao_local,
            //                                      items.RuidoEmDb,
            //                                      items.geradortipoCombustivel,
            //                                      items.HorasDeFuncionamento,
            //                                      items.GeradorPrecoCompra
            //                                      //items.Status
            //                                  };

            //            for (int i = 0; i < GeradorAbatidos.ToArray().Length; i++)
            //            {
            //                //#Dentro deste for vamos guaradar os valores lidos para devolver a vista

            //                GetGeradorInfo.Add(new GeradorElectrico
            //                {
            //                    ID = GeradorAbatidos.ToArray()[i].ID,
            //                    RuidoEmDb = GeradorAbatidos.ToArray()[i].RuidoEmDb,
            //                    CapacidadeEmLitros = GeradorAbatidos.ToArray()[i].capacidade_LTR,
            //                    HorasDeFuncionamento = GeradorAbatidos.ToArray()[i].HorasDeFuncionamento,
            //                    // TipoControladorRemoto=GetGerador.ToArray()[i].,       
            //                    GeradorModelo = GeradorAbatidos.ToArray()[i].modelo,
            //                    GeradorFabricante = GeradorAbatidos.ToArray()[i].fabricante,
            //                    GeradorPotenciaKVA = GeradorAbatidos.ToArray()[i].potencia_KVA,
            //                    GeradorAnoDeFabrico = GeradorAbatidos.ToArray()[i].ano_fabrico,
            //                    GeradorNumeroDeFases = GeradorAbatidos.ToArray()[i].n_fases,
            //                    GeradorPrecoCompra = GeradorAbatidos.ToArray()[i].ID,
            //                    // GeradorDataCompra=GetGerador.ToArray()[i].,          
            //                    // GeradorDistribuidor=GetGerador.ToArray()[i].,
            //                    GeradorProtocoloCAN = GeradorAbatidos.ToArray()[i].incorpora_can,
            //                    GeradorProtocoloModbus = GeradorAbatidos.ToArray()[i].incorpora_modbus,
            //                    GeradorTipoCombustivel = GeradorAbatidos.ToArray()[i].geradortipoCombustivel,
            //                    Marca = GeradorAbatidos.ToArray()[i].marca,
            //                    GeradorIncorporaGSM = GeradorAbatidos.ToArray()[i].incorpora_gsm,
            //                    GeradorprogramadorLocal = GeradorAbatidos.ToArray()[i].programacao_local,
            //                    GeradorTipoDeArranque = GeradorAbatidos.ToArray()[i].tipo_arranque,
            //                    GeradorBateria = GeradorAbatidos.ToArray()[i].bateria_v,
            //                    Dimensao_kg = GeradorAbatidos.ToArray()[i].dimensao_kg,
            //                    Dimensao_H = GeradorAbatidos.ToArray()[i].dimensao_H,
            //                    Dimensao_L = GeradorAbatidos.ToArray()[i].dimensao_L,
            //                    Dimensao_C = GeradorAbatidos.ToArray()[i].dimensao_C
            //                    //Status = GeradorAbatidos.ToArray()[i].Status
            //                    //Status="Stock"
            //                }
            //                    );
            //            }

            //        }
            //        break;
            //    #endregion

            //    #region MOSTRA A LISTA DE GERADORES COM PARTICULARES
            //    case "Particulares":
            //        using (MyDbContext db = new MyDbContext())
            //        {
            //            var GeradorAbatidos = from items in db.Geradors
            //                                  where items.Id_Estado == 9  // Indica que o gerador está com um particular
            //                                  select new
            //                                  {
            //                                      items.ID,
            //                                      items.modelo,
            //                                      items.marca,
            //                                      items.fabricante,
            //                                      items.potencia_KVA,
            //                                      items.n_fases,
            //                                      items.ano_fabrico,
            //                                      items.capacidade_LTR,
            //                                      items.dimensao_kg,
            //                                      items.dimensao_H,
            //                                      items.dimensao_L,
            //                                      items.dimensao_C,
            //                                      items.incorpora_can,
            //                                      items.incorpora_gsm,
            //                                      items.incorpora_modbus,
            //                                      items.bateria_v,
            //                                      items.tipo_arranque,
            //                                      items.programacao_local,
            //                                      items.RuidoEmDb,
            //                                      items.geradortipoCombustivel,
            //                                      items.HorasDeFuncionamento,
            //                                      items.GeradorPrecoCompra
            //                                      //items.Status
            //                                  };

            //            for (int i = 0; i < GeradorAbatidos.ToArray().Length; i++)
            //            {
            //                //#Dentro deste for vamos guaradar os valores lidos para devolver a vista

            //                GetGeradorInfo.Add(new GeradorElectrico
            //                {
            //                    ID = GeradorAbatidos.ToArray()[i].ID,
            //                    RuidoEmDb = GeradorAbatidos.ToArray()[i].RuidoEmDb,
            //                    CapacidadeEmLitros = GeradorAbatidos.ToArray()[i].capacidade_LTR,
            //                    HorasDeFuncionamento = GeradorAbatidos.ToArray()[i].HorasDeFuncionamento,
            //                    // TipoControladorRemoto=GetGerador.ToArray()[i].,       
            //                    GeradorModelo = GeradorAbatidos.ToArray()[i].modelo,
            //                    GeradorFabricante = GeradorAbatidos.ToArray()[i].fabricante,
            //                    GeradorPotenciaKVA = GeradorAbatidos.ToArray()[i].potencia_KVA,
            //                    GeradorAnoDeFabrico = GeradorAbatidos.ToArray()[i].ano_fabrico,
            //                    GeradorNumeroDeFases = GeradorAbatidos.ToArray()[i].n_fases,
            //                    GeradorPrecoCompra = GeradorAbatidos.ToArray()[i].ID,
            //                    // GeradorDataCompra=GetGerador.ToArray()[i].,          
            //                    // GeradorDistribuidor=GetGerador.ToArray()[i].,
            //                    GeradorProtocoloCAN = GeradorAbatidos.ToArray()[i].incorpora_can,
            //                    GeradorProtocoloModbus = GeradorAbatidos.ToArray()[i].incorpora_modbus,
            //                    GeradorTipoCombustivel = GeradorAbatidos.ToArray()[i].geradortipoCombustivel,
            //                    Marca = GeradorAbatidos.ToArray()[i].marca,
            //                    GeradorIncorporaGSM = GeradorAbatidos.ToArray()[i].incorpora_gsm,
            //                    GeradorprogramadorLocal = GeradorAbatidos.ToArray()[i].programacao_local,
            //                    GeradorTipoDeArranque = GeradorAbatidos.ToArray()[i].tipo_arranque,
            //                    GeradorBateria = GeradorAbatidos.ToArray()[i].bateria_v,
            //                    Dimensao_kg = GeradorAbatidos.ToArray()[i].dimensao_kg,
            //                    Dimensao_H = GeradorAbatidos.ToArray()[i].dimensao_H,
            //                    Dimensao_L = GeradorAbatidos.ToArray()[i].dimensao_L,
            //                    Dimensao_C = GeradorAbatidos.ToArray()[i].dimensao_C
            //                    //Status = GeradorAbatidos.ToArray()[i].Status
            //                }
            //                    );

            //            }

            //        }
            //        break;
            //    #endregion

            //    default:
            //    break;
            //}

        }

        #endregion 

        #region NESTA ACTION VAMOS ACTUALIZAR OS PARÂMETROS DE UM GERADOR

        [HttpGet]
        public ActionResult ActualizarGerador(int id)
        {
            using (MyDbContext db =new MyDbContext())
            {
                var GET_Gerador_Actualizar = db.Geradors.FirstOrDefault(a=>a.ID==id);

                GeradorElectrico GeradorParaActualizar = new GeradorElectrico
                {
                    ID                           =GET_Gerador_Actualizar.ID,                    
                    RuidoEmDb                    =GET_Gerador_Actualizar.RuidoEmDb,
                    CapacidadeEmLitros           =GET_Gerador_Actualizar.capacidade_LTR,
                    HorasDeFuncionamento         =GET_Gerador_Actualizar.HorasDeFuncionamento,
                    TipoControladorRemoto        =GET_Gerador_Actualizar.incorpora_can,
                    GeradorModelo                =GET_Gerador_Actualizar.modelo,
                    GeradorFabricante            =GET_Gerador_Actualizar.fabricante,
                    GeradorPotenciaKVA           =GET_Gerador_Actualizar.potencia_KVA,
                    GeradorAnoDeFabrico          =GET_Gerador_Actualizar.ano_fabrico,
                    GeradorNumeroDeFases         =GET_Gerador_Actualizar.n_fases,
                    GeradorPrecoCompra           =GET_Gerador_Actualizar.GeradorPrecoCompra,
                    GeradorDataCompra            =GET_Gerador_Actualizar.GeradorDataCompra,
                   // GeradorDistribuidor          =GET_Gerador_Actualizar.,
                    GeradorProtocoloCAN          =GET_Gerador_Actualizar.incorpora_can, 
                    GeradorProtocoloModbus       =GET_Gerador_Actualizar.incorpora_modbus, 
                    GeradorTipoCombustivel       =GET_Gerador_Actualizar.geradortipoCombustivel,
                    Marca                        =GET_Gerador_Actualizar.marca,
                    GeradorIncorporaGSM          =GET_Gerador_Actualizar.incorpora_gsm, 
                    GeradorprogramadorLocal      =GET_Gerador_Actualizar.programacao_local, 
                    GeradorTipoDeArranque        =GET_Gerador_Actualizar.tipo_arranque,
                    GeradorBateria               =GET_Gerador_Actualizar.bateria_v,
                    Dimensao_kg                  = GET_Gerador_Actualizar.dimensao_kg,
                    Dimensao_H                   = GET_Gerador_Actualizar.dimensao_H,
                    Dimensao_L                   = GET_Gerador_Actualizar.dimensao_L,
                    Dimensao_C                   =GET_Gerador_Actualizar.dimensao_C,
                    Estado                       = GET_Gerador_Actualizar.ID

                };

                return View(GeradorParaActualizar);

            }
            
        }

        [HttpPost]
        public ActionResult ActualizarGerador(GeradorElectrico model)
        {

            using (MyDbContext db =new MyDbContext())
            {

                var Gerador_Actualizado = db.Geradors.FirstOrDefault(a=>a.ID==model.ID);

                   Gerador_Actualizado.ID = model.ID;
                   Gerador_Actualizado.RuidoEmDb = model.RuidoEmDb;
                   Gerador_Actualizado.capacidade_LTR = model.CapacidadeEmLitros;
                   Gerador_Actualizado.HorasDeFuncionamento = model.HorasDeFuncionamento;
                   Gerador_Actualizado.incorpora_can = model.GeradorProtocoloCAN;
                   Gerador_Actualizado.modelo = model.GeradorModelo;
                   Gerador_Actualizado.fabricante = model.GeradorFabricante;
                   Gerador_Actualizado.potencia_KVA = model.GeradorPotenciaKVA;
                   Gerador_Actualizado.ano_fabrico = model.GeradorAnoDeFabrico;
                   Gerador_Actualizado.n_fases = model.GeradorNumeroDeFases;
                   Gerador_Actualizado.GeradorPrecoCompra = model.GeradorPrecoCompra;
                   Gerador_Actualizado.GeradorDataCompra = model.GeradorDataCompra;
                   // GeradorDistribuidor          =GET_Gerador_Actualizar.,
                   Gerador_Actualizado.incorpora_can = model.GeradorProtocoloCAN;
                   Gerador_Actualizado.incorpora_modbus = model.GeradorProtocoloModbus;
                   Gerador_Actualizado.geradortipoCombustivel = model.GeradorTipoCombustivel;
                   Gerador_Actualizado.marca = model.Marca;
                   Gerador_Actualizado.incorpora_gsm = model.GeradorIncorporaGSM;
                   Gerador_Actualizado.programacao_local = model.GeradorprogramadorLocal;
                   Gerador_Actualizado.tipo_arranque = model.GeradorTipoDeArranque;
                   Gerador_Actualizado.bateria_v = model.GeradorBateria;
                   Gerador_Actualizado.dimensao_kg = model.Dimensao_kg;
                   Gerador_Actualizado.dimensao_H = model.Dimensao_H;
                   Gerador_Actualizado.dimensao_L = model.Dimensao_L;
                   Gerador_Actualizado.dimensao_C = model.Dimensao_C;
                   Gerador_Actualizado.Id_Estado = model.Estado;

                   db.SaveChanges();

            }
            return (RedirectToAction ("MostraListaDeGeradores"));
        }
        #endregion

        #region Inserir Novo Gerador na BDA

        [HttpGet]
        public ActionResult GestaoDeGeradores()
        {
            // #NESTE CONTROLADOR DEVOLVE A VISTA ONDE VAO SER INSERIDOS OS NOVOS DADOS DO GERADOR
            // #ViewBag.Provincias
            using (MyDbContext db = new MyDbContext())
            {
                ViewBag.Provincias = db.Provincias.Select(t => t.Nome).Distinct().ToList();

                var nuno = from items in db.Provincias
                               where items.ID!=0
                               orderby items.Nome
                               select items;

                ViewBag.Provincias = nuno.ToList();
                               
            }

            return View();
        }

        [HttpPost]
        public ActionResult GestaoDeGeradores(GeradorElectrico model)
        {
            //#ESTE CÓDIGO PERMITE INTRODUZIR UM NOVO GERADOR NA BDA
            //#O GEBRADOR SERÁ REGISTADO COM O ESTADO STOCK

            Gerador InfoGerador = new Gerador();

            using (MyDbContext db = new MyDbContext())
            {
               
                //#InfoGerador.ID = model.ID;
                InfoGerador.GeradorDataCompra = model.GeradorDataCompra;
                InfoGerador.GeradorPrecoCompra = model.GeradorPrecoCompra;
                InfoGerador.GeradorDataCompra = model.GeradorDataCompra;
                InfoGerador.HorasDeFuncionamento = model.HorasDeFuncionamento;

                InfoGerador.incorpora_can = model.GeradorProtocoloCAN;
                InfoGerador.incorpora_gsm = model.GeradorIncorporaGSM;
                InfoGerador.incorpora_modbus = model.GeradorProtocoloModbus;
                InfoGerador.marca = model.Marca;
                InfoGerador.modelo = model.GeradorModelo;
                InfoGerador.fabricante = model.GeradorFabricante;

                InfoGerador.n_fases = model.GeradorNumeroDeFases;
                InfoGerador.potencia_KVA = model.GeradorPotenciaKVA;
                InfoGerador.programacao_local = model.GeradorprogramadorLocal;
                InfoGerador.RuidoEmDb = model.RuidoEmDb;
                InfoGerador.tipo_arranque = model.GeradorTipoDeArranque;

                InfoGerador.ano_fabrico = model.GeradorAnoDeFabrico;
                InfoGerador.bateria_v = model.GeradorBateria;
                InfoGerador.capacidade_LTR = model.CapacidadeEmLitros;
                InfoGerador.dimensao_C = model.Dimensao_C;
                InfoGerador.dimensao_H = model.Dimensao_H;

                InfoGerador.dimensao_kg = model.Dimensao_kg;
                InfoGerador.dimensao_L = model.Dimensao_L;
                InfoGerador.geradortipoCombustivel = model.GeradorTipoCombustivel;

                // Código adicionado em 20-05-2016
                InfoGerador.Id_Estado = 1;
                 
                db.Geradors.Add(InfoGerador);
                db.SaveChanges();

            }

            return View();
        }

        #endregion

        #region Editar Lista de Gerador Do Sistema

        [HttpGet]
        public ActionResult EditarListaDeGeradores(string id)
        {
            // Recebe o código do Gerador, cujo dados devem ser alterados, e mostra o formulário ao utilizador para editar os dados.
            // Com o id indicado iremos a BDA procurar o gerador e apresentar ao utilizador o resultado.
            // Devolve a página com os dados do gerador seleccionado.
            return View();
        }
        [HttpPost]
        public ActionResult EditarListaDeGeradores(ListaDeGeradores model)
        {
            // Recebe o objecto com os dados do novo Gerador e guarda as informações na BDA
            // Depois volta à página onde é mostrada a lista de geradores de modo a permitir ao utilizador 
            // ver o resultado produzido.

            return RedirectToAction("MostraListaDeGeradores"); 
           
        }

        #endregion

        #region Consultar Histórico do Gerador Na BDA

        [HttpGet]
        public ActionResult HistoricoDoGerador(int ID)
        {
            // #Recebe o id do gerador e depois permite fazer uma pesquisa na BDA.
            // #Esta action permite consultar todas as informações sobre um gerador, desde a instalação à data actual
            // #Vamos devolver uma lista com toda a informação do Gerador seleccionado.

            using (MyDbContext db = new MyDbContext())
            {

                var InfoManutencaoGerador = from items in db.Manutencoes
                                            where items.ID == ID
                                            select new
                                        {
                                            items.ID,
                                            data = items.Requisicao.Data,
                                            items.Site.Bairro.Nome,
                                            items.Observacoes,
                                            items.Site.DataInstalacao,
                                            items.Site.Gerador.HorasDeFuncionamento,
                                           // items.Estado,
                                            funcionario = items.Funcionario   
                                        };

                InfoManutencaoGerador.ToList();

                List<HistoricoDoGerador> Hgerador = new List<HistoricoDoGerador>();

                for (int i = 0; i < InfoManutencaoGerador.ToArray().Length; i++)
                {
                    Hgerador.Add(new HistoricoDoGerador
                    {
                         DataDaInstalacao                    = InfoManutencaoGerador.ToArray()[i].DataInstalacao,
                         DataDaManutencao                    = InfoManutencaoGerador.ToArray()[i].data,
                         MotivoDaManutencao                  = InfoManutencaoGerador.ToArray()[i].Observacoes,
                         HorasDeFuncionamento                = InfoManutencaoGerador.ToArray()[i].HorasDeFuncionamento
                         //NomeDoTecnicoResponsavel            = InfoManutencaoGerador.ToArray()[i].funcionario.Nome,
                        // ApelidoDoTecnicoResponsavel         = InfoManutencaoGerador.ToArray()[i].funcionario.Apelido,
                       //  TipoDeAvarias                       = Convert.ToString(InfoManutencaoGerador.ToArray()[i].Estado)
                        //Obs_Material_01          = InfoManutencaoGerador.ToArray()[i].
                       // Obs_Material_02           = InfoManutencaoGerador.ToArray()[i]
                       // Obs_Material_03           = InfoManutencaoGerador.ToArray()[i]
                       // Obs_Material_04           = InfoManutencaoGerador.ToArray()[i]
                       //Obs_Material_05            = InfoManutencaoGerador.ToArray()[i]
                       // Obs_Material_06           = InfoManutencaoGerador.ToArray()[i]
                       // Obs_Material_07           = InfoManutencaoGerador.ToArray()[i]
                       // Obs_Material_08           = InfoManutencaoGerador.ToArray()[i]
                       // Obs_Material_09           = InfoManutencaoGerador.ToArray()[i]
                       // Obs_Material_10           = InfoManutencaoGerador.ToArray()[i]
                    });
                }


                return View(Hgerador);
            }
           
        }

        [HttpPost]
        public ActionResult HistoricoDoGerador(string name)
        {
            return View();
        }

        #endregion
    }
}




