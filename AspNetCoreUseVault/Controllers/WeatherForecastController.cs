using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VaultSharp;
using VaultSharp.V1.AuthMethods;
using VaultSharp.V1.AuthMethods.Token;
using VaultSharp.V1.Commons;

namespace AspNetCoreUseVault.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            // from appsettings.App.json
            var name = _configuration["AppName"];

            // from appsettings.DataBase.json
            var host = _configuration["Host"];

            return name + " " + host;

            /*
            IAuthMethodInfo authMethod = new TokenAuthMethodInfo(vaultToken: "root");

            VaultClientSettings vaultClientSettings = new VaultClientSettings("https://0194706abc5ca050-1-8200.papa.r.killercoda.com", authMethod);
            IVaultClient vaultClient = new VaultClient(vaultClientSettings);

            var secretData = new Dictionary<string, object> { { "password", "Hashi123" } };
            vaultClient.V1.Secrets.KeyValue.V2.WriteSecretAsync(
                path: "/bidianqing",
                data: secretData,
                mountPoint: "data"
            ).Wait();

            Secret<SecretData> secret = vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(
                path: "/bidianqing",
                mountPoint: "data"
            ).Result;

            var password = secret.Data.Data["password"];
            //*/
        }
    }
}
