using System;
using System.Collections.Generic;

namespace RepositoriesLibrary.Models;

public partial class ListBookDate
{
    public int Id { get; set; }

    public int? RoomNumber { get; set; }

    public string? UserId { get; set; }

    public DateTime? Date { get; set; }
}
