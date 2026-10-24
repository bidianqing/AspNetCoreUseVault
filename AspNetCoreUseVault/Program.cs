using VaultSharp.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

const string vaultAddress = "https://0194706abc5ca050-1-8200.papa.r.killercoda.com";
const string vaultToken = "root";
const string vaultMountPoint = "coreapp";

// coreapp/bidianqing/liecheqiyu/appsettings.App.json
builder.Configuration.AddVaultConfiguration(
    options: () => new VaultOptions(vaultAddress, vaultToken),
    basePath: "bidianqing/liecheqiyu/appsettings.App.json",
    mountPoint: vaultMountPoint
);

// coreapp/bidianqing/liecheqiyu/appsettings.DataBase.json
builder.Configuration.AddVaultConfiguration(
    options: () => new VaultOptions(vaultAddress, vaultToken),
    basePath: "bidianqing/liecheqiyu/appsettings.DataBase.json",
    mountPoint: vaultMountPoint
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
