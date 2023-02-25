using System;
using System.Collections.Generic;

namespace RepositoriesLibrary.Models;
public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? BedTypes { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
