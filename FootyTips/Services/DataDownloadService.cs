using FootyTips.Models.DTOs;
using FootyTips.Services.Interfaces;

namespace FootyTips.Services
{
    public class DataDownloadService : IDataDownloadService
    {
        IFootballDataTranslator _dataTranslator;

        public DataDownloadService(IFootballDataTranslator footballDataTranslator)
        {
            _dataTranslator = footballDataTranslator;
        }

        public async Task<bool> Download(string url)
        {
            List<string> dataRows = await RetrieveRowsFromCSV(url);

            var rawData = CreateRawObjects(dataRows);

            if (rawData.Count > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<List<FootballDataRAW>> TestFile(string url)
        {
            List<string> dataRows = await RetrieveRowsFromCSV(url);

            return CreateRawObjects(dataRows);
        }

        private async Task<List<string>> RetrieveRowsFromCSV(string url)
        {
            var dataRows = new List<string>();

            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            using (var content = response.Content)
            using (var stream = (MemoryStream)await content.ReadAsStreamAsync())
            using (var sr = new StreamReader(stream))
            {
                while (!sr.EndOfStream)
                {
                    var data = sr.ReadLine();
                    if (!string.IsNullOrEmpty(data))
                    {
                        dataRows.Add(data);
                    }
                }
            }

            return dataRows;
        }

        private List<FootballDataRAW> CreateRawObjects (List<string> dataRows)
        {
            var rawData = new List<FootballDataRAW>();

            dataRows.RemoveAt(0);

            foreach (var row in dataRows)
            {
                rawData.Add(_dataTranslator.TranslateString(row));
            }

            return rawData;
        }
    }
}
