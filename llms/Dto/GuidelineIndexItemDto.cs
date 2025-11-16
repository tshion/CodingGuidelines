namespace llms.Dto
{
    /// <summary>
    /// 各ガイドラインの索引情報のDTO
    /// </summary>
    /// <param name="Category">ガイドラインのカテゴリー</param>
    /// <param name="Title">ガイドラインのタイトル</param>
    /// <param name="EnUs">ガイドラインの英訳</param>
    /// <param name="JaJp">ガイドラインの日本語の原案</param>
    /// <param name="Filename">ガイドラインのファイル名</param>
    public record GuidelineIndexItemDto(
        string Category,
        string Title,
        string EnUs,
        string JaJp,
        string Filename
    );
}
