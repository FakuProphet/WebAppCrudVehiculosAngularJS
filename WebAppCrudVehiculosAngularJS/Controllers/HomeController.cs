
using System.Web.Mvc;
using WebAppCrudVehiculosAngularJS.Models;

namespace WebAppCrudVehiculosAngularJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listado()
        {
            return View();
        }

        public JsonResult AgregarVehiculo(Vehiculo v)
        {

            string resultado = string.Empty;

            try
            {
                bool valido = new Gestor().agregarVehiculos(v);
                if (valido)
                {
                    resultado = "Registro exitoso";
                }
                else
                {
                    resultado = "Dominio ya registrado";
                }
            }
            catch (System.Exception)
            {
                resultado = "Falla";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
            
        }


    }
}