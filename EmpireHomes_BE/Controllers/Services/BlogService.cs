using EmpireHomes_BE.Controllers.Services.Azure;

namespace EmpireHomes_BE.Controllers.Services
{
    public class BlogService
    {

        private readonly string[] validExtensions = { ".jpg", ".jpeg", ".png" };

        public async Task<string> uploadImage(IFormFile file, IBlobStorage storage, string connectionString, string container)
        {
            if (file == null) throw new ArgumentNullException("Image file is required");

            var extension = Path.GetExtension(file.FileName);
            if (!Array.Exists(validExtensions, element => element == extension)) throw new InvalidDataException("Invalid file extension");

            Stream stream = file.OpenReadStream();
            await storage.UploadDocument(connectionString, container, file.FileName, stream);
            return $"https://empirehomesstorage.blob.core.windows.net/{container}/{file.FileName}";

        }
    }
}
