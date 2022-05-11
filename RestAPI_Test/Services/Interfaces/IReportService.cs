namespace RestAPI_Test.Services.Interfaces
{
    public interface IReportService
    {
        Task<string> GetReportByUserIdAsync(int id);
    }
}
