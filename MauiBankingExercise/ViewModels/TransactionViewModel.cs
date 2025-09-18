using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiBankingExercise.ViewModels
{
    public class TransactionViewModel : INotifyPropertyChanged
    {
        private readonly IBankingApiService _apiService;
        private readonly int _accountId;

        public ObservableCollection<Transaction> Transactions { get; } = new();

        public event PropertyChangedEventHandler PropertyChanged;

        public TransactionViewModel(IBankingApiService apiService, int accountId)
        {
            _apiService = apiService;
            _accountId = accountId;
        }

        public async Task LoadTransactionsAsync()
        {
            var txns = await _apiService.GetTransactionsByAccountIdAsync(_accountId);

            Transactions.Clear();
            foreach (var txn in txns)
                Transactions.Add(txn);
        }
    }
}



