using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System;

namespace PersonalManagementServicePOC.AzureHosts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((ctx, builder) =>
             {
                 var root = builder.Build();
                 builder.AddAzureKeyVault(
                            $"https://{root["KeyVault:Vault"]}.vault.azure.net/",
                            root["KeyVault:ClientId"],
                            root["KeyVault:ClientSecret"],
                            new DefaultKeyVaultSecretManager());
             }
          ).UseStartup<Startup>();

        private static string GetKeyVaultEndpoint(string vault) => "https://" + vault + ".vault.azure.net/";

    }
}
