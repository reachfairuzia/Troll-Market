using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrollMarket.DataAccess.Models;

public partial class TrollMarketContext : DbContext
{
    public TrollMarketContext()
    {
    }

    public TrollMarketContext(DbContextOptions<TrollMarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-0PNG5HD9; Database=TrollMarket; user=sa; password=indocyber; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__Accounts__536C85E5FF2A48FA");

            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Buyer__F3DBC57392D633A0");

            entity.ToTable("Buyer");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Balance).HasColumnType("money");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC07A4399CCC");

            entity.ToTable("Cart");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK_Cart_Cart");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK9la0a3h43b1tdsyc5g4vdoy1x");

            entity.HasOne(d => d.Seller).WithMany(p => p.Carts)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_Cart_Seller");

            entity.HasOne(d => d.Shipment).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ShipmentId)
                .HasConstraintName("FKkb8rxagd8mulon96g7n0nvncy");
        });

        modelBuilder.Entity<History>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__History__3214EC076A381CF2");

            entity.ToTable("History");

            entity.Property(e => e.PurchaseDate).HasColumnType("date");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Histories)
                .HasForeignKey(d => d.BuyerId)
                .HasConstraintName("FK_History_Buyer");

            entity.HasOne(d => d.Product).WithMany(p => p.Histories)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK6ub4bpoo0p6dsug6o267uk13m");

            entity.HasOne(d => d.Seller).WithMany(p => p.Histories)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_History_Seller");

            entity.HasOne(d => d.Shipment).WithMany(p => p.Histories)
                .HasForeignKey(d => d.ShipmentId)
                .HasConstraintName("FKke619x6to41ehejia8he171o9");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD1F01180A");

            entity.ToTable("Product");

            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Seller).WithMany(p => p.Products)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_Product_Seller");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seller__F3DBC57348AEA71A");

            entity.ToTable("Seller");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.ShipperId).HasName("PK__Shipment__1F8AFE59FF68DCA0");

            entity.ToTable("Shipment");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
