using MauiBankingExercise.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

public class CustomerService
{
    private readonly SQLiteConnection _db;

    public CustomerService(SQLiteConnection db)
    {
        _db = db;
    }

    public List<Customer> GetAllCustomers()
    {
        return _db.Table<Customer>().ToList();
    }

    public List<Account> GetAccountsForCustomer(int customerId)
    {
        return _db.Table<Account>().Where(a => a.CustomerId == customerId).ToList();
    }

    public List<Transaction> GetTransactionsForAccount(int accountId)
    {
        return _db.Table<Transaction>().Where(t => t.AccountId == accountId).ToList();
    }
}

