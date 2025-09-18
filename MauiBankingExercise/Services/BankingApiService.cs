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
    public class BankingApiService: IBankingApiService
    {
        private readonly HttpClient _httpClient;

        public BankingApiService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("BankingApi");
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("api/Customers")
                   ?? new List<Customer>();
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Account>>("api/Accounts");
        }

        public async Task<List<Account>> GetAccountsByCustomerAsync(int customerId)
        {
            return await _httpClient.GetFromJsonAsync<List<Account>>($"api/Accounts/customer/{customerId}")
                   ?? new List<Account>();
        }


        public async Task<List<Transaction>> GetTransactionsAsync(int accountId)
        {
            return await _httpClient.GetFromJsonAsync<List<Transaction>>($"api/Transactions/{accountId}");
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            await _httpClient.PostAsJsonAsync("api/Transactions", transaction);
        }
    }
}
