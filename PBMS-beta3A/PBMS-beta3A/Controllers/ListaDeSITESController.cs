using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBMS_beta3A.Model;



namespace PBMS_beta3A.Controllers
{
    public class ListaDeSITESController : Controller
    {

        #region Mostra a lista de sites instalados

        [HttpGet]
        public ActionResult GestaoDaListaDeSITES()
        {
            List<ListaDeSITES> model = new List<ListaDeSITES>();

          //  model.Add(new ListaDeSITES() {SITENome="Kizombo",SITEProvincia="Luanda",SITEMunicipio="Kilamba Kiaxi",SITEBairro="Kilamba",SITEDataInstalacao=DateTime.Now,SITENomeCliente="Unitel",SITEContactoMobile=9234585,SITEGRWYNumber=22244444,SITEGRDORKVA=100,SITETiposDeSite="Antena",SITEEstadoOnOff="On" });

            return View(model);
        }
        #endregion   

        #region  Mostra os vários SITES -> Partialview

        public PartialViewResult SitesRequisitados(string site)
        {
            List<ListaDeSITES> model = new List<ListaDeSITES>();

          //  model.Add(new ListaDeSITES() { SITENome = "Kizombo", SITEProvincia = "Luanda", SITEMunicipio = "Kilamba Kiaxi", SITEBairro = "Kilamba", SITEDataInstalacao = DateTime.Now, SITENomeCliente = "Unitel", SITEContactoMobile = 9234585, SITEGRWYNumber = 22244444, SITEGRDORKVA = 100, SITETiposDeSite = "Antena", SITEEstadoOnOff = "On" });

            return PartialView(model);
        }
        #endregion

        #region Instalar um Novo SITE na rede de Backup

        [HttpGet]
        public ActionResult CriarNovoSite()
        {
            // Mostra ao utilizador a vista que recebe os parãmetros informativos do novo site

            return View();
        }
        [HttpPost]
        public ActionResult CriarNovoSite(CriarNovoSite model)
        {
            // Recebe os dados e guarda na base de dados em SQL Server 2008 
            return View();
        }

        #endregion

        #region Fazer alterações dos parâmetros do SITE

        [HttpGet]
        public ActionResult EditarSiteParametros(string id)
        {
            // Recebe o código do Site que se deseja fazer alterações básicas e vamos a BDA carregar o Obj para apresentar ao Utilizador.
           //  O utlizador análisa todas as informações do Obj e vê qual a que será actualizada.

            // Portanto, nesta action faremos a selecção do objecto da lista que será alterado os seus parâmetros.
            return View();
        }
        [HttpPost]
        public ActionResult EditarSiteParametros(ListaDeSITES model)
        {
            // Recebe o novo Obj com as actualizações feitas e guarda na BDA.

            // Portanto, nesta action será programado o código que vai interagir com a base de dados para guardar o Obj alterado.
           
            return View();
        }
        #endregion
    }
}
