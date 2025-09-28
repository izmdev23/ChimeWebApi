using ChimeWebApi.Database;

namespace ChimeWebApi.Core.Services
{
	public class FileService(IWebHostEnvironment _Env, FileDatabase _FileDb)
	{

		public async Task<string?> AddProductImage(IFormFile file, Guid productId)
		{
			string uploadFolder = Path.Combine(_Env.WebRootPath, "uploads");
			if (Directory.Exists(uploadFolder) == false)
			{
				Directory.CreateDirectory(uploadFolder);
			}

			string fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";
			string filePath = Path.Combine(uploadFolder, fileName);
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			var res = await _FileDb.Images.AddAsync(new()
			{
				Name = fileName,
				ProductId = productId
			});

			if (res == null)
			{
				Console.WriteLine($"Error: Failed to save image {fileName} to database");
				return null;
			}

			return fileName;
		}
	}
}
