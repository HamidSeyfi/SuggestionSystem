namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SuggestionStatus
    {
        public int Id { get; set; }

        public int Code { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }
    }
}
