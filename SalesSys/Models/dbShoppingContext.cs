using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesSys.Models
{
    public partial class dbShoppingContext : DbContext
    {
        public dbShoppingContext()
        {
        }

        public dbShoppingContext(DbContextOptions<dbShoppingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAdmin> TAdmins { get; set; } = null!;
        public virtual DbSet<TCategory> TCategories { get; set; } = null!;
        public virtual DbSet<TMember> TMembers { get; set; } = null!;
        public virtual DbSet<TOrder> TOrders { get; set; } = null!;
        public virtual DbSet<TOrderDetail> TOrderDetails { get; set; } = null!;
        public virtual DbSet<TProduct> TProducts { get; set; } = null!;
        public virtual DbSet<TShoppingCar> TShoppingCars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\C#\\.net core\\SalesSys\\SalesSys\\AppData\\dbShopping.mdf;Integrated Security=True; Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAdmin>(entity =>
            {
                entity.HasKey(e => e.FUid);

                entity.ToTable("tAdmin");

                entity.Property(e => e.FUid)
                    .HasMaxLength(50)
                    .HasColumnName("fUId");

                entity.Property(e => e.FPwd)
                    .HasMaxLength(50)
                    .HasColumnName("fPwd");
            });

            modelBuilder.Entity<TCategory>(entity =>
            {
                entity.HasKey(e => e.FCategoryId)
                    .HasName("PK__tCategor__53E607B38F32A91D");

                entity.ToTable("tCategory");

                entity.Property(e => e.FCategoryId).HasColumnName("fCategoryId");

                entity.Property(e => e.FCategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("fCategoryName");
            });

            modelBuilder.Entity<TMember>(entity =>
            {
                entity.HasKey(e => e.FUid);

                entity.ToTable("tMember");

                entity.Property(e => e.FUid)
                    .HasMaxLength(50)
                    .HasColumnName("fUId");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPwd)
                    .HasMaxLength(50)
                    .HasColumnName("fPwd");
            });

            modelBuilder.Entity<TOrder>(entity =>
            {
                entity.HasKey(e => e.FOrderId)
                    .HasName("PK__tmp_ms_x__5DA911FAD79D2628");

                entity.ToTable("tOrder");

                entity.Property(e => e.FOrderId).HasColumnName("fOrderId");

                entity.Property(e => e.FOrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fOrderDate");

                entity.Property(e => e.FOrderState)
                    .HasMaxLength(50)
                    .HasColumnName("fOrderState");

                entity.Property(e => e.FReceiver)
                    .HasMaxLength(50)
                    .HasColumnName("fReceiver");

                entity.Property(e => e.FReceiverAddress)
                    .HasMaxLength(150)
                    .HasColumnName("fReceiverAddress");

                entity.Property(e => e.FReceiverPhone)
                    .HasMaxLength(50)
                    .HasColumnName("fReceiverPhone");

                entity.Property(e => e.FUid)
                    .HasMaxLength(50)
                    .HasColumnName("fUId");
            });

            modelBuilder.Entity<TOrderDetail>(entity =>
            {
                entity.HasKey(e => e.FOrderDetailsId)
                    .HasName("PK__tOrderDe__D9F8227CB53A1E2C");

                entity.ToTable("tOrderDetails");

                entity.Property(e => e.FOrderDetailsId).HasColumnName("fOrderDetailsId");

                entity.Property(e => e.FOrderId).HasColumnName("fOrderId");

                entity.Property(e => e.FPid)
                    .HasMaxLength(50)
                    .HasColumnName("fPId");

                entity.Property(e => e.FPname)
                    .HasMaxLength(50)
                    .HasColumnName("fPName");

                entity.Property(e => e.FPrice).HasColumnName("fPrice");

                entity.Property(e => e.FQty).HasColumnName("fQty");
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK__tProduct__D9F8227C8EA80556");

                entity.ToTable("tProduct");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FCategoryId).HasColumnName("fCategoryId");

                entity.Property(e => e.FImg)
                    .HasMaxLength(50)
                    .HasColumnName("fImg");

                entity.Property(e => e.FPid)
                    .HasMaxLength(50)
                    .HasColumnName("fPId");

                entity.Property(e => e.FPname)
                    .HasMaxLength(50)
                    .HasColumnName("fPName");

                entity.Property(e => e.FPrice).HasColumnName("fPrice");
            });

            modelBuilder.Entity<TShoppingCar>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK__tShoppin__D9F8227CA2E00215");

                entity.ToTable("tShoppingCar");

                entity.Property(e => e.FId).HasColumnName("fId");

                entity.Property(e => e.FPid)
                    .HasMaxLength(50)
                    .HasColumnName("fPId");

                entity.Property(e => e.FPname)
                    .HasMaxLength(50)
                    .HasColumnName("fPName");

                entity.Property(e => e.FPrice).HasColumnName("fPrice");

                entity.Property(e => e.FQty).HasColumnName("fQty");

                entity.Property(e => e.FUid)
                    .HasMaxLength(50)
                    .HasColumnName("fUId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
