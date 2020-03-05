namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwRoleSuggestionStatusBusiness")]
    public partial class vwRoleSuggestionStatusBusiness
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string RoleName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string SuggestionStatusName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string SuggestionBusinessName { get; set; }
    }
}
