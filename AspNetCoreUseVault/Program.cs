using VaultSharp.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

const string vaultAddress = "https://8574e1a8c09e2e62-1-8200.papa.r.killercoda.com";
const string vaultToken = "root";
const string vaultMountPoint = "coreapp";

static VaultOptions VaultOptions()
{
    return new VaultOptions(vaultAddress: vaultAddress, vaultToken: vaultToken, reloadOnChange: true, reloadCheckIntervalSeconds: 5);
}

// coreapp/bidianqing/liecheqiyu/appsettings.App.json
builder.Configuration.AddVaultConfiguration(
    options: VaultOptions,
    basePath: "bidianqing/liecheqiyu/appsettings.App.json",
    mountPoint: vaultMountPoint
);

// coreapp/bidianqing/liecheqiyu/appsettings.DataBase.json
builder.Configuration.AddVaultConfiguration(
    options: VaultOptions,
    basePath: "bidianqing/liecheqiyu/appsettings.DataBase.json",
    mountPoint: vaultMountPoint
);

builder.Services.AddHostedService<VaultChangeWatcher>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
