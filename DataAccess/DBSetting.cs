public sealed class DbSettings
{
    public string Provider { get; set; } = "sqlite";
    public string ConnectionString { get; set; } = "";
    public string SqlFolder { get; set; } = "sql";

    public static DbSettings Load(string path = "appsettings.json")
    {
        var json = File.ReadAllText(path);
        return System.Text.Json.JsonSerializer.Deserialize<DbSettingsWrapper>(json)!.Database;
    }
    private class DbSettingsWrapper { public DbSettings Database { get; set; } = new(); }
}
