using ElectricityConsumption.Protos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectricityConsumption.Server.Infrastructure.FluentConfigurations;

public class MeterReadingConfiguration : IEntityTypeConfiguration<MeterReading>
{
    public void Configure(EntityTypeBuilder<MeterReading> builder)
    {
        builder.HasKey(x => x.Time);
    }
}
