using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace GW.AspNetTraining.TrainingsWebApp
{
    public static class Extensions
    {
        public static IHtmlString JaNeinFor<TModel>(
            this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {
            if(expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var spanTag = new TagBuilder("Span");
            if(metadata.Model != null && bool.TryParse(metadata.Model.ToString(), out var result) 
                && result)
            {
                spanTag.SetInnerText("Ja");
            }
            else
            {
                spanTag.SetInnerText("Nein");
            }
            var html = spanTag.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(html);
        }
    }
}