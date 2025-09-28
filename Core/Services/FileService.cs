namespace ChimeWebApi.Core.Services
{
	public class FileService(IWebHostEnvironment _Env)
	{

		public async Task<string?> Upload(IFormFile file)
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
			return fileName;
		}
	}
}
