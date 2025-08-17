namespace MauiBankingExercise.Views;
using MauiBankingExercise.ViewModels;

public partial class CustomerSelectionPage : ContentPage
{
	public CustomerSelectionPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.CustomerSelectionViewModel();
    }

    private void OnCustomerSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Models.Customer customer)
        {
            DisplayAlert("Customer Selected", $"You chose: {customer.FirstName}", "OK");
        }
    }
}