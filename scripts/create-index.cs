/// mcp-server プロジェクト向けにコーディング規約の一覧を生成するスクリプト
/// 
/// ``` shell
/// dotnet run create-index.cs
/// ```

#:property JsonSerializerIsReflectionEnabledByDefault=true

using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

string guidelineDirPath = Path.GetFullPath(
    Path.Join(Environment.CurrentDirectory,  "guidelines")
);
if (!Directory.Exists(guidelineDirPath))
{
    Console.WriteLine($"指定されたディレクトリーが存在しません: {guidelineDirPath}");
    Environment.Exit(1);
    return;
}

string prefixOriginal = "* 原案: ";
string prefixEnglish = "* 英訳: ";
var tasks = Directory.GetFiles(guidelineDirPath, "*.md", SearchOption.AllDirectories)
    .Select(async filePath =>
    {
        var category = Directory.GetParent(filePath)?.Name;
        if (string.IsNullOrWhiteSpace(category)) { return null; }

        List<string> lines = (await File.ReadAllLinesAsync(filePath)).ToList();

        var textOriginal = lines.FirstOrDefault(line => line.StartsWith(prefixOriginal))
            ?.Replace(prefixOriginal, "");
        if (string.IsNullOrWhiteSpace(textOriginal)) { return null; }

        var textEnglish = lines.FirstOrDefault(line => line.StartsWith(prefixEnglish))
            ?.Replace(prefixEnglish, "");
        if (string.IsNullOrWhiteSpace(textEnglish)) { return null; }

        return new
        {
            category,
            textEnglish,
            textJapanese = textOriginal,
            filename = Path.GetFileName(filePath)
        };
    });

var result = await Task.WhenAll(tasks);
string json = JsonSerializer.Serialize(
    new
    {
        updateDate = DateTime.UtcNow.ToString("u"),
        items = result.Where(x => x != null)
    },
    new JsonSerializerOptions()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        WriteIndented = true,
    }
);
await File.WriteAllTextAsync(Path.Join(guidelineDirPath, "index.json"), json);

Console.WriteLine($"{guidelineDirPath} に出力完了！");
