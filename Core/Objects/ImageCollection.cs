namespace ChimeWebApi.Core.Objects
{
	public class ImageCollection
	{
		public Dictionary<Guid, Dictionary<Guid, List<string>>> Data { get; set; }

		public ImageCollection()
		{
			Data = [];
		}

		public void Add(Guid productId, Guid variantId, string name)
		{
			if (Data.ContainsKey(productId) == false) Data.Add(productId, []);
			if (Data[productId].ContainsKey(variantId) == false) Data[productId].Add(variantId, []);
			if (Data[productId][variantId].Contains(name)) return;
			Data[productId][variantId].Add(name);
		}

		public string? Get(Guid productId, Guid variantId, string name)
		{
			if (Data.ContainsKey(productId) == false) return null;
			if (Data[productId].ContainsKey(variantId) == false) return null;
			var d = Data[productId][variantId].Find(e => e == name);
			return d;
		}

		public void Remove(Guid productId)
		{
			if (Data.ContainsKey(productId) == false) return;
			Data = Data.Where(e => e.Key != productId).ToDictionary();
		}

		public void Remove(Guid productId, Guid variantId)
		{
			if (Data.ContainsKey(productId) == false) return;
			if (Data[productId].ContainsKey(variantId) == false) return;
			Data[productId] = Data[productId].Where(e => e.Key != variantId).ToDictionary();
		}

		public void Remove(Guid productId, Guid variantId, string name)
		{
			if (Data.ContainsKey(productId) == false) return;
			if (Data[productId].ContainsKey(variantId) == false) return;
			Data[productId][variantId] = [.. Data[productId][variantId].Where(e => e != name)];
		}

		public void Clear()
		{
			Data.Clear();
		}

	}
}
