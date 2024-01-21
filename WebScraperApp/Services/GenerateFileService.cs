namespace WebScraperApp.Services
{
    public class GenerateFileService
    {
        public async Task GenerateCsvFileAsync(string filePath, string content)
        {
            await File.WriteAllTextAsync(filePath, content);
        }
    }
}
