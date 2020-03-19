namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommitteeRoleType")]
    public partial class CommitteeRoleType
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
