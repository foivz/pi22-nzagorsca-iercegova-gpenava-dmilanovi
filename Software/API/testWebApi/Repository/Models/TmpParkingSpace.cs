using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models
{
    [Keyless]
    [Table("tmp_parking_space")]
    public partial class TmpParkingSpace
    {
        [Column("psp_parking_space_id")]
        public long PspParkingSpaceId { get; set; }
        [Column("psp_label")]
        [StringLength(150)]
        public string? PspLabel { get; set; }
        [Column("psp_latitude")]
        public double? PspLatitude { get; set; }
        [Column("psp_longitude")]
        public double? PspLongitude { get; set; }
        [Column("psp_city_name")]
        [StringLength(50)]
        public string? PspCityName { get; set; }
        [Column("psp_address_name")]
        [StringLength(50)]
        public string? PspAddressName { get; set; }
        [Column("psp_calculated_free_places")]
        public int? PspCalculatedFreePlaces { get; set; }
        [Column("psp_calculated_occupied_places")]
        public int? PspCalculatedOccupiedPlaces { get; set; }
    }
}
