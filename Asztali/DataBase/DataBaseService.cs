using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asztali.DataBase
{
    internal class DataBaseService
    {
        private static string connectionString;
        private static string table;
        private static string query_parameters;


        public static void DbConnectionCheck(string connectionString)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Sikeres csatlakozás");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No no");
                Console.WriteLine(ex);
            }
        }



        public static DataTable GetAllData(string tableName, string connectionString)
        {
            //kapcsolodas
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            //kell egy parancs
            using var command = new MySqlCommand("select * from " + tableName, connection);
            //parancs feldolgozasa
            using var reader = command.ExecuteReader();
            //adatszerkezet letrehozasa
            var dataTable = new DataTable();
            //betoltjuk a lekert es feldolgozott adatokat
            dataTable.Load(reader);
            return dataTable;
        }

        
    }
}
