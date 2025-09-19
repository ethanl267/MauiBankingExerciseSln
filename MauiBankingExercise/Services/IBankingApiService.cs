using MauiBankingExercise.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiBankingExercise.Services
{
    public interface IBankingApiService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<List<Account>> GetAccountsAsync();
        Task<List<Account>> GetAccountsByCustomerAsync(int customerId);
        Task<Account> GetAccountByIdAsync(int accountId);
        Task<List<Transaction>> GetTransactionsByAccountIdAsync(int accountId);
        Task CreateTransactionAsync(Transaction transaction);
        Task DepositAsync(int accountId, decimal amount);
        Task WithdrawAsync(int accountId, decimal amount);
    }
}

