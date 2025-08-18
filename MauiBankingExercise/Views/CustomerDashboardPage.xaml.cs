using MauiBankingExercise.Models;
using MauiBankingExercise.ViewModels;

namespace MauiBankingExercise.Views;


public partial class CustomerDashboardPage : ContentPage
{
	private Customer _customer;

    public CustomerDashboardPage(Customer selectedCustomer)
    {
        InitializeComponent();

        // Pass the selected customer to your ViewModel
        BindingContext = new CustomerDashBoardViewModel(selectedCustomer);

        // Save reference if you need it later
        _customer = selectedCustomer;

        // Show customer’s name in the page title
        Title = $"{selectedCustomer.FirstName}'s Dashboard";
    }

}
