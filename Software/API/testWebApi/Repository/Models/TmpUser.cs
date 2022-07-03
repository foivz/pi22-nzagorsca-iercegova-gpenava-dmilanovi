using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repository.Models
{
    [Table("tmp_users")]
    public partial class TmpUser
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("lozinka")]
        [StringLength(50)]
        [Unicode(false)]
        public string Lozinka { get; set; } = null!;
        [Column("card_id")]
        public int CardId { get; set; }
        [Column("car_table")]
        [StringLength(50)]
        [Unicode(false)]
        public string CarTable { get; set; } = null!;
        [Column("name")]
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;
        [Column("surname")]
        [StringLength(50)]
        [Unicode(false)]
        public string Surname { get; set; } = null!;
        [Column("tipKorisnika")]
        [StringLength(50)]
        [Unicode(false)]
        public string TipKorisnika { get; set; } = null!;
    }
}
