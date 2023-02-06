using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1er_Preentrega_Proyecto_Final.Models;

namespace _1er_Preentrega_Proyecto_Final.Manejadores
{
    internal class ManejadorUsuario
    {
        public static string CadenaConexion = "Data Source=DESKTOP-9P4B039;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Models.Usuario> ConsultaUsuarios()
        {
            List<Models.Usuario> usuario = new List<Models.Usuario>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand comandoSeleccion = new SqlCommand("SELECT * FROM Usuario", conexion);
                conexion.Open();

                SqlDataReader readerUsuarios = comandoSeleccion.ExecuteReader();
                if (readerUsuarios.HasRows)
                {
                    while (readerUsuarios.Read())
                    {
                        Usuario usuarios= new Usuario();
                        usuarios.Id = readerUsuarios.GetInt64(0);
                        usuarios.Nombre = Convert.ToString(readerUsuarios["Nombre"]);
                        usuarios.Apellido = Convert.ToString(readerUsuarios["Apellido"]);
                        usuarios.NombreUsuario = Convert.ToString(readerUsuarios["NombreUsuario"]);
                        usuarios.Contraseña = Convert.ToString(readerUsuarios["Contraseña"]);
                        usuarios.Mail = Convert.ToString(readerUsuarios["Mail"]);

                        usuario.Add(usuarios);
                    }
                }

                return usuario;
            }
        }
        public static Usuario ConsultaUsuario(long Id)
        {
            Usuario usuario1 = new Usuario();
            //DataSet dataUsuario = new DataSet();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand comandoSeleccion = new SqlCommand("SELECT * FROM Usuario WHERE Id=@Id", conexion);
                SqlParameter idParametro = new SqlParameter();
                idParametro.Value = Id;
                idParametro.SqlDbType = SqlDbType.BigInt;
                idParametro.ParameterName = "Id";

                comandoSeleccion.Parameters.Add(idParametro);

                conexion.Open();

                SqlDataReader readerUsuarios = comandoSeleccion.ExecuteReader();
                if (readerUsuarios.HasRows)
                {
                    readerUsuarios.Read();
                    {
                        usuario1.Id = readerUsuarios.GetInt64(0);
                        usuario1.Nombre = Convert.ToString(readerUsuarios["Nombre"]);
                        usuario1.Apellido = Convert.ToString(readerUsuarios["Apellido"]);
                        usuario1.NombreUsuario = Convert.ToString(readerUsuarios["NombreUsuario"]);
                        usuario1.Contraseña = Convert.ToString(readerUsuarios["Contraseña"]);
                        usuario1.Mail = Convert.ToString(readerUsuarios["Mail"]);
                    }
                }

                return usuario1;
            }

        }
    }
}
