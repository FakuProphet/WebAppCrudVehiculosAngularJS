
using System.ComponentModel.DataAnnotations;


namespace WebAppCrudVehiculosAngularJS.Models
{
    public class Vehiculo
    {
        [Key]
        public int id { get; set; }
        public string marca { get; set; }
        public string nombre { get; set; }
        public string color { get; set; }
        public string anio { get; set; }
    }
}