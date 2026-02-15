namespace Twit.WebApi.Settings;

public class TwitSettings
{
    public string ConnectionString { get; set; }
    public int MaxPostLength { get; set; } = 1000;
    public int MaxCommentLength { get; set; } = 500;
    public int PageSize { get; set; } = 20;
}