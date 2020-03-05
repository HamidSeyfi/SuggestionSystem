namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwSuggestionBusiness")]
    public partial class vwSuggestionBusiness
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SuggestionBusinessId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SuggestionBusinessName { get; set; }

        public int? SuggestionBusinessBelongingId { get; set; }

        [StringLength(500)]
        public string SuggestionBusinessBelongingName { get; set; }

        public int? SuggestionBusinessBelongingValues_RelId { get; set; }

        [StringLength(50)]
        public string Value { get; set; }
    }
}
