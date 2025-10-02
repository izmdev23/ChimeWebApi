using ChimeWebApi.Core.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChimeWebApi.Core.Objects
{
	public class ApiResponse
	{
		public ApiResponse()
		{
			Code = ResponseCode.None;
			Message = string.Empty;
		}

		public ApiResponse(ResponseCode code, string message, object? data = null)
		{
			Code = code;
			Message = message;
			Data = data;
		}

		public ApiResponse(Response response)
		{
			Code = response.Code;
			Message = response.Message;
			Data = response.Data;
		}

		public ResponseCode Code { get; set; }
		public string Message { get; set; }
		public object? Data { get; set; }
	}
}
