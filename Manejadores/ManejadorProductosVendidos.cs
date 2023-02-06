using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1er_Preentrega_Proyecto_Final.Models;
using System.Security.Cryptography.X509Certificates;

namespace _1er_Preentrega_Proyecto_Final.Manejadores
{
    internal class ManejadorProductosVendidos
    {
        public static string CadenaConexion = "Data Source=DESKTOP-9P4B039;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Producto ObtenerProducto(long Id)
        {
            Producto productos = new Producto();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand comandoSelect = new SqlCommand("SELECT * FROM Producto WHERE Id=@Id", conexion);
                //SqlCommand comandoSelect = new SqlCommand("SELECT IdProducto FROM Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta", conexion);
                comandoSelect.Parameters.AddWithValue("@Id", Id);
                conexion.Open();
                SqlDataReader reader = comandoSelect.ExecuteReader();
                if (reader.HasRows)
                {
                   reader.Read();
                   productos.Id = reader.GetInt64(0);
                   productos.Descripciones = reader.GetString(1);
                   productos.Costo = reader.GetDecimal(2);
                   productos.PrecioVenta = reader.GetDecimal(3);
                   productos.Stock = reader.GetInt32(4);
                   productos.IdUsuario = reader.GetInt64(5);

                }
                return productos;
            }
        }
        public static List<Producto> ObtenerProductosVendidos(long IdUsuario)
        {
            List<long> ListIdProducto = new List<long>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                //SqlCommand comandoSelect = new SqlCommand("SELECT * FROM Producto WHERE Id=@Id", conexion);
                SqlCommand comandoSelect = new SqlCommand("SELECT IdProducto FROM Venta INNER JOIN ProductoVendido ON Venta.Id = ProductoVendido.IdVenta WHERE IdUsuario = @IdUsuario", conexion);
                comandoSelect.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                conexion.Open();
                SqlDataReader reader = comandoSelect.ExecuteReader();
                if (reader.HasRows)
                {
                   while (reader.Read())
                    {
                        ListIdProducto.Add(reader.GetInt64(0));
                    }

                }
            }
            List <Producto> productos= new List<Producto>();
            foreach (var id in ListIdProducto)
            {

                Producto prodTemp = ObtenerProducto(id);
                productos.Add(prodTemp);
            }
            return productos;
        }
    }

}
