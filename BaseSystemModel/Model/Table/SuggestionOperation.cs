namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuggestionOperation")]
    public partial class SuggestionOperation
    {
        public int Id { get; set; }

        public int FK_SuggestionId { get; set; }

        public int FK_SuggestionBusinessId { get; set; }

        public int FK_UserId { get; set; }

        public DateTime Date { get; set; }

        public virtual Suggestion Suggestion { get; set; }

        public virtual SuggestionBusiness SuggestionBusiness { get; set; }

        public virtual User User { get; set; }
    }
}
