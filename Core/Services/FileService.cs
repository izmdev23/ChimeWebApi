using ChimeWebApi.Core.Enums;
using ChimeWebApi.Core.Objects;
using ChimeWebApi.Database;
using ChimeWebApi.Models.Request;

namespace ChimeWebApi.Core.Services
{
	public class FileService(IWebHostEnvironment _HostEnv, FileDatabase _FileDb)
	{
		private static readonly string ImageFolder = "images";

		public async Task<Response<string?>> AddProductVariantImage(ImageVariantDto dto)
		{
			string uploadFolder = Path.Combine([_HostEnv.WebRootPath, ImageFolder, dto.ProductId.ToString(), dto.VariantId.ToString()]);
			if (!Directory.Exists(uploadFolder))
			{
				Directory.CreateDirectory(uploadFolder);
			}
			Console.WriteLine(Directory.Exists(uploadFolder));
			string fileId = Guid.NewGuid().ToString().Replace("-", "");
			string date = DateTime.UtcNow.ToString()
				.Replace(" ", "")
				.Replace("\\", "")
				.Replace("/", "")
				.Replace(":", "")
				.Replace("-", "");
			string filename = $"{fileId}{date}{Path.GetExtension(dto.Image.FileName)}";
			string finalPath = Path.Combine(uploadFolder, filename);
			using (var stream = new FileStream(finalPath, FileMode.Create))
			{
				await dto.Image.CopyToAsync(stream);
				await _FileDb.ProductImages.AddAsync(new()
				{
					Name = filename,
					ProductId = dto.ProductId,
					VariantId = dto.VariantId
				});
				await _FileDb.SaveChangesAsync();
			}
			return new()
			{
				Code = ResponseCode.Success,
				Message = $"{filename} uploaded",
				Source = nameof(FileService),
				Data = filename
			};
		}



		public string GetImageVariantFolder(Guid productId, Guid variantId)
		{
			string path = Path.Combine([_HostEnv.WebRootPath, ImageFolder, productId.ToString(), variantId.ToString()]);
			if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
			return path;
		}

		public string? GetImageVariant(Guid productId, Guid variantId, string filename)
		{
			var file = Path.Combine(GetImageVariantFolder(productId, variantId), filename);
			var path = GetImageVariantFolder(productId, variantId);
			var f = Directory.GetFiles(path);
			var filePath = Directory.GetFiles(path).Where(e => e == file).FirstOrDefault(string.Empty);
			if (filePath == string.Empty) return null;

			var fileUrl = $"{ImageFolder}/{productId}/{variantId}/{Path.GetFileName(filePath)}";
			return fileUrl;
		}


	}
}
