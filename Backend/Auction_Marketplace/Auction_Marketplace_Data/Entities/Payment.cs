﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Auction_Marketplace.Data.Enums;

namespace Auction_Marketplace_Data.Entities
{
	public class Payment
	{
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("User")]
        public int EndUserId { get; set; }

        [ForeignKey("Cause")]
        public int? CauseId { get; set; }

        [ForeignKey("Auction")]
        public int? AuctionId { get; set; }

        [ForeignKey("UserPaymentMethod")]
        public int UserPaymentMethodId { get; set; }

        [Required]
        public PaymentFor Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted{ get; set; }
     
    }
}

