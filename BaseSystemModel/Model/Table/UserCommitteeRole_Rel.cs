namespace SuggestionSystem.BaseSystemModel.Model.Table
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserCommitteeRole_Rel
    {
        public int Id { get; set; }

        public int FK_UserId { get; set; }

        public int FK_CommitteeRoleId { get; set; }

        public virtual CommitteeRole CommitteeRole { get; set; }

        public virtual User User { get; set; }
    }
}
