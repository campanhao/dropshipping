using Api;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Barrios.Dropshipping.Api.Controllers.Base
{
    public class BaseController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));

        public void LogarErro(Exception ex)
        {
            log.Error(string.Empty, ex);
        }
    }
}