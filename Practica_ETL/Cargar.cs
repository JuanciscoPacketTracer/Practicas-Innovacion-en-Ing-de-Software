using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Practica_ETL
{
    public static class Cargar
    {
        public static void InsertarClientes(List<Cliente> clientes)
        {
            string connectionString = "Server=127.0.0.1;Database=bdpractica;Uid=root;Pwd=rootroot;";
            if (clientes == null || clientes.Count == 0)
            {
                return;
            }

            const int batchSize = 500;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    int total = clientes.Count;
                    for (int offset = 0; offset < total; offset += batchSize)
                    {
                        var batch = clientes.Skip(offset).Take(batchSize).ToList();

                        var sb = new StringBuilder();
                        sb.Append("INSERT IGNORE INTO Clientes (Id, Nombre, Correo, Edad) VALUES ");

                        for (int i = 0; i < batch.Count; i++)
                        {
                            if (i > 0) sb.Append(",");
                            sb.AppendFormat("(@Id{0}, @Nombre{0}, @Correo{0}, @Edad{0})", i);
                        }

                        string sql = sb.ToString();

                        using (var cmd = new MySqlCommand(sql, conn, transaction))
                        {
                            for (int i = 0; i < batch.Count; i++)
                            {
                                var c = batch[i];
                                cmd.Parameters.AddWithValue($"@Id{i}", c.Id);
                                cmd.Parameters.AddWithValue($"@Nombre{i}", (object)c.Nombre ?? DBNull.Value);
                                cmd.Parameters.AddWithValue($"@Correo{i}", (object)c.Correo ?? DBNull.Value);
                                cmd.Parameters.AddWithValue($"@Edad{i}", c.Edad);
                            }

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {
                                // Ignore batch errors so processing continues for remaining batches
                                // Consider logging the exception in a real application
                            }
                        }
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
