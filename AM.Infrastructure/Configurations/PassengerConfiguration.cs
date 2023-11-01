using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    internal class PassengerConfiguration :IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName, f =>
                {
                    f.Property(n => n.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                    f.Property(l => l.LastName).HasColumnName("PassLastName").IsRequired();
                });
        }
    }
}
