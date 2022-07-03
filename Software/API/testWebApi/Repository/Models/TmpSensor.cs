using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models
{
    [Keyless]
    [Table("tmp_sensor")]
    public partial class TmpSensor
    {
        [Column("snr_sensor_id")]
        public long SnrSensorId { get; set; }
        [Column("snr_ble_mac")]
        [StringLength(17)]
        public string? SnrBleMac { get; set; }
        [Column("snr_nbps_packets_sent")]
        public int? SnrNbpsPacketsSent { get; set; }
        [Column("snr_nbps_battery_voltage")]
        public double? SnrNbpsBatteryVoltage { get; set; }
        [Column("snr_nbps_battery_level")]
        public double? SnrNbpsBatteryLevel { get; set; }
        [Column("snr_nbps_network_signal")]
        public int? SnrNbpsNetworkSignal { get; set; }
        [Column("snr_nbps_rsrq_value")]
        public int? SnrNbpsRsrqValue { get; set; }
        [Column("snr_nbps_cell_id")]
        public long? SnrNbpsCellId { get; set; }
        [Column("snr_current_magdata_time")]
        public DateTimeOffset? SnrCurrentMagdataTime { get; set; }
    }
}
