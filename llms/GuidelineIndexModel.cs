using llms.Dto;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace llms
{
    /// <summary>
    /// ガイドライン索引情報の操作ロジック
    /// </summary>
    public static class GuidelineIndexModel
    {
        private static JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower,
            WriteIndented = true,
        };


        private static string GetJsonPath(string dirPath)
            => Path.Join(dirPath, "index.json");

        /// <summary>
        /// ガイドライン索引情報の読み取り
        /// </summary>
        public static async Task<GuidelineIndexDto?> Load(string dirPath)
        {
            string json = await File.ReadAllTextAsync(GetJsonPath(dirPath));
            return JsonSerializer.Deserialize<GuidelineIndexDto>(json, options);
        }

        /// <summary>
        /// ガイドライン索引情報をdistDirPath にindex.json として出力する
        /// </summary>
        public static Task Save(
            string distDirPath,
            IEnumerable<GuidelineIndexItemDto> indexes
        )
        {
            string json = JsonSerializer.Serialize(
                new GuidelineIndexDto(
                    DateTime.UtcNow.ToString("u"),
                    indexes.ToArray()!
                ),
                options
            );
            return File.WriteAllTextAsync(GetJsonPath(distDirPath), json);
        }
    }
}
