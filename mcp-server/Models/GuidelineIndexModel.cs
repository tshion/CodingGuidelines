using mcp_server.Models.Dto;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace mcp_server.Models
{
    /// <summary>
    /// コーディング規約のデータ操作ロジック
    /// </summary>
    public static class GuidelineIndexModel
    {
        private static JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };


        private static string GetJsonPath(string dirPath)
            => Path.Join(dirPath, "index.json");

        /// <summary>
        /// コーディング規約一覧の読み取り
        /// </summary>
        public static async Task<GuidelineIndexDto?> Load(string dirPath)
        {
            string json = await File.ReadAllTextAsync(GetJsonPath(dirPath));
            return JsonSerializer.Deserialize<GuidelineIndexDto>(json, options);
        }
    }
}
