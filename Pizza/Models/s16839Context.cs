using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pizza.Models
{
    public partial class s16839Context : DbContext
    {
        public s16839Context()
        {
        }

        public s16839Context(DbContextOptions<s16839Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<BreadType> BreadType { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DeliveryMan> DeliveryMan { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<IngredientSet> IngredientSet { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }

        // Unable to generate entity type for table 'dbo.DEPT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s16839;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("Admin_pk");

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_id_order");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.Admin)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Admin_Order");
            });

            modelBuilder.Entity<BreadType>(entity =>
            {
                entity.HasKey(e => e.IdBreadType)
                    .HasName("Bread_type_pk");

                entity.ToTable("Bread_type");

                entity.Property(e => e.IdBreadType).HasColumnName("id_bread_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("smallmoney");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("Customer_pk");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeliveryMan>(entity =>
            {
                entity.HasKey(e => e.IdDeliveryMan)
                    .HasName("Delivery_Man_pk");

                entity.ToTable("Delivery_Man");

                entity.Property(e => e.IdDeliveryMan).HasColumnName("id_delivery_man");

                entity.Property(e => e.EmpNumber).HasColumnName("emp_number");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

           

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IdIngredient)
                    .HasName("Ingredient_pk");

                entity.Property(e => e.IdIngredient).HasColumnName("id_ingredient");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("smallmoney");
            });

            modelBuilder.Entity<IngredientSet>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.IngredientIdIngredient })
                    .HasName("Ingredient_Set_pk");

                entity.ToTable("Ingredient_Set");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_id_pizza");

                entity.Property(e => e.IngredientIdIngredient).HasColumnName("Ingredient_id_ingredient");

                entity.HasOne(d => d.IngredientIdIngredientNavigation)
                    .WithMany(p => p.IngredientSet)
                    .HasForeignKey(d => d.IngredientIdIngredient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ingredient_Set_Ingredient");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.IngredientSet)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ingredient_Set_Pizza");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("Order__pk");

                entity.ToTable("Order_");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.CustomerIdCustomer).HasColumnName("Customer_id_customer");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.DeliveryManIdDeliveryMan).HasColumnName("Delivery_Man_id_delivery_man");

                entity.Property(e => e.OrderStatus).HasColumnName("order_status");

                entity.Property(e => e.TimeDelivered)
                    .HasColumnName("time_delivered")
                    .HasColumnType("time(3)");

                entity.Property(e => e.TimeOrdered)
                    .HasColumnName("time_ordered")
                    .HasColumnType("time(3)");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("total_price")
                    .HasColumnType("smallmoney");

                entity.HasOne(d => d.CustomerIdCustomerNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerIdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Customer");

                entity.HasOne(d => d.DeliveryManIdDeliveryManNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DeliveryManIdDeliveryMan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Delivery_Man");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza).HasColumnName("id_pizza");

                entity.Property(e => e.BreadTypeIdBreadType).HasColumnName("Bread_type_id_bread_type");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("smallmoney");

                entity.Property(e => e.IsCustomizable).HasColumnName("is_customizable");

                entity.Property(e => e.IsSpicy).HasColumnName("is_spicy");

                entity.Property(e => e.IsVege).HasColumnName("is_vege");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_id_order");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("smallmoney");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnName("size")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.BreadTypeIdBreadTypeNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.BreadTypeIdBreadType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pizza_Bread_type");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .HasConstraintName("Pizza_Order");
            });
        }
    }
}
