using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MauiBankingExercise.ViewModels
{
    public class TransactionViewModel : INotifyPropertyChanged
    {

        private readonly BankingDatabaseService _service;
        private readonly int _accountId;

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                if (_selectedAccount != value)
                {
                    _selectedAccount = value;
                    OnPropertyChanged(nameof(SelectedAccount));
                }
            }
        }

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

        public ICommand DepositCommand { get; }
        public ICommand WithdrawCommand { get; }

        public TransactionViewModel(int accountId)
        {
            _service = new BankingDatabaseService(App.DbConnection);

            _accountId = accountId; 

            SelectedAccount = _service.GetAccountById(accountId);

            if (SelectedAccount == null)
            {
                Console.WriteLine($" No account found with ID {accountId}");
            }
            else
            {
                Console.WriteLine($" Loaded account {SelectedAccount.AccountNumber}, Balance: {SelectedAccount.AccountBalance}");
            }

            var allTransactions = _service.GetTransactionsByAccountId(accountId);
            Console.WriteLine($"Found {allTransactions.Count} transactions for account {accountId}");

            Transactions = new ObservableCollection<Transaction>(allTransactions);

            DepositCommand = new Command<decimal>(Deposit);
            WithdrawCommand = new Command<decimal>(Withdraw);
        }


        private void Deposit(decimal amount)
        {
            _service.Deposit(_accountId, amount);

            RefreshData();
        }

        private void Withdraw(decimal amount)
        {
            try
            {
                _service.Withdraw(_accountId, amount);

                RefreshData();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"❌ {ex.Message}");
                
            }
        }

        private void RefreshData()
        {
            SelectedAccount = _service.GetAccountById(_accountId);
            OnPropertyChanged(nameof(SelectedAccount));

            Transactions = new ObservableCollection<Transaction>(_service.GetTransactionsByAccountId(_accountId));
            OnPropertyChanged(nameof(Transactions));
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

