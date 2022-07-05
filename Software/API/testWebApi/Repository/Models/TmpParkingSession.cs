using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models
{
    [Table("parking_sessions")]
    public partial class TmpParkingSession
    {
        [Key]
        [Column("pss_parking_session_id")]
        public int PssParkingSessionId { get; set; }
        [Column("pss_sensor_id")]
        public short? PssSensorId { get; set; }
        [Column("pss_parking_spot_id")]
        public short? PssParkingSpotId { get; set; }
        [Column("pss_start_time")]
        [StringLength(50)]
        public string? PssStartTime { get; set; }
        [Column("pss_end_time")]
        [StringLength(50)]
        public string? PssEndTime { get; set; }
    }
}
