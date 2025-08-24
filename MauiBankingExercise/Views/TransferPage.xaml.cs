using MauiBankingExercise.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiBankingExercise.Views
{
    public partial class TransferPage : ContentPage
    {
        private readonly TransactionViewModel _viewModel;

        public TransferPage(int accountId)
        {
            InitializeComponent();

            
            _viewModel = new TransactionViewModel(accountId);
            BindingContext = _viewModel;
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





