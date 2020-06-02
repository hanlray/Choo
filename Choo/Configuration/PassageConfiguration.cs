using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Choo.Configuration
{
    public class PassageConfiguration : IEntityTypeConfiguration<TrainPassage>
    {
        public void Configure(EntityTypeBuilder<TrainPassage> builder)
        {
            builder.ToTable("TrainPassages");

            builder.HasData
            (
                new TrainPassage
                {
                    TrainPassageId = 1,
                    TrainNumber = 1,
                    PassTime = DateTime.Parse("08/18/2018 07:22:16")
                }
            );
        }
    }
}
