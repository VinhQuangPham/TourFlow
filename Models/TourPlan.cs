using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TourFlowBE.Models;

public partial class TourPlan
{
    public int Id { get; set; }

    public int? TourId { get; set; }

    public string? Detail { get; set; }

    [JsonIgnore]
    public virtual Tour? Tour { get; set; }
}
