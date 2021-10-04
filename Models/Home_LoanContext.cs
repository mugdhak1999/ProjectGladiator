using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectGladiator.Models
{
    public partial class Home_LoanContext : DbContext
    {
        public Home_LoanContext()
        {
        }

        public Home_LoanContext(DbContextOptions<Home_LoanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDetails> AccountDetails { get; set; }
        public virtual DbSet<AdminDetails> AdminDetails { get; set; }
        public virtual DbSet<ApplicationDetails> ApplicationDetails { get; set; }
        public virtual DbSet<IncomeDetails> IncomeDetails { get; set; }
        public virtual DbSet<LoanDetails> LoanDetails { get; set; }
        public virtual DbSet<PersonalDetails> PersonalDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-2RRQG73;Database=Home_Loan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDetails>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__Account___BE2ACD6EC5C79012");

                entity.ToTable("Account_Details");

                entity.Property(e => e.AccountNumber).ValueGeneratedNever();

                entity.Property(e => e.AmountAvailable).HasColumnType("numeric(20, 5)");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.AccountDetails)
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("FK__Account_D__LoanI__44FF419A");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.AccountDetails)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__Account_D__usern__440B1D61");
            });

            modelBuilder.Entity<AdminDetails>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Admin_De__F3DBC57334935E96");

                entity.ToTable("Admin_Details");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationDetails>(entity =>
            {
                entity.HasKey(e => e.LoanId)
                    .HasName("PK__Applicat__4F5AD437085BE3BB");

                entity.ToTable("Application_Details");

                entity.Property(e => e.LoanId)
                    .HasColumnName("LoanID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.ApprovalDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationDetails)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK__Applicati__Appli__412EB0B6");
            });

            modelBuilder.Entity<IncomeDetails>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Income_D__F3DBC57348867E73");

                entity.ToTable("Income_Details");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyLocation)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfEmployment)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithOne(p => p.IncomeDetails)
                    .HasForeignKey<IncomeDetails>(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Income_De__usern__3B75D760");
            });

            modelBuilder.Entity<LoanDetails>(entity =>
            {
                entity.HasKey(e => e.ApplicationId)
                    .HasName("PK__Loan_Det__C93A4F79843AB87F");

                entity.ToTable("Loan_Details");

                entity.Property(e => e.ApplicationId)
                    .HasColumnName("ApplicationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.InterestRate).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.LoanAmount).HasColumnType("numeric(18, 5)");

                entity.Property(e => e.LoanStartDate).HasColumnType("date");

                entity.Property(e => e.MaxLoanAmountGrantable).HasColumnType("numeric(20, 5)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.LoanDetails)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__Loan_Deta__usern__3E52440B");
            });

            modelBuilder.Entity<PersonalDetails>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Personal__F3DBC5734C6093D6");

                entity.ToTable("Personal_Details");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PanNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
