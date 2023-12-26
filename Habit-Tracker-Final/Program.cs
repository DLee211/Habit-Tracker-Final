using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;

namespace Habit_Tracker_Final
{
    class Program
    {
        private static string connectionString = @"Data Source = habit-tracker.db";

        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();
                
                tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS drinking_water(
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Date TEXT, 
                                        Quantity INTEGER)";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }

            Engine.GetUserInput();
        }
    }
}
