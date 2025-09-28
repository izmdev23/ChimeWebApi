using ChimeWebApi.Core.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChimeWebApi.Core.Objects
{
	public class ControllerResponse
	{
		public ControllerResponse()
		{
			Code = ResponseCode.None;
			Message = string.Empty;
		}

		public ControllerResponse(ResponseCode code, string message, object? data = null)
		{
			Code = code;
			Message = message;
			Data = data;
		}

		public ControllerResponse(Response response)
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
