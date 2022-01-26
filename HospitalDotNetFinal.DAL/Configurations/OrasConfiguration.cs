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
    public class OrasConfiguration : IEntityTypeConfiguration<Oras>
    {
        public void Configure(EntityTypeBuilder<Oras> builder)
        {
            builder.Property(x => x.NumeOras)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
        }
    }
}
