using AirlineTicketReservation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineTicketReservation.API.Data.Configurations {
    public class PassengerEntityConfiguration : IEntityTypeConfiguration<Passenger> {
        public void Configure(EntityTypeBuilder<Passenger> builder) {

            builder.ToTable("tb_passengers");

            builder.HasKey(x => x.Id);
            builder.HasIndex(w => new { w.Email, w.IdentityDocument }).IsUnique();

            builder.Property(p => p.FullName)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(p => p.Phone)
               .IsRequired()
               .HasMaxLength(15);

            builder.Property(p => p.IdentityDocument)
               .IsRequired()
               .HasMaxLength(20);

            builder.Property(p => p.Roles)
                .IsRequired()
                .HasConversion<string>();

            builder.HasOne(p => p.LoyaltyProgram)
                .WithOne(l => l.Passenger)
                .HasForeignKey<LoyaltyProgram>(l => l.PassengerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
