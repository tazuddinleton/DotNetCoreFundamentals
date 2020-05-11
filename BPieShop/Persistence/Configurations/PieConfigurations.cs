using BPieShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPieShop.Persistence.Configurations
{
    public class PieConfigurations : IEntityTypeConfiguration<Pie>
    {
        public void Configure(EntityTypeBuilder<Pie> builder)
        {
            builder.HasKey(x => x.PieId);
                    
        }
    }
}
