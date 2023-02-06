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
    internal class ManejadorVentas
    {
        public static string CadenaConexion = "Data Source=DESKTOP-9P4B039;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Venta ObtenerVenta(long Id)
        {
            Venta venta = new Venta();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand comandoSeleccion = new SqlCommand("SELECT * FROM Venta WHERE Id = @Id", conexion);
                comandoSeleccion.Parameters.AddWithValue("@Id", Id);
                conexion.Open();
                SqlDataReader reader = comandoSeleccion.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    venta.Id = reader.GetInt64(0);
                    venta.Comentarios = reader.GetString(1);
                    venta.IdUsuario = reader.GetInt64(2);
                }
            }
            return venta;
        }
        public static List<Venta> TraerVentas(long IdUsuario)
        {
            List<long> VentaHecha = new List<long>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand comandoSeleccion = new SqlCommand("SELECT Id FROM Venta WHERE IdUsuario = @IdUsuario", conexion);
                comandoSeleccion.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                conexion.Open();
                SqlDataReader reader = comandoSeleccion.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        VentaHecha.Add(reader.GetInt64(0));
                    }
                }
            }
            List<Venta> VentasRealizadas = new List<Venta>();
            foreach (var Id in VentaHecha)
            {
                Venta ventaTempporal = ObtenerVenta(Id);
                VentasRealizadas.Add(ventaTempporal);
            }
            return VentasRealizadas;
        }

    }

}