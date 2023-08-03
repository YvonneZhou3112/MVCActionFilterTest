using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Filters
{
    public class UserAuthorizeAttribute:FilterAttribute, IAuthorizationFilter
    {
        public void  OnAuthorization(AuthorizationContext context)
        { 

        }
    }
}