using System.Web.Http;
using BooksLibrary.Web.Infrastucture.Mappings;

namespace BooksLibrary.Web.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            // Configure Autofac

            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            AutoMapperConfiguration.Configure();
        }
    }
}