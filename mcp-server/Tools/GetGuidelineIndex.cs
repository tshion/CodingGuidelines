using llms;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1050:名前空間で型を宣言します", Justification = "<保留中>")]
public static partial class Tools
{
    [McpServerTool, Description("Get a list of coding guidelines.")]
    public static async Task<IEnumerable<string>> GetGuidelineList()
    {
        try
        {
            var dto = await GuidelineIndexModel.Load(GetGuidelineDirPath());
            return dto!.Indexes
                .Select(x => new
                {
                    category = x.Category,
                    fileName = x.Filename,
                    textEnglish = x.EnUs,
                    textJapanese = x.JaJp
                })
                .Select(x => JsonSerializer.Serialize(x));
        }
        catch
        {
            return ["Not found"];
        }
    }
}
