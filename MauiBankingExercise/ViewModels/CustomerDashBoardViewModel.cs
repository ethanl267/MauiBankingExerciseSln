using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBankingExercise.ViewModels
{
    public class CustomerDashBoardViewModel
    {
        private readonly BankingDatabaseService _service;

        public ObservableCollection<Account> Accounts { get; set; }

        public CustomerDashBoardViewModel(int customerId)
        {
            _service = new BankingDatabaseService(App.DbConnection);

            // Get all accounts from the service
            var allAccounts = _service.GetAccountsByCustomerId(customerId);

            // Assign accounts, not customers
            Accounts = new ObservableCollection<Account>(allAccounts);
        }
    }
}
