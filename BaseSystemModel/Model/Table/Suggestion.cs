namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Suggestion")]
    public partial class Suggestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Suggestion()
        {
            SuggestionOperation = new HashSet<SuggestionOperation>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int FK_SuggestionStatusId { get; set; }

        public int FK_UserId_Insert { get; set; }

        public DateTime InsertDate { get; set; }

        public int? FK_UserId_Update { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual SuggestionStatus SuggestionStatus { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestionOperation> SuggestionOperation { get; set; }
    }
}
