using ChimeWebApi.Core.Enums;

namespace ChimeWebApi.Core.Objects
{
	public class Response
	{
		public required ResponseCode Code;
		public required string Message = string.Empty;
		public required string Source = string.Empty;
		public object? Data = null;
	}

	public class Response<Type>
	{
		public required ResponseCode Code;
		public required string Message = string.Empty;
		public required string Source = string.Empty;
		public Type? Data = default(Type);
	}
}
