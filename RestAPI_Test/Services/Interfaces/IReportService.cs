namespace RestAPI_Test.Services.Interfaces
{
    public interface IReportService
    {
        Task<bool> GetReportByUserIdAsync(int id);
    }
}
