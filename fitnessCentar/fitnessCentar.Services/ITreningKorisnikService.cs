﻿using fitnessCentar.Model.Requests;
using fitnessCentar.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessCentar.Services
{
    public interface ITreningKorisnikService : ICRUDService<Model.TreningKorisnik, TreningKorisnikSearchObject, TreningKorisnikInsertRequest, TreningKorisnikUpdateRequest>
    {
    }
}
