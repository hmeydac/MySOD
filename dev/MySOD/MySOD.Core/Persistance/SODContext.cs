namespace MySOD.Core.Persistance
{
    using System.Data.Entity;

    public class SODContext : DbContext
    {
        public SODContext()
            : base("MySODConnectionString")
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<StartOfDay> StartOfDays { get; set; }

        public DbSet<Commitment> Commitments { get; set; }
    }
}
