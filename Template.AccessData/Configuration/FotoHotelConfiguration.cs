using MicroservicioHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.AccessData.Configuration
{
    public class FotoHotelConfiguration : IEntityTypeConfiguration<FotoHotel>
    {
        public void Configure(EntityTypeBuilder<FotoHotel> builder)
        {
            
        }
    }
}
