using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaciDolci.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaciDolci.App.Attributes
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var roles = this.Roles.Split(',');

            //BaciDolciContext data = new BaciDolciContext();

            //var currentRoles =
            //    data.Users.FirstOrDefault(user => user.UserName == filterContext.HttpContext.User.Identity.Name).Roles;

            //List<string> names = new List<string>();

            //foreach (IdentityUserRole identityUserRole in currentRoles)
            //{
            //    var name = data.Roles.FirstOrDefault(role => role.Id == identityUserRole.RoleId).Name;
            //    names.Add(name);
            //}

            if (filterContext.HttpContext.Request.IsAuthenticated && !roles.Any(filterContext.HttpContext.User.IsInRole)) // && roles.Any(s=> filterContext.HttpContext.User.IsInRole(s)))
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Unauthorized.cshtml"
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}