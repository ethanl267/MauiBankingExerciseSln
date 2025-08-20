using SQLite;
using MauiBankingExercise.Views;
using MauiBankingExercise.Services;

namespace MauiBankingExercise
{
    public partial class App : Application
    {
        public static SQLiteConnection DbConnection;

        public App()
        {
            InitializeComponent();

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "banking.db");
            DbConnection = new SQLiteConnection(dbPath);

            BankingSeeder.Seed(DbConnection);

            MainPage = new NavigationPage(new CustomerSelectionPage());
        }

    }
}