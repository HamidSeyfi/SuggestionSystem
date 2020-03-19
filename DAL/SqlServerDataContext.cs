namespace SuggestionSystem.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SuggestionSystem.BaseSystemModel.Model.Table;

    public partial class SqlServerDataContext : DbContext
    {
        public SqlServerDataContext()
            : base(SuggestionSystem.BaseSystemModel.Common.ConnectionString.SqlServerConnectionString)
        {
        }
        public virtual DbSet<Access> Access { get; set; }
        public virtual DbSet<CommitteeRole> CommitteeRole { get; set; }
        public virtual DbSet<CommitteeRoleType> CommitteeRoleType { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Suggestion> Suggestion { get; set; }
        public virtual DbSet<SuggestionStatus> SuggestionStatus { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCommitteeRole_Rel> UserCommitteeRole_Rel { get; set; }
        public virtual DbSet<UserAccess_Rel> UserAccess_Rel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>()
                .Property(e => e.CodeStr)
                .IsUnicode(false);

            modelBuilder.Entity<Access>()
                .HasMany(e => e.UserAccess_Rel)
                .WithRequired(e => e.Access)
                .HasForeignKey(e => e.FK_AccessId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommitteeRole>()
                .HasMany(e => e.UserCommitteeRole_Rel)
                .WithRequired(e => e.CommitteeRole)
                .HasForeignKey(e => e.FK_CommitteeRoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.LogName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Log)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.FK_UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Suggestion)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FK_UserId_Insert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Suggestion1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.FK_UserId_Update);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserAccess_Rel)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FK_UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserCommitteeRole_Rel)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FK_UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
