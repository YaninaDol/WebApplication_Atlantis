using System;
using System.Collections.Generic;

namespace RepositoriesLibrary.Models;

public partial class RoomSide
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
