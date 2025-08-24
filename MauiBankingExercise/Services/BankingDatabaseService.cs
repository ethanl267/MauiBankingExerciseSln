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

        public Account GetAccountById(int accountId)
        {
            return _db.Table<Account>()
                      .FirstOrDefault(x => x.AccountId == accountId);
        }

        public List<Transaction> GetTransactionsByAccountId(int id)
        {
            return _db.Table<Transaction>().Where(x => x.AccountId == id).ToList();
        }

        public List<Customer> GetAllCustomers()
        {
            return _db.Table<Customer>()
                      .Take(2)   
                      .ToList();
        }

        public void Deposit(int accountId, decimal amount)
        {
            var account = GetAccountById(accountId);
            if (account == null) throw new InvalidOperationException("Account not found");

            account.AccountBalance += amount;
            _db.Update(account);

            _db.Insert(new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                Description = "Deposit",
                TransactionDate = DateTime.Now
            });
        }

        public void Withdraw(int accountId, decimal amount)
        {
            var account = GetAccountById(accountId);
            if (account == null) throw new InvalidOperationException("Account not found");
            if (account.AccountBalance < amount) throw new InvalidOperationException("Insufficient balance");

            account.AccountBalance -= amount;
            _db.Update(account);

            _db.Insert(new Transaction
            {
                AccountId = accountId,
                Amount = -amount,
                Description = "Withdrawal",
                TransactionDate = DateTime.Now
            });
        }

    }
}


