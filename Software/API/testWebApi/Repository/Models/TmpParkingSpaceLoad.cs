using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models
{
    [Keyless]
    [Table("tmp_parking_space_load")]
    public partial class TmpParkingSpaceLoad
    {
        [Column("psl_parking_space_id")]
        public long? PslParkingSpaceId { get; set; }
        [Column("psl_load")]
        public double? PslLoad { get; set; }
        [Column("psl_datetime")]
        public DateTimeOffset? PslDatetime { get; set; }
    }
}
