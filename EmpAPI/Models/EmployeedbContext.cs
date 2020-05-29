using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmpAPI.Models
{
    public partial class EmployeedbContext : DbContext
    {
        public EmployeedbContext()
        {
        }

        public EmployeedbContext(DbContextOptions<EmployeedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;database=misa.nnphong", x => x.ServerVersion("10.4.12-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasComment("Bảng danh mục nhân viên");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasComment("PK")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(255)")
                    .HasComment("Quê quán")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Age)
                    .HasColumnType("int(11)")
                    .HasComment("Tuổi");

                entity.Property(e => e.CreatedBy)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeCode)
                    .HasColumnType("varchar(20)")
                    .HasComment("Mã nhân viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.EmployeeName)
                    .HasColumnType("varchar(100)")
                    .HasComment("Tên nhân viên")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("varchar(20)")
                    .HasComment("Giới tính")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(50)")
                    .HasComment("Số điện thoại")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_unicode_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
