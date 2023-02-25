using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepositoriesLibrary.Models;
namespace DataAccess.Data;

public partial class Atlantis20DbContext : IdentityDbContext<IdentityUser>
{
    public Atlantis20DbContext()
    {
    }

    public Atlantis20DbContext(DbContextOptions<Atlantis20DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookingInfo> BookingInfos { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ListBookDate> ListBookDates { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomSide> RoomSides { get; set; }

    public virtual DbSet<RoomStatus> RoomStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ATLANTIS_2_0_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
