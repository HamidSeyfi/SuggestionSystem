namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuggestionBusinessBelonging")]
    public partial class SuggestionBusinessBelonging
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuggestionBusinessBelonging()
        {
            SuggestionBusinessBelongingValues_Rel = new HashSet<SuggestionBusinessBelongingValues_Rel>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestionBusinessBelongingValues_Rel> SuggestionBusinessBelongingValues_Rel { get; set; }
    }
}
