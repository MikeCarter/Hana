using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static string BigText(this HtmlHelper helper, string name){
            return BigText(helper, name, "");

        }
        public static string BigText(this HtmlHelper helper, string name, string value)
        {
            var format = "<textarea name='{0}' id='{0}' style='width:80%;height:225px'>{1}</textarea>";
            return string.Format(format, name, value);
        }

        public static string ToLocalCurrency(this Decimal input)
        {
            return Math.Round(input, System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits).ToString();
        }

        public static string UserName(this HtmlHelper helper) {

            string result = "Guest";
            if(helper.ViewContext.HttpContext.Request.Cookies["un"]!=null)
                result = helper.ViewContext.HttpContext.Request.Cookies["un"].Value;

            return result;
        }

    }
    public static class ListExtensions {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
            foreach (var item in collection) action(item);
            return collection;
        }

        public static SelectList ToSelectList<T>(this IEnumerable<T> collection) {
            return new SelectList(collection, "Key", "Value");
        }

        public static SelectList ToSelectList<T>(this IEnumerable<T> collection, string selectedValue) {
            return new SelectList(collection, "Key", "Value", selectedValue);
        }

        public static SelectList ToSelectList<T>(this IEnumerable<T> collection, string dataValueField, string dataTextField) {
            return new SelectList(collection, dataValueField, dataTextField);
        }

        public static SelectList ToSelectList<T>(this IEnumerable<T> collection, string dataValueField, string dataTextField, string selectedValue) {
            return new SelectList(collection, dataValueField, dataTextField, selectedValue);
        }
    }
}
