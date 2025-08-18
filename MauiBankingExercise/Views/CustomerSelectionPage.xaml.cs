namespace MauiBankingExercise.Views;
using MauiBankingExercise.ViewModels;
using System.Threading.Tasks;

public partial class CustomerSelectionPage : ContentPage
{
    public CustomerSelectionPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.CustomerSelectionViewModel();
    }

    private async void OnCustomerSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Models.Customer customer)
        {
            await DisplayAlert("Customer Selected", $"You chose: {customer.FirstName}", "OK");

            // Pass the selected customer to the dashboard
            await Navigation.PushAsync(new CustomerDashboardPage(customer));

            // Optional: clear selection so the same item can be tapped again
            ((CollectionView)sender).SelectedItem = null;
        }
    }


}