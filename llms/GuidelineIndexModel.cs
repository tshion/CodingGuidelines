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
                    indexes.ToList()!
                ),
                options
            );
            return File.WriteAllTextAsync(Path.Join(distDirPath, "index.json"), json);
        }
    }
}
