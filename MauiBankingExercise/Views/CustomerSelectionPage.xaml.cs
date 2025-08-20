using MauiBankingExercise.ViewModels;
using Microsoft.Maui.Controls;
using System.Linq;
using System.Threading.Tasks;
using MauiBankingExercise.Models;


namespace MauiBankingExercise.Views
{
    public partial class CustomerSelectionPage : ContentPage
    {
        public CustomerSelectionPage()
        {
            InitializeComponent();
            BindingContext = new CustomerSelectionViewModel();
        }

        private async void CustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCustomer = e.CurrentSelection.FirstOrDefault() as Customer;
            if (selectedCustomer != null)
            {
                await Navigation.PushAsync(new CustomerDashboardPage(selectedCustomer.CustomerId));
            }
        }
    }
}





