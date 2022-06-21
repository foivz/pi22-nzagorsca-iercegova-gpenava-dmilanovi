using System;
using System.Collections.Generic;

namespace PodaciIzBaze.Models
{
    public partial class TmpUser
    {
        public int UserId { get; set; }
        public string Lozinka { get; set; } = null!;
        public int CardId { get; set; }
        public string CarTable { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string TipKorisnika { get; set; } = null!;
    }
}
