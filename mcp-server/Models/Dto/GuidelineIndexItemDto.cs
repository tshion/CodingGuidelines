namespace mcp_server.Models.Dto
{
    /// <summary>
    /// コーディング規約のDTO
    /// </summary>
    /// <param name="Category">カテゴリー</param>
    /// <param name="textEnglish">英訳</param>
    /// <param name="textJapanese">日本語の原案</param>
    /// <param name="Filename">ガイドラインのファイル名</param>
    public record GuidelineIndexItemDto(
        string Category,
        string textEnglish,
        string textJapanese,
        string Filename
    );
}
