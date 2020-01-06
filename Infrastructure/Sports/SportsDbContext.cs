using Domain.Sports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Sports
{
    public class SportsDbContext : DbContext
    {
        public SportsDbContext() { }
        public SportsDbContext(DbContextOptions<SportsDbContext> options) : base(options) { }

        //TODO: get from Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            if (!options.IsConfigured)
            {
                //options.UseSqlite("Data Source=database1.db"); //doesn't support byte/ushort/short/uint

                //Oracle UseMySQL - notice capital letters.
                options.UseMySql(@"Server=localhost;Database=database1;Uid=root;Pwd=--09=-09");
                //MySQL:   Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
                //SQL SERVER: Server = myServerAddress; Database = myDataBase; User Id = myUsername; Password = myPassword;   -or Trusted_Connection=True;

                // .UseSqlite("DataSource=:memory:")
                //  if (!optionsBuilder.IsConfigured)
                //{
                //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
                //}
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //TODO
            mb.Entity<TeamMapDao>()
                .HasKey(o => new { o.SeasonId, o.TeamId });

            mb.Entity<LeagueDao>()
                .Property(p => p.Sex)
                .HasConversion<EnumToNumberConverter<Sex, short>>();
            mb.Entity<LeagueDao>()
                .Property(p => p.Sport)
                .HasConversion<EnumToNumberConverter<Sport, short>>();
            mb.Entity<LeagueDao>()
                .Property(p => p.LeagueLocation)
                .HasConversion<EnumToNumberConverter<LeagueLocation, short>>();
            
            
            //modelBuilder.Entity<League>()
            //    .OwnsMany(o => o.Conferences).
            //    .OwnsMany(o => o.Divisions)
            //    .OwnsMany(o => o.Teams);



            //modelBuilder.Entity<TeamMap>()
            //    .HasOne(o => o.Conference)
            //    .WithMany(o => o.C)
            //    .HasForeignKey(o => o.BookId);
            //modelBuilder.Entity<BookCategory>()
            //    .HasOne(o => o.Category)
            //    .WithMany(o => o.BookCategories)
            //    .HasForeignKey(o => o.CategoryId);
        }  

        //make them internal, or getter internal
        public DbSet<LeagueDao> Leagues { get; set; }
        public DbSet<ConferenceDao> Conferences { get; set; }
        public DbSet<DivisionDao> Divisions { get; set; }
        public DbSet<SeasonDao> Seasons { get; set; }
        public DbSet<TeamDao> Teams { get; set; }
    }
}