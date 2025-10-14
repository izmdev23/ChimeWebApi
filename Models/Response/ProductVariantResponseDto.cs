namespace ChimeWebApi.Models.Response
{
	public class ProductVariantResponseDto
	{
		public required Dictionary<Guid, string> Variants { get; set; }

		public ProductVariantResponseDto AddImageUrl(Guid variantId, string imgUrl)
		{
			Variants.Add(variantId, imgUrl);
			return this;
		}
	}
}
