namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SuggestionStatusBusiness_Rel
    {
        public int Id { get; set; }

        public int FK_SuggestionStatusId { get; set; }

        public int FK_SuggestionBusinessId { get; set; }

        public virtual SuggestionStatus SuggestionStatus { get; set; }
    }
}
