﻿using System;
using Auction_Marketplace.Data.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Auction_Marketplace.Data.Entities
{
	public class RoleClaim : IdentityRoleClaim<int>, IBaseEntity
    {
        // Implementing IBaseEntity interface
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

