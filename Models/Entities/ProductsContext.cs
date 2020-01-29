using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fox.Microservices.Products.Models.Entities
{
    public partial class ProductsContext : DbContext
    {
        public ProductsContext()
        {
        }

        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PD_S_BAND> PD_S_BAND { get; set; }
        public virtual DbSet<PD_S_CLASS> PD_S_CLASS { get; set; }
        public virtual DbSet<PD_S_GROUP> PD_S_GROUP { get; set; }
        public virtual DbSet<PD_S_PRODUCT> PD_S_PRODUCT { get; set; }
        public virtual DbSet<PD_S_PRODUCT_EXT_AUS> PD_S_PRODUCT_EXT_AUS { get; set; }
        public virtual DbSet<PD_S_PRODUCT_PRICELIST> PD_S_PRODUCT_PRICELIST { get; set; }
        public virtual DbSet<PD_S_PRODUCT_WARRANTIES_EXT_AUS> PD_S_PRODUCT_WARRANTIES_EXT_AUS { get; set; }
        public virtual DbSet<PD_S_SUBCLASS> PD_S_SUBCLASS { get; set; }
        public virtual DbSet<PD_S_SUPPLIER> PD_S_SUPPLIER { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CAU02DB01FOXSIT.D09.ROOT.SYS;Database=FoxAustralia_SIT2;Trusted_Connection=False;User ID=foxuser;Password=Df0x35ZZ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<PD_S_BAND>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.BAND_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_PD_S_BAND_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.BAND_CODE).HasMaxLength(4);

                entity.Property(e => e.BAND_DESCR).HasMaxLength(255);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<PD_S_CLASS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CLASS_CODE })
                    .HasName("PK_SY_PRODUCT_CLASS");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_PRODUCT_CLASS_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CLASS_CODE).HasMaxLength(3);

                entity.Property(e => e.CLASS_DESCR).HasMaxLength(255);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<PD_S_GROUP>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.GROUP_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_PD_S_GROUP_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.GROUP_CODE).HasMaxLength(4);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.GROUP_DESCR).HasMaxLength(255);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<PD_S_PRODUCT>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRODUCT_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_PD_S_PRODUCT_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.PRODUCT_CODE, e.CLASS_CODE })
                    .HasName("IDX_PD_S_PRODUCT_001");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.BAND_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PD_S_BAND");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.BRAND_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PD_S_SUPPLIER");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.FAMILY_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PD_S_FAMILY");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.REPLENISHMENT_TYPE_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PD_S_REPLENISHMENT_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CLASS_CODE, e.SUBCLASS_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PD_S_SUBCLASS");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRODUCT_CODE, e.DT_INSERT, e.USERUPDATE, e.DT_UPDATE })
                    .HasName("missing_index_17741");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.PRODUCT_CODE).HasMaxLength(8);

                entity.Property(e => e.BAND_CODE).HasMaxLength(4);

                entity.Property(e => e.BATTERY_SIZE_CODE).HasMaxLength(3);

                entity.Property(e => e.BRAND_CODE).HasMaxLength(8);

                entity.Property(e => e.CLASS_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FAMILY_CODE).HasMaxLength(4);

                entity.Property(e => e.FLG_ACTIVE).HasMaxLength(1);

                entity.Property(e => e.FLG_CUSTOM).HasMaxLength(1);

                entity.Property(e => e.FLG_DUMMY).HasMaxLength(1);

                entity.Property(e => e.FLG_FRANCHISEE).HasMaxLength(1);

                entity.Property(e => e.FLG_ORDERABLE).HasMaxLength(1);

                entity.Property(e => e.FLG_QUALITYCHECK).HasMaxLength(1);

                entity.Property(e => e.FLG_QUICKSALE).HasMaxLength(1);

                entity.Property(e => e.FLG_SERIAL).HasMaxLength(1);

                entity.Property(e => e.FLG_SIDE).HasMaxLength(1);

                entity.Property(e => e.FLG_STOCKTAKE).HasMaxLength(1);

                entity.Property(e => e.FLG_TRIAL).HasMaxLength(1);

                entity.Property(e => e.GROUP_CODE).HasMaxLength(4);

                entity.Property(e => e.PRODUCT_DESCR).HasMaxLength(255);

                entity.Property(e => e.PRODUCT_STATUS).HasMaxLength(3);

                entity.Property(e => e.REPLENISHMENT_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SUBCLASS_CODE).HasMaxLength(3);

                entity.Property(e => e.SUPPLIER_CODE).HasMaxLength(8);

                entity.Property(e => e.TARIFF_POSITION_CODE).HasMaxLength(20);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.VAT_CODE).HasMaxLength(3);

                entity.HasOne(d => d.PD_S_BAND)
                    .WithMany(p => p.PD_S_PRODUCT)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.BAND_CODE })
                    .HasConstraintName("FK_PD_S_PRODUCT_PD_S_BAND");

                entity.HasOne(d => d.PD_S_SUPPLIER)
                    .WithMany(p => p.PD_S_PRODUCTPD_S_SUPPLIER)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.BRAND_CODE })
                    .HasConstraintName("FK_PD_S_PRODUCT_PD_S_SUPPLIER");

                entity.HasOne(d => d.PD_S_GROUP)
                    .WithMany(p => p.PD_S_PRODUCT)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.GROUP_CODE })
                    .HasConstraintName("FK_PD_S_PRODUCT_PD_S_GROUP");

                entity.HasOne(d => d.PD_S_SUPPLIERNavigation)
                    .WithMany(p => p.PD_S_PRODUCTPD_S_SUPPLIERNavigation)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SUPPLIER_CODE })
                    .HasConstraintName("FK_PD_S_PRODUCT_PD_S_SUPPLIER_CODE");

                entity.HasOne(d => d.PD_S_SUBCLASS)
                    .WithMany(p => p.PD_S_PRODUCT)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CLASS_CODE, d.SUBCLASS_CODE })
                    .HasConstraintName("FK_PD_S_PRODUCT_PD_S_SUBCLASS");
            });

            modelBuilder.Entity<PD_S_PRODUCT_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRODUCT_CODE })
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_PD_S_PRODUCT_EXT_AUS_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.PRODUCT_CODE).HasMaxLength(8);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_NHC_APPROVED_FROM).HasColumnType("datetime");

                entity.Property(e => e.DT_NHC_APPROVED_TO).HasColumnType("datetime");

                entity.Property(e => e.DT_OHS_APPROVED_FROM).HasColumnType("datetime");

                entity.Property(e => e.DT_OHS_APPROVED_TO).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.DVA).HasMaxLength(1);

                entity.Property(e => e.DVA_CODE).HasMaxLength(10);

                entity.Property(e => e.DVA_PRE_G_APPROVAL).HasMaxLength(1);

                entity.Property(e => e.DVA_PRE_W_APPROVAL).HasMaxLength(1);

                entity.Property(e => e.FLG_CUSTOM_DEVICE).HasMaxLength(1);

                entity.Property(e => e.NDIS_SUPPORT_NO).HasMaxLength(21);

                entity.Property(e => e.PRODUCT_COMMER).HasMaxLength(255);

                entity.Property(e => e.RAP_CODE).HasMaxLength(10);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SALE_TYPE).HasMaxLength(3);

                entity.Property(e => e.TECHNOLOGY).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.WC_ACT).HasMaxLength(1);

                entity.Property(e => e.WC_ALLOWED_FOR_NSW_POST_MAY).HasMaxLength(1);

                entity.Property(e => e.WC_ALLOWED_FOR_VIC_WORKSAFE).HasMaxLength(1);

                entity.Property(e => e.WC_ALLSTATE).HasMaxLength(1);

                entity.Property(e => e.WC_INCLUDED_NSW_WC_LIST).HasMaxLength(1);

                entity.Property(e => e.WC_INCLUDED_VIC_WC_LIST).HasMaxLength(1);

                entity.Property(e => e.WC_NSW).HasMaxLength(1);

                entity.Property(e => e.WC_NSW_WS_CODE).HasMaxLength(15);

                entity.Property(e => e.WC_NT).HasMaxLength(1);

                entity.Property(e => e.WC_QLD).HasMaxLength(1);

                entity.Property(e => e.WC_SA).HasMaxLength(1);

                entity.Property(e => e.WC_TAS).HasMaxLength(1);

                entity.Property(e => e.WC_VIC).HasMaxLength(1);

                entity.Property(e => e.WC_VIC_WS_CODE).HasMaxLength(15);

                entity.Property(e => e.WC_WA).HasMaxLength(1);

                entity.Property(e => e.ZERO_TOPUP).HasMaxLength(1);
            });

            modelBuilder.Entity<PD_S_PRODUCT_PRICELIST>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRODUCT_CODE, e.PRICELIST_CODE, e.DT_VALID })
                    .HasName("PK_PRODUCT_PRICELIST");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_PD_S_PRODUCT_PRICELIST_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRICELIST_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PRICELIST_PD_S_PRICELIST");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRODUCT_CODE })
                    .HasName("IDX_PD_S_PRODUCT_PRICELIST_PD_S_PRODUCT");

                entity.HasIndex(e => new { e.PRODUCT_CODE, e.PRICELIST_CODE, e.DT_VALID })
                    .HasName("IDX_PD_S_PRODUCT_PRICELIST_001");

                entity.HasIndex(e => new { e.PRODUCT_CODE, e.COMPANY_CODE, e.DIVISION_CODE, e.PRICELIST_CODE, e.DT_VALID })
                    .HasName("missing_index_25801");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.PRODUCT_CODE).HasMaxLength(8);

                entity.Property(e => e.PRICELIST_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_VALID).HasColumnType("date");

                entity.Property(e => e.CURRENCY_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.PD_S_PRODUCT)
                    .WithMany(p => p.PD_S_PRODUCT_PRICELIST)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.PRODUCT_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PD_S_PRODUCT_PRICELIST_PD_S_PRODUCT");
            });

            modelBuilder.Entity<PD_S_PRODUCT_WARRANTIES_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.PRODUCT_CODE, e.WARRANTY_TYPE, e.DT_EFFECTIVE_FROM })
                    .HasName("PK__PD_S_PRO__E4E1619C79D93FCE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.PRODUCT_CODE).HasMaxLength(8);

                entity.Property(e => e.WARRANTY_TYPE).HasMaxLength(3);

                entity.Property(e => e.DT_EFFECTIVE_FROM).HasColumnType("datetime");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.NOTE).HasMaxLength(150);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(100);

                entity.Property(e => e.USERUPDATE).HasMaxLength(100);
            });

            modelBuilder.Entity<PD_S_SUBCLASS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CLASS_CODE, e.SUBCLASS_CODE })
                    .HasName("PK_PD_S_PRODUCT_SUBCLASS");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_PD_S_PRODUCT_SUBCLASS_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CLASS_CODE })
                    .HasName("IDX_PD_S_SUBCLASS_PD_S_CLASS");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SUBCLASSGROUP_CODE })
                    .HasName("IDX_PD_S_SUBCLASS_PD_S_SUBCLASS_GROUP");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CLASS_CODE).HasMaxLength(3);

                entity.Property(e => e.SUBCLASS_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SUBCLASSGROUP_CODE).HasMaxLength(3);

                entity.Property(e => e.SUBCLASS_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.PD_S_CLASS)
                    .WithMany(p => p.PD_S_SUBCLASS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CLASS_CODE })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PD_S_SUBCLASS_PD_S_CLASS");
            });

            modelBuilder.Entity<PD_S_SUPPLIER>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SUPPLIER_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_PD_S_SUPPLIER_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SUPPLIER_CODE).HasMaxLength(8);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_SERIAL21).HasMaxLength(1);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SUPPLIER_DESCR).HasMaxLength(255);

                entity.Property(e => e.SUPPLIER_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.HasSequence("NextFoxid").StartsAt(0);

            modelBuilder.HasSequence("GETNEXTBATCHNUMBER").StartsAt(200);

            modelBuilder.HasSequence("NextFoxCouponid").StartsAt(0);

            modelBuilder.HasSequence("NextFoxid").StartsAt(4000);

            modelBuilder.HasSequence("NextFoxVoucherId");
        }
    }
}
