namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuggestionBusiness")]
    public partial class SuggestionBusiness
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuggestionBusiness()
        {
            SuggestionBusinessBelongingValues_Rel = new HashSet<SuggestionBusinessBelongingValues_Rel>();
            SuggestionOperation = new HashSet<SuggestionOperation>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestionBusinessBelongingValues_Rel> SuggestionBusinessBelongingValues_Rel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestionOperation> SuggestionOperation { get; set; }
    }
}
