namespace llms.Dto
{
    /// <summary>
    /// ガイドラインの索引情報のDTO
    /// </summary>
    /// <param name="UpdateDate">更新日時</param>
    /// <param name="Indexes">索引</param>
    public record GuidelineIndexDto(
        string UpdateDate,
        GuidelineIndexItemDto[] Indexes
    );
}
