namespace Contact.Center.Api.Dtos
{
    public record KpiDto(int KpiId, string KpiName, string KpiType, int KpiMaxGrade, string KpiRadioBtn);
    public record CreateKpiDto(string KpiName, string KpiType, int KpiMaxGrade, string KpiRadioBtn, DateTime CreatedAt);
    public record UpdateKpiDto(string KpiName, string KpiType, int KpiMaxGrade, string KpiRadioBtn, DateTime UpdatedAt);
    public record DeleteKpiDto(int KpiId);

}