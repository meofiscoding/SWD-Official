using System;
using System.Collections.Generic;
using App.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.DAL.DataContext
{
    public partial class CMCContext : DbContext
    {
        public CMCContext()
        {
        }

        public CMCContext(DbContextOptions<CMCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplyingDiscount> ApplyingDiscounts { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<CardBox> CardBoxes { get; set; } = null!;
        public virtual DbSet<CardType> CardTypes { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Email> Emails { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Receipt> Receipts { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TemplateCard> TemplateCards { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=CMC;uid=sa;pwd=19112001;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplyingDiscount>(entity =>
            {
                entity.ToTable("ApplyingDiscount");

                entity.Property(e => e.ApplyingDiscountId).HasColumnName("applying_discount_id");

                entity.Property(e => e.DiscountId).HasColumnName("discount_id");

                entity.Property(e => e.TemplateCardId).HasColumnName("template_card_id");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.ApplyingDiscounts)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplyingDiscount_Discount");

                entity.HasOne(d => d.TemplateCard)
                    .WithMany(p => p.ApplyingDiscounts)
                    .HasForeignKey(d => d.TemplateCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplyingDiscount_TemplateCard");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("Card");

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.CardContent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("card_content");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TemplateId).HasColumnName("template_id");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Card_TemplateCard");
            });

            modelBuilder.Entity<CardBox>(entity =>
            {
                entity.ToTable("CardBox");

                entity.Property(e => e.CardBoxId).HasColumnName("card_box_id");

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.CardBoxes)
                    .HasForeignKey(d => d.CardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardBox_Card");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CardBoxes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CardBox_User");
            });

            modelBuilder.Entity<CardType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("CardType");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Detail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .HasColumnName("type_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.DiscountId).HasColumnName("discount_id");

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

                entity.Property(e => e.Id).HasColumnName("id");

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

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(50)
                    .HasColumnName("transaction_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_User");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.ToTable("Receipt");

                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipt_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

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

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedAt")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TemplateCards)
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
                    .HasColumnName("identity_number")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("phone_number")
                    .IsFixedLength();

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
