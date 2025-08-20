using MauiBankingExercise.Models;
using MauiBankingExercise.Services;

namespace MauiBankingExercise.Views
{
    public partial class CustomerDashboardPage : ContentPage
    {
        private Customer _customer;
        private CustomerService _service;

        public CustomerDashboardPage(int customerId)
        {
            InitializeComponent();

            _service = new CustomerService(App.DbConnection);

            // Fetch the customer from database
            _customer = _service.GetAllCustomers()
                                .FirstOrDefault(c => c.CustomerId == customerId)
                        ?? throw new Exception("Customer not found");

            BindingContext = this; // optional, or create a ViewModel
        }
    }
}

