﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace HBMStore.WebApps.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");
    }
}
