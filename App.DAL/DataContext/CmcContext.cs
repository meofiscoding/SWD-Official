using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using App.DAL.Models;
using Microsoft.Extensions.Configuration;

namespace App.DAL.DataContext;

public partial class CmcContext : DbContext
{
    public CmcContext()
    {
    }

    public CmcContext(DbContextOptions<CmcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplyingDiscount> ApplyingDiscounts { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<CardBox> CardBoxes { get; set; }

    public virtual DbSet<CardType> CardTypes { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TemplateCard> TemplateCards { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("CMC"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplyingDiscount>(entity =>
        {
            entity.ToTable("ApplyingDiscount");

            entity.Property(e => e.ApplyingDiscountId)
                .ValueGeneratedNever()
                .HasColumnName("applying_discount_id");
            entity.Property(e => e.DiscountId).HasColumnName("discount_id");
            entity.Property(e => e.TemplateCardId).HasColumnName("template_card_id");

            entity.HasOne(d => d.Discount).WithMany(p => p.ApplyingDiscounts)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplyingDiscount_Discount");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.ToTable("Card");

            entity.Property(e => e.CardId)
                .ValueGeneratedNever()
                .HasColumnName("card_id");
            entity.Property(e => e.CardContent)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("card_content");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasColumnName("created_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TemplateId).HasColumnName("template_id");

            entity.HasOne(d => d.Template).WithMany(p => p.Cards)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Card_TemplateCard");
        });

        modelBuilder.Entity<CardBox>(entity =>
        {
            entity.ToTable("CardBox");

            entity.Property(e => e.CardBoxId)
                .ValueGeneratedNever()
                .HasColumnName("card_box_id");
            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Card).WithMany(p => p.CardBoxes)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CardBox_Card");
        });

        modelBuilder.Entity<CardType>(entity =>
        {
            entity.HasKey(e => e.TypeId);

            entity.ToTable("CardType");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("type_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.ToTable("Discount");

            entity.Property(e => e.DiscountId)
                .ValueGeneratedNever()
                .HasColumnName("discount_id");
            entity.Property(e => e.DiscountPercent).HasColumnName("discount_percent");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.ToTable("Email");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EmailContent)
                .HasMaxLength(255)
                .HasColumnName("email_content");
            entity.Property(e => e.EmailTitle)
                .HasMaxLength(255)
                .HasColumnName("email_title");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .HasColumnName("user_email");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("payment_id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("transaction_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Payments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_User");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.ToTable("Receipt");

            entity.Property(e => e.ReceiptId)
                .ValueGeneratedNever()
                .HasColumnName("receipt_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasColumnName("created_date");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receipt_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role_name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<TemplateCard>(entity =>
        {
            entity.HasKey(e => e.TemplateId);

            entity.ToTable("TemplateCard");

            entity.Property(e => e.TemplateId).HasColumnName("template_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.TemplateCards)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TemplateCard_CardType");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.IdentityNumber)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("identity_number");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
