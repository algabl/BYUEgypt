using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using BYUEgypt.Models.ViewModels;


namespace BYUEgypt.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-burials")]
    public class PaginationTagHelper : TagHelper
    {
        // Dynamically create the page links for us
        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp) => uhf = temp;
        
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }
        public PageInfo PageBurials { get; set; }
        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        
        public override void Process (TagHelperContext context, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);
            TagBuilder final = new TagBuilder("div");
            
            
            
            for (int i = 1; i < PageBurials.TotalPages + 1; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new {pageNum = i});
                if (PageClassesEnabled) {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageBurials.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
                tb.InnerHtml.Append(i.ToString());
                final.InnerHtml.AppendHtml(tb);
            }
            
            /*for (int i = 1; i < PageBurials.TotalPages + 1; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new {pageNum = i});
                if (PageClassesEnabled) {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageBurials.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
                tb.InnerHtml.Append(i.ToString());
                final.InnerHtml.AppendHtml(tb);
            }*/

            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}