using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Diccionario> clientes = new Dictionary<string, Diccionario>();

            while (true)
            {
                var cliente = CargarCliente();

                if (clientes.ContainsKey(cliente.NumeroTelefono))
                {
                    Console.WriteLine("El cliente ya existe. Se actualizarán las compras y el total gastado.");
                    cliente = clientes[cliente.NumeroTelefono];
                }
                else
                {
                    clientes.Add(cliente.NumeroTelefono, cliente);
                }

                CargarCompras(cliente);

                Console.Write("¿Desea agregar otro cliente? (si/no): ");
                if (Console.ReadLine().ToLower() != "si") break;
            }

            Console.WriteLine("\nClientes registrados:");
            foreach (var cliente in clientes.Values)
            {
                Console.WriteLine(cliente);
                Console.WriteLine();
            }
        }

        static Diccionario CargarCliente()
        {
            string nombre;
            do
            {
                Console.Write("Nombre: ");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                }
                else if (nombre.Any(char.IsDigit))
                {
                    Console.WriteLine("El nombre no puede contener números.");
                }
            } while (string.IsNullOrWhiteSpace(nombre) || nombre.Any(char.IsDigit));

            string apellido;
            do
            {
                Console.Write("Apellido: ");
                apellido = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(apellido))
                {
                    Console.WriteLine("El apellido no puede estar vacío.");
                }
                else if (apellido.Any(char.IsDigit))
                {
                    Console.WriteLine("El apellido no puede contener números.");
                }
            } while (string.IsNullOrWhiteSpace(apellido) || apellido.Any(char.IsDigit));

            string numeroTelefono;
            do
            {
                Console.Write("Número de Teléfono: ");
                numeroTelefono = Console.ReadLine().Replace(" ", "");
                if (!EsNumeroDeTelefonoValido(numeroTelefono))
                {
                    Console.WriteLine("El número de teléfono debe contener solo dígitos y tener entre 8 y 12 caracteres (sin contar espacios).");
                }
            } while (!EsNumeroDeTelefonoValido(numeroTelefono));

            return new Diccionario(nombre, apellido, numeroTelefono);
        }

        static bool EsNumeroDeTelefonoValido(string numero)
        {
            return numero.All(char.IsDigit) && numero.Length >= 8 && numero.Length <= 12;
        }

        static void CargarCompras(Diccionario cliente)
        {
            while (true)
            {
                Console.Write("Ingrese una compra (o escriba 'fin' para terminar): ");
                string compra = Console.ReadLine();
                if (compra.ToLower() == "fin") break;

                Console.Write("Ingrese el monto de la compra: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal monto))
                {
                    cliente.AgregarCompra(compra, monto);
                }
                else
                {
                    Console.WriteLine("Monto inválido. Intente de nuevo.");
                }
            }
        }
    }
}
