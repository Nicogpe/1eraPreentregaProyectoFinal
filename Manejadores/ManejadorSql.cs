using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1er_Preentrega_Proyecto_Final.Manejadores
{
    internal class ManejadorSql
    {
        string CadenaConexion = "Data Source=DESKTOP-9P4B039;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection conexion = new SqlConnection();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public void Comando(DataSet dataComando, SqlCommand sqlComando)
        {
            conexion.Open();
            sqlComando.Connection= conexion;
            dataAdapter.SelectCommand= sqlComando;
            dataAdapter.Fill(dataComando, "DATA");
            conexion.Close();

        }
    }
}
