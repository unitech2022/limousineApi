using System;
namespace LimousineApi.ViewModels
{
	public class UserForLogin
	{
		public string? UserName{ get; set; }
		public string? DeviceToken { get; set; }
		public string? Code { get; set; }
	}
}

