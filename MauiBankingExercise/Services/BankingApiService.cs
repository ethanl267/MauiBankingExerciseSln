using MauiBankingExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiBankingExercise.Services
{
    public class BankingApiService : IBankingApiService
    {
        private readonly HttpClient _httpClient;

        public BankingApiService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BankingApi");
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("api/Customers") ?? new List<Customer>();
        }

        public async Task<List<Account>> GetAccountsAsync()
            => await _httpClient.GetFromJsonAsync<List<Account>>("api/Accounts") ?? new List<Account>();

        public async Task<List<Account>> GetAccountsByCustomerAsync(int customerId)
            => await _httpClient.GetFromJsonAsync<List<Account>>($"api/Accounts/customer/{customerId}") ?? new List<Account>();

        public async Task<Account> GetAccountByIdAsync(int accountId)
            => await _httpClient.GetFromJsonAsync<Account>($"api/Accounts/{accountId}") ?? new Account();

        public async Task<List<Transaction>> GetTransactionsByAccountIdAsync(int accountId)
            => await _httpClient.GetFromJsonAsync<List<Transaction>>($"api/Transactions/{accountId}") ?? new List<Transaction>();

        public async Task CreateTransactionAsync(Transaction transaction)
            => await _httpClient.PostAsJsonAsync("api/Transactions", transaction);


        private async Task<TransactionType> GetTransactionTypeByNameAsync(string typeName)
        {
            var types = await _httpClient.GetFromJsonAsync<List<TransactionType>>("api/TransactionTypes")
                        ?? new List<TransactionType>();

            var type = types.FirstOrDefault(t => t.Name.Equals(typeName, StringComparison.OrdinalIgnoreCase));
            if (type == null)
                throw new Exception($"TransactionType '{typeName}' not found in API.");

            return type;
        }


        public async Task DepositAsync(int accountId, decimal amount)
        {
            var depositType = await GetTransactionTypeByNameAsync("Deposit");

            var transaction = new Transaction
            {
                AccountId = accountId,
                TransactionType = depositType,
                Amount = amount,
                TransactionDate = DateTime.Now
            };

            await CreateTransactionAsync(transaction);
        }


        public async Task WithdrawAsync(int accountId, decimal amount)
        {
            var withdrawType = await GetTransactionTypeByNameAsync("Withdraw");

            var transaction = new Transaction
            {
                AccountId = accountId,
                TransactionType = withdrawType,
                Amount = amount,
                TransactionDate = DateTime.Now
            };

            await CreateTransactionAsync(transaction);
        }
    }
}
