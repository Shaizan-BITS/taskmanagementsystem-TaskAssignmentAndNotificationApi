using Microsoft.EntityFrameworkCore;
using TaskAssignmentAndNotificationApi.Models;

namespace TaskAssignmentAndNotificationApi.Database
{
    public partial class TaskAssignmentAndNotificationDbContext : DbContext
    {
        public TaskAssignmentAndNotificationDbContext()
        {
        }

        public TaskAssignmentAndNotificationDbContext(DbContextOptions<TaskAssignmentAndNotificationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Discussion> Discussions { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Models.Task> Tasks { get; set; } = null!;
        public virtual DbSet<TaskAssignment> TaskAssignments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskManagementSystem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CommentId)
                    .HasColumnName("CommentID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.DiscussionId).HasColumnName("DiscussionID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK__Comments__Create__31EC6D26");

                entity.HasOne(d => d.Discussion)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.DiscussionId)
                    .HasConstraintName("FK__Comments__Discus__30F848ED");
            });

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.Property(e => e.DiscussionId)
                    .HasColumnName("DiscussionID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => d.CreatedById)
                    .HasConstraintName("FK__Discussio__Creat__2D27B809");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__Discussio__TaskI__2C3393D0");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationId)
                    .HasColumnName("NotificationID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.NotificationDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__UserI__3B75D760");
            });

            modelBuilder.Entity<Models.Task>(entity =>
            {
                entity.Property(e => e.TaskId)
                    .HasColumnName("TaskID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AssigneeId).HasColumnName("AssigneeID");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.CreatorId).HasColumnName("CreatorID");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.TaskAssignees)
                    .HasForeignKey(d => d.AssigneeId)
                    .HasConstraintName("FK__Tasks__AssigneeI__276EDEB3");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.TaskCreators)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("FK__Tasks__CreatorID__286302EC");
            });

            modelBuilder.Entity<TaskAssignment>(entity =>
            {
                entity.HasKey(e => e.AssignmentId)
                    .HasName("PK__TaskAssi__32499E57B8604FAE");

                entity.Property(e => e.AssignmentId)
                    .HasColumnName("AssignmentID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AssigneeId).HasColumnName("AssigneeID");

                entity.Property(e => e.AssignerId).HasColumnName("AssignerID");

                entity.Property(e => e.AssignmentDate).HasColumnType("datetime");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.TaskAssignmentAssignees)
                    .HasForeignKey(d => d.AssigneeId)
                    .HasConstraintName("FK__TaskAssig__Assig__37A5467C");

                entity.HasOne(d => d.Assigner)
                    .WithMany(p => p.TaskAssignmentAssigners)
                    .HasForeignKey(d => d.AssignerId)
                    .HasConstraintName("FK__TaskAssig__Assig__36B12243");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskAssignments)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__TaskAssig__TaskI__35BCFE0A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
