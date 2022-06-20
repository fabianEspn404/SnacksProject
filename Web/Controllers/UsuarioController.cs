using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            IEnumerable<Usuario> lista = null;
            try
            {
                IServiceUsuario _SeviceUsuario = new ServiceUsuario();
                lista = _SeviceUsuario.GetUsuarios();
                ViewBag.tituloPag = "Lista de Usuarios";
                //ViewBag.ListaUsuario = ;

            }
            catch (Exception ex)
            {
                //Log.Error(ex, MethodBase.GetCurrentMethod());
                //TempData["Message"] = "Error al procesar los datos! " + ex.Message;

                //// Redireccion a la captura del Error
                //return RedirectToAction("Default", "Error");
            }
                return View(lista);
        }
    }
}