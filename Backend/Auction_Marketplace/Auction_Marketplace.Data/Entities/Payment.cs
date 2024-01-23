﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Auction_Marketplace.Data.Enums;
using Auction_Marketplace.Data.Entities.Abstract;

namespace Auction_Marketplace.Data.Entities
{
	public class Payment : IBaseEntity
	{
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("EndUser")]
        public int EndUserId { get; set; }
        public User EndUser { get; set; }

        [ForeignKey("Cause")]
        public int? CauseId { get; set; }
        public Cause Cause { get; set; }

        [ForeignKey("Auction")]
        public int? AuctionId { get; set; }
        public Auction Auction { get; set; }

        [ForeignKey("UserPaymentMethod")]
        public int UserPaymentMethodId { get; set; }
        public UserPaymentMethod UserPaymentMethod { get; set; }

        [Required]
        public PaymentFor Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted{ get; set; }

        // Implementing IBaseEntity interface
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}

