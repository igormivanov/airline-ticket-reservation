using AirlineTicketReservation.API.Models;
using AirlineTicketReservation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketReservation.API.Data.Configurations {
    public class LoyaltyProgramEntityConfiguration : IEntityTypeConfiguration<LoyaltyProgramEntity> {
        public void Configure(EntityTypeBuilder<LoyaltyProgramEntity> builder) {

            builder.ToTable("tb_loyalty_programs");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreationDate)
                  .IsRequired();

            builder.Property(l => l.Level)
                .HasConversion<string>();
        }
    }
}
