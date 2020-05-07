﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpersAndViewComponents.TagHelpers
{
    public class SpeackerCardTagHelper : TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            var html = $@"<div class='card' style='width: 18rem; '>
   < img class='card-img-top' src='...' alt='Card image cap'>
  <div class='card-body'>
    <h5 class='card-title'>Card title</h5>
    <p class='card-text'>Some quick example text to build on the card title and make up the bulk of the card's content.</p>
  </div>
  <ul class='list-group list-group-flush'>
    <li class='list-group-item'>Cras justo odio</li>
    <li class='list-group-item'>Dapibus ac facilisis in</li>
    <li class='list-group-item'>Vestibulum at eros</li>
  </ul>
  <div class='card-body'>
    <a href = '#' class='card-link'>Card link</a>
    <a href = '#' class='card-link'>Another link</a>
  </div>
</div>";

            output.Content.AppendHtml(html);
            output.Attributes.Add("class", "sp-card");
        }
    }
}
