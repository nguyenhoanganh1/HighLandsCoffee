namespace WindowsFormsApp2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoleDetail
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NameAction { get; set; }

        public int? IdEmployee { get; set; }

        public int? IdRole { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Role Role { get; set; }
    }
}
