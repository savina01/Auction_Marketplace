﻿using System;
using Auction_Marketplace_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auction_Marketplace_Data.Configuration
{
	public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
        }
    }
}

