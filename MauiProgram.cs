using Microsoft.Extensions.Logging;

namespace HybridMobileGame
{
    //Main setup logic for the Maui app.
    public static class MauiProgram
    {
        //Build and configure your Maui app.
        public static MauiApp CreateMauiApp()
        {
            //Instance for configuring the app before creating the final app instance
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("LeftHandLeftPin.ttf", "LPin"); //New font!
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
