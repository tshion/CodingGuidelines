/// コーディング規約を追加するスクリプト
///
/// ``` shell
/// dotnet run add-guideline.cs "${カテゴリー}" "${ファイル名}"
/// ```

var category = args.ElementAtOrDefault(0)?.Trim();
var filename = args.ElementAtOrDefault(1)?.Trim();
if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(filename))
{
    Console.WriteLine($"パラメータを設定してください -> category: {category}, filename: {filename}");
    Environment.Exit(1);
    return;
}

string dirPath = Path.Join(Environment.CurrentDirectory, "..", "guidelines", category);
if (!Directory.Exists(dirPath))
{
    Directory.CreateDirectory(dirPath);
}

await File.WriteAllTextAsync(
    Path.Join(dirPath, $"{filename}.md"),
    @"* 原案:
* 英訳:
___

## 解説

## 参考文献
    ".Trim()
);
