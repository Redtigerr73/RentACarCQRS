using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public partial class TransferFeeConfiguration : IEntityTypeConfiguration<TransferFee>
    {
        public void Configure(EntityTypeBuilder<TransferFee> entity)
        {
            entity.ToTable("TransferFee");

            entity.HasIndex(e => new { e.PickUpLocationId, e.DropOffLocationId }, "IX_PickUp_DropOff")
                .IsUnique();

            entity.HasOne(d => d.DropOffLocation)
                .WithMany(p => p.TransferFeeDropOffLocations)
                .HasForeignKey(d => d.DropOffLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferFee_Location1");

            entity.HasOne(d => d.PickUpLocation)
                .WithMany(p => p.TransferFeePickUpLocations)
                .HasForeignKey(d => d.PickUpLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferFee_Location");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<TransferFee> entity);
    }
}