using System;
using System.Collections.Generic;

namespace RepositoriesLibrary.Models;

public partial class Room
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Picture1 { get; set; }

    public string? Picture2 { get; set; }

    public string? Picture3 { get; set; }

    public int? Category { get; set; }

    public int? Capacity { get; set; }

    public int? Status { get; set; }

    public string? Description { get; set; }

    public int? Side { get; set; }

    public string? Views { get; set; }

    public string? Size { get; set; }

    public string? Notice { get; set; }
    public int? Price { get; set; }
    public virtual Category? CategoryNavigation { get; set; }

    public virtual RoomSide? SideNavigation { get; set; }

    public virtual RoomStatus? StatusNavigation { get; set; }
}
