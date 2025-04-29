using Microsoft.EntityFrameworkCore;
using NZtut.API.Models.Domain;

namespace NZtut.API.Data
{
    public class NZtutDbContext: DbContext
    {
        public NZtutDbContext(DbContextOptions<NZtutDbContext> dbContextOptions): base(dbContextOptions)
        {
             
        }

        public DbSet<Difficulty> Difficulties{ get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            //Easy , Medium, Hard

            var difficulties = new List<Difficulty>()
            {
               new Difficulty()
               {
                   Id = Guid.Parse("f341e365-576e-4325-84c5-5dc0cb5a0808"),
                   Name = "Easy"
               },
               new Difficulty()
               {
                   Id = Guid.Parse("ca71359b-5198-4aba-8bb7-673c8d881d45"),
                   Name = "Medium"
               },
               new Difficulty()
               {
                   Id = Guid.Parse("e6426a88-6e27-4283-b2c4-55c5488e0b9c"),
                   Name = "Hard"
               }
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("4d5e9b47-81a8-4170-9322-68262f7a9581"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/30650062/pexels-photo-30650062/free-photo-of-black-and-white-fishing-scene-in-duzce-turkiye.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load"
                },
                new Region
                {
                    Id = Guid.Parse("9c32bfac-b1ea-4ff3-81de-f7526de92044"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://images.pexels.com/photos/6964308/pexels-photo-6964308.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("c6b4f5b1-f000-4342-8fbb-c30584c55f81"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://images.pexels.com/photos/31633279/pexels-photo-31633279/free-photo-of-joyful-surfer-tossing-surfboard-on-sunny-beach.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("1419e0fe-b92b-4cf3-9d0d-ef7332310c70"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/31008251/pexels-photo-31008251/free-photo-of-delicious-french-pastry-with-whipped-cream-and-mimosa.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("463b3c10-baab-4229-9fc6-b7317bcf32e6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/31633701/pexels-photo-31633701/free-photo-of-man-in-traditional-african-clothing-in-desert.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("3d22a598-e59e-4c7e-b2a2-a07f5686d362"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
