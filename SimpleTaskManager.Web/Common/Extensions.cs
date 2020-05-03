using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using SimpleTaskManager.Data.Entities;
using SimpleTaskManager.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SimpleTaskManager.Web.Common
{
    public static class Extensions
    {
        public static List<SelectListItem> ToSelectList(this Type enumType)
        {
            if (!enumType.IsEnum)
                throw new InvalidOperationException("Other type has been used where enum was intended");

            var itemList = new List<SelectListItem>();
            foreach (int value in Enum.GetValues(enumType))
            {
                itemList.Add(new SelectListItem(Enum.GetName(enumType, value), value.ToString()));
            }
            return itemList;
        }

        public static bool IsActiveAccount(this IPrincipal principal, IServiceCollection services)
        {            
            // Not sure this is right (building the service provider here) but for now I will leave it
            // TODO: Fix the dependency injection here
            var userRepository = services.BuildServiceProvider().GetService<IUserRepository>();
            return userRepository.IsActiveUser(principal.Identity.Name);
        }
    }
}
