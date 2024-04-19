using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBMS_beta3A.Model;
using PBMS_beta3A.dbModel;
using System.Web.Security;



namespace PBMS_beta3A.Controllers
{
    public class ControloDeAcessoPBMSController : Controller
    {
        #region Sistema de Login para aceder ao PBMS

        [HttpGet]
        public ActionResult ValidarLogin()
        {
            //Mostra a vista de Login

            return View();
        }

        [HttpPost]
        public ActionResult ValidarLogin(V_DadoDeLogin model)
        {
            if ((model.Email !=null))
            {
                if(VerificarSeoUtlizadorEValido(model.Email,model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email,false);

                    return RedirectToAction("Index", "Home");
                }
               
            }

           return View(model);
           // return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Sistema de LogOut para sair com segurança do PBMS

        [HttpGet]
        public ActionResult SairDoSistema()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SairDoSistema(V_DadoDeLogin model)
        {
            return View();
        }
        #endregion
        
        private bool VerificarSeoUtlizadorEValido(string EmailDeUtilizador, string PasswordDeUtilizador)
        {
            try
            {
                bool UlizadorValido = false;
                var VerificaAPasswordDeUtilizadorSeValida = new SimpleCrypto.PBKDF2();

                using (MyDbContext db = new MyDbContext())
                {
                    var VerificaSeEmailDeUtilizadorExisteNaDb = db.DadoDeLogins.FirstOrDefault(a => a.Email.Equals(EmailDeUtilizador));

                    if (VerificaSeEmailDeUtilizadorExisteNaDb != null)
                    {
                        if (VerificaSeEmailDeUtilizadorExisteNaDb.Password == VerificaAPasswordDeUtilizadorSeValida.Compute(PasswordDeUtilizador, VerificaSeEmailDeUtilizadorExisteNaDb.PasswordSalt))
                        {
                            UlizadorValido = true;
                        }
                    }
                }

                return UlizadorValido;
            }
            catch (Exception e) { return false; }
        }
     
    }
}


 //<add name="MyDbContext" connectionString="Server=tcp:nundel.database.windows.net,1433;Data Source=nundel.database.windows.net;Initial Catalog=MyDbContext;Persist Security Info=False;User ID={mnuno};Password={cazenga_st48$};Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" providerName="System.Data.SqlClient"/> 
 
 //                                         Server=tcp:gprodb.database.windows.net,1433;Initial Catalog=dbContext;Persist Security Info=False;User ID={ekumbi};Password={cazenga48!72};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
										  
 //<add name="dbContext" connectionString="Server=tcp:gprodb.database.windows.net,1433;Initial Catalog=dbContext;Persist Security Info=False;User ID={ekumbi};Password={cazenga48!72};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" providerName="System.Data.SqlClient"/>										  
 
 