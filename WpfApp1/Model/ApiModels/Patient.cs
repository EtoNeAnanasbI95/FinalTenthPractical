using System;
using System.Collections.Generic;

namespace EMIAS.Models;

public partial class Patient
{
    public long? Oms { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public DateOnly BirthDay { get; set; }

    public string AddressPatient { get; set; } = null!;

    public string? LivingAddress { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Nickname { get; set; }
}
