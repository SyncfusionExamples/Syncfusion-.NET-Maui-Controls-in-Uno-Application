using Syncfusion.Maui.Core.Hosting;
namespace SyncfusionMauiApp;

public static class AppBuilderExtensions
{
    public static MauiAppBuilder UseMauiControls(this MauiAppBuilder builder) =>
        builder
        .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("SyncfusionMauiApp/Assets/Fonts/OpenSansRegular.ttf", "OpenSansRegular");
                fonts.AddFont("SyncfusionMauiApp/Assets/Fonts/OpenSansSemibold.ttf", "OpenSansSemibold");
            });
}
