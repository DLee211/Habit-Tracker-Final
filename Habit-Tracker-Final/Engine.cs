using Microsoft.Data.Sqlite;

namespace habit_tracker;

public class Engine
{
    private static string connectionString = @"Data Source = habit-tracker.db";

    public static void GetUserInput()
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
                Environment.Exit(0);
                break;
            // case "1":
            //     ViewRecords();
            //     break;
            case "2":
                InsertRecords();
                break;
            // case "3":
            //     DeleteRecords();
            //     break;
            // case "4":
            //     UpdateRecords();
            //     break;
        }
    }

    private static void InsertRecords()
    {
        using (var connection = new SqliteConnection(connectionString))
        {

            string date = GetDateInput();

            int quantity = GetQuantityInput();
            
            connection.Open();

            var tableCmd = connection.CreateCommand();

            //tableCmd.CommandText = "INSERT INTO drinking_water (CURRENT_DATE, Q)";
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
            Console.ReadLine();
        }

        return quantity;
    }

    private static string GetDateInput()
    {
        Console.WriteLine("Enter Date: dd/MM/yyyy");

        string date = Console.ReadLine();

        while (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,
                   out DateTime dt))
        {
            Console.WriteLine("Invalid date, please retry: dd/MM/yyyy");
            date = Console.ReadLine();
        }

        return date;
    }
}