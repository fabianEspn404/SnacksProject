using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Utils;

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
        //GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            ViewBag.Message = "Your create page.";

            try
            {
                IServiceUsuario _ServiceUsuario = new ServiceUsuario();


                if (ModelState.IsValid)
                {
                    Usuario oUsuario1;
                    oUsuario1 = (Usuario)Session["User"];


                    Usuario oUsuario2 = _ServiceUsuario.Save(usuario);

                }
                else
                {

                    // Valida Errores si Javascript está deshabilitado
                    Util.ValidateErrors(this);
                    //ViewBag.ListaUsuario = listaUsuario();
                    //ViewBag.ListaTipoUsuario = listaTipoUsuario();
                    return View("Create", usuario);

                }

                return RedirectToAction("Index","Login");


            }
            catch (Exception ex)
            {
                // Salvar el error en un archivo 
                //Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData["Redirect"] = "Usuario";
                TempData["Redirect-Action"] = "Index";
                // Redireccion a la captura del Error
                return RedirectToAction("Default", "Error");
            }

        }
    }
}