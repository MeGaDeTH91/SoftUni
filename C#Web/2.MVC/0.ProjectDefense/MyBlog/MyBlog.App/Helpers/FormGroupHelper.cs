namespace MyBlog.App.Helpers
{
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MyBlog.Common;
    using System;
    using System.IO;
    using System.Linq.Expressions;
    using System.Text.Encodings.Web;

    public static class FormGroupHelper
    {
        public static IHtmlContent FormGroupFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression)
        {
            using (var writer = new StringWriter())
            {
                var label = htmlHelper.LabelFor(expression, new { @class = CommonConstants.OpenControlLabel });
                var editor = htmlHelper.EditorFor(expression, new { htmlAttributes = new { @class = CommonConstants.FormControl } });
                var validationMessage = htmlHelper.ValidationMessageFor(expression, null, new { @class = CommonConstants.TextDanger });

                writer.Write(CommonConstants.DivClass_FormGroup);
                label.WriteTo(writer, HtmlEncoder.Default);
                writer.Write(CommonConstants.DivClass_ColSm);
                editor.WriteTo(writer, HtmlEncoder.Default);
                validationMessage.WriteTo(writer, HtmlEncoder.Default);
                writer.Write(CommonConstants.DivClosing);

                return new HtmlString(writer.ToString());
            }
        }
    }
}
