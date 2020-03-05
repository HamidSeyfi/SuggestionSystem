namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwSuggestionStatusBusiness")]
    public partial class vwSuggestionStatusBusiness
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SuggestionStatusBusiness_RelID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SuggestionStatusId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string SuggestionStatusName { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SuggestionBusinessId { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string SuggestionBusinessName { get; set; }
    }
}
