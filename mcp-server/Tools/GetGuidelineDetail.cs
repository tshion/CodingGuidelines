using llms;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1050:名前空間で型を宣言します", Justification = "<保留中>")]
public static partial class Tools
{
    [McpServerTool, Description("Get the full text of the specified coding guideline.")]
    public static async Task<IEnumerable<string>> GetGuidelineDetail(
        [Description("The guideline written in English.")] string enUs
    )
    {
        try
        {
            var dirPath = GetGuidelineDirPath();
            var dto = await GuidelineIndexModel.Load(dirPath);
            var tasks = dto!.Indexes
                .Where(x => x.EnUs == enUs)
                .Select(async x =>
                {
                    var fullText = await File.ReadAllTextAsync(Path.Join(dirPath, x.Filename));
                    return new { x.Category, fullText };
                });
            var result = await Task.WhenAll(tasks);
            return result.Select(x => JsonSerializer.Serialize(x));
        }
        catch
        {
            return ["Not found"];
        }
    }
}
