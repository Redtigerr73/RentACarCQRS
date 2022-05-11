using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Booking> Bookings { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Package> Packages { get; set; }
        DbSet<TransferFee> TransferFees { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}