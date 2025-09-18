using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MauiBankingExercise.ViewModels
{
    public class CustomerDashboardViewModel
    {
        private readonly IBankingApiService _apiService;

        // Public property to set the customerId dynamically
        public int CustomerId { get; set; }

        // Observable collection bound to your CollectionView
        public ObservableCollection<Account> Accounts { get; set; } = new ObservableCollection<Account>();

        // Constructor now only takes the API service
        public CustomerDashboardViewModel(IBankingApiService apiService)
        {
            _apiService = apiService;
        }

        // Method to load accounts for the current CustomerId
        public async Task LoadAccountsAsync()
        {
            if (CustomerId == 0) return; // safety check

            var accountsFromApi = await _apiService.GetAccountsByCustomerAsync(CustomerId);
            Accounts.Clear();
            foreach (var acc in accountsFromApi)
                Accounts.Add(acc);
        }
    }
}


