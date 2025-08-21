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
            var allAccounts = _service.GetAccountsByCustomerId(customerId);
            Accounts = new ObservableCollection<Account>(allAccounts);
        }
    }
}
