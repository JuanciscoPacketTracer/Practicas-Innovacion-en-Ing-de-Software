using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_ETL
{
    public static class Extract
    {
        public static List<Cliente> LeerCSV(string ruta)
        {

            var clientes = new List<Cliente>();
            var lineas = File.ReadAllLines(ruta);

            for (int i = 1; i < lineas.Length; i++)
            {
                var columnas = lineas[i].Split(',');
                clientes.Add(new Cliente
                {
                    Id = int.Parse(columnas[0]),
                    Nombre = columnas[1],
                    Correo = columnas[2],
                    Edad = int.Parse(columnas[3])
                });
            }
            return clientes;
        }
    }
}
