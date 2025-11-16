using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1050:名前空間で型を宣言します", Justification = "<保留中>")]
public static partial class Tools
{
    [McpServerTool, Description("Get the full text of coding guidelines.")]
    public static async Task<string> GetGuidelineDetail(
        [Description("Coding guidelines category.")] string category,
        [Description("File name for coding guidelines.")] string fileName
    )
    {
        try
        {
            var dirPath = GetGuidelineDirPath();
            var fullText = await File.ReadAllTextAsync(Path.Join(dirPath, category, fileName));
            var result = new
            {
                category,
                fileName,
                fullText
            };
            var json = JsonSerializer.Serialize(result);
            return json;
        }
        catch
        {
            return "Not found";
        }
    }
}
