using ChimeWebApi.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChimeWebApi.Models.Request
{
	public class ImageVariantDto
	{
		[Required(ErrorMessage = "image is invalid")]
		public required IFormFile Image { get; set; }
		[Required(ErrorMessage = "variant id is invalid")]
		public required Guid VariantId { get; set; }
		[Required(ErrorMessage = "product id is invalid")]
		public required Guid ProductId { get; set; }
	}
}
