namespace habit_tracker;

public class Engine
{
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
            // case "2":
            //     InsertRecords();
            //     break;
            // case "3":
            //     DeleteRecords();
            //     break;
            // case "4":
            //     UpdateRecords();
            //     break;
        }
    }
}