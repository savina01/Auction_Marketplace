﻿using Auction_Marketplace.Data.Configuration;
using Auction_Marketplace.Data.Entities;
using Auction_Marketplace.Data.Entities.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Auction_Marketplace.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserPaymentMethod> UserPaymentMethods { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        /*public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }*/

        //override savechangesasync
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is IBaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                var entity = entityEntry.Entity as IBaseEntity;
                var now = DateTime.UtcNow; // current datetime

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt = now;
                }
                entity.UpdatedAt = now;
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           // builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            //builder.ApplyConfiguration(new BaseEntityConfig());
            builder.ApplyConfigurationsFromAssembly(typeof(Auction).Assembly);

            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(r => r.Cause)
                .WithMany()
                .HasForeignKey(r => r.CauseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(r => r.UserPaymentMethod)
                .WithMany()
                .HasForeignKey(r => r.UserPaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
               .HasOne(r => r.EndUser)
               .WithMany()
               .HasForeignKey(r => r.EndUserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Bid>()
              .HasOne(r => r.Item)
              .WithMany()
              .HasForeignKey(r => r.ItemId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Bid>()
              .HasOne(r => r.User)
              .WithMany()
              .HasForeignKey(r => r.UserId)
              .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
