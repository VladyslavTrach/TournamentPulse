using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data.EntityTypeConfiguration;



namespace TournamentPulse.Infrastructure.Data
{
    public class ApplicationDataContext : IdentityDbContext
    {
        //-----Fix "Unable to create an object of type DataContext" Bug-----//

        public ApplicationDataContext()
        {

        }
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }



        // DbSet properties
        public DbSet<Academy> Academies { get; set; }
        public DbSet<Association> Associations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<TournamentCategoryFighter> TournamentCategoryFighter { get; set; }
        //public DbSet<AgeClass> AgeClasses { get; set; }
        //public DbSet<RankClass> RankClasses { get; set; }
        //public DbSet<WeightClass> WeightClasses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply entity configurations
            modelBuilder.ApplyConfiguration(new FighterEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentCategoryFighterEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AcademyEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new AgeClassEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AssociationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new RankClassEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new WeightClassEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MatchEntityConfiguration());


            //-----------//
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(ul => ul.UserId);
        }

        //-----Fix "Unable to create an object of type DataContext" Bug-----//

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PTAHNE9\\SQLEXPRESS;Initial Catalog=TournamentPulse;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }



    //-----FIX of Scaffolding Bug-----//

    //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    //{
    //    public DataContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
    //        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true");

    //        return new DataContext(optionsBuilder.Options);
    //    }
    //}
}