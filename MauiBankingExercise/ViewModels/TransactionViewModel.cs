using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiBankingExercise.ViewModels
{
    public class TransactionViewModel : INotifyPropertyChanged
    {
        private readonly BankingDatabaseService _service;

        private ObservableCollection<Transaction> _transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get => _transactions;
            set
            {
                if (_transactions != value)
                {
                    _transactions = value;
                    OnPropertyChanged(nameof(Transactions));
                }
            }
        }

        public TransactionViewModel(int accountId)
        {
            _service = new BankingDatabaseService(App.DbConnection);
            var allTransactions = _service.GetTransactionsByAccountId(accountId);
            Console.WriteLine($"Found {allTransactions.Count} transactions for account {accountId}");
            Transactions = new ObservableCollection<Transaction>(allTransactions);
        }

        // INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

