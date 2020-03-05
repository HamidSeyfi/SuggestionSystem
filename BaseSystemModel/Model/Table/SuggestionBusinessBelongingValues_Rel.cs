namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SuggestionBusinessBelongingValues_Rel
    {
        public int Id { get; set; }

        public int FK_SuggestionBusinessId { get; set; }

        public int Fk_SuggestionBusinessBelonging { get; set; }

        [Required]
        [StringLength(10)]
        public string ValueType { get; set; }

        [Required]
        [StringLength(50)]
        public string Value { get; set; }

        public virtual SuggestionBusiness SuggestionBusiness { get; set; }

        public virtual SuggestionBusinessBelonging SuggestionBusinessBelonging { get; set; }
    }
}
