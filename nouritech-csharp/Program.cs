using System;
using MySqlConnector;

namespace NouriTech.InventoryControl
{
    class Program
    {
        static void Main(string[] args)
        {
string connString = "Server=127.0.0.1;Port=3306;Database=food_waste_analytics;Uid=sa;Pwd=sasa;SslMode=None;";
            Console.WriteLine("=== NOURITECH FOODTECH - INVENTORY CONTROL SYSTEM (ADO.NET) ===");

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    Console.WriteLine("[OK] Conexión ADO.NET establecida correctamente a MySQL en Docker.\n");

                    string query = "SELECT id, ingredient_name, quantity_kg, reason, discarded_at FROM food_wastes;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("ID | INSUMO           | CANTIDAD (KG) | CAUSA                | FECHA");
                        Console.WriteLine("-------------------------------------------------------------------------");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["id"],-2} | {reader["ingredient_name"],-16} | {reader["quantity_kg"],-13} | {reader["reason"],-20} | {reader["discarded_at"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Error de conexión ADO.NET: {ex.Message}");
            }
        }
    }
}