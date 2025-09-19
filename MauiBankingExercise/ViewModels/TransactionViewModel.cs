using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiBankingExercise.ViewModels
{
    public class TransactionViewModel : INotifyPropertyChanged
    {
        private readonly IBankingApiService _apiService;
        private readonly int _accountId;

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Transaction> Transactions { get; } = new();

        public ICommand DepositCommand { get; }
        public ICommand WithdrawCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TransactionViewModel(IBankingApiService apiService, int accountId)
        {
            _apiService = apiService;
            _accountId = accountId;
            Task.Run(async () => await LoadTransactionsAsync());

            DepositCommand = new Command<decimal>(async (amount) => await DepositAsync(amount));
            WithdrawCommand = new Command<decimal>(async (amount) => await WithdrawAsync(amount));
        }

        public async Task LoadTransactionsAsync()
        {
            SelectedAccount = await _apiService.GetAccountByIdAsync(_accountId);

            var txns = await _apiService.GetTransactionsByAccountIdAsync(_accountId);

            Transactions.Clear();
            foreach (var txn in txns)
                Transactions.Add(txn);
        }

        private async Task DepositAsync(decimal amount)
        {
            if (amount <= 0) return;

            await _apiService.DepositAsync(_accountId, amount);

            SelectedAccount.AccountBalance += amount;

            await LoadTransactionsAsync();
        }

        private async Task WithdrawAsync(decimal amount)
        {
            if (amount <= 0) return;
            if (SelectedAccount.AccountBalance < amount) return;

            await _apiService.WithdrawAsync(_accountId, amount);

            SelectedAccount.AccountBalance -= amount;

            await LoadTransactionsAsync();
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}








