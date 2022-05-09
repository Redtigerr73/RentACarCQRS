using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<BookingEntity> Bookings { get; set; }
        DbSet<CarEntity> Cars { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
