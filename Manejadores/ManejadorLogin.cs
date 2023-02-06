using _1er_Preentrega_Proyecto_Final.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_Preentrega_Proyecto_Final.Manejadores
{
    internal class ManejadorLogin
    {
        public static string CadenaConexion = "Data Source=DESKTOP-9P4B039;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Usuario Login(string NombreUsuario, string Contraseña)
        {
            Usuario Ingreso = new Usuario();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand comandoSeleccion = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario and Contraseña = @Contraseña", conexion);
                comandoSeleccion.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                comandoSeleccion.Parameters.AddWithValue("@Contraseña", Contraseña);
                conexion.Open();
                SqlDataReader reader = comandoSeleccion.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Ingreso.Id = reader.GetInt64(0);
                    Ingreso.Nombre = reader.GetString(1);
                    Ingreso.Apellido = reader.GetString(2);
                    Ingreso.NombreUsuario = reader.GetString(3);
                    Ingreso.Contraseña = reader.GetString(4);
                    Ingreso.Mail = reader.GetString(5);
                    Console.WriteLine("Bienvenido " + Ingreso.Nombre + " " + Ingreso.Apellido);
                }
                else
                {
                    Console.WriteLine("Usuario o Contraseña incorrectos");
                }
            }
            return Ingreso;
        }
    }
}
