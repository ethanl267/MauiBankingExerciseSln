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
        public ObservableCollection<Account> Accounts { get; set; }

        public CustomerDashBoardViewModel(Customer customer)
        {
            // Initialize with some dummy data
            Accounts = new ObservableCollection<Account>
            {
                new Account {  AccountNumber = "111111", AccountBalance = 2500.50m },
                new Account { AccountNumber = "222222", AccountBalance = 3500.75m },
            };

        }
    }
}
