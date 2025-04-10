using Datalogic.Services;
using Datalogic.ViewModels;
using Datalogic.Views;
using Microsoft.Extensions.Logging;

namespace Datalogic
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

            builder.Services.AddSingleton<MonkeysViewModel>();
            builder.Services.AddTransient<MonkeyDetailsViewModel>();

            builder.Services.AddTransient<DetailsPage>();

            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddSingleton<MonkeyService>();
            

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
