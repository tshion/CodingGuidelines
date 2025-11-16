namespace llms.Dto
{
    /// <summary>
    /// ガイドラインの索引情報のDTO
    /// </summary>
    /// <param name="UpdateDate">更新日時</param>
    /// <param name="Indexes">索引</param>
    internal record GuidelineIndexDto(
        string UpdateDate,
        List<GuidelineIndexItemDto> Indexes
    );
}
