using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    public class Diccionario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroTelefono { get; set; }
        public decimal TotalGastado { get; set; }
        public List<string> Compras { get; set; }

        public Diccionario(string nombre, string apellido, string numeroTelefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            NumeroTelefono = numeroTelefono;
            TotalGastado = 0;
            Compras = new List<string>();
        }

        public void AgregarCompra(string compra, decimal monto)
        {
            Compras.Add(compra);
            TotalGastado += monto;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} {Apellido}\nNúmero de Teléfono: {NumeroTelefono}\nTotal Gastado: {TotalGastado:C}\nCompras: {string.Join(", ", Compras)}";
        }
    }
}
