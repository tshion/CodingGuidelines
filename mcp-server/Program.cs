using ModelContextProtocol.Server;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithToolsFromAssembly();
var app = builder.Build();

app.MapMcp();

app.Run();


[McpServerToolType]
public static partial class Tools
{
    private static string GetGuidelineDirPath()
    {
        var args = Environment.GetCommandLineArgs().Skip(1);
        var argDirPath = args.FirstOrDefault();
        if (string.IsNullOrWhiteSpace(argDirPath))
        {
            throw new Exception("ガイドラインが配置されているディレクトリーパスを指定してください。");
        }

        string guidelineDirPath = Path.GetFullPath(argDirPath);
        if (!Directory.Exists(guidelineDirPath))
        {
            throw new Exception($"指定されたディレクトリーが存在しません: {guidelineDirPath}");
        }

        return guidelineDirPath;
    }
}
