using MauiBankingExercise.ViewModels;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Threading.Tasks;
using MauiBankingExercise.Models;


namespace MauiBankingExercise.Views
{
    public partial class CustomerSelectionPage : ContentPage
    {
        public CustomerSelectionPage(CustomerSelectionViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCustomer = e.CurrentSelection.FirstOrDefault() as Customer;
            if (selectedCustomer != null)
            {
                // Resolve ViewModel from DI
                var viewModel = App.Services.GetRequiredService<CustomerDashboardViewModel>();


                // Set the CustomerId property
                viewModel.CustomerId = selectedCustomer.CustomerId;

                // Load accounts for this customer
                await viewModel.LoadAccountsAsync();

                // Push the page with the ViewModel
                await Navigation.PushAsync(new CustomerDashboardPage(viewModel));
            }

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}





