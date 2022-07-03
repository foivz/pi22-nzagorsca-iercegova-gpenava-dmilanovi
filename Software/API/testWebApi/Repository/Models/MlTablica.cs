using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models
{
    [Keyless]
    [Table("ml_tablica")]
    public partial class MlTablica
    {
        [Column("spt_occupied_timestamp")]
        public DateTimeOffset? SptOccupiedTimestamp { get; set; }
    }
}
