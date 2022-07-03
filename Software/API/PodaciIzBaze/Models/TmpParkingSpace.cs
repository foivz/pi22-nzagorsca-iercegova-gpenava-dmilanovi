using System;
using System.Collections.Generic;

namespace PodaciIzBaze.Models
{
    public partial class TmpParkingSpace
    {
        public long PspParkingSpaceId { get; set; }
        public string? PspLabel { get; set; }
        public double? PspLatitude { get; set; }
        public double? PspLongitude { get; set; }
        public string? PspCityName { get; set; }
        public string? PspAddressName { get; set; }
        public int? PspCalculatedFreePlaces { get; set; }
        public int? PspCalculatedOccupiedPlaces { get; set; }
    }
}
