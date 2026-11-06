using fushcasinaS5A.Repositories;
using fushcasinaS5A.Utils;
using Microsoft.Extensions.Logging;

namespace fushcasinaS5A
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

            // Obtener la ruta de la base de datos
            string dbPath = FileAccessHelper.GetLocalFilePath("uisrael_db");
            builder.Services.AddSingleton<PersonRepository>(s => ActivatorUtilities.CreateInstance<PersonRepository>(s, dbPath));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
