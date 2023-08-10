using System;
using System.Collections.Generic;

namespace APIBACKEND.Models;

public partial class Todolist
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public bool EsActivo { get; set; }
}
