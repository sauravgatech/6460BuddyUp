using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.ComponentModel.DataAnnotations;

namespace GT.CS6460.BuddyUp.WebAPP
{
    public static class EnumDropDownList
    {
        public static HtmlString EnumDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> modelExpression, string firstElement)
        {
            var typeOfProperty = modelExpression.ReturnType;
            if(!typeOfProperty.IsEnum)
                throw new ArgumentException(string.Format("Type {0} is not an enum", typeOfProperty));     
            var enumValues = new SelectList(Enum.GetValues(typeOfProperty));
            return htmlHelper.DropDownListFor(modelExpression, enumValues, firstElement);
        }
    }

    public static class DisplayAttributeExtension
    {
        public static string GetPropertyDescription<T>(Expression<Func<T>> expression)
        {
            var propertyExpression = (MemberExpression) expression.Body;
            var propertyMember = propertyExpression.Member;
            var displayAttributes = propertyMember.GetCustomAttributes(typeof (DisplayAttribute), true);
            return displayAttributes.Length == 1 ? ((DisplayAttribute) displayAttributes[0]).Description : string.Empty;
        }
    }
}