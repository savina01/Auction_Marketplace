﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Auction_Marketplace_Data.Entities.Abstract;
namespace Auction_Marketplace_Data.Entities
{
	public class Auction : IBaseEntity
	{
        [Key]
        public int AuctionId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        // Implementing IBaseEntity interface
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

