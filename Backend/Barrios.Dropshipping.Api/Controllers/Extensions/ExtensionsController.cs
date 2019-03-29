using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Api.Controllers.Extensions
{
    public static class ExtensionsController
    {
        public static int GetId(Controller controller)
        {
            return Convert.ToInt32(controller.HttpContext.User.Claims.Single(c => c.Type.Equals("id")).Value);
        }
    }
}