using System.Text.RegularExpressions;
using AutoMapper;

namespace NetPonto.Web.ValueFormatters
{
    class SlideshareEmbedCodeToHtml : IValueFormatter
    {
        private const string Template = @"<div style=""width:425px"" id=""{0}"">
                      <object id=""__sse1925010"" width=""425"" height=""355"">
                        <param name=""movie"" value=""http://static.slidesharecdn.com/swf/ssplayer2.swf?doc={1}"" />
                        <param name=""allowFullScreen"" value=""true""/>
                        <param name=""allowScriptAccess"" value=""always""/>
                        <embed name=""__sse1925010"" src=""http://static.slidesharecdn.com/swf/ssplayer2.swf?doc={1}"" type=""application/x-shockwave-flash"" allowscriptaccess=""always"" allowfullscreen=""true"" width=""425"" height=""355""></embed>
                      </object>
                    </div>";

        private static readonly Regex GetIdAndDoc = new Regex(@"\[slideshare id=(?<id>\d+)&doc=(?<doc>[a-zA-Z0-9-]+)\]",
                                                              RegexOptions.Compiled);

        public string FormatValue(ResolutionContext context)
        {
            return RenderAsSlideshareEmbedCode((string) context.SourceValue);
        }

        public string RenderAsSlideshareEmbedCode(string embedCode)
        {
            if (string.IsNullOrEmpty(embedCode))
            {
                return string.Empty;
            }

            var m = GetIdAndDoc.Match(embedCode);
            var id = m.Groups["id"];
            var doc = m.Groups["doc"];

            return string.Format(Template, id, doc);
        }
    }
}
