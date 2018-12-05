﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gear.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GearDBEntities : DbContext
    {
        public GearDBEntities()
            : base("name=GearDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<ChatRoom> ChatRooms { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentRating> CommentRatings { get; set; }
        public virtual DbSet<CommentWarning> CommentWarnings { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameCode> GameCodes { get; set; }
        public virtual DbSet<GameRating> GameRatings { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<LibraryGame> LibraryGames { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
    }
}
