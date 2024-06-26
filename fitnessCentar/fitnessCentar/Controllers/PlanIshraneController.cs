﻿using fitnessCentar.Model.Requests;
using fitnessCentar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fitnessCentar.Controllers
{
    [ApiController]
    [Authorize(Roles = "Korisnik, Admin,Uposlenik")]
    public class PlanIshraneController: BaseCRUDController<Model.PlanIshrane, Model.SearchObjects.PlanIshraneSearchObject, PlanIshraneInsertRequest, PlanIshraneUpdateRequest>
    {
        public PlanIshraneController(ILogger<BaseController<Model.PlanIshrane, Model.SearchObjects.PlanIshraneSearchObject>> logger, IPlanIshraneService service)
            : base(logger, service)
        {
        }
    }
}
