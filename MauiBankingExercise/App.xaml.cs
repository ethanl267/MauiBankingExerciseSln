using MauiBankingExercise.Views;

namespace MauiBankingExercise
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            Services = serviceProvider;

            // Start with CustomerSelectionPage from DI
            MainPage = new NavigationPage(
                Services.GetRequiredService<CustomerSelectionPage>()
            );
        }
    }
}
