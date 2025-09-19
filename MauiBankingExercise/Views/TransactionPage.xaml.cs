using MauiBankingExercise.Models;
using MauiBankingExercise.ViewModels;

namespace MauiBankingExercise.Views
{
    public partial class TransactionPage : ContentPage
    {
        private readonly TransactionViewModel _viewModel;

        public TransactionPage(Account account)
        {
            InitializeComponent();

            _viewModel = App.Services.GetRequiredService<TransactionViewModel>();
            _viewModel.SelectedAccount = account;

            BindingContext = _viewModel;
            _ = _viewModel.LoadTransactionsAsync();
        }

        private async void GoToTransferPageClicked(object sender, EventArgs e)
        {
            if (_viewModel.SelectedAccount == null)
            {
                await DisplayAlert("Error", "No account selected.", "OK");
                return;
            }

            await Navigation.PushAsync(new TransferPage(_viewModel.SelectedAccount.AccountId));

        }
    }
}

