﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TourFlowBE.Models;

public partial class CityDestination
{
    public int Id { get; set; }

    public string? City { get; set; }

    public int? CountryDestinationId { get; set; }

    public virtual CountryDestination? CountryDestination { get; set; }

    public virtual ICollection<Img> Imgs { get; set; } = new List<Img>();

    [JsonIgnore]
    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}