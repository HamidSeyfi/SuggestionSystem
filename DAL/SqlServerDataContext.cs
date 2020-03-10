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
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleAccess_Rel> RoleAccess_Rel { get; set; }
        public virtual DbSet<RoleSuggestionStatusBusiness_Rel> RoleSuggestionStatusBusiness_Rel { get; set; }
        public virtual DbSet<Suggestion> Suggestion { get; set; }
        public virtual DbSet<SuggestionBusiness> SuggestionBusiness { get; set; }
        public virtual DbSet<SuggestionBusinessBelonging> SuggestionBusinessBelonging { get; set; }
        public virtual DbSet<SuggestionBusinessBelongingValues_Rel> SuggestionBusinessBelongingValues_Rel { get; set; }
        public virtual DbSet<SuggestionOperation> SuggestionOperation { get; set; }
        public virtual DbSet<SuggestionStatus> SuggestionStatus { get; set; }
        public virtual DbSet<SuggestionStatusBusiness_Rel> SuggestionStatusBusiness_Rel { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<UserRole_Rel> UserRole_Rel { get; set; }
        public virtual DbSet<vwRoleAccess> vwRoleAccess { get; set; }
        public virtual DbSet<vwRoleSuggestionStatusBusiness> vwRoleSuggestionStatusBusiness { get; set; }
        public virtual DbSet<vwSuggestion> vwSuggestion { get; set; }
        public virtual DbSet<vwSuggestionBusiness> vwSuggestionBusiness { get; set; }
        public virtual DbSet<vwSuggestionStatusBusiness> vwSuggestionStatusBusiness { get; set; }
        public virtual DbSet<vwUserRole> vwUserRole { get; set; }
        public virtual DbSet<vwUserRoleAccess> vwUserRoleAccess { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>()
                .HasMany(e => e.RoleAccess_Rel)
                .WithRequired(e => e.Access)
                .HasForeignKey(e => e.FK_AccessId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RoleAccess_Rel)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.FK_RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RoleSuggestionStatusBusiness_Rel)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.FK_RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.RoleSuggestionStatusBusiness_Rel1)
                .WithRequired(e => e.Role1)
                .HasForeignKey(e => e.FK_RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRole_Rel)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.FK_RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Suggestion>()
                .HasMany(e => e.SuggestionOperation)
                .WithRequired(e => e.Suggestion)
                .HasForeignKey(e => e.FK_SuggestionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SuggestionBusiness>()
                .HasMany(e => e.SuggestionBusinessBelongingValues_Rel)
                .WithRequired(e => e.SuggestionBusiness)
                .HasForeignKey(e => e.FK_SuggestionBusinessId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SuggestionBusiness>()
                .HasMany(e => e.SuggestionOperation)
                .WithRequired(e => e.SuggestionBusiness)
                .HasForeignKey(e => e.FK_SuggestionBusinessId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SuggestionBusinessBelonging>()
                .HasMany(e => e.SuggestionBusinessBelongingValues_Rel)
                .WithRequired(e => e.SuggestionBusinessBelonging)
                .HasForeignKey(e => e.Fk_SuggestionBusinessBelonging)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SuggestionBusinessBelongingValues_Rel>()
                .Property(e => e.ValueType)
                .IsUnicode(false);

            modelBuilder.Entity<SuggestionStatus>()
                .HasMany(e => e.Suggestion)
                .WithRequired(e => e.SuggestionStatus)
                .HasForeignKey(e => e.FK_SuggestionStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SuggestionStatus>()
                .HasMany(e => e.SuggestionStatusBusiness_Rel)
                .WithRequired(e => e.SuggestionStatus)
                .HasForeignKey(e => e.FK_SuggestionStatusId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

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
                .HasMany(e => e.SuggestionOperation)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FK_UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRole_Rel)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FK_UserId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Log>()
               .Property(e => e.LogName)
               .IsUnicode(false);

            modelBuilder.Entity<User>()
               .HasMany(e => e.Log)
               .WithOptional(e => e.User)
               .HasForeignKey(e => e.FK_UserId);



        }
    }
}
