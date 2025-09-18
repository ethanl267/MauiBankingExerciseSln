using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using System.Collections.ObjectModel;

namespace MauiBankingExercise.ViewModels
{
    public class CustomerSelectionViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; } = new();

        private readonly IBankingApiService _apiService;

        // Inject API service instead of local DB
        public CustomerSelectionViewModel(IBankingApiService apiService)
        {
            _apiService = apiService;
            _ = LoadCustomersAsync();
        }

        // Async load method
        public async Task LoadCustomersAsync()
        {

            var customers = await _apiService.GetCustomersAsync();
            Customers.Clear();

            foreach (var c in customers)
                Customers.Add(c);

        }
    }
}

