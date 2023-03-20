using System;
namespace LimousineApi.ViewModels
{
	public class UserForUpdate
	{
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public double? Points { get; set; }
        public string? Gender { get; set; }
        public string? Image { get; set; }
        public DateTime? Birth { get; set; }
    }
}

