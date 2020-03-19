namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommitteeRole")]
    public partial class CommitteeRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommitteeRole()
        {
            UserCommitteeRole_Rel = new HashSet<UserCommitteeRole_Rel>();
        }

        public int Id { get; set; }

        public int? Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int FK_CommitteeRoleTypeCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCommitteeRole_Rel> UserCommitteeRole_Rel { get; set; }
    }
}
