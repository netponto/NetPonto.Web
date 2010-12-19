using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace NetPonto.Web.Extensions
{
    public static class SlideshareStringExtensions
    {
        private static Regex GetIdAndDoc= new Regex(@"\[slideshare id=(?<id>\d+)&doc=(?<doc>[a-zA-Z0-9-]+)\]", 
            RegexOptions.Compiled);

        public static string RenderAsSlideshareEmbedCode(this string embedCode)
        {
            if (string.IsNullOrEmpty(embedCode))
	        {
                return string.Empty;
	        }
            Match m = GetIdAndDoc.Match(embedCode);
            var id = m.Groups["id"];
            var doc = m.Groups["doc"];
            var template = @"<div style=""width:425px"" id=""{0}"">
                      <object id=""__sse1925010"" width=""425"" height=""355"">
                        <param name=""movie"" value=""http://static.slidesharecdn.com/swf/ssplayer2.swf?doc={1}"" />
                        <param name=""allowFullScreen"" value=""true""/>
                        <param name=""allowScriptAccess"" value=""always""/>
                        <embed name=""__sse1925010"" src=""http://static.slidesharecdn.com/swf/ssplayer2.swf?doc={1}"" type=""application/x-shockwave-flash"" allowscriptaccess=""always"" allowfullscreen=""true"" width=""425"" height=""355""></embed>
                      </object>
                    </div>";

            return string.Format(template, id, doc);
        }
    }
}