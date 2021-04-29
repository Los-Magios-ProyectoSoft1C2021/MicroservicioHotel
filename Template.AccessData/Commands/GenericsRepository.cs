using MicroservicioHotel.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroservicioHotel.AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly HotelDbContext _context;

        public GenericsRepository(HotelDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add<T>(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update<T>(entity);
            _context.SaveChanges();
        }
    }
}
