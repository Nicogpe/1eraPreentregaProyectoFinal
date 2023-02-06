using _1er_Preentrega_Proyecto_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _1er_Preentrega_Proyecto_Final.Manejadores
{
    internal class ManejadorProductos
    {
        public static string CadenaConexion = "Data Source=DESKTOP-9P4B039;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Producto ObtenerProducto(long id)
        {
            Producto producto = new Producto();

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand comandoSelect = new SqlCommand("SELECT * FROM Producto WHERE Id = @id", conexion);

                comandoSelect.Parameters.AddWithValue("@id", id);

                conexion.Open();

                SqlDataReader reader = comandoSelect.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    producto.Id = reader.GetInt64(0);
                    producto.Descripciones = reader.GetString(1);
                    producto.Costo = reader.GetDecimal(2);
                    producto.PrecioVenta = reader.GetDecimal(3);
                    producto.Stock = reader.GetInt32(4);
                    producto.IdUsuario = reader.GetInt64(5);
                }
            }
            return producto;
        }
        public static List<Producto> ObtenerCargados(long IdUsuario)
        {
            List<long> productoCargado = new List<long>();
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                SqlCommand comandoSelect = new SqlCommand("SELECT Id FROM Producto WHERE IdUsuario = @idUsuario", conexion);
                comandoSelect.Parameters.AddWithValue("@idUsuario", IdUsuario);
                conexion.Open();
                SqlDataReader reader = comandoSelect.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productoCargado.Add(reader.GetInt64(0));
                    }
                }
            }
            List<Producto> ProdCargados = new List<Producto>();
            foreach (var id in productoCargado)
            {
                Producto ProdTemp = ObtenerProducto(id);
                ProdCargados.Add(ProdTemp);
            }
            return ProdCargados;
        }
    }
}
