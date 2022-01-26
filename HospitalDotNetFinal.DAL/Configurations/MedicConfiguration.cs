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
    public class MedicConfiguration : IEntityTypeConfiguration<Medic>
    {
        public void Configure(EntityTypeBuilder<Medic> builder)
        {
            builder.Property(x => x.NumeMedic)
               .HasColumnType("nvarchar(100)")
               .HasMaxLength(100);

            builder.Property(x => x.NumarDeTelefon)
                .HasColumnType("nvarchar(25)")
                .HasMaxLength(10);
        }
    }
}
