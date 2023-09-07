
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ftp_Gestor
{
    public class BuildServices
    {
        public static IConfiguration Configuration { get; set; } = null!;

        public static ServiceCollection Service { get; set; } = null!;





        public BuildServices()
        {
            Service = new ServiceCollection();

        }

        public void ConfigureSettings()
        {
           
            var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{enviroment}.json", optional: false, reloadOnChange: true)
            .Build();
            //Configuration.GetSection("FileSettingsPath").Bind(PathFileSettings);
            //string json = File.ReadAllText(PathFileSettings.Path);
            //GlobalAppSettings = JsonConvert.DeserializeObject<GlobalAppSettings>(json)!;



        }

        //public ServiceCollection ConfigureServices()
        //{
        //    //Service
        //    //  //  .AddSingleton(GlobalAppSettings)
        //    //  ////  .AddSingleton(Directories)
        //    //  ////  .AddSingleton(FtpSessionProperties)
        //    //  // // .AddSingleton(Settings)
               
        //    //  //  .AddScoped<IFtpService, FtpService>()
        //    //  //  .AddScoped<ICompressionService, CompressionService>()
        //    //  //  .AddScoped<IDirectoryService, DirectoryService>()
        //    //  //  .AddScoped<ISessionService, SessionService>();
                

        //    //return Service;
        //    //// var builderService = new BuildServices(configuration);
        //    // new BuildServices(configuration).ConfigureServices(services);
        //    // var serviceProvider = services.BuildServiceProvider();
        //    // var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettingsModel>>().Value;
        //    // Crear el servicio
        //    //var serviceProvider = new ServiceCollection()



        //    //services.Configure<AppSettingsModel>(_configuration!.GetSection("AppSettingsModel").Bind)
        //    //        .AddSingleton<IOptions<AppSettingsModel>>()
        //    //        .AddScoped<IFtpService, FtpService>();

        //}

       
    }
}
