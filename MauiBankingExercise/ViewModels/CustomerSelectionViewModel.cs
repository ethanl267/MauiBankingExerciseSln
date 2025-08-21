using MauiBankingExercise.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiBankingExercise.Services;

namespace MauiBankingExercise.ViewModels
{
    public class CustomerSelectionViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
        private BankingDatabaseService _service;

        public CustomerSelectionViewModel()
        {
            _service = new BankingDatabaseService(App.DbConnection);
            var allCustomers = _service.GetAllCustomers();
            Customers = new ObservableCollection<Customer>(allCustomers);
        }
    }
}
