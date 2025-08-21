using MauiBankingExercise.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace MauiBankingExercise.Services
{
    public class BankingDatabaseService
    {
        private readonly SQLiteConnection _db;

        public BankingDatabaseService(SQLiteConnection db)
        {
            _db = db;
        }

        public List<Account> GetAllAccounts()
        {
            return _db.Table<Account>().ToList();
        }

        public List<Account> GetAccountsByCustomerId(int id)
        {
            return _db.Table<Account>().Where(x => x.CustomerId == id).ToList();
        }

        public List<Customer> GetAllCustomers()
        {
            return _db.Table<Customer>()
                      .Take(2)   
                      .ToList();
        }
    }
}


