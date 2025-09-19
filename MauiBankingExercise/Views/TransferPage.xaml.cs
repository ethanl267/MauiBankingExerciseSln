using MauiBankingExercise.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using MauiBankingExercise.Services;

namespace MauiBankingExercise.Views
{
    public partial class TransferPage : ContentPage
    {
        private readonly TransactionViewModel _viewModel;

        public TransferPage(int accountId)
        {
            InitializeComponent();

            var apiService = App.Services.GetRequiredService<IBankingApiService>();

            _viewModel = new TransactionViewModel(apiService, accountId);
            BindingContext = _viewModel;

            Task.Run(async () => await _viewModel.LoadTransactionsAsync());
        }

        private void DepositClicked(object sender, EventArgs e)
        {
            if (decimal.TryParse(AmountEntry.Text, out var amount))
            {
                _viewModel.DepositCommand.Execute(amount);
                AmountEntry.Text = string.Empty;
            }
        }

        private void WithdrawClicked(object sender, EventArgs e)
        {
            if (decimal.TryParse(AmountEntry.Text, out var amount))
            {
                _viewModel.WithdrawCommand.Execute(amount);
                AmountEntry.Text = string.Empty;
            }
        }
    }
}







