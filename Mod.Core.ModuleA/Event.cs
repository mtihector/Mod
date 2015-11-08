namespace Mod.Core.ModuleA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        [Key]
        [Column(Order = 0)]
        public Guid AggregateId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(500)]
        public string EventType { get; set; }

        [Key]
        [Column(Order = 3)]
        public string EventData { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime CreatedOn { get; set; }

        public virtual Aggregate Aggregate { get; set; }
    }
}
