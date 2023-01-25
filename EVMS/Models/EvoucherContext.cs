using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EVMS.Models;

public partial class EvoucherContext : DbContext
{
    public EvoucherContext()
    {
    }

    public EvoucherContext(DbContextOptions<EvoucherContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCmsuser> TbCmsusers { get; set; }

    public virtual DbSet<TbEvoucher> TbEvouchers { get; set; }

    public virtual DbSet<TbPaymentMethod> TbPaymentMethods { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=MyatKo;Database=EVoucher; User Id=sa; Password=a; Encrypt=False; Integrated Security=True");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer("Server=MyatKo;Database=EVoucher; User Id=sa; Password=a; Encrypt=False; Integrated Security=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCmsuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CMSUser");

            entity.ToTable("tbCMSUser");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accesstime)
                .HasColumnType("datetime")
                .HasColumnName("accesstime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<TbEvoucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EVoucher");

            entity.ToTable("tbEVoucher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accesstime)
                .HasColumnType("datetime")
                .HasColumnName("accesstime");
            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.BuyType)
                .HasMaxLength(50)
                .HasColumnName("buy_type");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("expiry_date");
            entity.Property(e => e.Image)
                .HasColumnType("image")
                .HasColumnName("image");
            entity.Property(e => e.IsPaid).HasColumnName("is_paid");
            entity.Property(e => e.MyselfMaxLimit).HasColumnName("myself_max_limit");
            entity.Property(e => e.MyselfName)
                .HasMaxLength(50)
                .HasColumnName("myself_name");
            entity.Property(e => e.MyselfPhone)
                .HasMaxLength(50)
                .HasColumnName("myself_phone");
            entity.Property(e => e.OtherBuyLimit).HasColumnName("other_buy_limit");
            entity.Property(e => e.OtherGiftLimit).HasColumnName("other_gift_limit");
            entity.Property(e => e.OtherName)
                .HasMaxLength(50)
                .HasColumnName("other_name");
            entity.Property(e => e.OtherPhone)
                .HasMaxLength(50)
                .HasColumnName("other_phone");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.TbEvouchers)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("FK__tbEVouche__useri__239E4DCF");
        });

        modelBuilder.Entity<TbPaymentMethod>(entity =>
        {
            entity.ToTable("tbPaymentMethod");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.MethodName)
                .HasMaxLength(50)
                .HasColumnName("method_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
