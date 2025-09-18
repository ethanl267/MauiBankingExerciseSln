using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using MauiBankingExercise.ViewModels;

namespace MauiBankingExercise.Views
{
    public partial class CustomerDashboardPage : ContentPage
    {
        private CustomerDashboardViewModel ViewModel => (CustomerDashboardViewModel) BindingContext;

        public CustomerDashboardPage(CustomerDashboardViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        public async Task InitializeAsync(int customerId)
        {
            ViewModel.CustomerId = customerId;
            await ViewModel.LoadAccountsAsync();
        }

        private async void OnAccountSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Account selectedAccount)
            {
                
                await Navigation.PushAsync(new TransactionPage(selectedAccount.AccountId));
            }

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}


