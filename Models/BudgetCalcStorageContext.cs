using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BudgetWebApp19010155.Models
{
    public partial class BudgetCalcStorageContext : DbContext
    {
        public BudgetCalcStorageContext()
        {
        }

        public BudgetCalcStorageContext(DbContextOptions<BudgetCalcStorageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BasicInfo> BasicInfo { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<PropertyInfoBuy> PropertyInfoBuy { get; set; }
        public virtual DbSet<PropertyInfoRent> PropertyInfoRent { get; set; }
        public virtual DbSet<VehicleInfo> VehicleInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=Mark-I\\SQLEXPRESS;Initial Catalog=BudgetCalcStorage;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasicInfo>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__BASIC_IN__5A2040DB39210E99");

                entity.ToTable("BASIC_INFO");

                entity.Property(e => e.UId)
                    .HasColumnName("U_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Groceries)
                    .HasColumnName("groceries")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.GrossInc)
                    .HasColumnName("gross_inc")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MonthlyExp)
                    .HasColumnName("monthly_exp")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.NetIncome)
                    .HasColumnName("net_income")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.OtherExp)
                    .HasColumnName("other_exp")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PhoneCosts)
                    .HasColumnName("phone_costs")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TravelCosts)
                    .HasColumnName("travel_costs")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.WaterLights)
                    .HasColumnName("water_lights")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.BasicInfo)
                    .HasForeignKey<BasicInfo>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BASIC_INFO__U_ID__7E37BEF6");
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__LOGIN_IN__5A2040DBDC1119AF");

                entity.ToTable("LOGIN_INFO");

                entity.Property(e => e.UId).HasColumnName("U_ID");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PropertyInfoBuy>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__PROPERTY__5A2040DB8DD36162");

                entity.ToTable("PROPERTY_INFO_BUY");

                entity.Property(e => e.UId)
                    .HasColumnName("U_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IntRate)
                    .HasColumnName("int_rate")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.NoOfMonths).HasColumnName("no_of_months");

                entity.Property(e => e.PurPrice)
                    .HasColumnName("pur_price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotDeposit)
                    .HasColumnName("tot_deposit")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotRepayment)
                    .HasColumnName("tot_repayment")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.PropertyInfoBuy)
                    .HasForeignKey<PropertyInfoBuy>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROPERTY_I__U_ID__06CD04F7");
            });

            modelBuilder.Entity<PropertyInfoRent>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__PROPERTY__5A2040DBC0D40B4F");

                entity.ToTable("PROPERTY_INFO_RENT");

                entity.Property(e => e.UId)
                    .HasColumnName("U_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RentAmt)
                    .HasColumnName("rent_amt")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.PropertyInfoRent)
                    .HasForeignKey<PropertyInfoRent>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROPERTY_I__U_ID__09A971A2");
            });

            modelBuilder.Entity<VehicleInfo>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__VEHICLE___5A2040DB2DA4B4C5");

                entity.ToTable("VEHICLE_INFO");

                entity.Property(e => e.UId)
                    .HasColumnName("U_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.InsurancePrem)
                    .HasColumnName("insurance_prem")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IntRate)
                    .HasColumnName("int_rate")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ModelMake)
                    .IsRequired()
                    .HasColumnName("model_make")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PurPrice)
                    .HasColumnName("pur_price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotDeposit)
                    .HasColumnName("tot_deposit")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TotRepayment)
                    .HasColumnName("tot_repayment")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.U)
                    .WithOne(p => p.VehicleInfo)
                    .HasForeignKey<VehicleInfo>(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VEHICLE_IN__U_ID__01142BA1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
