namespace NetPonto.Web.Extensions
{
    public static class TemplateExtensions
    {
        /// <summary>
        /// brunomlopes: I'm not sure this is the correct way to find an id, but seems to work.
        /// </summary>
        /// <param name="htmlFieldPrefix"></param>
        /// <returns></returns>
        public static string AsHtmlIdInTemplate(this string htmlFieldPrefix)
        {
            return htmlFieldPrefix.Replace(".", "_").Replace("[","_").Replace("]","_");
        }
    }
}