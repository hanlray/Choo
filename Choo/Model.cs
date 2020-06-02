using Choo.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace Choo
{
    public class ChooDbContext : DbContext
    {
        public ChooDbContext(DbContextOptions<ChooDbContext> options) : base(options)
        {
        }

        public DbSet<TrainPassage> TrainPassages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<CarPassage>()
                .Property(p => p.CarPassageId)
                .ValueGeneratedOnAdd();*/

            //modelBuilder.ApplyConfiguration(new PassageConfiguration());
            modelBuilder.Entity<TrainPassage>().HasData
            (
                new TrainPassage
                {
                    TrainPassageId = 1,
                    TrainNumber = 1,
                    PassTime = DateTime.Parse("08/18/2018 07:22:16")
                },
                new TrainPassage
                {
                    TrainPassageId = 2,
                    TrainNumber = 1,
                    PassTime = DateTime.Parse("08/18/2018 08:22:16")
                }
            );
            modelBuilder.Entity<CarPassage>()
                .HasData(
                new CarPassage() { 
                    CarPassageId = 1, 
                    TrainPassageId = 1,
                    CarNumber = 1,
                    PassTime = DateTime.Parse("08/18/2018 07:22:16") 
                },
                new CarPassage()
                {
                    CarPassageId = 2,
                    TrainPassageId = 1,
                    CarNumber = 2,
                    PassTime = DateTime.Parse("08/18/2018 07:22:18")
                },
                new CarPassage()
                {
                    CarPassageId = 3,
                    TrainPassageId = 2,
                    CarNumber = 1,
                    PassTime = DateTime.Parse("08/18/2018 08:22:16")
                },
                new CarPassage()
                {
                    CarPassageId = 4,
                    TrainPassageId = 2,
                    CarNumber = 2,
                    PassTime = DateTime.Parse("08/18/2018 08:22:18")
                });
        }
    }

    public class TrainPassage
    {
        public TrainPassage() { }
        public TrainPassage(DateTime passTime)
        {
            PassTime = passTime;
        }

        public int TrainPassageId { get; set; }
        public int TrainNumber { get; set; }
        public DateTime PassTime { get; set; }

        public virtual ICollection<CarPassage> CarPassages { get; set; }
    }

    public class CarPassage
    {
        private DateTime time;

        public CarPassage() { }
        public CarPassage(DateTime time)
        {
            this.time = time;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarPassageId { get; set; }

        public int CarNumber { get; set; }
        public DateTime PassTime { get; set; }

        public int TrainPassageId { get; set; }
        public virtual TrainPassage TrainPassage { get; set; }
    }
}
