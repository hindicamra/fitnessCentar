﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCentar.Model
{
    public partial class TreningKorisnik
    {
        public int TreningKorisnikId { get; set; }

        public int? TreningId { get; set; }

        public int? KorisnikId { get; set; }

        public string? Opis { get; set; }

        public DateTime? DatumVreme { get; set; }
    }
}
