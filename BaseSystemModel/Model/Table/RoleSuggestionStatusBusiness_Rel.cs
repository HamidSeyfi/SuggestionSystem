namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoleSuggestionStatusBusiness_Rel
    {
        public int Id { get; set; }

        public int FK_RoleId { get; set; }

        public int FK_SuggestionStatusBusiness_Rel { get; set; }

        public virtual Role Role { get; set; }

        public virtual Role Role1 { get; set; }
    }
}
