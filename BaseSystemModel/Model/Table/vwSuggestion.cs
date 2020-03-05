namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwSuggestion")]
    public partial class vwSuggestion
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SuggestionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SuggestionTitle { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(101)]
        public string InsertUserFullName { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime SuggestionInsertDate { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(101)]
        public string UpdateUserFullName { get; set; }

        public DateTime? SuggestionUpdateDate { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(500)]
        public string SuggestionStatusName { get; set; }
    }
}
