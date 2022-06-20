using ApplicationCore.Services;
using Infraestructure.Models;
using Web.Utils;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Web.Utils.SweetAlertHelper;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(Usuario usuario)
        {
            IServiceUsuario _ServiceUsuario = new ServiceUsuario();
            Usuario oUsuario = null;
            try
            {
                if (ModelState.IsValid)
                {
                    oUsuario = _ServiceUsuario.GetUsuario(usuario.Username, usuario.Clave);

                    if (oUsuario == null)
                    {
                        //Utils.Log.Warn($"{usuario.IdUsuario} se intentó conectar  y falló");
                        ViewBag.NotificationMessage = SweetAlertHelper.Mensaje("Usuario incorrecto", "Por favor ingrese los datos correctos", SweetAlertMessageType.success);

                    }
                    //else if (oUsuario.Activo == 0)
                    //{
                    //    //    //Utils.Log.Warn($"{usuario.IdUsuario} se intentó conectar  y falló");
                    //    ViewBag.NotificationMessage = Infraestructure.Utils.SweetAlertHelper.Mensaje("Usuario no activo", "Por favor contacte a soporte", SweetAlertMessageType.warning);

                    //}
                    else
                    {
                        Session["User"] = oUsuario;
                        //Utils.Log.Info($"Accede {oUsuario.Nombre} con el rol {oUsuario.TipoUsuario.IdTipoUsuario}-{oUsuario.TipoUsuario.Descripcion}");
                        TempData["mensaje"] = SweetAlertHelper.Mensaje("Login", "Usario autenticado satisfactoriamente", SweetAlertMessageType.success);
                        ViewBag.NotificationMessage = SweetAlertHelper.Mensaje("Usuario incorrecto", "Por favor ingrese los datos correctos", SweetAlertMessageType.warning);
                        //Utils.SweetAlertHelper.Mensaje("Login", "Usario autenticado satisfactoriamente", SweetAlertMessageType.success);

                        return RedirectToAction("Index", "Home");


                    }
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                //Utils.Log.Error(ex, MethodBase.GetCurrentMethod());
                // Pasar el Error a la página que lo muestra
                TempData["Message"] = ex.Message;
                TempData.Keep();
                return RedirectToAction("Default", "Error");
            }
        }
        public ActionResult Logout()
        {
            Usuario oUsuario = Session["User"] as Usuario;
            try
            {
                if (oUsuario != null)
                {
                    //Utils.Log.Info($"Se desconecta {oUsuario.Nombre} con el rol {oUsuario.TipoUsuario.IdTipoUsuario}-{oUsuario.TipoUsuario.Descripcion}");
                    Session["User"] = null;
                }

                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                //Utils.Log.Error(ex, MethodBase.GetCurrentMethod());
                // Pasar el Error a la página que lo muestra
                TempData["Message"] = ex.Message;
                TempData["Redirect"] = "Login";
                TempData["Redirect-Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
        }
    }
}