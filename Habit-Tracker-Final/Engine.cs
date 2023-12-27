using System.Globalization;
using Microsoft.Data.Sqlite;

namespace Habit_Tracker_Final;

public class Engine
{
    private static string connectionString = @"Data Source = habit-tracker.db";

    public static bool closeApp = false;

    public static void GetUserInput()
    {
        while (closeApp == false)
        {
            Console.WriteLine("\nMenu");
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("\ntype 0 if you want to close application");
            Console.WriteLine("Type 1 to View records");
            Console.WriteLine("Type 2 to insert record");
            Console.WriteLine("Type 3 to delete record");
            Console.WriteLine("Type 4 to update record");
            Console.WriteLine("--------------------------------------------");

            string command = Console.ReadLine();

            switch (command)
            {
                case "0":
                    closeApp = true;
                    Environment.Exit(0);
                    break;
                 case "1":
                     ViewRecords();
                     break;
                case "2":
                    InsertRecords();
                    break;
                case "3":
                    DeleteRecords();
                    break;
                // case "4":
                //     UpdateRecords();
                //     break;
            }
        }
    }

    private static void ViewRecords()
    {
        Console.Clear();
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText =
                $"SELECT * FROM drinking_water ";

            List<DrinkingWater> tableData = new();

            SqliteDataReader reader = tableCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tableData.Add(
                        new DrinkingWater
                        {
                            Id = reader.GetInt32(0),
                            Date = reader.GetDateTime(1),
                            Quantity = reader.GetInt32(2),
                        }); ;
                }
            }
            else
            {
                Console.WriteLine("No rows found");
            }

            connection.Close();

            Console.WriteLine("------------------------------------------\n");
            foreach (var dw in tableData)
            {
                Console.WriteLine($"{dw.Id} - {dw.Date} - Quantity: {dw.Quantity}");
            }
            Console.WriteLine("------------------------------------------\n");
        }
    }

    private static void DeleteRecords()
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            Console.WriteLine("Enter the id of the row you want to delete:");
            string id = Console.ReadLine();
            int Id;

            while (!int.TryParse(id, out Id))
            {
                Console.WriteLine("Id has to be an integer!");
                id = Console.ReadLine();
            }
            connection.Open();

            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = $"DELETE FROM drinking_water WHERE Id = '{Id}';VACUUM;";

            tableCmd.ExecuteNonQuery();
            
            connection.Close();

        }
    }

    private static void InsertRecords()
    {
        using (var connection = new SqliteConnection(connectionString))
        {

            DateTime date = GetDateInput();

            int quantity = GetQuantityInput();
            
            connection.Open();

            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText = $"INSERT INTO drinking_water(Date,Quantity) VALUES('{date}','{quantity}')";

            tableCmd.ExecuteNonQuery();
            
            connection.Close();
        }
    }

    private static int GetQuantityInput()
    {
        Console.WriteLine("Enter how many glasses that was drank");

        string glasses = Console.ReadLine();
        int quantity;

        while (!int.TryParse(glasses, out quantity))
        {
            Console.WriteLine("Must be an integer!:");
            glasses = Console.ReadLine();
        }

        return quantity;
    }

    private static DateTime GetDateInput()
    {
        Console.WriteLine("Enter Date: dd/MM/yyyy");

        string date = Console.ReadLine();
        DateTime dt;

        while (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,
                   out dt))
        {
            Console.WriteLine("Invalid date, please retry: dd/MM/yyyy");
            date = Console.ReadLine();
        }
    
        return dt;
    }
}

internal class DrinkingWater
{
    public int Id;
    public DateTime Date;
    public int Quantity;
}