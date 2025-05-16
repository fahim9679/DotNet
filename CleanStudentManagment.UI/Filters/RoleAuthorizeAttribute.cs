using CleanStudentManagment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagment.UI.Filters
{
    public class RoleAuthorizeAttribute:AuthorizeAttribute,IAuthorizationFilter
    {
        private readonly int _roles;
        public RoleAuthorizeAttribute(int roles)
        {
            _roles = roles;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var sessionObject = context.HttpContext.Session.GetString("LoginDetails");            
            if (string.IsNullOrEmpty(sessionObject))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
                return;
            }
            var loginDetails = JsonConvert.DeserializeObject<LoginViewModel>(sessionObject);
            if(loginDetails.Role != _roles)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
    
    
}
