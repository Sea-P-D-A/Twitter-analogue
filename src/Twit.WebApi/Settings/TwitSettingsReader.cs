namespace Twit.WebApi.Settings;

public static class TwitSettingsReader
{
    public static TwitSettings Read(IConfiguration configuration)
    {
        var settings = new TwitSettings();
        
        settings.ConnectionString = configuration.GetConnectionString("DefaultConnection");
        
        return settings;
    }
}