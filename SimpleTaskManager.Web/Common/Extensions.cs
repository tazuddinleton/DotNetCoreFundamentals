using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleTaskManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
