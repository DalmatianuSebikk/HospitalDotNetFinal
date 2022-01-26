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

    public class SpitalConfiguration : IEntityTypeConfiguration<Spital>
    {
        public void Configure(EntityTypeBuilder<Spital> builder)
        {
            builder.Property(x => x.NumeSpital)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
        }
    }

}
