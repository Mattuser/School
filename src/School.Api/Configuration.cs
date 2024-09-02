namespace School.Api;

public static class Configuration
{
    public const int DEFAULTSTATUSCODE = 200;
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 25;
    public static string ConnectionString { get; set; } = string.Empty;
 
}
