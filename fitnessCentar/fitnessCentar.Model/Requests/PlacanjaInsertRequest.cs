﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCentar.Model.Requests
{
    public class PlacanjaInsertRequest
    {
        [Required(ErrorMessage = "Iznos je obavezno polje.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Iznos mora biti veći od 0.")]

        public float Iznos { get; set; }

        public int TipClanarineId { get; set; }

        public int KorisnikId { get; set; } 

        [Required(ErrorMessage = "Datum je obavezno polje.")]
        public DateTime Datum { get; set; }
    }
}
