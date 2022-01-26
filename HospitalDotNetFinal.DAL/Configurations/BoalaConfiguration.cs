using HospitalDotNetFinal.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDotNetFinal.DAL.Configurations
{
    public class BoalaConfiguration : IEntityTypeConfiguration<Boala>
    {

        public void Configure(EntityTypeBuilder<Boala> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumeBoala)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

        }
    }
}
