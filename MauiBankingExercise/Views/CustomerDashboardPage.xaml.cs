using MauiBankingExercise.Models;

namespace MauiBankingExercise.Views;


public partial class CustomerDashboardPage : ContentPage
{
	private Customer _customer;

	public CustomerDashboardPage(Customer customer)
	{
        InitializeComponent();
        _customer = customer;

        // Example: show customer’s name in the page title
        Title = $"{customer.FirstName}'s Dashboard";
    } 
}
