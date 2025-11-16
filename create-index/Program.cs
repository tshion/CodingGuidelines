using llms;
using llms.Dto;

var arg = args.FirstOrDefault();
if (string.IsNullOrWhiteSpace(arg))
{
    Console.WriteLine("ガイドラインが配置されているディレクトリーパスを指定してください。");
    return;
}

string guidelineDirPath = Path.GetFullPath(arg);
if (!Directory.Exists(guidelineDirPath))
{
    Console.WriteLine($"指定されたディレクトリーが存在しません: {guidelineDirPath}");
    return;
}

var tasks = Directory.GetFiles(guidelineDirPath, "*.md", SearchOption.AllDirectories)
    .Select(async filePath =>
    {
        var category = Directory.GetParent(filePath)?.Name;
        if (string.IsNullOrWhiteSpace(category)) { return null; }

        List<string> lines = (await File.ReadAllLinesAsync(filePath)).ToList();

        var title = lines.FirstOrDefault()?.TrimStart('#').Trim();
        if (string.IsNullOrWhiteSpace(title)) { return null; }

        int indexEnUs = lines.FindIndex(x => x.StartsWith("### 英訳"));
        if (indexEnUs < 0) { return null; }

        int indexJaJp = lines.FindIndex(x => x.StartsWith("### 日本語"));
        if (indexJaJp < 0) { return null; }

        int indexNote = lines.FindIndex(x => x.StartsWith("## 解説"));
        if (indexNote < 0) { return null; }

        return new GuidelineIndexItemDto(
            category,
            title,
            string.Join(
                Environment.NewLine,
                lines.GetRange(indexEnUs, indexJaJp - indexEnUs)
                    .Where((line, i) => 0 < i && !string.IsNullOrWhiteSpace(line))
            ),
            string.Join(
                Environment.NewLine,
                lines.GetRange(indexJaJp, indexNote - indexJaJp)
                .Where((line, i) => 0 < i && !string.IsNullOrWhiteSpace(line))
            ),
            Path.GetFileName(filePath)
        );
    });

var result = await Task.WhenAll(tasks);
await GuidelineIndexModel.Save(guidelineDirPath, result.Where(x => x != null)!);
Console.WriteLine($"{guidelineDirPath} に出力完了！");
