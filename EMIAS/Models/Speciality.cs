using System;
using System.Collections.Generic;

namespace EMIAS.Models;

public partial class Speciality
{
    public int? IdSpeciality { get; set; }

    public string NameSpecialities { get; set; } = null!;

    public string PathImage { get; set; } = null!;
}
