using MauiBankingExercise.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBankingExercise.ViewModels
{
    public class CustomerSelectionViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }
        public CustomerSelectionViewModel()
        {
            // Initialize with some dummy data
            Customers = new ObservableCollection<Customer>
            {
                new Customer { FirstName = "Jane", LastName = "Smith"},
                new Customer { FirstName = "Bob",  LastName ="Doe"},
            };
        }
    }
}
