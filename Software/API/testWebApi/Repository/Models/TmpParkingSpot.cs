using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models
{
    [Keyless]
    [Table("tmp_parking_spot")]
    public partial class TmpParkingSpot
    {
        [Column("spt_parking_spot_id")]
        public long SptParkingSpotId { get; set; }
        [Column("spt_label")]
        [StringLength(150)]
        public string? SptLabel { get; set; }
        [Column("spt_parking_space_id")]
        public long? SptParkingSpaceId { get; set; }
        [Column("spt_index")]
        public int? SptIndex { get; set; }
        [Column("spt_latitude")]
        public double? SptLatitude { get; set; }
        [Column("spt_longitude")]
        public double? SptLongitude { get; set; }
        [Column("spt_occupied")]
        public bool? SptOccupied { get; set; }
        [Column("spt_occupied_timestamp")]
        public DateTimeOffset? SptOccupiedTimestamp { get; set; }
        [Column("spt_spot_type")]
        [StringLength(150)]
        public string? SptSpotType { get; set; }
    }
}
