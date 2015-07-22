using System;
using System.Configuration;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using qweMVC.Utilities;

namespace qweMVC.Filters
{
    public class CustomAuthAttribute:AuthorizeAttribute
    {
        public string UsersConfigKey { get; set; }
        public string RolesConfigKey { get; set; }
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated) return;

            var authorizedUsers = ConfigurationManager.AppSettings[UsersConfigKey];
            var authorizedRoles = ConfigurationManager.AppSettings[RolesConfigKey];

            Users = String.IsNullOrEmpty(Users) ? authorizedUsers : Users;
            Roles = String.IsNullOrEmpty(Roles) ? authorizedRoles : Roles;

            if (!String.IsNullOrEmpty(Roles))
            {
                if (!CurrentUser.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
                }
            }

            if (!String.IsNullOrEmpty(Users))
            {
                if (!Users.Contains(CurrentUser.UserId.ToString(CultureInfo.InvariantCulture)))
                {
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
                }
            }
        }
    }
}