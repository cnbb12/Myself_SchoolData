using System.Web.Http;
using WebActivatorEx;
using SchoolData;
using Swashbuckle.Application;
using SchoolData.App_Start;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SchoolData
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "SchoolData");
                c.IncludeXmlComments(GetXmlCommentsPath());
                c.OperationFilter<HttpHeaderFilter>();
            }).EnableSwaggerUi("help/{*assetPath}", c => { }); //将访问地址改为 help/index
        }
        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}/bin/SchoolData.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
