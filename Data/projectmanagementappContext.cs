using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectManagement.Data;

#nullable disable

namespace ProjectManagement.Data2
{
    public partial class projectmanagementappContext : DbContext
    {
        public projectmanagementappContext()
        {
        }

        public projectmanagementappContext(DbContextOptions<projectmanagementappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientPartner> ClientPartners { get; set; }
        public virtual DbSet<OnProject> OnProjects { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectManager> ProjectManagers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost; port=4306; user=studentai; password=studentai; database=projectmanagementapp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientPartner>(entity =>
            {
                entity.ToTable("client_partner");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.CpAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("cp_address");

                entity.Property(e => e.CpDetails)
                    .IsRequired()
                    .HasColumnName("cp_details");

                entity.Property(e => e.CpName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("cp_name");
            });

            modelBuilder.Entity<OnProject>(entity =>
            {
                entity.ToTable("on_project");

                entity.HasIndex(e => e.ClientPartnerId, "client_partner_id");

                entity.HasIndex(e => e.ProjectId, "project_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ClientPartnerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("client_partner_id");

                entity.Property(e => e.DateEnd)
                    .HasColumnType("date")
                    .HasColumnName("date_end")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.DateStart)
                    .HasColumnType("date")
                    .HasColumnName("date_start");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IsClient).HasColumnName("is_client");

                entity.Property(e => e.IsPartner).HasColumnName("is_partner");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("project_id");

                entity.HasOne(d => d.ClientPartner)
                    .WithMany(p => p.OnProjects)
                    .HasForeignKey(d => d.ClientPartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("on_project_ibfk_1");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.OnProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("on_project_ibfk_2");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("project");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ActualEndDate)
                    .HasColumnType("date")
                    .HasColumnName("actual_end_date");

                entity.Property(e => e.ActualStartDate)
                    .HasColumnType("date")
                    .HasColumnName("actual_start_date");

                entity.Property(e => e.PlannedEndDate)
                    .HasColumnType("date")
                    .HasColumnName("planned_end_date");

                entity.Property(e => e.PlannedStartDate)
                    .HasColumnType("date")
                    .HasColumnName("planned_start_date");

                entity.Property(e => e.ProjectDescription)
                    .IsRequired()
                    .HasColumnName("project_description");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("project_name");
            });

            modelBuilder.Entity<ProjectManager>(entity =>
            {
                entity.ToTable("project_manager");

                entity.HasIndex(e => new { e.ProjectId, e.EmployeeId }, "project_id");

                entity.HasIndex(e => e.EmployeeId, "user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ProjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("project_id");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectManagers)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_manager_ibfk_3");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ProjectManagers)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("project_manager_ibfk_1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("surname");
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
