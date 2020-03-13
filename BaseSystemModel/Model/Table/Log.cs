namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        public int Id { get; set; }

        public int? FK_UserId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        public string LogName { get; set; }

        //[Required]
        [StringLength(1000)]
        public string LogText { get; set; }

        public virtual User User { get; set; }

        public byte LogType { get; set; }
    }
}
