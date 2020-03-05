namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            RoleAccess_Rel = new HashSet<RoleAccess_Rel>();
            RoleSuggestionStatusBusiness_Rel = new HashSet<RoleSuggestionStatusBusiness_Rel>();
            RoleSuggestionStatusBusiness_Rel1 = new HashSet<RoleSuggestionStatusBusiness_Rel>();
            UserRole_Rel = new HashSet<UserRole_Rel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleAccess_Rel> RoleAccess_Rel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleSuggestionStatusBusiness_Rel> RoleSuggestionStatusBusiness_Rel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleSuggestionStatusBusiness_Rel> RoleSuggestionStatusBusiness_Rel1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole_Rel> UserRole_Rel { get; set; }
    }
}
