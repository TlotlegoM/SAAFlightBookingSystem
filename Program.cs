using System;
using System.Data.SqlClient;

namespace SAAFlightBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                @"Server=DESKTOP-VA3GND2;
                  Database=SAAFlightBookingDB;
                  Trusted_Connection=True;
                  TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    connection.Open();

                    Console.WriteLine(
                        "Database connection successful!");
                    Console.WriteLine();

                    string query =
                        "SELECT PassengerID, FirstName, LastName, Email, Phone, PassportNumber FROM Passengers";

                    using (SqlCommand command =
                           new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader =
                               command.ExecuteReader())
                        {
                            Console.WriteLine("Passenger Records");
                            Console.WriteLine(
                                "--------------------------------");

                            while (reader.Read())
                            {
                                Console.WriteLine(
                                    $"ID: {reader["PassengerID"]}");

                                Console.WriteLine(
                                    $"Name: {reader["FirstName"]} {reader["LastName"]}");

                                Console.WriteLine(
                                    $"Email: {reader["Email"]}");

                                Console.WriteLine(
                                    $"Phone: {reader["Phone"]}");

                                Console.WriteLine(
                                    $"Passport: {reader["PassportNumber"]}");

                                Console.WriteLine(
                                    "--------------------------------");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Database connection failed.");

                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}