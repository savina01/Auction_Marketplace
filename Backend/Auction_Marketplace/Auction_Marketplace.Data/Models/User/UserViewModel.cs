﻿using System.ComponentModel.DataAnnotations;

namespace Auction_Marketplace.Data.Models.User
{
	public class UserViewModel
	{
		[Required]
		public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

		public string? ProfilePicture { get; set; }
	}
}