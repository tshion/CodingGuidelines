using ModelContextProtocol.Server;
using System.ComponentModel;

namespace mcp_server.Tools;

[McpServerToolType]
public static class CodingGuidelineTools
{
    [McpServerTool, Description("Get a category list of coding guideline.")]
    public static async Task<List<string>> GetCategoryList()
    {
        var guidelinesPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "guidelines");
        if (!Directory.Exists(guidelinesPath))
        {
            return [];
        }

        var categoryFolders = Directory.GetDirectories(guidelinesPath)
            .Select(path => new DirectoryInfo(path).Name)
            .ToList();

        return await Task.FromResult(categoryFolders);
    }
}
