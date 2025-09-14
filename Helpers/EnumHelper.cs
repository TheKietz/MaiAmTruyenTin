using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaiAmTruyenTin.Helpers
{
    public static class EnumHelper
    {
        public static List<SelectListItem> GetEnumSelectList<TEnum>(TEnum selectedValue)
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<Enum>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.GetType()
                            .GetField(e.ToString())
                            .GetCustomAttribute<DisplayAttribute>()?
                            .Name ?? e.ToString(),
                    Selected = e.Equals(selectedValue)
                }).ToList();
        }
    }
}
