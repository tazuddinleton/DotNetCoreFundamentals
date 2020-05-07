using BPieShop.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPieShop.TagHelpers
{
    public class PieTagHelper : TagHelper
    {
        public Pie Pie { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var template =
          @$"
        < div class='card h-100'>
            <a href = '#' >< img class='card-img-top' src='http://placehold.it/700x400' alt=''></a>
            <div class='card-body'>
                <h4 class='card-title'>
                    <a href = '#' > {Pie.Name}</ a >
                </ h4 >
                < h5 >${Pie.Price}</h5>
                <p class='card-text'>{Pie.ShortDescription}</p>
            </div>
            <div class='card-footer'>
                <small class='text-muted'>&#9733; &#9733; &#9733; &#9733; &#9734;</small>
            </div>
        </div>";


    
    output.Content.AppendHtml(template);
            output.TagName = "div";


        }
    }
}
