using AccountVerification.ApiClient;
using AccountVerification.Models;
using Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AccountVerification
{
    public class CommonUtility
    {
        public static string ApirUrl = string.Empty;
        public static string FullImageBaseUrl { get; set; }
        public static string ThumbnailBaseUrl { get; set; }
        public static LoginResponse loginDetails { get; set; }
        public static List<GetCategoriesResponse> categories { get; set; }
        public static List<GetAllFilterbyCategoryResponse> filters { get; set; }
    }

    public static class ExtensionMethods
    {

        public static System.Web.Mvc.SelectList ToSelectList<TEnum>(this TEnum obj, object selectedValue)
      where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = Enum.GetName(typeof(TEnum), x),
                        Value = (Convert.ToInt32(x)).ToString()
                    }), "Value", "Text", selectedValue);
        }

        public static System.Web.Mvc.SelectList ToSelectList<TEnum>(this TEnum obj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {

            return new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
                .Select(x =>
                    new SelectListItem
                    {
                        Text = Enum.GetName(typeof(TEnum), x),
                        Value = (Convert.ToInt32(x)).ToString()
                    }), "Value", "Text");
        }

    }
}