using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CafeLab.Models
{
    public partial class DBCafeContext : DbContext
    {
        public DBCafeContext()
        {
        }

        public DBCafeContext(DbContextOptions<DBCafeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cafe> Cafes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<DishesInOrder> DishesInOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<SaleCard> SaleCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= SURFACELAPTOP3; Database=DBCafe; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Cafe>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dishes_Categories");
            });

            modelBuilder.Entity<DishesInOrder>(entity =>
            {
                entity.HasKey(e => e.DishInOrderId)
                    .HasName("PK_Dishes_in_Orders");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.DishesInOrders)
                    .HasForeignKey(d => d.DishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dishes_in_Orders_Dishes");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.DishesInOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dishes_in_Orders_Orders");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Datetime).HasColumnType("datetime");

                entity.HasOne(d => d.Cafe)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CafeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Cafes");

                entity.HasOne(d => d.Salecard)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SalecardId)
                    .HasConstraintName("FK_Orders_SaleCards");
            });

            modelBuilder.Entity<SaleCard>(entity =>
            {
                entity.Property(e => e.SalecardId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
