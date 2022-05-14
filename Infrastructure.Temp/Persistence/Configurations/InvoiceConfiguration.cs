﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Domain.Entities;
using Domain.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.Persistence.Configurations
{
    public partial class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> entity)
        {
            entity.ToTable("Invoice");

            entity.Property(e => e.IssueDate).HasColumnType("datetime");

            entity.Property(e => e.PaymentDate).HasColumnType("datetime");

            entity.Property(e => e.PaymentType).HasMaxLength(50);

            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Invoice> entity);
    }
}