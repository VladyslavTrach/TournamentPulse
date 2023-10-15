using Microsoft.EntityFrameworkCore;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data.EntityTypeConfiguration;



namespace TournamentPulse.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // DbSet properties
        public DbSet<Academy> Academies { get; set; }
        public DbSet<Association> Associations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }


        //public DbSet<Fighter> Fighters { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<FighterCategoryTournament> FighterCategoryTournaments { get; set; }
        //public DbSet<AgeClass> AgeClasses { get; set; }
        //public DbSet<RankClass> RankClasses { get; set; }
        //public DbSet<WeightClass> WeightClasses { get; set; }
        //public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply entity configurations
            //modelBuilder.ApplyConfiguration(new FighterEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new FighterCategoryTournamentsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AcademyEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new AgeClassEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AssociationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new RankClassEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new WeightClassEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}