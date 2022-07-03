using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models
{
    [Keyless]
    [Table("tmp_parking_session")]
    public partial class TmpParkingSession
    {
        [Column("pss_parking_session_id")]
        public long PssParkingSessionId { get; set; }
        [Column("pss_sensor_id")]
        public long? PssSensorId { get; set; }
        [Column("pss_parking_spot_id")]
        public long? PssParkingSpotId { get; set; }
        [Column("pss_start_time")]
        public DateTimeOffset? PssStartTime { get; set; }
        [Column("pss_end_time")]
        public DateTimeOffset? PssEndTime { get; set; }
    }
}
