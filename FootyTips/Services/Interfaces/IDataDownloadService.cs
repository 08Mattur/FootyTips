using FootyTips.Models.DTOs;

namespace FootyTips.Services.Interfaces
{
    public interface IDataDownloadService
    {
        public Task<bool> Download(string url);

        public Task<List<FootballDataRAW>> TestFile(string url);
    }
}
