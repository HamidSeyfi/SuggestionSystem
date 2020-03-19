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
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int FK_CommitteeRoleCode { get; set; }

        public int FK_SuggestionStatusCode { get; set; }

        public int FK_UserId_Insert { get; set; }

        public DateTime InsertDate { get; set; }

        public int? FK_UserId_Update { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
