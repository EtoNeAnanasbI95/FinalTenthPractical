using System;
using System.Collections.Generic;

namespace EMIAS.Models;

public partial class ResearchDocument
{
    public int? IdAppointment { get; set; }

    public string Rtf { get; set; } = null!;

    public byte[]? Attachment { get; set; }
}
