/// このリポジトリの設定を転記するスクリプト
///
/// ``` shell
/// dotnet run sync-config.cs
/// ```

string rootDirPath = Path.Join(Directory.GetCurrentDirectory(), "..");
new List<(string, string)>()
{
    new(".github/copilot-instructions.md", ".gemini/GEMINI.md"),
}.ForEach(config =>
{
    string pathFrom = Path.Join(rootDirPath, config.Item1);
    string pathTo = Path.Join(rootDirPath, config.Item2);
    File.Copy(pathFrom, pathTo, true);
    Console.WriteLine($"Sync: {pathFrom} -> {pathTo}");
});

