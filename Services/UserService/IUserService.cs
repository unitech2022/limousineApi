using System;
using LimousineApi.Models;
using LimousineApi.ViewModels;

namespace LimousineApi.Serveries
{
	public interface IUserService
	{
		Task<object> Register(UserForRegister userForRegister);
		Task<object> IsUserRegistered(string UserName);
		Task<object> LoginAdmin(AdminForLoginRequest adminForLogin);
		Task<object> LoginUser(UserForLogin userForLogin);
		Task<object> RegisterAdmin(UserForRegister adminForRegister);
		Task<object> UpdateUser(UserForUpdate userForUpdate);
		Task<User> GetUser(string UserId);
	}
}

