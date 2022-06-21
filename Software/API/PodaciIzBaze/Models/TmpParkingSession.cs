using System;
using System.Collections.Generic;

namespace PodaciIzBaze.Models
{
    public partial class TmpParkingSession
    {
        public long PssParkingSessionId { get; set; }
        public long? PssSensorId { get; set; }
        public long? PssParkingSpotId { get; set; }
        public DateTimeOffset? PssStartTime { get; set; }
        public DateTimeOffset? PssEndTime { get; set; }
    }
}
