
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
                if(ModelState.IsValid)
                new Gestor().agregarVehiculos(v);
                resultado = "Registro exitoso";

            }
            catch (System.Exception)
            {
                resultado = "Falla";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
            
        }


    }
}