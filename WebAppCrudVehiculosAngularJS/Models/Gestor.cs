using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

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
                    string marca = dr.GetString(2);
                    string nombre = dr.GetString(1);
                    string anio = dr.GetString(4);
                    string dom = dr.GetString(5);
                    string color = dr.GetString(3);
                    miVehiculo.nombre = nombre;
                    miVehiculo.marca = marca;
                    miVehiculo.color = color;
                    miVehiculo.anio = anio;
                    miVehiculo.dominio = dom;
                   
                }
            }
            return miVehiculo;
        }



        public List<Vehiculo> GetVehiculoListado()
        {

            List<Vehiculo> listado = new List<Vehiculo>();
            Vehiculo miVehiculo = null;
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                SqlCommand com = new SqlCommand("Sp_get_listado_vehiculo", con);
                com.CommandType = CommandType.StoredProcedure;
              

                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    miVehiculo = new Vehiculo();
                    int id = dr.GetInt32(0);
                    string marca = dr.GetString(2);
                    string nombre = dr.GetString(1);
                    string anio = dr.GetString(4);
                    string dom = dr.GetString(5);
                    string color = dr.GetString(3);
                    miVehiculo.nombre = nombre;
                    miVehiculo.marca = marca;
                    miVehiculo.color = color;
                    miVehiculo.anio = anio;
                    miVehiculo.dominio = dom;
                    miVehiculo.id = id;
                    listado.Add(miVehiculo);

                }
            }
            return listado;
        }





        public bool agregarVehiculos(Vehiculo v)
        {
            bool bandera = false;
            using (SqlConnection con = new SqlConnection(cadena))
            {
                Vehiculo vh = new Vehiculo();
                vh = GetVehiculo(v.dominio);
                if (vh==null)
                {
                    bandera = true;
                    SqlCommand cmd = new SqlCommand("Sp_registrar_vehiculo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = v.nombre;
                    cmd.Parameters.Add("@color", SqlDbType.VarChar).Value = v.color;
                    cmd.Parameters.Add("@anio", SqlDbType.VarChar).Value = v.anio;
                    cmd.Parameters.Add("@marca", SqlDbType.VarChar).Value = v.marca;
                    cmd.Parameters.Add("@dominio", SqlDbType.VarChar).Value = v.dominio;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    bandera = false;
                }
            }

            return bandera;
        }


        public void ActualizarRegistro(Vehiculo v)
        {
            using (SqlConnection con = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("Sp_actualizar_registro_vehiculo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = v.nombre;
                cmd.Parameters.Add("@marca", SqlDbType.VarChar).Value = v.marca;
                cmd.Parameters.Add("@anio", SqlDbType.VarChar).Value = v.anio;
                cmd.Parameters.Add("@color", SqlDbType.VarChar).Value = v.color;
                cmd.Parameters.Add("@dominio", SqlDbType.VarChar).Value = v.dominio;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



    }
}