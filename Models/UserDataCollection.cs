using System;
using System.Collections.Generic;

namespace TourFlowBE.Models;

public partial class UserDataCollection
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ExpectedDestination { get; set; }

    public string? Departure { get; set; }

    public int? Budget { get; set; }

    public int? Participants { get; set; }

    public DateOnly? ExpectedDate { get; set; }

    public virtual TourflowUser? User { get; set; }
}
