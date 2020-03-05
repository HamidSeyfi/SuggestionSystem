namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoleAccess_Rel
    {
        public int Id { get; set; }

        public int FK_RoleId { get; set; }

        public int FK_AccessId { get; set; }

        public virtual Access Access { get; set; }

        public virtual Role Role { get; set; }
    }
}
