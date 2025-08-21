namespace MauiBankingExercise.Views;
using MauiBankingExercise.Services;
using MauiBankingExercise.ViewModels;
using MauiBankingExercise.Models;

public partial class TransactionPage : ContentPage
{
    private BankingDatabaseService _service;
    public TransactionPage(int AccountId)
	{
		InitializeComponent();
        BindingContext = new TransactionViewModel(AccountId);
    }

   
}