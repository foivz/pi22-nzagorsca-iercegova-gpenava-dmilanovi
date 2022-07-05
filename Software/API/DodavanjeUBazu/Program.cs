using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DodavanjeUBazu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lineNumber = 0;
            int i = 0;
            using (SqlConnection conn = new SqlConnection(@"Data source=31.147.204.119\\PISERVER,1433;Initial Catalog=PI2201_DB;trusted_connection=false;User id=PI2201_User;Password=--1HVzr}"))
            {
                conn.Open();
                using (StreamReader reader = new StreamReader(@"C:\Users\nzago\OneDrive\Radna površina\Projekt_PI\BazaPodatakaMobilisis\Podaci za vrijeme\Od22.11Do31.12.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (lineNumber != 0)
                        {
                            var values = line.Split(',');
                            i++;
                            var sql = "INSERT INTO dbo.tmp_metereoloski_podaci VALUES ('" + i + "','" + values[1] + "', '" + values[2] + "','" + values[15] + "', '" + values[16] + "')";
                            var cmd = new SqlCommand();
                            cmd.CommandText = sql;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                        }
                        lineNumber++;
                    }
                }
                conn.Close();
            }
            Console.WriteLine("Products Import Complete");
            Console.ReadLine();
        }
    }
}
