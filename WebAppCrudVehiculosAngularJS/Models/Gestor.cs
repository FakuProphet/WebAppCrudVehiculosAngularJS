using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebAppCrudVehiculosAngularJS.Models
{
    public class Gestor
    {
        
        string cadena = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

        public void Delete_registro_vehiculo(string dominio)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("Sp_eliminar_registro_vehiculo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dominio", dominio);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public Vehiculo GetVehiculo(string dominio)
        {

            Vehiculo miVehiculo = null;
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_get_registro_vehiculo", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@dominio", SqlDbType.VarChar).Value = dominio;

                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    miVehiculo = new Vehiculo();
                    string marca = dr.GetString(0);
                    string nombre = dr.GetString(1);
                    string anio = dr.GetString(0);
                    string dom = dr.GetString(1);
                    string color = dr.GetString(1);
                    miVehiculo.nombre = nombre;
                    miVehiculo.marca = marca;
                    miVehiculo.color = color;
                    miVehiculo.anio = anio;
                    miVehiculo.dominio = dom;
                    
                }
            }


            return miVehiculo;

        }



        public void agregarVehiculos(Vehiculo v)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = v.nombre;
                cmd.Parameters.Add("@color", SqlDbType.VarChar).Value = v.color;
                cmd.Parameters.Add("@anio", SqlDbType.VarChar).Value = v.anio;
                cmd.Parameters.Add("@marca", SqlDbType.VarChar).Value = v.marca;
                cmd.Parameters.Add("@dominio", SqlDbType.VarChar).Value = v.dominio;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}