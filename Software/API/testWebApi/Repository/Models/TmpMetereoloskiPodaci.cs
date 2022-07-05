using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models
{
    [Table("tmp_metereoloski_podaci")]
    public partial class TmpMetereoloskiPodaci
    {
        [Key]
        [Column("ID_podatka")]
        public int IdPodatka { get; set; }
        [Column("dateTime", TypeName = "datetime")]
        public DateTime? DateTime { get; set; }
        [Column("temp")]
        public double? Temp { get; set; }
        [Column("cloudcover")]
        [StringLength(30)]
        public string? Cloudcover { get; set; }
        [Column("visibility")]
        [StringLength(50)]
        public string? Visibility { get; set; }
    }
}
