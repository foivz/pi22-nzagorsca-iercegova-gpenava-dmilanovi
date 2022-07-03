using System;
using System.Collections.Generic;

namespace PodaciIzBaze.Models
{
    public partial class TmpSensor
    {
        public long SnrSensorId { get; set; }
        public string? SnrBleMac { get; set; }
        public int? SnrNbpsPacketsSent { get; set; }
        public double? SnrNbpsBatteryVoltage { get; set; }
        public double? SnrNbpsBatteryLevel { get; set; }
        public int? SnrNbpsNetworkSignal { get; set; }
        public int? SnrNbpsRsrqValue { get; set; }
        public long? SnrNbpsCellId { get; set; }
        public DateTimeOffset? SnrCurrentMagdataTime { get; set; }
    }
}
