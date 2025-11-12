using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace mcp_server.Tools;

[McpServerToolType]
public static class CodingGuidelineTools
{
    private static string GuidelinesDirPath => Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "guidelines");


    [McpServerTool, Description("Get a category list of coding guideline.")]
    public static async Task<List<string>> GetCategoryList()
    {
        if (!Directory.Exists(GuidelinesDirPath))
        {
            return [];
        }

        var categoryFolders = Directory.GetDirectories(GuidelinesDirPath)
            .Select(path => new DirectoryInfo(path).Name)
            .ToList();

        return await Task.FromResult(categoryFolders);
    }

    [McpServerTool, Description("Search coding guideline.")]
    public static async Task<List<string>> SearchGuideline(
        [Description("Category name for coding guideline.")] string category = "",
        [Description("Search keyword.")] string keyword = ""
        )
    {
        var path = !string.IsNullOrWhiteSpace(category)
            ? Path.Combine(GuidelinesDirPath, category)
            : GuidelinesDirPath;

        var query = Directory.GetFiles(path, "*.md", SearchOption.AllDirectories)
            .Select(async filePath =>
            {
                string content = await File.ReadAllTextAsync(filePath);
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    return content;
                }
                else
                {
                    return content.Contains(keyword, StringComparison.OrdinalIgnoreCase) ? content : null;
                }
            });
        var result = await Task.WhenAll(query);
        return result.Where(content => content != null).ToList()!;
    }
}
