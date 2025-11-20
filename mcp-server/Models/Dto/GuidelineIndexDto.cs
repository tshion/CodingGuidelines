namespace mcp_server.Models.Dto
{
    /// <summary>
    /// コーディング規約一覧のDTO
    /// </summary>
    /// <param name="UpdateDate">更新日時</param>
    /// <param name="Items">一覧</param>
    public record GuidelineIndexDto(
        string UpdateDate,
        IEnumerable<GuidelineIndexItemDto> Items
    );
}
