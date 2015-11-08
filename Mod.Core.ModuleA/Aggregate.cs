namespace Mod.Core.ModuleA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Aggregate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aggregate()
        {
            Events = new HashSet<Event>();
        }

        public Guid AggregateId { get; set; }

        [Required]
        [StringLength(200)]
        public string Application { get; set; }

        [Required]
        [StringLength(500)]
        public string Type { get; set; }

        public int CurrentVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
    }
}
