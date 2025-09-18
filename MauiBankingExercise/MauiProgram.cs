using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using MauiBankingExercise.Models;
using MauiBankingExercise.Services;
using MauiBankingExercise.ViewModels;
using MauiBankingExercise.Views;

using Microsoft.Extensions.Logging;

namespace MauiBankingExercise
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddHttpClient("BankingApi", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7258");
            });

            // Register your API service
            builder.Services.AddScoped<IBankingApiService, BankingApiService>();

            // Register ViewModels
            builder.Services.AddTransient<CustomerSelectionViewModel>();
            builder.Services.AddTransient<CustomerDashboardViewModel>();

            // Register Pages
            builder.Services.AddTransient<CustomerSelectionPage>();
            builder.Services.AddTransient<CustomerDashboardPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

           var app = builder.Build();
            return app;
        }
    }
}
