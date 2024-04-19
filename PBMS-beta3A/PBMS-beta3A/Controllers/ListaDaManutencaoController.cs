using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBMS_beta3A.Model;
using PBMS_beta3A.dbModel;

namespace PBMS_beta3A.Controllers
{
    public class ListaDaManutencaoController : Controller
    {

        #region Apresenta a lista dos Sites com as respectivas datas de manutenções preventivas

        [HttpGet]
        public ActionResult IndexListaManutencao()
        {

            #region ViewBag que passa dinâmicamente os dados para uma DropList na Vista.

            // De modo a termos uma lista dinâmica dos nomes do Clientes que estão no sistemaNesta secção iremos fazer uma consulta a base de dados para carregar o nome dos clintes para uma lista.
            //é preciso previamente carregar esta informação a partir da base de dados. Para tal criaremos um Obj que vai ter o nome e o código da empresa.
            // criaremos uma List de Obj deste tipo e passamos esta informação para a ViewBag.
            // Deste modo podemos remover qualquer elemento da DBA que irá automaticamente se refletir no vista.


            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "UNITEL",            Value = "1" });

            items.Add(new SelectListItem { Text = "MOVICEL",           Value = "2" });

            items.Add(new SelectListItem { Text = "BPC",               Value = "3", Selected = true });

            items.Add(new SelectListItem { Text = "BROLAZ",            Value = "4" });

            items.Add(new SelectListItem { Text = "GS-INDUSTRIAL",     Value = "5" });

            ViewBag.MovieType = items;

            #endregion 

            List<ListaDaManutencao> model = new List<ListaDaManutencao>();

            model.Add(new ListaDaManutencao() { Site = "Mutamba", Provincia = "Luanda", Municipio = "Sambinzanga", Cliente = "Nuno Miguel", DataUltimaManutencao = DateTime.Now, DataProximaManutencao = DateTime.Now, Observacao = "Revisão", Funcionario = "João Martins", Status = "Concluida" });
            model.Add(new ListaDaManutencao() { Site = "kinaxixi", Provincia = "Luanda", Municipio = "Kilamba Kiaxi", Cliente = "Nuno Miguel", DataUltimaManutencao = DateTime.Now, DataProximaManutencao = DateTime.Now, Observacao = "Revisão", Funcionario = "Dário da Silva", Status = "Em curso" });
            model.Add(new ListaDaManutencao() { Site = "Zango Zero", Provincia = "Benguela", Municipio = "Viana", Cliente = "Nuno Miguel", DataUltimaManutencao = DateTime.Now, DataProximaManutencao = DateTime.Now, Observacao = "Revisão", Funcionario = "Oscar Paredes", Status = "Concluida" });
            model.Add(new ListaDaManutencao() { Site = "Viana Sul", Provincia = "Benguela", Municipio = "Maianga", Cliente = "Nuno Miguel", DataUltimaManutencao = DateTime.Now, DataProximaManutencao = DateTime.Now, Observacao = "Revisão", Funcionario = "Justiva Salvador", Status = "Em espera" });

            ViewBag.ListaDeNomesDosClientes = model;

            return View(model);
        }

        #endregion

        #region Aqui Vamos criar a Action que vai estar ligada a vista Partcial que vai actualizar a página

        public PartialViewResult ProximaManutencaoParaoClienteX(Int32 id)
        {
            List<ListaDaManutencao> model = new List<ListaDaManutencao>();

            model.Add(new ListaDaManutencao() { Site = "NDL HBO", Provincia = "10", Municipio = "11", Cliente = "Nundel Technologies", DataUltimaManutencao = DateTime.Now, DataProximaManutencao = DateTime.Now, Observacao = "Revisão", Funcionario = "Oscar Paredes", Status = "Concluida" });
            model.Add(new ListaDaManutencao() { Site = "NDL LDA", Provincia = "12", Municipio = " 21", Cliente = "Nundel Technologies", DataUltimaManutencao = DateTime.Now, DataProximaManutencao = DateTime.Now, Observacao = "Reparação", Funcionario = "Oscar Paredes", Status = "Concluida" });
            model.Add(new ListaDaManutencao() { Site = "NDL BGL", Provincia = "14", Municipio = "31", Cliente = "Nundel Technologies", DataUltimaManutencao = DateTime.Now, DataProximaManutencao = DateTime.Now, Observacao = "Avaria", Funcionario = "Oscar Paredes", Status = "Concluida" });
            model.Add(new ListaDaManutencao() { Site = "NDL HLA", Provincia = "18", Municipio = "41", Cliente = "Nundel Technologies", DataUltimaManutencao = DateTime.Now, DataProximaManutencao = DateTime.Now, Observacao = "Revisão", Funcionario = "Oscar Paredes", Status = "Concluida" });

            return PartialView(model);  
        }
        
        #endregion


        #region Apresentação da vista que permite fazer requisição do material para manutenção

        [HttpGet]
        public ActionResult RequistarMaterial(string id)
        {
            // Neste action iremos quando o utilizador clicar no botão requisitar material iremos receber ID do Site que fará a manutenção preventiva.
            // Em seguida será apresentada a vista que permitirá o utilizador fazer a requisição do material.

          
            int [] numeros=new int[3]{1,2,3};
            
             RequisitarMaterial model = new RequisitarMaterial();

             //model.DataDaManutencao = DateTime.Now;
             //model.SiteID =id;
             //model.TecnicoID = 54343;

            // model.CogidoDasPecas = numeros.ToList();

            return View(model);
        }
        [HttpPost]
        public ActionResult RequistarMaterial(RequisitarMaterial model)
        {
            // Regista o pedido feito da requisição de material na BDA.

            using (MyDbContext db = new MyDbContext())
            {
              //  Requisicao material = new Requisicao();

              // //  model.SiteID;
              ////  model.TecnicoID;
              //  //material.data = model.DataDaManutencao;
              //  //material.mat0001 = material.mat0001;
              //  //material.mat0002 = material.mat0002;
              //  //material.mat0003 = material.mat0003;
              //  //material.mat0004 = material.mat0004;
              //  //material.mat0005 = material.mat0005; 
              //  //material.mat0006 = material.mat0006;
              //  //material.mat0008 = material.mat0007;
              //  //material.mat0009 = material.mat0009;
              //  //material.mat0010 = material.mat0010;
              //  //material.mat0011 = material.mat0011;
              //  //material.mat0012 = material.mat0012;
              //  //material.mat0013 = material.mat0013;
              //  //material.mat0014 = material.mat0014;
              //  //material.mat0015 = material.mat0015;
              //  //material.mat0016 = material.mat0016;

              //  db.Requisicoes.Add(material);
              //  db.SaveChanges();

            }


            return View();
        }

        #endregion
    }
}


//ListaDaManutencao/IndexListaManutencao