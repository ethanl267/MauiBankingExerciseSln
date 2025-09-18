namespace MauiBankingExercise.Views;
using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using MauiBankingExercise.ViewModels;

public partial class TransactionPage : ContentPage
{
    private readonly TransactionViewModel _viewModel;
    private int _accountId;

    public TransactionPage(int accountId)
    {
        InitializeComponent();
        _accountId = accountId;

        BindingContext = new TransactionViewModel(accountId);
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
