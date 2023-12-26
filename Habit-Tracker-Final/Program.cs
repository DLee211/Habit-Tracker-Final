using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;

namespace habit_tracker
{
    class Program
    {
        private static string connectionString = @"Data Source = habit-tracker.db";

        static void Main(string[] args)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                connection.Close();
            }
        }
    }
}
