using System.Data.SqlClient;
using _1er_Preentrega_Proyecto_Final.Manejadores;
using _1er_Preentrega_Proyecto_Final.Models;

namespace _1er_Preentrega_Proyecto_Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Usuario> usuario = new List<Usuario>();
            Usuario usuarios = new Usuario();
            
            usuario = Manejadores.ManejadorUsuario.ConsultaUsuarios();
            Console.WriteLine(usuario[1].Nombre);
            usuarios = Manejadores.ManejadorUsuario.ConsultaUsuario(1);
            Console.WriteLine(usuarios.Nombre);

            List<Producto> productos = Manejadores.ManejadorProductos.ObtenerCargados(3);
            foreach (var item in productos)
            {
                Console.WriteLine(item.Descripciones);
            }

            List<Producto> prodVendido = Manejadores.ManejadorProductosVendidos.ObtenerProductosVendidos(1);
            foreach (var item in prodVendido)
            {
                Console.WriteLine(item.Descripciones);
            }
            List<Venta> Ventas = Manejadores.ManejadorVentas.TraerVentas(1);
            foreach (var item in Ventas)
            {
                Console.WriteLine(item.Id);
            }
            Console.WriteLine("Ingrese usuario: ");
            string NombreUsuario;
            NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese contraseña: ");
            string Contraseña;
            Contraseña = Console.ReadLine();
            Usuario User = Manejadores.ManejadorLogin.Login(NombreUsuario, Contraseña);
        }
    }
}