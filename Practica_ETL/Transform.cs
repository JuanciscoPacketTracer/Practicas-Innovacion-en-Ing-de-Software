using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_ETL
{
    public static class Transform
    {
        public static List<Cliente> LimpiarDatos(List<Cliente> clientes)
        {
            return clientes
                .Where(c => c.Edad >= 18)
                .Select(c => new Cliente
                {
                    Id = c.Id,
                    Nombre = c.Nombre.Trim().ToUpper(),
                    Correo = c.Correo.Trim().ToLower(),
                    Edad = c.Edad
                }).ToList();
        }
    }
}
