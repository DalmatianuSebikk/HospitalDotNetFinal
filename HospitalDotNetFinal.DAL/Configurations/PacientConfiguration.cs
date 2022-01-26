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
    public class PacientConfiguration : IEntityTypeConfiguration<Pacient>
    {
        public void Configure(EntityTypeBuilder<Pacient> builder)
        {
            builder.Property(x => x.NumePacient)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
            builder.Property(x => x.CNP)

                .HasColumnType("nvarchar(15)")
                .HasMaxLength(13);

            builder.Property(x => x.NumarDeTelefon)
                .HasColumnType("nvarchar(25)")
                .HasMaxLength(10);
        }
    }
}
