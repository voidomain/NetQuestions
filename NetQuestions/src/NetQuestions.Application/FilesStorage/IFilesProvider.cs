namespace NetQuestions.Application.FilesStorage;

public interface IFilesProvider
{
    public Task<string> UploadAsync(Stream stream, string key, string bucket);
}