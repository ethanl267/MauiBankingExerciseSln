using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using MauiBankingExercise.ViewModels;

namespace MauiBankingExercise.Views
{
    public partial class CustomerDashboardPage : ContentPage
    {
      //  private Customer _customer;
        private BankingDatabaseService _service;

        public CustomerDashboardPage(int customerId)
        {
            InitializeComponent();
            BindingContext = new CustomerDashBoardViewModel(customerId);

          //  _service = new BankingDatabaseService(App.DbConnection);

          /*  // Fetch the customer from database
            _customer = _service.GetAllCustomers()
                                .FirstOrDefault(c => c.CustomerId == customerId)
                        ?? throw new Exception("Customer not found");
          */
         
        }

        private async void OnAccountSelected(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Account clicked!"); // Debug line

            if (e.CurrentSelection.FirstOrDefault() is Account selectedAccount)
            {
                Console.WriteLine($"Navigating to account {selectedAccount.AccountId}");
                await Navigation.PushAsync(new TransactionPage(selectedAccount.AccountId));
            }

    ((CollectionView)sender).SelectedItem = null;
        }


    }
}

