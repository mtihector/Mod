namespace Mod.Core.ModuleA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelTest : DbContext
    {
        public ModelTest()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Aggregate> Aggregates { get; set; }
        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aggregate>()
                .Property(e => e.Application)
                .IsUnicode(false);

            modelBuilder.Entity<Aggregate>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Aggregate>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Aggregate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.EventType)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.EventData)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);
        }
    }
}
