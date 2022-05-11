﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Persistence.Configurations
{
    public partial class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> entity)
        {
            entity.ToTable("Package");

            entity.HasIndex(e => e.Name, "IX_Name")
                .IsUnique();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.TransferFee)
                .WithMany(p => p.Packages)
                .HasForeignKey(d => d.TransferFeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Package_TransferFee");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Package> entity);
    }
}
