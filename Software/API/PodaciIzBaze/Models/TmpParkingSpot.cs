using System;
using System.Collections.Generic;

namespace PodaciIzBaze.Models
{
    public partial class TmpParkingSpot
    {
        public long SptParkingSpotId { get; set; }
        public string? SptLabel { get; set; }
        public long? SptParkingSpaceId { get; set; }
        public int? SptIndex { get; set; }
        public double? SptLatitude { get; set; }
        public double? SptLongitude { get; set; }
        public bool? SptOccupied { get; set; }
        public DateTimeOffset? SptOccupiedTimestamp { get; set; }
        public string? SptSpotType { get; set; }
    }
}
