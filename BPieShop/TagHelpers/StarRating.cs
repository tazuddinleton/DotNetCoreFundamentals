
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPieShop.TagHelpers
{


    public class StarRating : TagHelper
    {   
        public double Rating { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //"<span class="text - warning">&#9733; &#9733; &#9733; &#9733; &#9734;</span>"

            int i = 0; 
            var content = new StringBuilder();
            while (i < Rating)
            {
                content.Append("&#9733");
                i++;
            }

            while (i < 5)
            {
                content.Append("&#9734;");
                i++;
            }
            
            output.Attributes.Add("class", "text-warning");            
            output.TagName = "span";
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
