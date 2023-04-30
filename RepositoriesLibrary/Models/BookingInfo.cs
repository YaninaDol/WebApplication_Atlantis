using System;
using System.Collections.Generic;

namespace RepositoriesLibrary.Models;

public partial class BookingInfo
{
    public int Id { get; set; }

    public DateTime? DateFisrt { get; set; }

    public DateTime? DateLast { get; set; }

    public int? RoomNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public int? TotalDays { get; set; }

    public string? UserId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }
}
