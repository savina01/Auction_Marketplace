﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Auction_Marketplace.Data.Enums;
using Auction_Marketplace_Data.Entities.Abstract;

namespace Auction_Marketplace_Data.Entities
{
    public class UserPaymentMethod : IBaseEntity
	{
        [Key]
        public int UserPaymentMethodId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public PaymentMethod Method { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsDefault { get; set; }

        // Implementing IBaseEntity interface
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

